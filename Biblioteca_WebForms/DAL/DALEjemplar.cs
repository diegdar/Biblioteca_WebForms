using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.DAL
{
    public class DALEjemplar
    {
        private DataLinQ_BibliotecaDataContext dataDB;
        public string Mensaje { get; set; }

        public DALEjemplar()
        {
            dataDB = new DataLinQ_BibliotecaDataContext();
        }

        public List<Ejemplar> GetList()
        {
            try
            {
                return dataDB.Ejemplars.ToList();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public bool Insert(Ejemplar ejemplar)
        {
            try
            {
                dataDB.Ejemplars.InsertOnSubmit(ejemplar);
                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public bool Delete(int ejemplarId)
        {
            try
            {

                var ejemplar = dataDB.Ejemplars.Where(ej =>ej.Equals(ejemplarId)).FirstOrDefault();
                if (true)
                {
                    
                }

                dataDB.Ejemplars.DeleteOnSubmit(ejemplar);
                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        private bool IsEjemplarRent(Ejemplar ejemplar)
        {
            var ejemplar = dataDB.Ejemplars.Where(ej => ej.Equals(ejemplarId)).FirstOrDefault();

        }

        public bool Update(int )
        {
            try
            {
                // modificar
                var empA = (from ejp in dataDB.Ejemplars
                            where ejp.IdEjemplar == 104
                            select emp).FirstOrDefault();
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