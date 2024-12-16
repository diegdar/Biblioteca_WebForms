using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca_WebForms.DAL
{
    public class DALObra
    {
        private DataLinQ_BibliotecaDataContext dataDB = new DataLinQ_BibliotecaDataContext();
        public string Mensaje { get; set; }

        public Obra GetById(int idObra)
        {
            try
            {
                return (from c in dataDB.Obras
                        where c.IdObra == idObra
                        select c).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public List<Obra> GetList()
        {
            try
            {
                return (from c in dataDB.Obras
                        select c).ToList();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public void Insert(Obra obra)
        {
            try
            {
                dataDB.Obras.InsertOnSubmit(obra);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
        }

        public void Update(Obra unaObra)
        {
            try
            {
                var obra = (from c in dataDB.Obras
                            where c.IdObra == unaObra.IdObra
                            select c).FirstOrDefault();

                if (obra != null)
                {
                    obra.Titulo = obra.Titulo;
                    obra.Sinopsis = obra.Sinopsis;
                    dataDB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
        }
        public void Delete(int IdObra)
        {
            try
            {
               var obra= (from c in dataDB.Obras
                          where c.IdObra == IdObra
                          select c).FirstOrDefault();

               if (obra != null)
               {
                   dataDB.Obras.DeleteOnSubmit(obra);
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