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

        public static Autor autorAct;

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

        private string ObtenerCadenaAMostrar(string cadenaIni)
        {
            if (string.IsNullOrEmpty(cadenaIni))
                return "";

            return cadenaIni;
        }
        private string ObtenerCadenaAGuardar(string cadenaIni)
        {
            if (string.IsNullOrEmpty(cadenaIni))
                return null;

            cadenaIni = cadenaIni.Trim();

            if (cadenaIni.Length == 0)
                return null;

            return cadenaIni;
        }
        private void TraerUnAutor()
        {
            DALAutor dAutor = new DALAutor();
            autorAct = dAutor.GetById(int.Parse(aId));
        }
        private void MostrarUnAutor()
        {
            txtNombre.Text = ObtenerCadenaAMostrar(autorAct.Nombre);
            txtApellido1.Text = ObtenerCadenaAMostrar(autorAct.Apellido1);
            txtApellido2.Text = ObtenerCadenaAMostrar(autorAct.Apellido2);
        }

        protected void retornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoAutor.aspx");
        }

        protected void actualizar_Click(object sender, EventArgs e)
        {
            DALAutor dAutor = new DALAutor();
            
            Autor autor = new Autor();
            autor.Nombre = ObtenerCadenaAGuardar(txtNombre.Text.ToString());
            autor.Apellido1 = ObtenerCadenaAGuardar(txtApellido1.Text.ToString());
            autor.Apellido2 = ObtenerCadenaAGuardar(txtApellido2.Text.ToString());
            autor.IdAutor = autorAct.IdAutor;

            if (dAutor.Update(autor))
            {
                Response.Redirect("ListadoAutor.aspx");
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

            autor.Nombre = ObtenerCadenaAGuardar(txtNombre.Text.ToString());
            autor.Apellido1 = ObtenerCadenaAGuardar(txtApellido1.Text.ToString());
            autor.Apellido2 = ObtenerCadenaAGuardar(txtApellido2.Text.ToString());

            if (dAutor.Insert(autor))
            {
                Response.Redirect("ListadoAutor.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }

        protected void borrar_Click(object sender, EventArgs e)
        {
            DALAutor dAutor = new DALAutor();

            if (dAutor.Delete(autorAct.IdAutor))
            {
                Response.Redirect("ListadoAutor.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }
    }
}