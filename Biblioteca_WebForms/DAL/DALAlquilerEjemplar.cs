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

        public int Insert(AlquilerEjemplar alquilerEjemplar)
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
				(FKAlquiler = @AlquilerId, FKEjemplar = @EjemplarId, FechaDevReal = @FechaDevReal); 
                SELECT SCOPE_IDENTITY();";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@AlquilerId", alquilerEjemplar.AlquilerId);
                cmd.Parameters.AddWithValue("@EjemplarId", alquilerEjemplar.EjemplarId);

                if (alquilerEjemplar.FechaDevReal == null)
                    cmd.Parameters.AddWithValue("@FechaDevReal", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@FechaDevReal", alquilerEjemplar.FechaDevReal);

                idAlquiler = cmd.ExecuteScalar();

                if (idAlquiler != null)
                {
                    alquilerEjemplar.Id = (int)(decimal)idAlquiler;
                    numFilas = 1;
                }
				else
					alquilerEjemplar.Id = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
				alquilerEjemplar.Id = 0;
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
                sentenciaSQL = "DELETE FROM dbo.Alquiler WHERE IdAlquilerEjemplar = @Id;";

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
        public int Update(AlquilerEjemplar alquilerEjemplar)
        {
            int numFilas = 0;
            string sentenciaSQL = string.Empty;

            // Devuelve 0 si no se ha actualizado ninguna línea de la tabla, -1 si ha habido algún error o 1 si se ha actualizado
            // la línea indicada en la variable alquilerEjemplar

            try
            {
                sentenciaSQL = @"UPDATE dbo.AlquilerEjemplar SET FKAlquiler = @AlquilerId, FKEjemplar = @EjemplarId, 
                FechaDevReal = @FechaDevReal WHERE IdAlquilerEjemplar = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@AlquilerId", alquilerEjemplar.AlquilerId);
                cmd.Parameters.AddWithValue("@EjemplarId", alquilerEjemplar.EjemplarId);

                if (alquilerEjemplar.FechaDevReal == null)
                    cmd.Parameters.AddWithValue("@FechaDevReal", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@FechaDevReal", alquilerEjemplar.FechaDevReal);

                cmd.Parameters.AddWithValue("@Id", alquilerEjemplar.Id);
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
            List<AlquilerEjemplar> lista listaAlquilerEjemplar = new List<AlquilerEjemplar>();
            string sentenciaSQL = "SELECT * FROM dbo.AlquilerEjemplar;";

            try
            {
                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    AlquilerEjemplar alquilerEjemplar = new AlquilerEjemplar();
                    alquilerEjemplar.Id = lector.GetInt32(lector.GetOrdinal("IdAlquilerEjemplar"));
                    alquilerEjemplar.AlquilerId = lector.GetInt32(lector.GetOrdinal("FKAlquiler"));
                    alquilerEjemplar.EjemplarId = lector.GetInt32(lector.GetOrdinal("FKEjemplar"));

                    if (lector.IsDBNull(lector.GetOrdinal("FechaDevReal")))
                        alquilerEjemplar.FechaDevReal = null;
                    else
                        alquilerEjemplar.FechaDevReal = lector.GetDateTime(lector.GetOrdinal("FechaDevReal"));

                    listaAlquilerEjemplar.Add(alquilerEjemplar);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            bdConnection.DisconnectBD();
            return listaAlquilerEjemplar;
        }
        public List<AlquilerEjemplar> SelectByIdAlquiler(int idAlquiler)
        {
            SqlDataReader lector = null;
			string sentenciaSQL = string.Empty;
            List<AlquilerEjemplar> lista listaAlquilerEjemplar = new List<AlquilerEjemplar>();
			
			// La vamos a usar para saber todos los ejemplares alquilados dado un idAlquiler

            try
            {
				sentenciaSQL = "SELECT * FROM dbo.AlquilerEjemplar WHERE FKAlquiler = @IdAlquiler;";
				
                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
				cmd.Parameters.AddWithValue("@IdAlquiler", idAlquiler);
                lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    AlquilerEjemplar alquilerEjemplar = new AlquilerEjemplar();
                    alquilerEjemplar.Id = lector.GetInt32(lector.GetOrdinal("IdAlquilerEjemplar"));
                    alquilerEjemplar.AlquilerId = lector.GetInt32(lector.GetOrdinal("FKAlquiler"));
                    alquilerEjemplar.EjemplarId = lector.GetInt32(lector.GetOrdinal("FKEjemplar"));

                    if (lector.IsDBNull(lector.GetOrdinal("FechaDevReal")))
                        alquilerEjemplar.FechaDevReal = null;
                    else
                        alquilerEjemplar.FechaDevReal = lector.GetDateTime(lector.GetOrdinal("FechaDevReal"));

                    listaAlquilerEjemplar.Add(alquilerEjemplar);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            bdConnection.DisconnectBD();
            return listaAlquilerEjemplar;
        }
        public AlquilerEjemplar SelectById(int idAlquilerEjemplar)
        {
            SqlDataReader lector = null;
            AlquilerEjemplar alquilerEjemplar = null;
            string sentenciaSQL = string.Empty;

            try
            {
                sentenciaSQL = "SELECT * FROM dbo.AlquilerEjemplar WHERE IdAlquilerEjemplar = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Id", idAlquilerEjemplar);
                lector = cmd.ExecuteReader();

                if (lector.Read())
                {
                    alquilerEjemplar = new AlquilerEjemplar();
                    alquilerEjemplar.Id = lector.GetInt32(lector.GetOrdinal("IdAlquilerEjemplar"));
                    alquilerEjemplar.AlquilerId = lector.GetInt32(lector.GetOrdinal("FKAlquiler"));
                    alquilerEjemplar.EjemplarId = lector.GetInt32(lector.GetOrdinal("FKEjemplar"));

                    if (lector.IsDBNull(lector.GetOrdinal("FechaDevReal")))
                        alquilerEjemplar.FechaDevReal = null;
                    else
                        alquilerEjemplar.FechaDevReal = lector.GetDateTime(lector.GetOrdinal("FechaDevReal"));
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            bdConnection.DisconnectBD();
            return alquilerEjemplar;
        }
    }
}