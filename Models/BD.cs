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

        public List<Figurita> DevolverFiguritas()
        {
            List<Figurita> figuritas = new List<Figurita>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Figuritas";
                figuritas = connection.Query<Figurita>(query).ToList();
            }
            return figuritas;
        }
        public List<Selecciones> DevolverSelecciones()
        {
            List<Selecciones> selecciones = new List<Selecciones>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Selecciones";
                selecciones = connection.Query<Selecciones>(query).ToList();
            }
            return selecciones;
        }
        public List<FiguritaXUsuario> DevolverFiguritasXUsuario()
        {
            List<FiguritaXUsuario> figuritas = new List<FiguritaXUsuario>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM FiguritaXUsuario";
                figuritas = connection.Query<FiguritaXUsuario>(query).ToList();
            }
            return figuritas;
        }
        public void agregarFiguritas(List<int> figuritas)
        {
              using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                foreach(int figurita in figuritas){
                string query = "UPDATE FiguritaXUsuario SET cantidad = cantidad + 1 WHERE idFigurita = @pfigurita";
                connection.Execute(query, new {pfigurita = figurita});
                }
            }
        }
        public List<FiguritaXUsuario> DevolverAlbum()
        {
            List<FiguritaXUsuario> album = new List<FiguritaXUsuario>();
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM FiguritaXUsuario";
                album = connection.Query<FiguritaXUsuario>(query).ToList();
            }
            return album;
        }
    }

}
