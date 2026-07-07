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
            List<FiguritasXUsuario> figuritasXUsuario = new List<figuritasXUsuario>; 
            using (SqlConnection connection = new SqlConnection(_connectionString)){
                string query = "SELECT idFig FROM FiguritasXUsuario";
                FiguritasXUsuario= connection.Query<Selecciones>(query).ToList(); 
            }
        }
          public List<Selecciones> devolverSelecciones()
        {
            List<Selecciones> selecciones = new list<selecciones>; 
            using (SqlConnection connection = new SqlConnection(_connectionString)){
                string query = "SELECT idFig FROM Selecciones";
                selecciones = connection.Query<Selecciones>(query).ToList(); 
            }
        }

    }

}
