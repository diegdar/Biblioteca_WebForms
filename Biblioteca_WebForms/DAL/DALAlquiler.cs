using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public class DALAlquiler
    {
        private DataLinQ_BibliotecaDataContext dataDB = new DataLinQ_BibliotecaDataContext();
        public string Mensaje { get; set; }

        public void Insert(Alquiler alquiler)
        {
            try
            {
                dataDB.Alquilers.InsertOnSubmit(alquiler);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
        }


        public int Delete(int idAlquiler)
        {
            //int numFilas = 0;
            //string sentenciaSQL = string.Empty;

            //// Devuelve 0 si no se ha borrado ninguna línea de la tabla, -1 si ha habido algún error o 1 si se ha borrado
            //// la línea indicada en la variable idAquiler

            //try
            //{
            //    sentenciaSQL = "DELETE FROM dbo.Alquiler WHERE IdAlquiler = @Id;";

            //    bdConnection.ConnectBD();
            //    SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
            //    cmd.Parameters.AddWithValue("@Id", idAlquiler);
            //    numFilas = cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //    numFilas = -1;
            //}

            //bdConnection.DisconnectBD();
            //return numFilas;
        }
        public int Update(Alquiler alquiler)
        {
            //int numFilas = 0;
            //string sentenciaSQL = string.Empty;

            //// Devuelve 0 si no se ha actualizado ninguna línea de la tabla, -1 si ha habido algún error o 1 si se ha actualizado
            //// la línea indicada en la variable alquiler

            //try
            //{
            //    sentenciaSQL = @"UPDATE dbo.Alquiler SET FechaAlquiler = @FechaAlquiler, FechaDevProbable = @FechaDevProbable, 
            //    FKSocio = @SocioId, FKBibliotecario = @BibliotecarioId WHERE IdAlquiler = @Id;";

            //    bdConnection.ConnectBD();
            //    SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
            //    cmd.Parameters.AddWithValue("@FechaAlquiler", alquiler.FechaAlquiler);
            //    cmd.Parameters.AddWithValue("@FechaDevProbable", alquiler.FechaDevProbable);
            //    cmd.Parameters.AddWithValue("@BibliotecarioId", alquiler.BibliotecarioId);
            //    cmd.Parameters.AddWithValue("@SocioId", alquiler.SocioId);
            //    cmd.Parameters.AddWithValue("@Id", alquiler.Id);
            //    numFilas = cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //    numFilas = -1;
            //}

            //bdConnection.DisconnectBD();
            //return numFilas;
        }
        public List<Alquiler> Select()
        {
            //SqlDataReader lector = null;
            //List<Alquiler> listaAlquiler = new List<Alquiler>();
            //string sentenciaSQL = "SELECT * FROM dbo.Alquiler;";

            //try
            //{
            //    bdConnection.ConnectBD();
            //    SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
            //    lector = cmd.ExecuteReader();

            //    while (lector.Read())
            //    {
            //        Alquiler alquiler = new Alquiler();
            //        alquiler.Id = lector.GetInt32(lector.GetOrdinal("IdAlquiler"));
            //        alquiler.FechaAlquiler = lector.GetDateTime(lector.GetOrdinal("FechaAlquiler"));
            //        alquiler.FechaDevProbable = lector.GetDateTime(lector.GetOrdinal("FechaDevProbable"));
            //        alquiler.BibliotecarioId = lector.GetInt32(lector.GetOrdinal("FKBibliotecario"));
            //        alquiler.SocioId = lector.GetInt32(lector.GetOrdinal("FKSocio"));
            //        listaAlquiler.Add(alquiler);
            //    }

            //    lector.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}

            //bdConnection.DisconnectBD();
            //return listaAlquiler;
        }
        //public List<Alquiler> SelectByIdSocio(int idSocio)
        //{
   //         SqlDataReader lector = null;
   //         string sentenciaSQL = string.Empty;
			//List<Alquiler> listaAlquiler = new List<Alquiler>();
			
			//// Lo vamos a usar para saber todos los alquileres de un socio

   //         try
   //         {
   //             sentenciaSQL = "SELECT * FROM dbo.Alquiler WHERE FKSocio= @IdSocio;";

   //             bdConnection.ConnectBD();
   //             SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
   //             cmd.Parameters.AddWithValue("@IdSocio", idSocio);
   //             lector = cmd.ExecuteReader();

   //             while (lector.Read())
   //             {
   //                 Alquiler alquiler = new Alquiler();
   //                 alquiler.Id = lector.GetInt32(lector.GetOrdinal("IdAlquiler"));
   //                 alquiler.FechaAlquiler = lector.GetDateTime(lector.GetOrdinal("FechaAlquiler"));
   //                 alquiler.FechaDevProbable = lector.GetDateTime(lector.GetOrdinal("FechaDevProbable"));
   //                 alquiler.BibliotecarioId = lector.GetInt32(lector.GetOrdinal("FKBibliotecario"));
   //                 alquiler.SocioId = lector.GetInt32(lector.GetOrdinal("FKSocio"));
   //                 listaAlquiler.Add(alquiler);
   //             }
				
   //             lector.Close();
   //         }
   //         catch (Exception ex)
   //         {
   //             Console.WriteLine($"Error: {ex.Message}");
   //         }

   //         bdConnection.DisconnectBD();
   //         return listaAlquiler;
   //     }
   //     public Alquiler SelectById(int idAlquiler)
   //     {
   //         Alquiler alquiler = null;
   //         SqlDataReader lector = null;
   //         string sentenciaSQL = string.Empty;

   //         try
   //         {
   //             sentenciaSQL = "SELECT * FROM dbo.Alquiler WHERE IdAlquiler = @Id;";

   //             bdConnection.ConnectBD();
   //             SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
   //             cmd.Parameters.AddWithValue("@Id", idAlquiler);
   //             lector = cmd.ExecuteReader();

   //             if (lector.Read())
   //             {
   //                 alquiler = new Alquiler();
   //                 alquiler.Id = lector.GetInt32(lector.GetOrdinal("IdAlquiler"));
   //                 alquiler.FechaAlquiler = lector.GetDateTime(lector.GetOrdinal("FechaAlquiler"));
   //                 alquiler.FechaDevProbable = lector.GetDateTime(lector.GetOrdinal("FechaDevProbable"));
   //                 alquiler.BibliotecarioId = lector.GetInt32(lector.GetOrdinal("FKBibliotecario"));
   //                 alquiler.SocioId = lector.GetInt32(lector.GetOrdinal("FKSocio"));
   //             }

   //             lector.Close();
   //         }
   //         catch (Exception ex)
   //         {
   //             Console.WriteLine($"Error: {ex.Message}");
   //         }

   //         bdConnection.DisconnectBD();
   //         return alquiler;
   //     }
    }
}