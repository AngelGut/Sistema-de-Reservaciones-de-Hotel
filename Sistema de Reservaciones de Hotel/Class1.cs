using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Capa_datos
{
    public class ConexionBD
    {
        private readonly string _connectionString;

        public ConexionBD()
        {
            _connectionString =
                "Server=.;Database=HotelCaribeDB;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public SqlConnection CrearConexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
