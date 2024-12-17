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

                return ejempFound.EstaAlquilado;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;   
            }

        }

    }
}