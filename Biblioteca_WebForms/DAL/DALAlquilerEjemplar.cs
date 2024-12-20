using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public class DALAlquilerEjemplar
    {
        private DataLinQ_BibliotecaDataContext dataDB = new DataLinQ_BibliotecaDataContext();
        public string Mensaje { get; set; }

        public bool Insert(AlquilerEjemplar alEjemplar)
        {
            // Devuelve true si se ha insertado el objeto y false si no se
            // ha conseguido

            try
            {
                dataDB.AlquilerEjemplars.InsertOnSubmit(alEjemplar);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }

        public bool Delete(int idAlEjemplar)
        {
            // Devuelve true si se ha borrado el objeto o false si no lo ha
            // conseguido

            try
            {
                var alEjemplar = (from al in dataDB.AlquilerEjemplars
                                  where al.IdAlquilerEjemplar == idAlEjemplar
                                  select al).FirstOrDefault();

                dataDB.AlquilerEjemplars.DeleteOnSubmit(alEjemplar);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public bool Update(AlquilerEjemplar newAlEjemplar)
        {
            // Devuelve true si se ha modificado el objeto o false si no se
            // ha conseguido

            try
            {
                var alEjemplar = (from al in dataDB.AlquilerEjemplars
                                  where al.IdAlquilerEjemplar == newAlEjemplar.IdAlquilerEjemplar
                                  select al).FirstOrDefault();

                alEjemplar.FKAlquiler = newAlEjemplar.FKAlquiler;
                alEjemplar.FKEjemplar = newAlEjemplar.FKEjemplar;
                alEjemplar.FechaDevReal = newAlEjemplar.FechaDevReal;
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public List<AlquilerEjemplar> GetList()
        {
            // Devuelve null si se ha producido un error o la lista de
            // de objetos si no se ha producido

            List<AlquilerEjemplar> listaAlEjemplar = new List<AlquilerEjemplar>();

            try
            {
                var lstAlEjemplar = from alEjemplar in dataDB.AlquilerEjemplars
                                    select alEjemplar;

                foreach (var alEjemplar in lstAlEjemplar)
                {
                    listaAlEjemplar.Add(alEjemplar);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return listaAlEjemplar;
        }
        public List<AlquilerEjemplar> GetAAlquilerById(int idAlquiler)
        {
            // Lo vamos a usar para saber todos los ejemplares de un alquiler
            // Devuelve null si se ha producido un error o la lista de
            // de objetos si no se ha producido

            List<AlquilerEjemplar> listaAlEjemplar = new List<AlquilerEjemplar>();

            try
            {
                var lstAlEjemplar = from alEjemplar in dataDB.AlquilerEjemplars
                                    where alEjemplar.FKAlquiler == idAlquiler
                                    select alEjemplar;

                foreach (var alEjemplar in lstAlEjemplar)
                {
                    listaAlEjemplar.Add(alEjemplar);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return listaAlEjemplar;
        }
        public AlquilerEjemplar GetById(int idAlEjemplar)
        {
            // Devuelve null si se ha producido un error o el objeto
            // buscado si no se ha producido

            AlquilerEjemplar alEjemplar = new AlquilerEjemplar();

            try
            {
                var alEjemplarById = (from al in dataDB.AlquilerEjemplars
                                      where al.IdAlquilerEjemplar == idAlEjemplar
                                      select al).FirstOrDefault();

                alEjemplar.IdAlquilerEjemplar = alEjemplarById.IdAlquilerEjemplar;
                alEjemplar.FKAlquiler = alEjemplarById.FKAlquiler;
                alEjemplar.FKEjemplar = alEjemplarById.FKEjemplar;
                alEjemplar.FechaDevReal = alEjemplarById.FechaDevReal;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return alEjemplar;
        }

        private void ObtenerEjemplaresAlquilados()
        {
            using (var db = dataDB) // Usar tu contexto LINQ to SQL
            {
                var ejemplaresAlquilados = from ejemplar in db.Ejemplars
                                           join obra in db.Obras on ejemplar.FKObra equals obra.IdObra
                                           join AlquilerEjemplar in db.AlquilerEjemplars on ejemplar.IdEjemplar equals alquiler.IdEjemplar
                                           join socio in db.Socio on alquiler.IdSocio equals socio.IdSocio
                                           where alquiler.FechaDevolucion == null // Solo ejemplares no devueltos
                                           select new
                                           {
                                               IdEjemplar = ejemplar.IdEjemplar,
                                               Titulo = obra.Titulo,
                                               CodigoBarras = ejemplar.CodigoBarras,
                                               NomSocio = socio.Apellido + ", " + socio.Nombre,
                                               FechaDevProbable = alquiler.FechaDevProbable
                                           };

                return ejemplaresAlquilados.ToList();
            }
        }
    }
}