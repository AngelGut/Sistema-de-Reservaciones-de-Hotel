using Capa_datos;
using Capa_Negocio.Factura.Cache;
using Capa_Negocio.Reserva.Servicios;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Factura
{
    // Servicio de negocio para gestionar las facturas del hotel.
    // Aquí va la lógica de:
    //  - Generar factura a partir de una reserva
    //  - Leer facturas desde la base de datos
    //  - Mantener una cache en memoria usando Dictionary<int, Factura>
    public class FacturaService
    {
        // Clase de conexión a la base de datos (capa de datos).
        private readonly ConexionBD _conexion = new ConexionBD();

        // Servicio de reservas, lo usamos para obtener los datos económicos de la reserva.
        private readonly ReservaService _reservaService;

        // Cache de facturas en memoria.
        private readonly CacheFacturas _cacheFacturas = new CacheFacturas();

        // Constructor: recibimos ReservaService por inyección de dependencias.
        public FacturaService(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        // ---------------------------------------------------------
        // 1. GENERAR FACTURA A PARTIR DE UNA RESERVA
        // ---------------------------------------------------------
        public async Task<Factura> GenerarFacturaAsync(int idReserva, CancellationToken token)
        {
            // Simulamos procesamiento de servidor (mandato: Task.Delay)
            await Task.Delay(700, token);

            // 1. Obtener la reserva desde la capa de reservas.
            var reserva = await _reservaService.ObtenerPorIdAsync(idReserva, token);
            if (reserva is null)
            {
                // Usamos la excepción de negocio ya definida.
                throw new ReservacionNoEncontradaException("No se encontró la reserva para generar la factura.");
            }

            // 2. Tomar los montos calculados desde la reserva.
            //    Estos valores vienen de las propiedades calculadas de Reserva:
            //    Dias, Subtotal, Itbis, Total.
            decimal subtotal = reserva.Subtotal;
            decimal itbis = reserva.Itbis;
            decimal total = reserva.Total;

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            // 3. Insertar la factura en la tabla dbo.Factura.
            //    Usamos SCOPE_IDENTITY() para recuperar el IdFactura generado.
            string sql = @"
                INSERT INTO Factura
                (IdReserva, FechaEmision, Subtotal, Itbis, Total)
                VALUES
                (@IdReserva, @FechaEmision, @Subtotal, @Itbis, @Total);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@IdReserva", idReserva);
            cmd.Parameters.AddWithValue("@FechaEmision", DateTime.Now);
            cmd.Parameters.AddWithValue("@Subtotal", subtotal);
            cmd.Parameters.AddWithValue("@Itbis", itbis);
            cmd.Parameters.AddWithValue("@Total", total);

            // Ejecutar el comando y obtener el nuevo IdFactura.
            object result = await cmd.ExecuteScalarAsync(token);
            int nuevoIdFactura = Convert.ToInt32(result);

            // 4. Crear el objeto Factura en memoria.
            var factura = new Factura
            {
                IdFactura = nuevoIdFactura, // número de factura
                IdReserva = idReserva,
                FechaEmision = DateTime.Now,
                Subtotal = subtotal,
                Itbis = itbis,
                Total = total
            };

            // 5. Guardar en la cache (Dictionary<int, Factura>).
            _cacheFacturas.AgregarOActualizar(factura);

            return factura;
        }

        // ---------------------------------------------------------
        // 2. OBTENER FACTURA POR ID
        // ---------------------------------------------------------
        public async Task<Factura?> ObtenerPorIdAsync(int idFactura, CancellationToken token)
        {
            // 1. Primero intentamos obtener desde la cache en memoria.
            if (_cacheFacturas.TryObtener(idFactura, out var facturaCache))
            {
                return facturaCache;
            }

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                SELECT IdFactura, IdReserva, FechaEmision, Subtotal, Itbis, Total
                FROM Factura
                WHERE IdFactura = @IdFactura;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IdFactura", idFactura);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            if (!await reader.ReadAsync(token))
                return null;

            // 2. Mapear los datos de la fila a un objeto Factura.
            var factura = new Factura
            {
                IdFactura = reader.GetInt32(0),
                IdReserva = reader.GetInt32(1),
                FechaEmision = reader.GetDateTime(2),
                Subtotal = reader.GetDecimal(3),
                Itbis = reader.GetDecimal(4),
                Total = reader.GetDecimal(5)
            };

            // 3. Guardar también en la cache.
            _cacheFacturas.AgregarOActualizar(factura);

            return factura;
        }

        // ---------------------------------------------------------
        // 3. OBTENER TODAS LAS FACTURAS (para mostrar en un DataGrid)
        // ---------------------------------------------------------
        public async Task<List<Factura>> ObtenerTodasAsync(CancellationToken token)
        {
            // Simular pequeña demora de servidor.
            await Task.Delay(400, token);

            var lista = new List<Factura>();

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                SELECT IdFactura, IdReserva, FechaEmision, Subtotal, Itbis, Total
                FROM Factura;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            // Limpiamos la cache antes de recargarla completa (opcional).
            _cacheFacturas.Limpiar();

            while (await reader.ReadAsync(token))
            {
                var factura = new Factura
                {
                    IdFactura = reader.GetInt32(0),
                    IdReserva = reader.GetInt32(1),
                    FechaEmision = reader.GetDateTime(2),
                    Subtotal = reader.GetDecimal(3),
                    Itbis = reader.GetDecimal(4),
                    Total = reader.GetDecimal(5)
                };

                lista.Add(factura);

                // También guardamos cada una en el Dictionary.
                _cacheFacturas.AgregarOActualizar(factura);
            }

            return lista;
        }

        // Capa_Negocio.Factura.FacturaService.cs

        // ---------------------------------------------------------
        // 4. OBTENER FACTURA POR ID RESERVA
        // ---------------------------------------------------------
        /// <summary>
        /// Busca una factura por el Id de la Reserva asociada (debido al UNIQUE constraint, solo puede haber una).
        /// </summary>
        public async Task<Factura?> ObtenerPorIdReservaAsync(int idReserva, CancellationToken token)
        {
            // Usamos Task.Delay() para simular el tiempo de respuesta del servidor (100ms)
            await Task.Delay(100, token);

            // 1. Intentar buscar en la cache (Opcional, requiere cache mapeada por IdReserva)
            // Para simplificar, buscamos directamente en la BD (más seguro por el UNIQUE constraint)

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
        SELECT IdFactura, IdReserva, FechaEmision, Subtotal, Itbis, Total
        FROM Factura
        WHERE IdReserva = @IdReserva;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IdReserva", idReserva);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            if (!await reader.ReadAsync(token))
                return null;

            // 2. Mapear y devolver (usando la misma lógica de FacturaService.ObtenerPorIdAsync)
            var factura = new Factura
            {
                IdFactura = reader.GetInt32(0),
                IdReserva = reader.GetInt32(1),
                FechaEmision = reader.GetDateTime(2),
                Subtotal = reader.GetDecimal(3),
                Itbis = reader.GetDecimal(4),
                Total = reader.GetDecimal(5)
            };

            return factura;
        }
    }
}
