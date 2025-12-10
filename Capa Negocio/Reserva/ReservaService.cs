using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Capa_datos;
using Capa_Negocio.Habitacion;
using Capa_Negocio.Habitacion.Servicios;
using Capa_Negocio.Reserva;

namespace Capa_Negocio.Reserva.Servicios
{
    public class ReservaService
    {
        // Conexión a la base de datos (capa de datos).
        private readonly ConexionBD _conexion = new ConexionBD();

        // Servicio de habitaciones para validar y actualizar estado de la habitación.
        private readonly HabitacionService _habitacionService;

        public ReservaService(HabitacionService habitacionService)
        {
            _habitacionService = habitacionService;
        }

        // ---------------------------------------------------------
        // 1. CREAR RESERVA
        // ---------------------------------------------------------
        /// <summary>
        /// Crea una nueva reserva en la base de datos.
        /// Valida fechas, disponibilidad de la habitación
        /// y toma el precio por noche desde la habitación si no se ha asignado.
        /// </summary>
        public async Task CrearReservaAsync(Reserva reserva, CancellationToken token)
        {
            // Simular tiempo de procesamiento de servidor
            await Task.Delay(5000, token);

            // 1. Validar fechas (regla básica)
            if (reserva.FechaSalida.Date <= reserva.FechaEntrada.Date)
                throw new FechaInvalidaException("La fecha de salida debe ser despues de la fecha de entrada.");

            // 2. Obtener la habitación para validar disponibilidad y precio
            var habitacion = await _habitacionService.ObtenerPorIdAsync(reserva.IdHabitacion, token);
            if (habitacion is null)
                throw new HabitacionNoDisponibleException("La habitación seleccionada no existe.");

            // Verificar disponibilidad usando la lógica de IReservable / EstadoHabitacion
            if (!habitacion.EstaDisponible())
                throw new HabitacionNoDisponibleException("La habitación no está disponible para reservar.");

            // Si el precio por noche de la reserva viene en 0,
            // tomamos el precio actual de la habitación como snapshot.
            if (reserva.PrecioPorNoche <= 0)
            {
                reserva.PrecioPorNoche = habitacion.PrecioPorNoche;
            }

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            // Insert de la reserva. Obtenemos el Id generado con SCOPE_IDENTITY.
            string sql = @"
                INSERT INTO Reserva
                (IdHabitacion, IdCliente, FechaEntrada, FechaSalida, EstadoReserva, PrecioPorNoche, Notas)
                VALUES
                (@IdHabitacion, @IdCliente, @FechaEntrada, @FechaSalida, @EstadoReserva, @PrecioPorNoche, @Notas);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@IdHabitacion", reserva.IdHabitacion);
            cmd.Parameters.AddWithValue("@IdCliente", reserva.IdCliente);
            cmd.Parameters.AddWithValue("@FechaEntrada", reserva.FechaEntrada.Date);
            cmd.Parameters.AddWithValue("@FechaSalida", reserva.FechaSalida.Date);
            cmd.Parameters.AddWithValue("@EstadoReserva", (int)EstadoReserva.Reservada);
            cmd.Parameters.AddWithValue("@PrecioPorNoche", reserva.PrecioPorNoche);
            cmd.Parameters.AddWithValue("@Notas",
                string.IsNullOrWhiteSpace(reserva.Notas)
                    ? (object)DBNull.Value
                    : reserva.Notas);

            // Ejecutamos y obtenemos el nuevo IdReserva
            object result = await cmd.ExecuteScalarAsync(token);
            int nuevoId = Convert.ToInt32(result);

            reserva.IdReserva = nuevoId;
            reserva.EstadoReserva = EstadoReserva.Reservada;
            reserva.FechaCreacion = DateTime.Now;

            // 3. Cambiar estado de la habitación a Ocupada
            habitacion.Estado = EstadoHabitacion.Ocupada;
            await _habitacionService.ActualizarHabitacionAsync(habitacion, token);
        }

