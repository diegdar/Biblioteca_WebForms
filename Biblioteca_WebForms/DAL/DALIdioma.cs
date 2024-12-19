using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public class DALIdioma
    {
        private DataLinQ_BibliotecaDataContext dataDB = new DataLinQ_BibliotecaDataContext();
        public string Mensaje { get; set; }

        public bool Insert(Idioma idioma)
        {
            // Devuelve true si se ha insertado el objeto y false si no se
            // ha conseguido

            try
            {
                dataDB.Idiomas.InsertOnSubmit(idioma);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }

        public bool Delete(int idIdioma)
        {
            // Devuelve true si se ha borrado el objeto o false si no lo ha
            // conseguido

            try
            {
                var idioma = (from id in dataDB.Idiomas
                              where id.IdIdioma == idIdioma
                              select id).FirstOrDefault();

                dataDB.Idiomas.DeleteOnSubmit(idioma);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public bool Update(Idioma newIdioma)
        {
            // Devuelve true si se ha modificado el objeto o false si no se
            // ha conseguido

            try
            {
                var idioma = (from id in dataDB.Idiomas
                              where id.IdIdioma == newIdioma.IdIdioma
                              select id).FirstOrDefault();

                if (idioma == null)
                    return false;

                idioma.Descripcion = newIdioma.Descripcion;
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public List<Idioma> GetList()
        {
            // Devuelve null si se ha producido un error o la lista de
            // de objetos si no se ha producido

            List<Idioma> listaIdioma = new List<Idioma>();

            try
            {
                var lstIdioma = from idioma in dataDB.Idiomas
                                   select idioma;

                foreach (var idioma in lstIdioma)
                {
                    listaIdioma.Add(idioma);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return listaIdioma;
        }
        public Idioma GetById(int idIdioma)
        {
            // Devuelve null si se ha producido un error o el objeto
            // buscado si no se ha producido

            Idioma idioma = new Idioma();

            try
            {
                var idiomaById = (from id in dataDB.Idiomas
                                     where id.IdIdioma == idIdioma
                                     select id).FirstOrDefault();

                if (idiomaById == null)
                    return null;

                idioma.IdIdioma = idiomaById.IdIdioma;
                idioma.Descripcion = idiomaById.Descripcion;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return idioma;
        }
    }
}