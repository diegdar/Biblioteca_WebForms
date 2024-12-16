using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Biblioteca.Models;

namespace Biblioteca_WebForms.DAL
{
    public class DALAlquilerEjemplar
    {
        private BDConnection bdConnection;

        public DALAlquilerEjemplar()
        {
            bdConnection = new BDConnection();
        }

        public int Insert(AlquilerEjemplar alquiler)
        {
            int numFilas = 0;
            object idAlquiler = null;
            string sentenciaSQL = string.Empty;

            // Devuelve -1 si ha habido un error, 0 si no se ha insertado ninguna fila pero no ha habido error y
            // 1 si la fila se ha insertado correctamente, en el campo Id del objeto se coloca el número autogenerado
            // en la inserción

            try
            {
                sentenciaSQL = @"INSERT INTO dbo.AlquilerEjemplar VALUES 
				(AlquilerId = @AlquilerId, EjemplarId = @EjemplarId, FechaDevReal = @FechaDevReal); 
                SELECT SCOPE_IDENTITY();";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@AlquilerId", alquiler.AlquilerId);
                cmd.Parameters.AddWithValue("@EjemplarId", alquiler.EjemplarId);

                if (alquiler.FechaDevReal == null)
                    cmd.Parameters.AddWithValue("@FechaDevReal", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@FechaDevReal", alquiler.FechaDevReal);

                idAlquiler = cmd.ExecuteScalar();

                if (idAlquiler != null)
                {
                    alquiler.Id = (int)(decimal)idAlquiler;
                    numFilas = 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                numFilas = -1;
            }

            bdConnection.DisconnectBD();
            return numFilas;
        }
        public int Delete(int idAlquilerEjemplar)
        {
            int numFilas = 0;
            string sentenciaSQL = string.Empty;

            // Devuelve 0 si no se ha borrado ninguna línea de la tabla, -1 si ha habido algún error o 1 si se ha borrado
            // la línea indicada en la variable idAquilerEjemplar

            try
            {
                sentenciaSQL = "DELETE FROM dbo.Alquiler WHERE Id = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Id", idAlquilerEjemplar);
                numFilas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                numFilas = -1;
            }

            bdConnection.DisconnectBD();
            return numFilas;
        }
        public int Update(AlquilerEjemplar alquiler)
        {
            int numFilas = 0;
            string sentenciaSQL = string.Empty;

            // Devuelve 0 si no se ha actualizado ninguna línea de la tabla, -1 si ha habido algún error o 1 si se ha actualizado
            // la línea indicada en la variable alquiler

            try
            {
                sentenciaSQL = @"UPDATE dbo.AlquilerEjemplar SET AlquilerId = @AlquilerId, EjemplarId = @EjemplarId, 
                FechaDevReal = @FechaDevReal WHERE Id = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@AlquilerId", alquiler.AlquilerId);
                cmd.Parameters.AddWithValue("@EjemplarId", alquiler.EjemplarId);

                if (alquiler.FechaDevReal == null)
                    cmd.Parameters.AddWithValue("@FechaDevReal", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@FechaDevReal", alquiler.FechaDevReal);

                cmd.Parameters.AddWithValue("@Id", alquiler.Id);
                numFilas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                numFilas = -1;
            }

            bdConnection.DisconnectBD();
            return numFilas;
        }
        public List<AlquilerEjemplar> Select()
        {
            SqlDataReader lector = null;
            List<AlquilerEjemplar> listaAlquiler = new List<AlquilerEjemplar>();
            string sentenciaSQL = "SELECT * FROM dbo.AlquilerEjemplar;";

            try
            {
                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    AlquilerEjemplar alquiler = new AlquilerEjemplar();
                    alquiler.Id = lector.GetInt32(lector.GetOrdinal("Id"));
                    alquiler.AlquilerId = lector.GetInt32(lector.GetOrdinal("AlquilerId"));
                    alquiler.EjemplarId = lector.GetInt32(lector.GetOrdinal("Ejemplar"));

                    if (lector.IsDBNull(lector.GetOrdinal("FechaDevReal")))
                        alquiler.FechaDevReal = null;
                    else
                        alquiler.FechaDevReal = lector.GetDateTime(lector.GetOrdinal("FechaDevReal"));

                    listaAlquiler.Add(alquiler);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            bdConnection.DisconnectBD();
            return listaAlquiler;
        }
        public AlquilerEjemplar SelectById(int idAlquiler)
        {
            SqlDataReader lector = null;
            AlquilerEjemplar alquiler = null;
            string sentenciaSQL = string.Empty;

            try
            {
                sentenciaSQL = "SELECT * FROM dbo.AlquilerEjemplar WHERE Id = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Id", idAlquiler);
                lector = cmd.ExecuteReader();

                if (lector.Read())
                {
                    alquiler = new AlquilerEjemplar();
                    alquiler.Id = lector.GetInt32(lector.GetOrdinal("Id"));
                    alquiler.AlquilerId = lector.GetInt32(lector.GetOrdinal("AlquilerId"));
                    alquiler.EjemplarId = lector.GetInt32(lector.GetOrdinal("Ejemplar"));

                    if (lector.IsDBNull(lector.GetOrdinal("FechaDevReal")))
                        alquiler.FechaDevReal = null;
                    else
                        alquiler.FechaDevReal = lector.GetDateTime(lector.GetOrdinal("FechaDevReal"));
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            bdConnection.DisconnectBD();
            return alquiler;
        }
    }
}