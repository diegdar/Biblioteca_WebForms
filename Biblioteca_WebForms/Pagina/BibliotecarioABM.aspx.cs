using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.Pagina
{
    public partial class BibliotecarioABM : System.Web.UI.Page
    {
        public static string sId;
        public static string sOpcion;

        Bibliotecario biblio;
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Título Específico del Formulario";
                lbMensaje.Text = "";
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
                            masterPage.Titulo = "Crear un nuevo Bibliotecario";
                            btGrabar.Visible = true;
                            break;
                        case "U":
                            TraerUnBibliotecario();
                            MostrarUnBibliotecario();
                            masterPage.Titulo = "Modificar un Bibliotecario";
                            btActualizar.Visible = true;
                            break;
                    }
                }
            }
        }

        private void TraerUnBibliotecario()
        {
            DALBibliotecario dbiblio = new DALBibliotecario();
            biblio = new Bibliotecario();
            biblio = dbiblio.GetById(int.Parse(sId));
        }

        private void MostrarUnBibliotecario()
        {
            txtApellido.Text = biblio.Apellido;
            txtNombre.Text = biblio.Nombre;
            txtEmail.Text = biblio.Email;
            txtContrasenia.Text=biblio.Contrasenia;
        }

        protected void btGrabar_Click(object sender, EventArgs e)
        {
            DALBibliotecario dbiblio = new DALBibliotecario();

            if (dbiblio.Insert(CargarDatos()))
            {
                Response.Redirect("ListadoBibliotecarios.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }

        protected void btActualizar_Click(object sender, EventArgs e)
        {
            DALBibliotecario dbiblio = new DALBibliotecario();
            
            if (dbiblio.Update(CargarDatos()))
            {
                Response.Redirect("ListadoBibliotecarios.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }

        private Bibliotecario CargarDatos()
        {
            DALBibliotecario dbiblio = new DALBibliotecario();
            biblio = new Bibliotecario();
            biblio.IdBibliotecario = int.Parse(sId);
            biblio.Apellido = txtApellido.Text;
            biblio.Nombre = txtNombre.Text;
            biblio.Email = txtEmail.Text;
            biblio.Contrasenia = txtContrasenia.Text;
            return biblio;
        }

        protected void btRetornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoBibliotecarios.aspx");
        }
    }
}