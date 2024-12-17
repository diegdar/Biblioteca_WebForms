using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace Biblioteca_WebForms
{
    public class CommonMethods
    {
        private DataLinQ_BibliotecaDataContext dataDB;
        
        public CommonMethods()
        {
            dataDB = new DataLinQ_BibliotecaDataContext();
        }

        public bool IsEjemplarRented(int ejemplarId)
        {
            return dataDB.AlquilerEjemplars.Where
                        (ae => ae.FKEjemplar == ejemplarId).Any();
        }

    }
}