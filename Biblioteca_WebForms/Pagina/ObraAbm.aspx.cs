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
                titulo.Text = "Obra";
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
                            break;
                        case "D":
                            borrar.Visible = true;
                            break;
                        case "U":
                            TraerUnaObra();
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