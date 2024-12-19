using Biblioteca_WebForms;
using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca
{
    public partial class EditIdioma : System.Web.UI.Page
    {
        public static string iId;
        public static string iOpcion;

        Idioma idioma;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Título Específico del Formulario";
                lbMensaje.Text = "";

                if (Request.QueryString["id"] != null)
                {
                    iId = Request.QueryString["id"].ToString();
                }

                if (Request.QueryString["opcion"] != null)
                {
                    iOpcion = Request.QueryString["opcion"].ToString();

                    switch (iOpcion)
                    {
                        case "C":
                            masterPage.Titulo = "Crear un Idioma Nuevo";
                            grabar.Visible = true;
                            break;
                        case "D":
                            masterPage.Titulo = "Borrar un Idioma";
                            borrar.Visible = true;
                            TraerUnIdioma();
                            break;
                        case "U":
                            TraerUnIdioma();
                            MostrarUnIdioma();
                            masterPage.Titulo = "Modificar un Idioma";
                            actualizar.Visible = true;
                            break;
                    }
                }
            }
        }

        private void TraerUnIdioma()
        {
            DALIdioma dIdioma = new DALIdioma();
            Idioma genero = dIdioma.GetById(int.Parse(iId));
        }
        private void MostrarUnIdioma()
        {
            txtDescripcion.Text = idioma.Descripcion;
        }

        protected void retornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        protected void actualizar_Click(object sender, EventArgs e)
        {
            DALIdioma dIdioma = new DALIdioma();
            idioma.Descripcion = txtDescripcion.Text.ToString();

            if (dIdioma.Update(idioma))
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }

        protected void grabar_Click(object sender, EventArgs e)
        {
            DALIdioma dIdioma = new DALIdioma();
            idioma = new Idioma();
            idioma.Descripcion = txtDescripcion.Text.ToString();
            idioma.IdIdioma = 0;

            if (dIdioma.Insert(idioma))
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }
        protected void borrar_Click(object sender, EventArgs e)
        {
            DALIdioma dIdioma = new DALIdioma();

            if (dIdioma.Delete(idioma.IdIdioma))
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }
    }
}