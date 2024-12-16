using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public partial class DataLinQ_BibliotecaDataContext
    {
        public DataLinQ_BibliotecaDataContext() :
        base(ConfigurationManager.ConnectionStrings["PFBibliotecaConnectionString"].ConnectionString)
        {
            OnCreated();
        }
    }
}