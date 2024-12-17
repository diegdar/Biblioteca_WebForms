using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public class DALAutor
    {
        private DataLinQ_BibliotecaDataContext dataDB = new DataLinQ_BibliotecaDataContext();
        public string Mensaje { get; set; }

        public Autor GetById(int idAutor)
        {
            try
            {
                return dataDB.Autors.Where(au=>au.IdAutor==idAutor).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public List<Autor> GetList()
        {
            try
            {
                return dataDB.Autors.ToList();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public bool Insert(Autor autor)
        {
            try
            {
                dataDB.Autors.InsertOnSubmit(autor);
                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public bool Update(Autor autor)
        {
            try
            {
                var autorExistente = dataDB.Autors.Where(au=>au.IdAutor == autor.IdAutor).FirstOrDefault();

                autorExistente.Apellido1 = autor.Apellido1;
                autorExistente.Apellido2 = autor.Apellido2;
                autorExistente.Nombre = autor.Nombre;
                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
        public bool Delete(int idAutor)
        {
            try
            {
                var autor = dataDB.Autors.Where(au=>au.IdAutor == idAutor).FirstOrDefault();
                               
                dataDB.Autors.DeleteOnSubmit(autor);
                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
    }
}
