using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca_WebForms;
using Biblioteca_WebForms.DAL;
using System.Security.Cryptography;

namespace Biblioteca_WebForms.Pagina
{
    public partial class EditUbicacion : System.Web.UI.Page
    {
        public static string uId;
        public static string uOpcion;

        public static Ubicacion ubicacionAct;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Título Específico del Formulario";
                lbMensaje.Text = "";

                if (Request.QueryString["id"] != null)
                {
                    uId = Request.QueryString["id"].ToString();
                }

                if (Request.QueryString["opcion"] != null)
                {
                    uOpcion = Request.QueryString["opcion"].ToString();

                    switch (uOpcion)
                    {
                        case "C":
                            masterPage.Titulo = "Crear una Ubicacion Nueva";
                            grabar.Visible = true;
                            break;
                        case "D":
                            masterPage.Titulo = "Borrar una Ubicacion";
                            borrar.Visible = true;
                            TraerUnaUbicacion();
                            break;
                        case "U":
                            TraerUnaUbicacion();
                            MostrarUnaUbicacion();
                            masterPage.Titulo = "Modificar una Ubicacion";
                            actualizar.Visible = true;
                            break;
                    }
                }
            }
        }
        private void TraerUnaUbicacion()
        {
            DALUbicacion dUbicacion = new DALUbicacion();
            ubicacionAct = dUbicacion.GetById(int.Parse(uId));
        }
        private void MostrarUnaUbicacion()
        {
            txtEstanteria.Text = ubicacionAct.Estanteria.ToString();
            txtFila.Text = ubicacionAct.Fila.ToString();
            txtColumna.Text = ubicacionAct.Columna.ToString();
        }
        protected void retornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoUbicacion.aspx");
        }
        protected void actualizar_Click(object sender, EventArgs e)
        {
            int numero;
            DALUbicacion dUbicacion = new DALUbicacion();

            int.TryParse(txtEstanteria.Text.ToString(), out numero);
            ubicacionAct.Estanteria = numero;
            ubicacionAct.Fila = txtFila.Text.ToString();
            ubicacionAct.Columna = txtColumna.ToString();

            if (dUbicacion.Update(ubicacionAct))
            {
                Response.Redirect("ListadoUbicacion.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }
        protected void grabar_Click(object sender, EventArgs e)
        {
            int numero;
            DALUbicacion dUbicacion = new DALUbicacion();
            Ubicacion ubicacion = new Ubicacion();

            int.TryParse(txtEstanteria.Text.ToString(), out numero);
            ubicacion.Estanteria = numero;
            ubicacion.Fila = txtFila.Text.ToString();
            ubicacion.Columna = txtColumna.Text.ToString();

            if (dUbicacion.Insert(ubicacion))
            {
                Response.Redirect("ListadoUbicacion.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }
        protected void borrar_Click(object sender, EventArgs e)
        {
            DALUbicacion dUbicacion = new DALUbicacion();

            if (dUbicacion.Delete(ubicacionAct.IdUbicacion))
            {
                Response.Redirect("ListadoUbicacion.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            }
        }
    }
}