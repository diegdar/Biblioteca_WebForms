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

        public static Editorial editorialAct;

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
            editorialAct = dEditorial.GetById(int.Parse(eId));
        }
        private void MostrarUnaEditorial()
        {
            txtDescripcion.Text = editorialAct.Descripcion;
        }
        protected void retornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoEditorial.aspx");
        }

        protected void actualizar_Click(object sender, EventArgs e)
        {
            DALEditorial dEditorial = new DALEditorial();
            editorialAct.Descripcion = txtDescripcion.Text.ToString();

            if (dEditorial.Update(editorialAct))
            {
                Response.Redirect("ListadoEditorial.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }
        protected void grabar_Click(object sender, EventArgs e)
        {
            DALEditorial dEditorial = new DALEditorial();
            Editorial editorial = new Editorial();
            editorial.Descripcion = txtDescripcion.Text.ToString();

            if (dEditorial.Insert(editorial))
            {
                Response.Redirect("ListadoEditorial.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }
        protected void borrar_Click(object sender, EventArgs e)
        {
            DALEditorial dEditorial = new DALEditorial();

            if (dEditorial.Delete(editorialAct.IdEditorial))
            {
                Response.Redirect("ListadoEditorial.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }
    }
}