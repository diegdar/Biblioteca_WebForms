using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.Pagina
{
    public partial class EjemplarAbm : System.Web.UI.Page
    {
        public static string sId;
        public static string sOpcion;

        private Ejemplar Ejemplar;
        private DALEjemplar DEjemplar;
        private DALEditorial DEditorial;
        private DALIdioma DIdioma;
        private DALObra DObra;
        private List<Editorial> editoriales;
        private List<Obra> obras;
        private List<Ubicacion> ubicaciones;
        private List<Idioma> idiomas;

        public EjemplarAbm()
        {
            Ejemplar = new Ejemplar();
            DEjemplar = new DALEjemplar();
            DEditorial = new DALEditorial();
            DIdioma = new DALIdioma();
            DObra = new DALObra();

            editoriales = new List<Editorial>();
            obras = new List<Obra>();
            ubicaciones = new List<Ubicacion>();
            idiomas = new List<Idioma>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCombos();

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
                            masterPage.Titulo = "Crear un nuevo Ejemplar";
                            break;
                        case "U":
                            GetAnEjemplar();
                            //ShowEjempFields();
                            masterPage.Titulo = "Modificar un Ejemplar";
                            break;
                    }
                }
            }
        }
        private void LoadCombos()
        {
            ddEditorial.DataSource = DEditorial.GetList();
            ddEditorial.DataTextField = "Descripcion";
            ddEditorial.DataValueField = "IdEditorial";
            ddEditorial.DataBind();


            ddIdioma.DataSource = DIdioma.GetList();
            ddIdioma.DataTextField = "Descripcion";
            ddIdioma.DataValueField = "IdIdioma";
            ddIdioma.DataBind();

            ddObra.DataSource = DObra.GetList();
            ddObra.DataTextField = "Titulo";
            ddObra.DataValueField = "IdObra";
            ddObra.DataBind();

        }

        private void GetAnEjemplar()
        {
            Ejemplar = DEjemplar.GetById(int.Parse(sId));
        }


        //private void ShowEjempFields()
        //{
        //    codBarras.Text = Ejemplar.CodigoBarras;
        //    txtAnioPublicacion.Text = Ejemplar.AnioPublicacion.ToString();
        //    txtNumPaginas.Text = Ejemplar.NumPaginas.ToString();
        //    ddlEditorial.SelectedValue = Ejemplar.FKEditorial.ToString();


        //    ddGenero.SelectedValue = obra.FKGenero.ToString();
        //}

        //private void CargarCombos()
        //{
        //    DALAutor daAutor = new DALAutor();
        //    ddAutor.DataSource = daAutor.GetList();
        //    ddAutor.DataTextField = "Apellido1";
        //    ddAutor.DataValueField = "IdAutor";
        //    ddAutor.DataBind();

        //    DALGenero daGenero = new DALGenero();
        //    ddGenero.DataSource = daGenero.GetList();
        //    ddGenero.DataTextField = "Descripcion";
        //    ddGenero.DataValueField = "IdGenero";
        //    ddGenero.DataBind();
        //}


        //protected void retornar_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("ListadoEjemplares.aspx");
        //}

        //protected void actualizar_Click(object sender, EventArgs e)
        //{
        //    DALObra dobra = new DALObra();
        //    Obra obra = new Obra();
        //    obra.Titulo = txtTitulo.Text.ToString();
        //    obra.Sinopsis = txtSinopsis.Text.ToString();
        //    obra.FKAutor = int.Parse(ddAutor.SelectedValue.ToString());
        //    obra.FKGenero = int.Parse(ddGenero.SelectedValue.ToString()); ;
        //    obra.IdObra = int.Parse(sId);
        //    if (dobra.Update(obra))
        //    {
        //        Response.Redirect("ListadoEjemplares.aspx");
        //    }
        //    else
        //    {
        //        lbMensaje.Text = "No se pudo realizar la grabacion del registro";
        //    };
        //}

        //protected void grabar_Click(object sender, EventArgs e)
        //{
        //    DALObra dobra = new DALObra();
        //    Obra obra = new Obra();
        //    obra.Titulo = txtTitulo.Text.ToString();
        //    obra.Sinopsis = txtSinopsis.Text.ToString();
        //    obra.FKAutor = 1;
        //    obra.FKGenero = 1;
        //    obra.IdObra = int.Parse(sId);
        //    if (dobra.Insert(obra))
        //    {
        //        Response.Redirect("ListadoEjemplares.aspx");
        //    }
        //    else
        //    {
        //        lbMensaje.Text = "No se pudo realizar la grabacion del registro";
        //    };
        //}

        protected void borrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRetornar_Click(object sender, EventArgs e)
        {

        }
    }
}