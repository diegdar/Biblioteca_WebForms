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
                return dataDB.Ejemplars.Where(ej => ej.EstaActivo == true).ToList();
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
                var ejemplar = dataDB.Ejemplars.Where
                    (ej => ej.IdEjemplar == ejemplarId).FirstOrDefault();

                ejemplar.EstaActivo = false;
                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public bool Update(Ejemplar ejempData)
        {
            try
            {
                var ejempFound = dataDB.Ejemplars.Where
                        (ej => ej.IdEjemplar == ejempData.IdEjemplar).FirstOrDefault();

                ejempFound.CodigoBarras = ejempData.CodigoBarras;
                ejempFound.ISBN = ejempData.ISBN;
                ejempFound.AnioPublicacion = ejempData.AnioPublicacion;
                ejempFound.EstaBuenEstado = ejempData.EstaBuenEstado;
                ejempFound.NumPaginas = ejempData.NumPaginas;
                ejempFound.EstaAlquilado = ejempData.EstaAlquilado;
                ejempFound.FKEditorial = ejempData.FKEditorial;
                ejempFound.FKObra = ejempData.FKObra;
                ejempFound.FkUbicacion = ejempData.FkUbicacion;
                ejempFound.FkIdioma = ejempData.FkIdioma;

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