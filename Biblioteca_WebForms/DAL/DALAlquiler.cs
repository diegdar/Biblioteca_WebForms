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

        public bool Insert(Alquiler alquiler)
        {
            // Devuelve true si se ha insertado el objeto y false si no se
            // ha conseguido

            try
            {
                dataDB.Alquilers.InsertOnSubmit(alquiler);
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
            // Devuelve true si se ha borrado el objeto o false si no lo ha
            // conseguido

            try
            {
                var alquiler = (from al in dataDB.Alquilers
                                where al.IdAlquiler == idAlquiler
                                select al).FirstOrDefault();

                dataDB.Alquilers.DeleteOnSubmit(alquiler);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public bool Update(Alquiler newAlquiler)
        {
            // Devuelve true si se ha modificado el objeto o false si no se
            // ha conseguido

            try
            {
                var alquiler = (from al in dataDB.Alquilers
                                where al.IdAlquiler == newAlquiler.IdAlquiler
                                select al).FirstOrDefault();

                if (alquiler == null)
                    return false;

                alquiler.FechaAlquiler = newAlquiler.FechaAlquiler;
                alquiler.FechaDevProbable = newAlquiler.FechaDevProbable;
                alquiler.FKBibliotecario = newAlquiler.FKBibliotecario;
                alquiler.FKSocio = newAlquiler.FKSocio;
                dataDB.SubmitChanges();
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
            // Devuelve null si se ha producido un error o la lista de
            // de objetos si no se ha producido

            List<Alquiler> listaAlquiler = new List<Alquiler>();

            try
            {
                var lstAlquiler = from alquiler in dataDB.Alquilers
                                  select alquiler;

                foreach (var alquiler in lstAlquiler)
                {
                    listaAlquiler.Add(alquiler);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return listaAlquiler;
        }
        public List<Alquiler> GetASocioById(int idSocio)
        {
            // Lo vamos a usar para saber todos los alquileres de un socio
            // Devuelve null si se ha producido un error o la lista de
            // de objetos si no se ha producido

            List<Alquiler> listaAlquiler = new List<Alquiler>();

            try
            {
                var lstAlquiler = from alquiler in dataDB.Alquilers
                                  where alquiler.FKSocio == idSocio
                                  select alquiler;

                foreach (var alquiler in lstAlquiler)
                {
                    listaAlquiler.Add(alquiler);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return listaAlquiler;

        }
        public Alquiler GetById(int idAlquiler)
        {
            // Devuelve null si se ha producido un error o el objeto
            // buscado si no se ha producido

            Alquiler alquiler = new Alquiler();

            try
            {
                var alquilerById = (from al in dataDB.Alquilers
                                    where al.IdAlquiler == idAlquiler
                                    select al).FirstOrDefault();

                if (alquilerById == null)
                    return null;

                alquiler.IdAlquiler = alquilerById.IdAlquiler;
                alquiler.FechaAlquiler = alquilerById.FechaAlquiler;
                alquiler.FechaDevProbable = alquilerById.FechaDevProbable;
                alquiler.FKBibliotecario = alquilerById.FKBibliotecario;
                alquiler.FKSocio = alquilerById.FKSocio;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return alquiler;
        }
    }
}