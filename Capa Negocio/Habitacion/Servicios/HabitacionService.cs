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
            await Task.Delay(5000, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                INSERT INTO Habitacion
                (Numero, Tipo, Nombre, PrecioPorNoche, Estado, Descripcion)
                VALUES (@Numero, @Tipo, @Nombre, @Precio, @Estado, @Desc);";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Numero", habitacion.Numero);
            cmd.Parameters.AddWithValue("@Tipo", (int)habitacion.Tipo);
            cmd.Parameters.AddWithValue("@Nombre", habitacion.Nombre);
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
            await Task.Delay(5000, token); // Simulación de espera

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
        SELECT IdHabitacion, Numero, Tipo, Nombre, PrecioPorNoche, Estado, Descripcion
        FROM Habitacion
        WHERE IdHabitacion = @Id;"; // La consulta trae 7 columnas

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", idHabitacion);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            if (!await reader.ReadAsync(token))
                return null;

            // --- Lectura segura y asignación usando GetOrdinal ---

            // 1. Obtener tipo e instancia
            int tipoIndex = reader.GetOrdinal("Tipo");
            var tipo = (TipoHabitacion)reader.GetInt32(tipoIndex);
            HabitacionBase hab = CrearInstanciaHabitacion(tipo);

            // 2. Asignar propiedades (usando GetOrdinal para seguridad)
            hab.IdHabitacion = reader.GetInt32(reader.GetOrdinal("IdHabitacion"));
            hab.Numero = reader.GetInt32(reader.GetOrdinal("Numero"));

            // Asumiendo NOT NULL en SQL:
            hab.PrecioPorNoche = reader.GetDecimal(reader.GetOrdinal("PrecioPorNoche"));
            hab.Estado = (EstadoHabitacion)reader.GetInt32(reader.GetOrdinal("Estado"));

            // ASIGNACIÓN SEGURA de Nombre (NVARCHAR(100))
            int nombreIndex = reader.GetOrdinal("Nombre");
            hab.Nombre = reader.IsDBNull(nombreIndex)
                         ? string.Empty
                         : reader.GetString(nombreIndex);

            // ASIGNACIÓN SEGURA de Descripción (NVARCHAR(200))
            int descIndex = reader.GetOrdinal("Descripcion");
            hab.Descripcion = reader.IsDBNull(descIndex)
                              ? string.Empty
                              : reader.GetString(descIndex);

            return hab;
        }

        // ---------------------------------------------------------
        // 3. OBTENER TODAS LAS HABITACIONES (BD REAL)
        // ---------------------------------------------------------
       
        public async Task<List<HabitacionBase>> ObtenerTodasAsync(CancellationToken token)
        {
            // Simulación de espera de BD
            await Task.Delay(5000, token);

            // ********** CÓDIGO FALTANTE: INICIALIZACIÓN **********
            var lista = new List<HabitacionBase>();

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
        SELECT IdHabitacion, Numero, Tipo, Nombre, PrecioPorNoche, Estado, Descripcion
        FROM Habitacion;";
            // *******************************************************

            // EL ERROR ESTABA AQUÍ: cmd, reader, y lista se usan sin estar completamente definidos
            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            // Obtenemos índices solo una vez fuera del bucle
            // Esto es crucial para la robustez
            int idHabIndex = reader.GetOrdinal("IdHabitacion");
            int numIndex = reader.GetOrdinal("Numero");
            int tipoIndex = reader.GetOrdinal("Tipo");
            int precioIndex = reader.GetOrdinal("PrecioPorNoche");
            int estadoIndex = reader.GetOrdinal("Estado");
            int nombreIndex = reader.GetOrdinal("Nombre");
            int descIndex = reader.GetOrdinal("Descripcion");

            while (await reader.ReadAsync(token))
            {
                var tipo = (TipoHabitacion)reader.GetInt32(tipoIndex);
                HabitacionBase hab = CrearInstanciaHabitacion(tipo);

                hab.IdHabitacion = reader.GetInt32(idHabIndex);
                hab.Numero = reader.GetInt32(numIndex);
                hab.PrecioPorNoche = reader.GetDecimal(precioIndex);
                hab.Estado = (EstadoHabitacion)reader.GetInt32(estadoIndex);

                // Lectura segura de Nombre y Descripción (manejo de NULLs)
                hab.Nombre = reader.IsDBNull(nombreIndex) ? string.Empty : reader.GetString(nombreIndex);
                hab.Descripcion = reader.IsDBNull(descIndex) ? string.Empty : reader.GetString(descIndex);

                // EL ERROR ESTABA AQUÍ: lista estaba fuera de alcance o no inicializada.
                lista.Add(hab);
            }

            // EL ERROR ESTABA AQUÍ: lista estaba fuera de alcance o no inicializada.
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
                await Task.Delay(5000, token);

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
            await Task.Delay(5000, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                UPDATE Habitacion
                SET Numero = @Numero,
                    Tipo = @Tipo, 
                    Nombre = @Nombre,
                    PrecioPorNoche = @Precio,
                    Estado = @Estado,
                    Descripcion = @Desc
                WHERE IdHabitacion = @Id;";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Numero", habitacion.Numero);
            cmd.Parameters.AddWithValue("@Tipo", (int)habitacion.Tipo);
            cmd.Parameters.AddWithValue("@Nombre", habitacion.Nombre);
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
            await Task.Delay(5000, token);

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
        // Capa_Negocio.Habitacion.Servicios.HabitacionService.cs

        // ... (después de EliminarHabitacionAsync o donde prefieras)

        // ---------------------------------------------------------
        // 6. OBTENER TODAS LAS HABITACIONES (CACHE)
        // ---------------------------------------------------------
        /// <summary>
        /// Devuelve la lista de habitaciones desde la caché en memoria.
        /// </summary>
        public List<HabitacionBase> ObtenerTodasLasHabitacionesCache()
        {
            return _cache.Habitaciones;
        }
    }
}
