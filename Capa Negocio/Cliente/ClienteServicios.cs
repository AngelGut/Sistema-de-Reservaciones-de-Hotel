using System;
using System.Collections.Generic;
using System.Linq;                
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Capa_datos;
using Capa_Negocio.Cliente;


namespace Capa_Negocio.Cliente
{
    public class ClienteServicios
    {
        /// <summary>
        /// Clase de conexión a la base de datos (capa de datos).
        /// </summary>
        private readonly ConexionBD _conexion = new ConexionBD();

        // ---------------------------------------------------------
        // 1. CREAR / INSERT
        // ---------------------------------------------------------
        /// <summary>
        /// Crea un nuevo cliente en la base de datos.
        /// </summary>
        public async Task CrearClienteAsync(Cliente cliente, CancellationToken token)
        {
            // Simular un pequeño retraso de procesamiento de servidor.
            await Task.Delay(600, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                INSERT INTO Cliente
                (Nombre, Documento, Telefono, Email, Nacionalidad)
                VALUES (@Nombre, @Documento, @Telefono, @Email, @Nacionalidad);";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            // Como en la tabla todos los campos son NOT NULL,
            // nos aseguramos de enviar siempre una cadena no nula.
            cmd.Parameters.AddWithValue("@Nombre",
                string.IsNullOrWhiteSpace(cliente.Nombre) ? string.Empty : cliente.Nombre);

            cmd.Parameters.AddWithValue("@Documento",
                string.IsNullOrWhiteSpace(cliente.Documento) ? string.Empty : cliente.Documento);

            cmd.Parameters.AddWithValue("@Telefono",
                string.IsNullOrWhiteSpace(cliente.Telefono) ? string.Empty : cliente.Telefono);

            cmd.Parameters.AddWithValue("@Email",
                string.IsNullOrWhiteSpace(cliente.Email) ? string.Empty : cliente.Email);

            cmd.Parameters.AddWithValue("@Nacionalidad",
                string.IsNullOrWhiteSpace(cliente.Nacionalidad) ? string.Empty : cliente.Nacionalidad);

            await cmd.ExecuteNonQueryAsync(token);
        }

        // ---------------------------------------------------------
        // 2. LEER 1 REGISTRO POR ID
        // ---------------------------------------------------------
        /// <summary>
        /// Obtiene un cliente por su Id. Devuelve null si no existe.
        /// </summary>
        public async Task<Cliente?> ObtenerPorIdAsync(int idCliente, CancellationToken token)
        {
            await Task.Delay(300, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                SELECT IdCliente, Nombre, Documento, Telefono, Email, Nacionalidad
                FROM Cliente
                WHERE IdCliente = @Id;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", idCliente);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            if (!await reader.ReadAsync(token))
                return null;

            var cliente = new Cliente
            {
                IdCliente = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Documento = reader.GetString(2),
                Telefono = reader.GetString(3),
                Email = reader.GetString(4),
                Nacionalidad = reader.GetString(5)
            };

            return cliente;
        }

        // ---------------------------------------------------------
        // 3. LEER TODOS LOS CLIENTES
        // ---------------------------------------------------------
        /// <summary>
        /// Obtiene todos los clientes registrados en la base de datos.
        /// </summary>
        public async Task<List<Cliente>> ObtenerTodosAsync(CancellationToken token)
        {
            await Task.Delay(500, token);

            var lista = new List<Cliente>();

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                SELECT IdCliente, Nombre, Documento, Telefono, Email, Nacionalidad
                FROM Cliente;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            while (await reader.ReadAsync(token))
            {
                var cliente = new Cliente
                {
                    IdCliente = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Documento = reader.GetString(2),
                    Telefono = reader.GetString(3),
                    Email = reader.GetString(4),
                    Nacionalidad = reader.GetString(5)
                };

                lista.Add(cliente);
            }

            return lista;
        }

        // ---------------------------------------------------------
        // 4. ACTUALIZAR / UPDATE
        // ---------------------------------------------------------
        /// <summary>
        /// Actualiza los datos de un cliente existente.
        /// </summary>
        public async Task ActualizarClienteAsync(Cliente cliente, CancellationToken token)
        {
            await Task.Delay(500, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
                UPDATE Cliente
                SET Nombre = @Nombre,
                    Documento = @Documento,
                    Telefono = @Telefono,
                    Email = @Email,
                    Nacionalidad = @Nacionalidad
                WHERE IdCliente = @Id;";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Nombre",
                string.IsNullOrWhiteSpace(cliente.Nombre) ? string.Empty : cliente.Nombre);

            cmd.Parameters.AddWithValue("@Documento",
                string.IsNullOrWhiteSpace(cliente.Documento) ? string.Empty : cliente.Documento);

            cmd.Parameters.AddWithValue("@Telefono",
                string.IsNullOrWhiteSpace(cliente.Telefono) ? string.Empty : cliente.Telefono);

            cmd.Parameters.AddWithValue("@Email",
                string.IsNullOrWhiteSpace(cliente.Email) ? string.Empty : cliente.Email);

            cmd.Parameters.AddWithValue("@Nacionalidad",
                string.IsNullOrWhiteSpace(cliente.Nacionalidad) ? string.Empty : cliente.Nacionalidad);

            cmd.Parameters.AddWithValue("@Id", cliente.IdCliente);

            await cmd.ExecuteNonQueryAsync(token);
        }

        // ---------------------------------------------------------
        // 5. ELIMINAR / DELETE
        // ---------------------------------------------------------
        /// <summary>
        /// Elimina un cliente por su Id.
        /// </summary>
        public async Task EliminarClienteAsync(int idCliente, CancellationToken token)
        {
            await Task.Delay(400, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"DELETE FROM Cliente WHERE IdCliente = @Id;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", idCliente);

            await cmd.ExecuteNonQueryAsync(token);
        }
    }
}
