using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace TP04_ALBUM.Models
{

    public class BD
    {

        private string _connectionString = @"Server=localhost; DataBase=Album; Integrated Security=True; TrustServerCertificate=True;";

        public List<Figurita> devolverFiguritas()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)){
                string query = "SELECT idFig FROM FiguritasXUsuario";
            }
        }

    }

}
