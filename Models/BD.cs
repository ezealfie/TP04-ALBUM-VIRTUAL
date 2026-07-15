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
                string query = @"SELECT f.* FROM Figuritas f INNER JOIN Selecciones s ON f.idSeleccion = s.idSeleccion ORDER BY s.nombre";
                figuritas = connection.Query<Figurita>(query).ToList();
            }
            return figuritas;
        }
        public Figurita DevolverFigurita(int figuritaid)
        {
            Figurita figurita = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Figuritas WHERE idFiguritas = @pid";
                figurita = connection.QueryFirstOrDefault<Figurita>(query, new { pid = figuritaid });
            }
            return figurita;

        }

        public List<Selecciones> DevolverSelecciones()
        {
            List<Selecciones> selecciones = new List<Selecciones>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Selecciones ORDER BY nombre";
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
                foreach (int figurita in figuritas)
                {
                    string query = "";
                    if (DevolverFiguritaUsuario(figurita) == null)
                    {
                        query = "INSERT INTO FiguritaXUsuario (IdFigurita,cantidad) Values (@pfigurita,1)";
                    }
                    else
                    {
                        query = "UPDATE FiguritaXUsuario SET cantidad = cantidad+1 WHERE idFigurita = @pfigurita";
                    }

                    connection.Execute(query, new { pfigurita = figurita });
                }
            }
        }
        public FiguritaXUsuario DevolverFiguritaUsuario(int figuritaid)
        {
            FiguritaXUsuario figurita = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM FiguritaXUsuario WHERE idFigurita = @pid";
                figurita = connection.QueryFirstOrDefault<FiguritaXUsuario>(query, new { pid = figuritaid });
            }
            return figurita;
        }
        public List<Figurita> DevolverAlbum()
        {
            List<Figurita> album = new List<Figurita>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT f.* FROM Figuritas f INNER JOIN FiguritaXUsuario fxu ON f.idFigurita = fxu.idFigurita";
                album = connection.Query<Figurita>(query).ToList();
            }
            return album;
        }
    }
}
