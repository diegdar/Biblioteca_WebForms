using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.Pagina
{
    public partial class SocioABM : System.Web.UI.Page
    {
        public static string sId;
        public static string sOpcion;

        Socio socio;
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
                            masterPage.Titulo = "Crear un nuevo Socio";
                            btGrabar.Visible = true;
                            break;
                        case "U":
                            TraerUnSocio();
                            MostrarUnSocio();
                            masterPage.Titulo = "Modificar un Socio";
                            btActualizar.Visible = true;
                            break;
                    }
                }
            }
        }


        private void TraerUnSocio()
        {
            DALSocio dbiblio = new DALSocio();
            socio = new Socio();
            socio = dbiblio.GetById(int.Parse(sId));
        }

        private void MostrarUnSocio()
        {
            txtApellido.Text = socio.Apellido;
            txtNombre.Text = socio.Nombre;
            txtEmail.Text = socio.Email;
            txtDomicilio.Text = socio.Domicilio;
            txtTelefono.Text = socio.Telefono;
        }

        protected void btGrabar_Click(object sender, EventArgs e)
        {
            DALSocio dsocio = new DALSocio();

            if (dsocio.Insert(CargarDatos()))
            {
                Response.Redirect("ListadoSocios.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }

        protected void btActualizar_Click(object sender, EventArgs e)
        {
            DALSocio dsocio = new DALSocio();

            if (dsocio.Update(CargarDatos()))
            {
                Response.Redirect("ListadoBibliotecarios.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }

        private Socio CargarDatos()
        {
            DALSocio dsocio = new DALSocio();
            socio = new Socio();
            socio.IdSocio = int.Parse(sId);
            socio.Apellido = txtApellido.Text;
            socio.Nombre = txtNombre.Text;
            socio.Email = txtEmail.Text;
            socio.Domicilio = txtDomicilio.Text;
            socio.Telefono = txtTelefono.Text;
            return socio;
        }


        protected void btRetornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoSocios.aspx");
        }
    }
}