        // ---------------------------------------------------------
        // 2. CANCELAR RESERVA
        // ---------------------------------------------------------
        /// <summary>
        /// Cancela una reserva existente si su estado lo permite.
        /// También actualiza la habitación a Disponible.
        /// </summary>
        public async Task CancelarReservaAsync(int idReserva, CancellationToken token)
        {
            await Task.Delay(5000, token);

            // 1. Leer reserva desde la BD
            Reserva? reserva = await ObtenerPorIdAsync(idReserva, token);
            if (reserva is null)
                throw new ReservacionNoEncontradaException("No se encontró la reserva especificada.");

            // 2. Usar la lógica de negocio de ICancelable
            reserva.Cancelar(); // lanzará excepción si no se puede cancelar

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                UPDATE Reserva
                SET EstadoReserva = @Estado
                WHERE IdReserva = @IdReserva;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Estado", (int)reserva.EstadoReserva);
            cmd.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);

            await cmd.ExecuteNonQueryAsync(token);

            // 3. Volver a poner la habitación como Disponible
            var habitacion = await _habitacionService.ObtenerPorIdAsync(reserva.IdHabitacion, token);
            if (habitacion != null)
            {
                habitacion.Estado = EstadoHabitacion.Disponible;
                await _habitacionService.ActualizarHabitacionAsync(habitacion, token);
            }
        }

        // ---------------------------------------------------------
        // 3. CHECK-IN
        // ---------------------------------------------------------
        /// <summary>
        /// Marca una reserva como CheckIn y la habitación como Ocupada.
        /// </summary>
        public async Task CheckInAsync(int idReserva, CancellationToken token)
        {
            await Task.Delay(5000, token);

            var reserva = await ObtenerPorIdAsync(idReserva, token);
            if (reserva is null)
                throw new ReservacionNoEncontradaException("No se encontró la reserva para Check-in.");

            if (reserva.EstadoReserva != EstadoReserva.Reservada)
                throw new InvalidOperationException("Solo se puede hacer Check-in de reservas en estado 'Reservada'.");

            reserva.EstadoReserva = EstadoReserva.CheckIn;

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                UPDATE Reserva
                SET EstadoReserva = @Estado
                WHERE IdReserva = @IdReserva;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Estado", (int)reserva.EstadoReserva);
            cmd.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);

            await cmd.ExecuteNonQueryAsync(token);

