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
    public partial class EditEditorial : System.Web.UI.Page
    {
        public static string eId;
        public static string eOpcion;

        Editorial editorial;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Título Específico del Formulario";
                lbMensaje.Text = "";

                if (Request.QueryString["id"] != null)
                {
                    eId = Request.QueryString["id"].ToString();
                }

                if (Request.QueryString["opcion"] != null)
                {
                    eOpcion = Request.QueryString["opcion"].ToString();
                    
                    switch (eOpcion)
                    {
                        case "C":
                            masterPage.Titulo = "Crear una Editorial Nueva";
                            grabar.Visible = true;
                            break;
                        case "D":
                            masterPage.Titulo = "Borrar una Editorial";
                            borrar.Visible = true;
                            TraerUnaEditorial();
                            break;
                        case "U":
                            TraerUnaEditorial();
                            MostrarUnaEditorial();
                            masterPage.Titulo = "Modificar una Editorial";
                            actualizar.Visible = true;
                            break;
                    }
                }
            }
        }

        private void TraerUnaEditorial()
        {
            DALEditorial dEditorial = new DALEditorial();
            Editorial editorial = dEditorial.GetById(int.Parse(eId));
        }
        private void MostrarUnaEditorial()
        {
            txtDescripcion.Text = editorial.Descripcion;
        }
        protected void retornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void actualizar_Click(object sender, EventArgs e)
        {
            DALEditorial dEditorial = new DALEditorial();
            editorial.Descripcion = txtDescripcion.Text.ToString();

            if (dEditorial.Update(editorial))
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
            DALEditorial dEditorial = new DALEditorial();
            editorial = new Editorial();
            editorial.Descripcion = txtDescripcion.Text.ToString();
            editorial.IdEditorial = 0;

            if (dEditorial.Insert(editorial))
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
            DALEditorial dEditorial = new DALEditorial();

            if (dEditorial.Delete(editorial.IdEditorial))
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