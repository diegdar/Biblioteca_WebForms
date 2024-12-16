using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public class DALGenero
    {
        private DataLinQ_BibliotecaDataContext dataDB = new DataLinQ_BibliotecaDataContext();
        public string Mensaje { get; set; }

        public Genero GetById(int idGenero)
        {
            try
            {
                return (from c in dataDB.Generos
                        where c.IdGenero == idGenero
                        select c).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public List<Genero> GetList()
        {
            try
            {
                return (from c in dataDB.Generos
                        select c).ToList();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public void Insert(Genero genero)
        {
            try
            {
                dataDB.Generos.InsertOnSubmit(genero);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
        }

        public void Update(Genero unGenero)
        {
            try
            {
                var genero = (from c in dataDB.Generos
                            where c.IdGenero == unGenero.IdGenero
                            select c).FirstOrDefault();

                if (genero != null)
                {
                    genero.Descripcion = unGenero.Descripcion;
                    dataDB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
        }
        public void Delete(int idGenero)
        {
            try
            {
                var genero = (from c in dataDB.Generos
                            where c.IdGenero == idGenero
                            select c).FirstOrDefault();

                if (genero != null)
                {
                    dataDB.Generos.DeleteOnSubmit(genero);
                    dataDB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
        }
    }
}