            var habitacion = await _habitacionService.ObtenerPorIdAsync(reserva.IdHabitacion, token);
            if (habitacion != null)
            {
                habitacion.Estado = EstadoHabitacion.Ocupada;
                await _habitacionService.ActualizarHabitacionAsync(habitacion, token);
            }
        }

        // ---------------------------------------------------------
        // 4. CHECK-OUT
        // ---------------------------------------------------------
        /// <summary>
        /// Marca una reserva como CheckOut y libera la habitación.
        /// </summary>
        public async Task CheckOutAsync(int idReserva, CancellationToken token)
        {
            await Task.Delay(400, token);

            var reserva = await ObtenerPorIdAsync(idReserva, token);
            if (reserva is null)
                throw new ReservacionNoEncontradaException("No se encontró la reserva para Check-out.");

            if (reserva.EstadoReserva != EstadoReserva.CheckIn)
                throw new InvalidOperationException("Solo se puede hacer Check-out de reservas en estado 'CheckIn'.");

            reserva.EstadoReserva = EstadoReserva.CheckOut;

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                UPDATE Reserva
                SET EstadoReserva = @Estado
                WHERE IdReserva = @IdReserva;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Estado", (int)reserva.EstadoReserva);
            cmd.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);

            await cmd.ExecuteNonQueryAsync(token);

            var habitacion = await _habitacionService.ObtenerPorIdAsync(reserva.IdHabitacion, token);
            if (habitacion != null)
            {
                habitacion.Estado = EstadoHabitacion.Disponible;
                await _habitacionService.ActualizarHabitacionAsync(habitacion, token);
            }
        }

        // ---------------------------------------------------------
        // 5. OBTENER RESERVA POR ID (uso interno del servicio)
        // ---------------------------------------------------------
        /// <summary>
        /// Obtiene una reserva por Id desde la tabla Reserva.
        /// </summary>
        public async Task<Reserva?> ObtenerPorIdAsync(int idReserva, CancellationToken token)
        {
            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                SELECT IdReserva, IdHabitacion, IdCliente,
                       FechaEntrada, FechaSalida, EstadoReserva,
                       FechaCreacion, PrecioPorNoche, Notas
                FROM Reserva
                WHERE IdReserva = @IdReserva;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IdReserva", idReserva);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            if (!await reader.ReadAsync(token))
                return null;

            var reserva = new Reserva
            {
                IdReserva = reader.GetInt32(0),
                IdHabitacion = reader.GetInt32(1),
                IdCliente = reader.GetInt32(2),
                FechaEntrada = reader.GetDateTime(3),
                FechaSalida = reader.GetDateTime(4),
                EstadoReserva = (EstadoReserva)reader.GetInt32(5),
                FechaCreacion = reader.GetDateTime(6),
                PrecioPorNoche = reader.GetDecimal(7),
                Notas = reader.IsDBNull(8) ? string.Empty : reader.GetString(8)
            };

            return reserva;
        }

        // ---------------------------------------------------------
        // 6. OBTENER RESERVAS ACTIVAS
        // ---------------------------------------------------------
        /// <summary>
        /// Devuelve las reservas activas (Reservada o CheckIn).
        /// </summary>
        public async Task<List<Reserva>> ObtenerReservasActivasAsync(CancellationToken token)
        {
            await Task.Delay(5000, token);

            var lista = new List<Reserva>();

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                SELECT IdReserva, IdHabitacion, IdCliente,
                       FechaEntrada, FechaSalida, EstadoReserva,
                       FechaCreacion, PrecioPorNoche, Notas
                FROM Reserva
                WHERE EstadoReserva IN (0, 1);  -- 0=Reservada, 1=CheckIn";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            while (await reader.ReadAsync(token))
            {
                var reserva = new Reserva
                {
                    IdReserva = reader.GetInt32(0),
                    IdHabitacion = reader.GetInt32(1),
                    IdCliente = reader.GetInt32(2),
                    FechaEntrada = reader.GetDateTime(3),
                    FechaSalida = reader.GetDateTime(4),
                    EstadoReserva = (EstadoReserva)reader.GetInt32(5),
                    FechaCreacion = reader.GetDateTime(6),
                    PrecioPorNoche = reader.GetDecimal(7),
                    Notas = reader.IsDBNull(8) ? string.Empty : reader.GetString(8)
                };

                lista.Add(reserva);
            }

            return lista;
        }

        

        // ---------------------------------------------------------
        // 7. REVERTIR A RESERVADA
        // ---------------------------------------------------------
        /// <summary>
        /// Cambia el estado de una reserva (Cancelada o CheckOut) a Reservada.
        /// Si revierte desde CheckOut/Cancelada, debe poner la habitación como Ocupada.
        /// </summary>
        public async Task RevertirAReservadaAsync(int idReserva, CancellationToken token)
        {
            await Task.Delay(500, token); // Simulación de espera

            var reserva = await ObtenerPorIdAsync(idReserva, token);
            if (reserva is null)
                throw new ReservacionNoEncontradaException("No se encontró la reserva para revertir.");

            if (reserva.EstadoReserva == EstadoReserva.Reservada)
                throw new InvalidOperationException("La reserva ya se encuentra en estado 'Reservada'.");

            // Lógica para revertir
            EstadoReserva estadoAnterior = reserva.EstadoReserva;
            reserva.EstadoReserva = EstadoReserva.Reservada;

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
        UPDATE Reserva
        SET EstadoReserva = @Estado
        WHERE IdReserva = @IdReserva;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Estado", (int)reserva.EstadoReserva);
            cmd.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);

            await cmd.ExecuteNonQueryAsync(token);

            // Si el estado anterior NO era CheckIn, y lo estamos volviendo a Reservada, 
            // la habitación debe estar marcada como Ocupada para el período.
            if (estadoAnterior != EstadoReserva.CheckIn)
            {
                var habitacion = await _habitacionService.ObtenerPorIdAsync(reserva.IdHabitacion, token);
                if (habitacion != null)
                {
                    habitacion.Estado = EstadoHabitacion.Ocupada; // Reservada implica Ocupada para fines de disponibilidad.
                    await _habitacionService.ActualizarHabitacionAsync(habitacion, token);
                }
            }
        }
    }

    // -------------------------------------------------------------
    // EXCEPCIONES PERSONALIZADAS (POO y reglas de negocio)
    // -------------------------------------------------------------
    public class HabitacionNoDisponibleException : Exception
    {
        public HabitacionNoDisponibleException(string mensaje) : base(mensaje) { }
    }

    public class ReservacionNoEncontradaException : Exception
    {
        public ReservacionNoEncontradaException(string mensaje) : base(mensaje) { }
    }

    public class FechaInvalidaException : Exception
    {
        public FechaInvalidaException(string mensaje) : base(mensaje) { }
    }
}
