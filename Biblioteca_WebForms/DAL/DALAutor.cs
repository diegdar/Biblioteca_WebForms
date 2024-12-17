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
                return (from c in dataDB.Autors
                        where c.IdAutor == idAutor
                        select c).FirstOrDefault();
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
                return (from c in dataDB.Autors
                        select c).ToList();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public void Insert(Autor autor)
        {
            try
            {
                dataDB.Autors.InsertOnSubmit(autor);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
        }

        public void Update(Autor unAutor)
        {
            try
            {
                var autor = (from c in dataDB.Autors
                              where c.IdAutor == unAutor.IdAutor
                              select c).FirstOrDefault();

                if (autor != null)
                {
                    autor.Apellido1 = unAutor.Apellido1;
                    autor.Apellido2 = unAutor.Apellido2;
                    autor.Nombre = unAutor.Nombre;
                    dataDB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
        }
        public bool Delete(int idAutor)
        {
            try
            {
                var autor = (from c in dataDB.Autors
                              where c.IdAutor == idAutor
                              select c).FirstOrDefault();

                if (autor != null)
                {
                    dataDB.Autors.DeleteOnSubmit(autor);
                    dataDB.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
    }
}
