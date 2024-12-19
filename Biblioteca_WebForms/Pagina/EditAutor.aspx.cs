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
    public partial class EditAutor : System.Web.UI.Page
    {
        public static string aId;
        public static string aOpcion;

        Autor autor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Título Específico del Formulario";
                lbMensaje.Text = "";

                if (Request.QueryString["id"] != null)
                {
                    aId = Request.QueryString["id"].ToString();
                }

                if (Request.QueryString["opcion"] != null)
                {
                    aOpcion = Request.QueryString["opcion"].ToString();

                    switch (aOpcion)
                    {
                        case "C":
                            masterPage.Titulo = "Crear un Autor Nuevo";
                            grabar.Visible = true;
                            break;
                        case "D":
                            masterPage.Titulo = "Borrar un Autor";
                            borrar.Visible = true;
                            TraerUnAutor();
                            break;
                        case "U":
                            TraerUnAutor();
                            MostrarUnAutor();
                            masterPage.Titulo = "Modificar un Autor";
                            actualizar.Visible = true;
                            break;
                    }
                }
            }
        }

        private void TraerUnAutor()
        {
            DALAutor dAutor = new DALAutor();
            autor = dAutor.GetById(int.Parse(aId));
        }
        private void MostrarUnAutor()
        {
            txtNombre.Text = autor.Nombre;
            txtApellido1.Text = autor.Apellido1;
            txtApellido1.Text = autor.Apellido2;
        }

        protected void retornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void actualizar_Click(object sender, EventArgs e)
        {
            DALAutor dAutor = new DALAutor();
            autor.Nombre = txtNombre.Text.ToString();
            autor.Apellido1 = txtApellido1.ToString();
            autor.Apellido2 = txtApellido2.ToString();

            if (dAutor.Update(autor))
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }

        protected void grabar_Click(object sender, EventArgs e)
        {
            DALAutor dAutor = new DALAutor();
            Autor autor = new Autor();
            autor.Nombre = txtNombre.Text;
            autor.Apellido1 = txtApellido1.Text;
            autor.Apellido2 = txtApellido2.Text;
            autor.IdAutor = 0;

            if (dAutor.Insert(autor))
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }

        protected void borrar_Click(object sender, EventArgs e)
        {
            DALAutor dAutor = new DALAutor();

            if (dAutor.Delete(autor.IdAutor))
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