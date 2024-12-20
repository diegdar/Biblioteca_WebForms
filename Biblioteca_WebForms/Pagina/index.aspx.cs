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
            //DALEjemplar DALEjemplar = new DALEjemplar();
            //Ejemplar ejemp = new Ejemplar();
            //ejemp.IdEjemplar = 15;
            //ejemp.AnioPublicacion = 2000;
            //DALEjemplar.Update(ejemp);

            if (Session["bibliotecarioAct"] != null && !IsPostBack)
            {
                Bibliotecario bi = (Bibliotecario)Session["bibliotecarioAct"];
                LblLogin.Text = bi.Email;
                btnLogout.Text = "Logout";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if (Session["bibliotecarioAct"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session["bibliotecarioAct"] = null;
                LblLogin.Text = "Si eres bibliotecario haz login";
                btnLogout.Text = "Login";
            }
        }
    }
}