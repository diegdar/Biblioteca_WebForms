using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms
{
    public partial class Ms : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string titulo = Request.QueryString["titulo"];
            if (titulo != null)
                lbTitulo.Text = titulo.Trim();
        }
    }
}