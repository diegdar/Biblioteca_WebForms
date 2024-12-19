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
        private string TipoOperacion;

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
                            TipoOperacion = "creacion";
                            break;
                        case "U":
                            GetSelectedEjemplar();
                            TipoOperacion = "edicion";
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
            // Agregar el elemento "Seleccione una Editorial" como el primero de la lista
            ddEditorial.Items.Insert(0, new ListItem("Seleccione una Editorial...", ""));

            ddIdioma.DataSource = DIdioma.GetList();
            ddIdioma.DataTextField = "Descripcion";
            ddIdioma.DataValueField = "IdIdioma";
            ddIdioma.DataBind();
            // Agregar el elemento "Seleccione un Idioma" como el primero de la lista
            ddIdioma.Items.Insert(0, new ListItem("Seleccione un Idioma...", ""));

            ddObra.DataSource = DObra.GetList();
            ddObra.DataTextField = "Titulo";
            ddObra.DataValueField = "IdObra";
            ddObra.DataBind();
            // Agregar el elemento "Seleccione ununa Obra" como el primero de la lista
            ddObra.Items.Insert(0, new ListItem("Seleccione una Obra...", ""));
        }

        private void GetSelectedEjemplar()
        {
            Ejemplar = DEjemplar.GetById(int.Parse(sId));

            txtCodBarras.Text = Ejemplar.CodigoBarras;
            txtIsbn.Text = Ejemplar.ISBN;
            ddEstado.SelectedValue = Ejemplar.EstaBuenEstado
                                     ? "1" : "0";//devuelve el valor 1 para true y 0 para false
            txtNumPaginas.Text = Ejemplar.NumPaginas.ToString();
            ddAlquilado.SelectedValue = Ejemplar.EstaAlquilado
                                     ? "1" : "0";//devuelve el valor 1 para true y 0 para false
            txtAnioPublicacion.Text = Ejemplar.AnioPublicacion.ToString();
            ddEditorial.SelectedValue = Ejemplar.FKEditorial.ToString();
            ddObra.SelectedValue = Ejemplar.FKObra.ToString();
            ddIdioma.SelectedValue = Ejemplar.FkIdioma.ToString();
            txtUbicacion.Text = "E:" + Ejemplar.Ubicacion.Estanteria.ToString() + " "
                               + "F:" + Ejemplar.Ubicacion.Fila.ToString() + " "
                               + "C:" + Ejemplar.Ubicacion.Columna.ToString();
            ddActivo.SelectedValue = (bool)Ejemplar.EstaActivo
                                     ? "1" : "0";
        }

        protected void btnRetornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoEjemplares.aspx");
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Ejemplar.CodigoBarras = txtCodBarras.Text;
            Ejemplar.ISBN = txtIsbn.Text.ToString();
            Ejemplar.AnioPublicacion = (short?)int.Parse(txtAnioPublicacion.Text);
            Ejemplar.EstaBuenEstado = (ddEstado.SelectedValue == "1");//Esto se evalúa a true si el valor seleccionado es "1", de lo contrario se evalúa a false.
            Ejemplar.NumPaginas = (short?)int.Parse(txtNumPaginas.Text);
            Ejemplar.EstaAlquilado = (ddAlquilado.SelectedValue == "1");
            Ejemplar.FKEditorial = int.Parse(ddEditorial.SelectedValue);
            Ejemplar.FKObra = int.Parse(ddObra.SelectedValue);
            Ejemplar.FkUbicacion = int.Parse(txtUbicacion.Text);
            Ejemplar.FkIdioma = int.Parse(ddIdioma.SelectedValue);
            Ejemplar.EstaActivo = (ddActivo.SelectedValue == "1");

            if (TipoOperacion == "edicion")
            {
                if (DEjemplar.Update(Ejemplar))
                {
                    Response.Redirect("ListadoEjemplares.aspx");
                }
                else
                {
                    lbMensaje.Text = "No se pudo realizar la grabacion del registro";
                };                
            }
            else
            {
                if (DEjemplar.Insert(Ejemplar))
                {
                    Response.Redirect("ListadoEjemplares.aspx");
                }
                else
                {
                    lbMensaje.Text = "No se pudo realizar la grabacion del registro";
                };
            }
        }


        protected void borrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

        }

    }
}