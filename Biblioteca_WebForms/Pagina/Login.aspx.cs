using Biblioteca.Pagina;
using Biblioteca_WebForms.DAL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.Pagina
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private CommonMethods comMethods;

        public WebForm1()
        {
            comMethods = new CommonMethods();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // No se muestra ningún mensaje
                lblMensaje.Text = "";
                txtUsuario.Text = string.Empty;
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            DALBibliotecario dalBibliotecario = new DALBibliotecario();

            if (txtUsuario.Text.Length > 0 && txtClave.Text.Length > 0)
            {
                Bibliotecario bibliotecario = dalBibliotecario.GetByEmail(txtUsuario.Text);

                if (bibliotecario != null)
                {
                    // Podemos comprobar la contraseña
                    if (bibliotecario.Contrasenia == txtClave.Text)
                    {
                        // Contraseña correcta
                        lblMensaje.Text = "Contraseña correcta";
                        Session["nombreBibliotecario"] = bibliotecario.Nombre + " " + 
                            bibliotecario.Apellido;
                        txtUsuario.Text = string.Empty;
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        // Contraseña incorrecta
                        lblMensaje.Text = "El usuario o la contraseña no son válidos";
                    }
                }
                else
                {
                    // El bibliotecario no existe
                    lblMensaje.Text = "El usuario o la contraseña no son válidos";
                }
            }
            else
            {
                // No hay bibliotecarios anónimos
                lblMensaje.Text = "No se puede entrar anónimamente";
            }

            txtUsuario.Text = string.Empty;
        }
    }
}