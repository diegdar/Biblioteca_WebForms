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
        private DALUbicacion DUbicacion;
        //public string TipoOperacion;

        public EjemplarAbm()
        {
            Ejemplar = new Ejemplar();
            DEjemplar = new DALEjemplar();
            DEditorial = new DALEditorial();
            DIdioma = new DALIdioma();
            DObra = new DALObra();
            DUbicacion = new DALUbicacion();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LoadCombos();
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
                            Session["TipoOperacion"] = "creacion";
                            break;
                        case "U":
                            GetSelectedEjemplar();
                            Session["TipoOperacion"] = "edicion";
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
            ddEditorial.Items.Insert(0, new ListItem("Seleccione una Editorial...", "-1"));

            ddIdioma.DataSource = DIdioma.GetList();
            ddIdioma.DataTextField = "Descripcion";
            ddIdioma.DataValueField = "IdIdioma";
            ddIdioma.DataBind();
            // Agregar el elemento "Seleccione un Idioma" como el primero de la lista
            ddIdioma.Items.Insert(0, new ListItem("Seleccione un Idioma...", "-1"));

            ddObra.DataSource = DObra.GetList();
            ddObra.DataTextField = "Titulo";
            ddObra.DataValueField = "IdObra";
            ddObra.DataBind();
            // Agregar el elemento "Seleccione una Obra" como el primero de la lista
            ddObra.Items.Insert(0, new ListItem("Seleccione una Obra...", "-1"));

            ddUbicacion.DataSource = DUbicacion.GetList();
            ddUbicacion.DataValueField = "IdUbicacion";
            ddUbicacion.DataBind();
            // Limpiar las opciones previas antes de agregar las nuevas
            ddUbicacion.Items.Clear();
            // Agregar el primer ítem para seleccionar una ubicacion
            ddUbicacion.Items.Add(new ListItem("Seleccione una ubicacion...", "-1"));
            // Recorrer la lista y agregar las opciones con la concatenación de los campos
            foreach (var ubicacion in DUbicacion.GetList())
            {
                string text = "E:" + ubicacion.Estanteria + " F:" + ubicacion.Fila + " C:" + ubicacion.Columna;
                ddUbicacion.Items.Add(new ListItem(text, ubicacion.IdUbicacion.ToString()));
            }
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
            ddUbicacion.SelectedValue = Ejemplar.FkUbicacion.ToString();
            ddActivo.SelectedValue = (bool)Ejemplar.EstaActivo
                                     ? "1" : "0";
        }

        protected void btnRetornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoEjemplares.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (!ValidarCampos(out string mensajeError))
            {
                lbMensaje.Text = mensajeError;
                return;
            }

            // Asignar valores al objeto Ejemplar
            AsignarValoresAEjemplar();

            // Guardar según la operación
            if ((string)Session["TipoOperacion"] == "edicion")
            {
                if (DEjemplar.Update(Ejemplar))
                {
                    Response.Redirect("ListadoEjemplares.aspx");
                }
                else
                {
                    lbMensaje.Text = "No se pudo realizar la grabación del registro.";
                }
            }
            else
            {
                if (DEjemplar.Insert(Ejemplar))
                {
                    Response.Redirect("ListadoEjemplares.aspx");
                }
                else
                {
                    lbMensaje.Text = "No se pudo realizar la grabación del registro.";
                }
            }
        }

        private bool ValidarCampos(out string mensajeError)
        {
            mensajeError = string.Empty;

            if (string.IsNullOrEmpty(txtCodBarras.Text))
            {
                mensajeError = "El código de barras es obligatorio.";
                return false;
            }

            if (string.IsNullOrEmpty(txtIsbn.Text))
            {
                mensajeError = "El ISBN es obligatorio.";
                return false;
            }

            if (!short.TryParse(txtAnioPublicacion.Text, out short anioPublicacion))
            {
                mensajeError = "El año de publicación debe ser un número válido.";
                return false;
            }

            if (anioPublicacion <= 1800)
            {
                mensajeError = "El año de publicación debe ser mayor a 1800.";
                return false;
            }

            if (!EsSeleccionValida(ddEstado.SelectedValue))
            {
                mensajeError = "Seleccione un estado válido (Bueno o Malo).";
                return false;
            }

            if (!short.TryParse(txtNumPaginas.Text, out _))
            {
                mensajeError = "El número de páginas debe ser un número válido.";
                return false;
            }

            if (!EsSeleccionValida(ddAlquilado.SelectedValue))
            {
                mensajeError = "Seleccione si el ejemplar está alquilado o no.";
                return false;
            }

            if (!EsSeleccionValidaConNumero(ddEditorial.SelectedValue, out _))
            {
                mensajeError = "Seleccione una editorial válida.";
                return false;
            }

            if (!EsSeleccionValidaConNumero(ddObra.SelectedValue, out _))
            {
                mensajeError = "Seleccione una obra válida.";
                return false;
            }

            if (!EsSeleccionValidaConNumero(ddUbicacion.SelectedValue, out _))
            {
                mensajeError = "Seleccione una ubicacion valida.";
                return false;
            }

            if (!EsSeleccionValidaConNumero(ddIdioma.SelectedValue, out _))
            {
                mensajeError = "Seleccione un idioma válido.";
                return false;
            }

            if (!EsSeleccionValida(ddActivo.SelectedValue))
            {
                mensajeError = "Seleccione si el ejemplar está activo o no.";
                return false;
            }

            return true;
        }

        private void AsignarValoresAEjemplar()
        {
            Ejemplar.IdEjemplar = int.Parse(sId);
            Ejemplar.CodigoBarras = txtCodBarras.Text;
            Ejemplar.ISBN = txtIsbn.Text;
            Ejemplar.AnioPublicacion = (short?)int.Parse(txtAnioPublicacion.Text);
            Ejemplar.EstaBuenEstado = (ddEstado.SelectedValue == "1");
            Ejemplar.NumPaginas = (short?)int.Parse(txtNumPaginas.Text);
            Ejemplar.EstaAlquilado = (ddAlquilado.SelectedValue == "1");
            Ejemplar.FKEditorial = int.Parse(ddEditorial.SelectedValue);
            Ejemplar.FKObra = int.Parse(ddObra.SelectedValue);
            Ejemplar.FkUbicacion = int.Parse(ddUbicacion.Text);
            Ejemplar.FkIdioma = int.Parse(ddIdioma.SelectedValue);
            Ejemplar.EstaActivo = (ddActivo.SelectedValue == "1");
        }

        private bool EsSeleccionValida(string valor)
        {
            return valor == "1" || valor == "0";
        }

        private bool EsSeleccionValidaConNumero(string valor, out int resultado)
        {
            var var1 = int.TryParse(valor, out resultado);
            var var2 = resultado > 0;
            return int.TryParse(valor, out resultado) && resultado > 0;
        }
    }
}