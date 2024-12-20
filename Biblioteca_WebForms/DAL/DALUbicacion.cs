using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public class DALUbicacion
    {
        private DataLinQ_BibliotecaDataContext dataDB = new DataLinQ_BibliotecaDataContext();
        public string Mensaje { get; set; }

        public bool Insert(Ubicacion ubicacion)
        {
            // Devuelve true si se ha insertado el objeto y false si no se
            // ha conseguido

            try
            {
                dataDB.Ubicacions.InsertOnSubmit(ubicacion);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }

        public bool Delete(int idUbicacion)
        {
            // Devuelve true si se ha borrado el objeto o false si no lo ha
            // conseguido

            try
            {
                var ubicacion = (from ub in dataDB.Ubicacions
                                 where ub.IdUbicacion == idUbicacion
                                 select ub).FirstOrDefault();

                dataDB.Ubicacions.DeleteOnSubmit(ubicacion);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public bool Update(Ubicacion newUbicacion)
        {
            // Devuelve true si se ha modificado el objeto o false si no se
            // ha conseguido

            try
            {
                var ubicacion = (from ub in dataDB.Ubicacions
                                 where ub.IdUbicacion == newUbicacion.IdUbicacion
                                 select ub).FirstOrDefault();

                if (ubicacion == null)
                    return false;

                ubicacion.Estanteria = newUbicacion.Estanteria;
                ubicacion.Fila = newUbicacion.Fila;
                ubicacion.Columna = newUbicacion.Columna;
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public List<Ubicacion> GetList()
        {
            // Devuelve null si se ha producido un error o la lista de
            // de objetos si no se ha producido

            List<Ubicacion> listaUbicacion = new List<Ubicacion>();

            try
            {
                var lstUbicacion = from ubicacion in dataDB.Ubicacions
                                   select ubicacion;

                foreach (var ubicacion in lstUbicacion)
                {
                    listaUbicacion.Add(ubicacion);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return listaUbicacion;
        }
        public Ubicacion GetById(int idUbicacion)
        {
            // Devuelve null si se ha producido un error o el objeto
            // buscado si no se ha producido

            Ubicacion ubicacion = new Ubicacion();

            try
            {
                var ubicacionById = (from ub in dataDB.Ubicacions
                                     where ub.IdUbicacion == idUbicacion
                                     select ub).FirstOrDefault();

                if (ubicacionById == null)
                    return null;

                ubicacion.IdUbicacion = ubicacionById.IdUbicacion;
                ubicacion.Estanteria = ubicacionById.Estanteria;
                ubicacion.Fila = ubicacionById.Fila;
                ubicacion.Columna = ubicacionById.Columna;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return ubicacion;
        }
    }
}