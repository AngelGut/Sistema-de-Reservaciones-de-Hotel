using System;
using System.Collections.Generic;
using System.Linq;                // Para LINQ (Where, ToList, etc.)
using System.Threading;           // Para CancellationToken
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Capa_datos;
using Capa_Negocio.Habitacion;
using Capa_Negocio.Habitacion.Cache;

namespace Capa_Negocio.Habitacion.Servicios
{
    public class HabitacionService
    {
        // Conexión a la base de datos (capa de datos)
        private readonly ConexionBD _conexion = new ConexionBD();

        // Cache en memoria con las 20 habitaciones iniciales
        private readonly CacheHab _cache = new CacheHab();

        // ---------------------------------------------------------
        // 1. CREAR / INSERT
        // ---------------------------------------------------------
        public async Task CrearHabitacionAsync(HabitacionBase habitacion, CancellationToken token)
        {
            // Simulación de procesamiento de servidor
            await Task.Delay(800, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                INSERT INTO Habitacion
                (Numero, Tipo, PrecioPorNoche, Estado, Descripcion)
                VALUES (@Numero, @Tipo, @Precio, @Estado, @Desc);";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Numero", habitacion.Numero);
            cmd.Parameters.AddWithValue("@Tipo", (int)habitacion.Tipo);
            cmd.Parameters.AddWithValue("@Precio", habitacion.PrecioPorNoche);
            cmd.Parameters.AddWithValue("@Estado", (int)habitacion.Estado);

            // OJO: en la tabla de la base de datos, Descripcion está como NOT NULL.
            // Para evitar errores, mandamos cadena vacía si viene null/empty.
            cmd.Parameters.AddWithValue("@Desc",
                string.IsNullOrWhiteSpace(habitacion.Descripcion)
                    ? string.Empty
                    : habitacion.Descripcion);

            await cmd.ExecuteNonQueryAsync(token);
        }

        // ---------------------------------------------------------
        // 2. OBTENER 1 HABITACIÓN POR ID (BD REAL)
        // ---------------------------------------------------------
        public async Task<HabitacionBase?> ObtenerPorIdAsync(int idHabitacion, CancellationToken token)
        {
            // Simulación de espera de BD
            await Task.Delay(300, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                SELECT IdHabitacion, Numero, Tipo, PrecioPorNoche, Estado, Descripcion
                FROM Habitacion
                WHERE IdHabitacion = @Id;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", idHabitacion);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            // Si no encontró filas, devolvemos null
            if (!await reader.ReadAsync(token))
                return null;

            var tipo = (TipoHabitacion)reader.GetInt32(2);
            HabitacionBase hab = CrearInstanciaHabitacion(tipo);

            hab.IdHabitacion = reader.GetInt32(0);
            hab.Numero = reader.GetInt32(1);
            hab.PrecioPorNoche = reader.GetDecimal(3);
            hab.Estado = (EstadoHabitacion)reader.GetInt32(4);

            // Aunque la columna es NOT NULL, este código es seguro si el esquema cambia
            hab.Descripcion = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

            return hab;
        }

        // ---------------------------------------------------------
        // 3. OBTENER TODAS LAS HABITACIONES (BD REAL)
        // ---------------------------------------------------------
        public async Task<List<HabitacionBase>> ObtenerTodasAsync(CancellationToken token)
        {
            // Simulación de espera de BD
            await Task.Delay(500, token);

            var lista = new List<HabitacionBase>();

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                SELECT IdHabitacion, Numero, Tipo, PrecioPorNoche, Estado, Descripcion
                FROM Habitacion;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            while (await reader.ReadAsync(token))
            {
                var tipo = (TipoHabitacion)reader.GetInt32(2);
                HabitacionBase hab = CrearInstanciaHabitacion(tipo);

                hab.IdHabitacion = reader.GetInt32(0);
                hab.Numero = reader.GetInt32(1);
                hab.PrecioPorNoche = reader.GetDecimal(3);
                hab.Estado = (EstadoHabitacion)reader.GetInt32(4);
                hab.Descripcion = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

                lista.Add(hab);
            }

            return lista;
        }

        // ---------------------------------------------------------
        // MÉTODO ESPECIAL (Task.WhenAny)
        // Búsqueda rápida de habitaciones disponibles usando BD + cache
        // ---------------------------------------------------------
        public async Task<List<HabitacionBase>> BuscarDisponiblesRapidoAsync(CancellationToken token)
        {
            // Tarea 1: búsqueda en BD real
            var tareaBD = Task.Run(async () =>
            {
                // Simulamos extra delay de BD
                await Task.Delay(800, token);

                var lista = await ObtenerTodasAsync(token);

                return lista
                    .Where(h => h.Estado == EstadoHabitacion.Disponible)
                    .ToList();
            }, token);

            // Tarea 2: búsqueda en cache (más rápida)
            var tareaCache = Task.Run(async () =>
            {
                // Cache responde más rápido
                await Task.Delay(200, token);

                return _cache.Habitaciones
                    .Where(h => h.Estado == EstadoHabitacion.Disponible)
                    .ToList();
            }, token);

            // Espera a que TERMINE cualquiera de las dos tareas
            var tareaGanadora = await Task.WhenAny(tareaBD, tareaCache);

            // tareaGanadora es Task<List<HabitacionBase>> → se espera su resultado
            return await tareaGanadora;
        }

        // ---------------------------------------------------------
        // 4. ACTUALIZAR / UPDATE
        // ---------------------------------------------------------
        public async Task ActualizarHabitacionAsync(HabitacionBase habitacion, CancellationToken token)
        {
            await Task.Delay(600, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                UPDATE Habitacion
                SET Numero = @Numero,
                    Tipo = @Tipo,
                    PrecioPorNoche = @Precio,
                    Estado = @Estado,
                    Descripcion = @Desc
                WHERE IdHabitacion = @Id;";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Numero", habitacion.Numero);
            cmd.Parameters.AddWithValue("@Tipo", (int)habitacion.Tipo);
            cmd.Parameters.AddWithValue("@Precio", habitacion.PrecioPorNoche);
            cmd.Parameters.AddWithValue("@Estado", (int)habitacion.Estado);
            cmd.Parameters.AddWithValue("@Desc",
                string.IsNullOrWhiteSpace(habitacion.Descripcion)
                    ? string.Empty
                    : habitacion.Descripcion);
            cmd.Parameters.AddWithValue("@Id", habitacion.IdHabitacion);

            await cmd.ExecuteNonQueryAsync(token);
        }

        // ---------------------------------------------------------
        // 5. ELIMINAR / DELETE
        // ---------------------------------------------------------
        public async Task EliminarHabitacionAsync(int idHabitacion, CancellationToken token)
        {
            await Task.Delay(400, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"DELETE FROM Habitacion WHERE IdHabitacion = @Id;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", idHabitacion);

            await cmd.ExecuteNonQueryAsync(token);
        }

        // ---------------------------------------------------------
        // Helper: crea la instancia correcta según TipoHabitacion
        // ---------------------------------------------------------
        private HabitacionBase CrearInstanciaHabitacion(TipoHabitacion tipo)
        {
            return tipo switch
            {
                TipoHabitacion.Simple => new Simple(),
                TipoHabitacion.Doble => new Doble(),
                TipoHabitacion.Suite => new Suite(),
                TipoHabitacion.Presidencial => new Presidencial(),
                _ => new Simple()
            };
        }
    }
}
