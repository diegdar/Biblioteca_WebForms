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
                return dataDB.Obras.Where(ob=>ob.IdObra == idObra).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public List<v_Obras> GetList()
        {
            try
            {
                return dataDB.v_Obras.ToList();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public bool Insert(Obra obra)
        {
            try
            {
                dataDB.Obras.InsertOnSubmit(obra);
                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public bool Update(Obra obra)
        {
            try
            {
                var obraExistente = dataDB.Obras.Where(ob => ob.IdObra ==obra.IdObra).FirstOrDefault();
                obraExistente.Titulo = obra.Titulo;
                obraExistente.Sinopsis = obra.Sinopsis;
                obraExistente.FKAutor = obra.FKAutor;
                obraExistente.FKGenero = obra.FKGenero;

                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public bool Delete(int idObra)
        {
            try
            {
                var obra = dataDB.Obras.Where(ob=>ob.IdObra == idObra).FirstOrDefault();
                dataDB.Obras.DeleteOnSubmit(obra);
                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public List<v_Obras> ObrasFiltrar(string text)
        {
            return dataDB.v_Obras.Where(ob => ob.Titulo.StartsWith(text)).ToList();
        }
    }
}
    