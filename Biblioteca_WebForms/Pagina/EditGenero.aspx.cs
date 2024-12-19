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
    public partial class EditGenero : System.Web.UI.Page
    {
        public static string gId;
        public static string gOpcion;

        Genero genero;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Título Específico del Formulario";
                lbMensaje.Text = "";

                if (Request.QueryString["id"] != null)
                {
                    gId = Request.QueryString["id"].ToString();
                }

                if (Request.QueryString["opcion"] != null)
                {
                    gOpcion = Request.QueryString["opcion"].ToString();
                    
                    switch (gOpcion)
                    {
                        case "C":
                            masterPage.Titulo = "Crear un Genero Nuevo";
                            grabar.Visible = true;
                            break;
                        case "D":
                            masterPage.Titulo = "Borrar un Genero";
                            borrar.Visible = true;
                            TraerUnGenero();
                            break;
                        case "U":
                            TraerUnGenero();
                            MostrarUnGenero();
                            masterPage.Titulo = "Modificar un Genero";
                            actualizar.Visible = true;
                            break;
                    }
                }
            }
        }

        private void TraerUnGenero()
        {
            DALGenero dGenero = new DALGenero();
            Genero genero = dGenero.GetById(int.Parse(gId));
        }
        private void MostrarUnGenero()
        {
            txtDescripcion.Text = genero.Descripcion;
        }
        
        protected void retornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        protected void actualizar_Click(object sender, EventArgs e)
        {
            DALGenero dGenero = new DALGenero();
            genero.Descripcion = txtDescripcion.Text.ToString();

            if (dGenero.Update(genero))
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
            DALGenero dGenero = new DALGenero();
            genero = new Genero();
            genero.Descripcion = txtDescripcion.Text.ToString();
            genero.IdGenero = 0;

            if (dGenero.Insert(genero))
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
            DALGenero dGenero = new DALGenero();

            if (dGenero.Delete(genero.IdGenero))
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