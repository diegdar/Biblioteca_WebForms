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

        public bool Insert(Alquiler nuevoAlquiler)
        {
            try
            {
                dataDB.Alquilers.InsertOnSubmit(nuevoAlquiler);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }

        public bool Delete(int idAlquiler)
        {
            var alquilerById = (from alquiler in dataDB.Alquilers
                        where alquiler.Id == idAlquiler
                        select alquiler);

            try
            {
                dataDB.Alquilers.DeleteOnSubmit(alquilerById);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public bool Update(Alquiler nuevoAlquiler)
        {
            try
            {
                var alquilerById = (from alquiler in dataDB.Alquilers
                                    where alquiler.IdAquiler = nuevoAlquiler.IdAlquiler
                                    select alquiler).FirstOrDefault();

                alquilerById.FechaAlquiler = nuevoAlquiler.FechaAlquiler;
                alquilerById.FechaDevProbable = nuevoAlquiler.FechaDevProbable;
                alquilerById.FKBibliotecario = nuevoAlquiler.FKBibliotecario;
                alquilerById.FKSocio = nuevoAlquiler.FKSocio;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public List<Alquiler> GetList()
        {
            List<Alquiler> listaAlquileres = new List<Alquiler>();

            try
            {
                var lstAlquileres = from alquiler in dataDB.Alquilers select alquiler;

                foreach (var alquiler in lstAlquileres)
                {
                    listaAquileres.Items.Add(alquiler);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
            
            return listaAlquileres;
        }
        public List<Alquiler> GetASocioById(int idSocio)
        {
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
        }
        public Alquiler GetById(int idAlquiler)
        {
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
        }
    }
}