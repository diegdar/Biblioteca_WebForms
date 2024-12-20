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
                return dataDB.Generos.Where(ge => ge.IdGenero == idGenero).FirstOrDefault();
                        
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
                return dataDB.Generos.ToList();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public bool Insert(Genero genero)
        {
            try
            {
                dataDB.Generos.InsertOnSubmit(genero);
                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public bool Update(Genero genero)
        {
            try
            {
                var generoExistente = dataDB.Generos.Where(ge => ge.IdGenero == genero.IdGenero).FirstOrDefault();

                if (generoExistente == null)
                    return false;

                generoExistente.Descripcion = genero.Descripcion;
                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
        public bool Delete(int idGenero)
        {
            try
            {
                var generoExistente = dataDB.Generos.Where(ge => ge.IdGenero == idGenero).FirstOrDefault();

                dataDB.Generos.DeleteOnSubmit(generoExistente);
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
