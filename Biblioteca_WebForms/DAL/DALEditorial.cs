using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public class DALEditorial
    {
        private DataLinQ_BibliotecaDataContext dataDB = new DataLinQ_BibliotecaDataContext();
        public string Mensaje { get; set; }

        public bool Insert(Editorial editorial)
        {
            // Devuelve true si se ha insertado el objeto y false si no se
            // ha conseguido

            try
            {
                dataDB.Editorials.InsertOnSubmit(editorial);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }

        public bool Delete(int idEditorial)
        {
            // Devuelve true si se ha borrado el objeto o false si no lo ha
            // conseguido

            try
            {
                var editorial = (from ed in dataDB.Editorials
                                 where ed.IdEditorial == idEditorial
                                 select ed).FirstOrDefault();

                dataDB.Editorials.DeleteOnSubmit(editorial);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public bool Update(Editorial newEditorial)
        {
            // Devuelve true si se ha modificado el objeto o false si no se
            // ha conseguido

            try
            {
                var editorial = (from ed in dataDB.Editorials
                                 where ed.IdEditorial == newEditorial.IdEditorial
                                 select ed).FirstOrDefault();

                if (editorial == null)
                    return false;

                editorial.Descripcion = newEditorial.Descripcion;
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public List<Editorial> GetList()
        {
            // Devuelve null si se ha producido un error o la lista de
            // de objetos si no se ha producido

            List<Editorial> listaEditorial = new List<Editorial>();

            try
            {
                var lstEditorial = from editorial in dataDB.Editorials
                                   select editorial;

                foreach (var editorial in lstEditorial)
                {
                    listaEditorial.Add(editorial);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return listaEditorial;
        }
        public Editorial GetById(int idEditorial)
        {
            // Devuelve null si se ha producido un error o el objeto
            // buscado si no se ha producido

            Editorial editorial = new Editorial();

            try
            {
                var editorialById = (from ed in dataDB.Editorials
                                     where ed.IdEditorial == idEditorial
                                     select ed).FirstOrDefault();

                if (editorialById == null)
                    return null;

                editorial.IdEditorial = editorialById.IdEditorial;
                editorial.Descripcion = editorialById.Descripcion;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return editorial;
        }
    }
}