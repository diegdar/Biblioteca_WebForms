using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Biblioteca.Models;

namespace Biblioteca_WebForms.DAL
{
    public class DALAlquiler
    {

        private BDConnection bdConnection;

        public DALAlquiler()
        {
            bdConnection = new BDConnection();
        }

        public int Insert(Alquiler alquiler)
        {
            int numFilas = 0;
            object idAlquiler = null;
            string sentenciaSQL = string.Empty;

            // Devuelve -1 si ha habido un error, 0 si no se ha insertado ninguna fila pero no ha habido error y
            // 1 si la fila se ha insertado correctamente, en el campo Id del objeto se coloca el número autogenerado
            // en la inserción

            try
            {
                sentenciaSQL = @"INSERT INTO dbo.Alquiler VALUES 
				(FechaAlquiler = @FechaAlquiler, FechaDevProbable = @FechaDevProbable, SocioId = @SocioId,
                BibliotecarioId = @BibliotecarioId); SELECT SCOPE_IDENTITY();";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@FechaAlquiler", alquiler.FechaAlquiler);
                cmd.Parameters.AddWithValue("@FechaDevProbable", alquiler.FechaDevProbable);
                cmd.Parameters.AddWithValue("@SocioId", alquiler.SocioId);
                cmd.Parameters.AddWithValue("@BibliotecarioId", alquiler.BibliotecarioId);
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
        public int Delete(int idAlquiler)
        {
            int numFilas = 0;
            string sentenciaSQL = string.Empty;

            // Devuelve 0 si no se ha borrado ninguna línea de la tabla, -1 si ha habido algún error o 1 si se ha borrado
            // la línea indicada en la variable idAquiler

            try
            {
                sentenciaSQL = "DELETE FROM dbo.Alquiler WHERE Id = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Id", idAlquiler);
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
        public int Update(Alquiler alquiler)
        {
            int numFilas = 0;
            string sentenciaSQL = string.Empty;

            // Devuelve 0 si no se ha actualizado ninguna línea de la tabla, -1 si ha habido algún error o 1 si se ha actualizado
            // la línea indicada en la variable alquiler

            try
            {
                sentenciaSQL = @"UPDATE dbo.Alquiler SET FechaAlquiler = @FechaAlquiler, FechaDevProbable = @FechaDevProbable, 
                SocioId = @SocioId, BibliotecarioId = @BibliotecarioId WHERE Id = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@FechaAlquiler", alquiler.FechaAlquiler);
                cmd.Parameters.AddWithValue("@FechaDevProbable", alquiler.FechaDevProbable);
                cmd.Parameters.AddWithValue("@BibliotecarioId", alquiler.BibliotecarioId);
                cmd.Parameters.AddWithValue("@SocioId", alquiler.SocioId);
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
        public List<Alquiler> Select()
        {
            SqlDataReader lector = null;
            List<Alquiler> listaAlquiler = new List<Alquiler>();
            string sentenciaSQL = "SELECT * FROM dbo.Alquiler;";

            try
            {
                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Alquiler alquiler = new Alquiler();
                    alquiler.Id = lector.GetInt32(lector.GetOrdinal("Id"));
                    alquiler.FechaAlquiler = lector.GetDateTime(lector.GetOrdinal("FechaAlquiler"));
                    alquiler.FechaDevProbable = lector.GetDateTime(lector.GetOrdinal("FechaDevProbable"));
                    alquiler.BibliotecarioId = lector.GetInt32(lector.GetOrdinal("BibliotecarioId"));
                    alquiler.SocioId = lector.GetInt32(lector.GetOrdinal("SocioId"));
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
        public Alquiler SelectById(int idAlquiler)
        {
            Alquiler alquiler = null;
            SqlDataReader lector = null;
            string sentenciaSQL = string.Empty;

            try
            {
                sentenciaSQL = "SELECT * FROM dbo.Alquiler WHERE Id = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Id", idAlquiler);
                lector = cmd.ExecuteReader();

                if (lector.Read())
                {
                    alquiler = new Alquiler();
                    alquiler.Id = lector.GetInt32(lector.GetOrdinal("Id"));
                    alquiler.FechaAlquiler = lector.GetDateTime(lector.GetOrdinal("FechaAlquiler"));
                    alquiler.FechaDevProbable = lector.GetDateTime(lector.GetOrdinal("FechaDevProbable"));
                    alquiler.BibliotecarioId = lector.GetInt32(lector.GetOrdinal("BibliotecarioId"));
                    alquiler.SocioId = lector.GetInt32(lector.GetOrdinal("SocioId"));
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