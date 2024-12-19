using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Services.Description;

namespace Biblioteca_WebForms
{
    public class CommonMethods
    {
        private DataLinQ_BibliotecaDataContext dataDB;
        public string Mensaje { get; set; }


        public CommonMethods()
        {
            dataDB = new DataLinQ_BibliotecaDataContext();
        }

        public bool IsEjemplarRented(int ejemplarId)
        {
            try
            {
                var ejempFound = dataDB.Ejemplars.Where
                            (ej => ej.IdEjemplar == ejemplarId).FirstOrDefault();

                if (ejempFound != null)
                    return ejempFound.EstaAlquilado;

                return false;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;   
            }
        }
        public bool IsAutorInBook(int autorId)
        {
            try
            {
                var autorFound = dataDB.Obras.Where
                            (ob => ob.FKAutor == autorId).FirstOrDefault();

                if (autorFound != null)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
        public bool IsEditorialInEjemplar(int editorialId)
        {
            try
            {
                var editorialFound = dataDB.Ejemplars.Where
                            (ed => ed.FKEditorial == editorialId).FirstOrDefault();

                if (editorialFound != null)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
        public bool IsGeneroInBook(int generoId)
        {
            try
            {
                var generoFound = dataDB.Obras.Where
                            (gn => gn.FKGenero == generoId).FirstOrDefault();

                if (generoFound != null)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
        public bool IsIdiomaInEjemplar(int idiomaId)
        {
            try
            {
                var idiomaFound = dataDB.Ejemplars.Where
                            (ej => ej.FkIdioma == idiomaId).FirstOrDefault();

                if (idiomaFound != null)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
    }
}