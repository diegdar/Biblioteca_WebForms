using Biblioteca_WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca
{
    public partial class ObraAbm : System.Web.UI.Page
    {
        public static string sId;
        public static string sOpcion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Ms masterPage = (Ms)this.Master; 
                masterPage.Titulo = "Título Específico del Formulario";

                if (Request.QueryString["id"] != null)
                {
                    sId = Request.QueryString["id"].ToString();
                }
                if (Request.QueryString["opcion"] != null)
                {
                    sOpcion = Request.QueryString["opcion"].ToString();
                    switch (sOpcion)
                    {
                        case "C":
                            grabar.Visible = true;
                            masterPage.Titulo = "Crear una Obra Nueva";
                            break;
                        case "D":
                            borrar.Visible = true;
                            masterPage.Titulo = "Borrar una Obra";
                            break;
                        case "U":
                            TraerUnaObra();
                            masterPage.Titulo = "Modificar una Obra";
                            actualizar.Visible = true;
                            break;
                    }
                }
            }
        }

        private void TraerUnaObra()
        {

        }

        protected void retornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ObraExplorar.aspx");
        }

        protected void actualizar_Click(object sender, EventArgs e)
        {

        }

        protected void grabar_Click(object sender, EventArgs e)
        {

        }

        protected void borrar_Click(object sender, EventArgs e)
        {

        }
    }
}