using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Capa_datos;
using Capa_Negocio.Habitacion; // Ajusta si tu namespace de modelos es otro

namespace Capa_Negocio.Habitacion.Servicios
{
    public class HabitacionService
    {
        private readonly ConexionBD _conexion = new ConexionBD();

        // ---------------------------------------------------------
        // 1. CREAR / INSERT
        // ---------------------------------------------------------
        public async Task CrearHabitacionAsync(HabitacionBase habitacion)
        {
            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync();

            string sql = @"INSERT INTO Habitacion
                           (Numero, Tipo, PrecioPorNoche, Estado, Descripcion)
                           VALUES (@Numero, @Tipo, @Precio, @Estado, @Desc);";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Numero", habitacion.Numero);
            cmd.Parameters.AddWithValue("@Tipo", (int)habitacion.Tipo);
            cmd.Parameters.AddWithValue("@Precio", habitacion.PrecioPorNoche);
            cmd.Parameters.AddWithValue("@Estado", (int)habitacion.Estado);
            cmd.Parameters.AddWithValue("@Desc",
                string.IsNullOrEmpty(habitacion.Descripcion)
                    ? (object)DBNull.Value
                    : habitacion.Descripcion);

            await cmd.ExecuteNonQueryAsync();
        }

        // ---------------------------------------------------------
        // 2. LEER 1 REGISTRO POR ID
        // ---------------------------------------------------------
        public async Task<HabitacionBase?> ObtenerPorIdAsync(int idHabitacion)
        {
            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync();

            string sql = @"SELECT IdHabitacion, Numero, Tipo, PrecioPorNoche, Estado, Descripcion
                           FROM Habitacion
                           WHERE IdHabitacion = @Id;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", idHabitacion);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            var tipo = (TipoHabitacion)reader.GetInt32(2);
            HabitacionBase hab = CrearInstanciaHabitacion(tipo);

            hab.IdHabitacion = reader.GetInt32(0);
            hab.Numero = reader.GetInt32(1);
            hab.PrecioPorNoche = reader.GetDecimal(3);
            hab.Estado = (EstadoHabitacion)reader.GetInt32(4);
            hab.Descripcion = reader.IsDBNull(5) ? null : reader.GetString(5);

            return hab;
        }

        // ---------------------------------------------------------
        // 3. LEER TODAS LAS HABITACIONES
        // ---------------------------------------------------------
        public async Task<List<HabitacionBase>> ObtenerTodasAsync()
        {
            var lista = new List<HabitacionBase>();

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync();

            string sql = @"SELECT IdHabitacion, Numero, Tipo, PrecioPorNoche, Estado, Descripcion
                           FROM Habitacion;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var tipo = (TipoHabitacion)reader.GetInt32(2);
                HabitacionBase hab = CrearInstanciaHabitacion(tipo);

                hab.IdHabitacion = reader.GetInt32(0);
                hab.Numero = reader.GetInt32(1);
                hab.PrecioPorNoche = reader.GetDecimal(3);
                hab.Estado = (EstadoHabitacion)reader.GetInt32(4);
                hab.Descripcion = reader.IsDBNull(5) ? null : reader.GetString(5);

                lista.Add(hab);
            }

            return lista;
        }

        // ---------------------------------------------------------
        // 4. ACTUALIZAR / UPDATE
        // ---------------------------------------------------------
        public async Task ActualizarHabitacionAsync(HabitacionBase habitacion)
        {
            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync();

            string sql = @"UPDATE Habitacion
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
                string.IsNullOrEmpty(habitacion.Descripcion)
                    ? (object)DBNull.Value
                    : habitacion.Descripcion);
            cmd.Parameters.AddWithValue("@Id", habitacion.IdHabitacion);

            await cmd.ExecuteNonQueryAsync();
        }

        // ---------------------------------------------------------
        // 5. ELIMINAR / DELETE
        // ---------------------------------------------------------
        public async Task EliminarHabitacionAsync(int idHabitacion)
        {
            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync();

            string sql = @"DELETE FROM Habitacion
                           WHERE IdHabitacion = @Id;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", idHabitacion);

            await cmd.ExecuteNonQueryAsync();
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
