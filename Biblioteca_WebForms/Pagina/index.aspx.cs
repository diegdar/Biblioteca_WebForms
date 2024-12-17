using Biblioteca_WebForms;
using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca.Pagina
{


    public partial class index : System.Web.UI.Page
    {
        private CommonMethods comMethods;

        public index()
        {
            comMethods = new CommonMethods();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DALEjemplar DALEjemplar = new DALEjemplar();
            DALEjemplar.Delete(5);

        }


    }
}