using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public class DALSocio
    {
        private DataLinQ_BibliotecaDataContext dataDB = new DataLinQ_BibliotecaDataContext();
        public string Mensaje { get; set; }

        public bool Insert(Socio socio)
        {
            // Devuelve true si se ha insertado el objeto y false si no se
            // ha conseguido

            try
            {
                dataDB.Socio.InsertOnSubmit(socio);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public bool Delete(int idSocio)
        {
            // Devuelve true si se ha borrado el objeto o false si no lo ha
            // conseguido

            try
            {
                var socio = (from so in dataDB.Socio
                             where so.IdSocio == idSocio
                             select so).FirstOrDefault();

                dataDB.Socio.DeleteOnSubmit(socio);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public bool Update(Socio newSocio)
        {
            // Devuelve true si se ha modificado el objeto o false si no se
            // ha conseguido

            try
            {
                var socio = (from so in dataDB.Socio
                             where so.IdSocio == newSocio.IdSocio
                             select so).FirstOrDefault();

                socio.Apellido = newSocio.Apellido;
                socio.Nombre = newSocio.Nombre;
                socio.Email = newSocio.Email;
                socio.Domicilio = newSocio.Domicilio;
                socio.Telefono = newSocio.Telefono;
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public List<Socio> GetList()
        {
            // Devuelve null si se ha producido un error o la lista de
            // de objetos si no se ha producido

            List<Socio> listaSocio = new List<Socio>();
            try
            {
                return dataDB.Socio.ToList();

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

        }
        public Socio GetById(int idSocio)
        {
            // Devuelve null si se ha producido un error o el objeto
            // buscado si no se ha producido

            Socio socio = new Socio();

            try
            {
                var socioById = (from so in dataDB.Socio
                                 where so.IdSocio == idSocio
                                 select so).FirstOrDefault();

                socio.IdSocio = socioById.IdSocio;
                socio.Apellido = socioById.Apellido;
                socio.Nombre = socioById.Nombre;
                socio.Email = socioById.Email;
                socio.Domicilio = socioById.Domicilio;
                socio.Telefono = socioById.Telefono;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return socio;
        }
        public List<Socio> GetFilter(string texto)
        {
            return dataDB.Socio.Where(bi => bi.Apellido.StartsWith(texto))
                                .OrderBy(bi => bi.Apellido)
                                .ToList();
        }

        public bool VerifyExist(int idSocio)
        {
            var resul = dataDB.Alquilers.Where(ob => ob.FKSocio == idSocio).ToList();
            if (resul.Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}