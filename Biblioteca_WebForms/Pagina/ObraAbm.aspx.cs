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
    public partial class ObraAbm : System.Web.UI.Page
    {
        public static string sId;
        public static string sOpcion;

        Obra obra;
        List<Autor> autor = new List<Autor>();
        List<Genero> generos = new List<Genero>();

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
                    CargarCombos();
                    switch (sOpcion)
                    {
                        case "C":
                            masterPage.Titulo = "Crear una Obra Nueva";
                            grabar.Visible = true;
                            break;
                        case "D":
                            masterPage.Titulo = "Borrar una Obra";
                            borrar.Visible = true;
                            TraerUnaObra();
                            break;
                        case "U":
                            TraerUnaObra();
                            MostrarUnaObra();
                            masterPage.Titulo = "Modificar una Obra";
                            actualizar.Visible = true;
                            break;
                    }
                }
            }
        }

        private void TraerUnaObra()
        {
            DALObra dObra = new DALObra();
            obra = new Obra();
            obra = dObra.GetById(int.Parse(sId));
        }
        private void MostrarUnaObra()
        {
            txtTitulo.Text = obra.Titulo;
            txtSinopsis.Text = obra.Sinopsis;
            ddAutor.SelectedValue = obra.FKAutor.ToString();
            ddGenero.SelectedValue = obra.FKGenero.ToString();
        }

        private void CargarCombos()
        {
            DALAutor daAutor = new DALAutor();
            ddAutor.DataSource = daAutor.GetList();
            ddAutor.DataTextField = "Apellido1";
            ddAutor.DataValueField = "IdAutor";
            ddAutor.DataBind();

            DALGenero daGenero = new DALGenero();
            ddGenero.DataSource = daGenero.GetList();
            ddGenero.DataTextField = "Descripcion";
            ddGenero.DataValueField = "IdGenero";
            ddGenero.DataBind();
        }


        protected void retornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoEjemplares.aspx");
        }

        protected void actualizar_Click(object sender, EventArgs e)
        {
            DALObra dobra = new DALObra();
            Obra obra = new Obra();
            obra.Titulo = txtTitulo.Text.ToString();
            obra.Sinopsis = txtSinopsis.Text.ToString();
            obra.FKAutor = int.Parse(ddAutor.SelectedValue.ToString());
            obra.FKGenero = int.Parse(ddGenero.SelectedValue.ToString()); ;
            obra.IdObra = int.Parse(sId);
            if (dobra.Update(obra))
            {
                Response.Redirect("ListadoEjemplares.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            };
        }

        protected void grabar_Click(object sender, EventArgs e)
        {
            DALObra dobra = new DALObra();
            Obra obra = new Obra();
            obra.Titulo = txtTitulo.Text.ToString();
            obra.Sinopsis = txtSinopsis.Text.ToString();
            obra.FKAutor = 1;
            obra.FKGenero = 1;
            obra.IdObra = int.Parse(sId);
            if (dobra.Insert(obra))
            {
                Response.Redirect("ListadoEjemplares.aspx");
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la grabacion del registro";
            };
        }

        protected void borrar_Click(object sender, EventArgs e)
        {

        }
    }
}