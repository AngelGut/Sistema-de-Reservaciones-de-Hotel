using System;
using System.Collections.Generic;
using System.Linq;                
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Capa_datos;
using Capa_Negocio.Cliente;
using System.Data;


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
        // CAPA DE NEGOCIO: Capa_Negocio.ClienteServicios.cs (Método CrearClienteAsync - Versión Robusta)

        public async Task CrearClienteAsync(Cliente cliente, CancellationToken token)
        {
            await Task.Delay(8000, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"
        INSERT INTO Cliente
        (Nombre, Documento, Telefono, Email, Nacionalidad)
        VALUES (@Nombre, @Documento, @Telefono, @Email, @Nacionalidad);";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            // Usamos Add para mayor control sobre el tipo, aunque AddWithValue debería funcionar.
            // DADO QUE LA COLUMNA ES NVARCHAR(100) NOT NULL, enviamos el valor o String.Empty.

            cmd.Parameters.Add(
                "@Nombre", SqlDbType.NVarChar, 100).Value =
                string.IsNullOrWhiteSpace(cliente.Nombre) ? string.Empty : cliente.Nombre.Trim();

            cmd.Parameters.Add(
                "@Documento", SqlDbType.NVarChar, 50).Value =
                string.IsNullOrWhiteSpace(cliente.Documento) ? string.Empty : cliente.Documento.Trim();

            cmd.Parameters.Add(
                "@Telefono", SqlDbType.NVarChar, 20).Value =
                string.IsNullOrWhiteSpace(cliente.Telefono) ? string.Empty : cliente.Telefono.Trim();

            cmd.Parameters.Add(
                "@Email", SqlDbType.NVarChar, 100).Value =
                string.IsNullOrWhiteSpace(cliente.Email) ? string.Empty : cliente.Email.Trim();

            cmd.Parameters.Add(
                "@Nacionalidad", SqlDbType.NVarChar, 100).Value =
                string.IsNullOrWhiteSpace(cliente.Nacionalidad) ? string.Empty : cliente.Nacionalidad.Trim();

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
            await Task.Delay(8000, token);

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
        // Capa_Negocio.Cliente.ClienteServicios.cs (Reemplazar ObtenerTodosAsync)

        // CAPA DE NEGOCIO: Capa_Negocio.ClienteServicios.cs (Método ObtenerTodosAsync corregido)

        // CAPA DE NEGOCIO: Capa_Negocio.ClienteServicios.cs (Método ObtenerTodosAsync - Versión Robusta)

        public async Task<List<Cliente>> ObtenerTodosAsync(CancellationToken token)
        {
            await Task.Delay(8000, token); // Retardo de simulación

            var lista = new List<Cliente>();

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            // Mantenemos el SELECT explícito
            string sql = @"
        SELECT IdCliente, Nombre, Documento, Telefono, Email, Nacionalidad
        FROM Cliente;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync(token);

            // === DEFINICIÓN DE ÍNDICES ROBUSTOS (MEJOR PRÁCTICA) ===
            // Obtenemos las posiciones de las columnas por su nombre una sola vez.
            int ordId = reader.GetOrdinal("IdCliente");
            int ordNombre = reader.GetOrdinal("Nombre");
            int ordDocumento = reader.GetOrdinal("Documento");
            int ordTelefono = reader.GetOrdinal("Telefono");
            int ordEmail = reader.GetOrdinal("Email");
            int ordNacionalidad = reader.GetOrdinal("Nacionalidad");


            while (await reader.ReadAsync(token))
            {
                // === Mapeo SEGURO usando los ordinales (índices obtenidos por nombre) ===
                var cliente = new Cliente
                {
                    IdCliente = reader.GetInt32(ordId), // Usamos la posición segura

                    // Usamos IsDBNull para campos NVARCHAR que podrían ser NULL
                    // aunque en tu esquema son NOT NULL, es buena práctica.
                    Nombre = reader.IsDBNull(ordNombre) ? string.Empty : reader.GetString(ordNombre),
                    Documento = reader.IsDBNull(ordDocumento) ? string.Empty : reader.GetString(ordDocumento),
                    Telefono = reader.IsDBNull(ordTelefono) ? string.Empty : reader.GetString(ordTelefono),
                    Email = reader.IsDBNull(ordEmail) ? string.Empty : reader.GetString(ordEmail),
                    Nacionalidad = reader.IsDBNull(ordNacionalidad) ? string.Empty : reader.GetString(ordNacionalidad)
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
            await Task.Delay(8000, token);

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
            await Task.Delay(8000, token);

            using SqlConnection conn = _conexion.CrearConexion();
            await conn.OpenAsync(token);

            string sql = @"DELETE FROM Cliente WHERE IdCliente = @Id;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", idCliente);

            await cmd.ExecuteNonQueryAsync(token);
        }
    }
}
