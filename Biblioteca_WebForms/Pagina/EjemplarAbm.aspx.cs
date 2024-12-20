// Sección de imports necesarios para manejar acceso a datos y funcionalidad web
using Biblioteca_WebForms.DAL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.Pagina
{
    public partial class EjemplarAbm : System.Web.UI.Page
    {
        // Variables estáticas para manejar el ID y la operación (Crear/Editar)
        public static string sId;
        public static string sOpcion;

        // Instancias de clases necesarias para manejo de datos
        private Ejemplar Ejemplar;
        private DALEjemplar DEjemplar;
        private DALEditorial DEditorial;
        private DALIdioma DIdioma;
        private DALObra DObra;
        private DALUbicacion DUbicacion;

        // Constructor: Inicializa las instancias de las clases necesarias
        public EjemplarAbm()
        {
            Ejemplar = new Ejemplar();
            DEjemplar = new DALEjemplar();
            DEditorial = new DALEditorial();
            DIdioma = new DALIdioma();
            DObra = new DALObra();
            DUbicacion = new DALUbicacion();
        }

        // Método que se ejecuta cuando se carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // Verifica que no sea un postback
            {
                LoadCombos(); // Carga las listas desplegables
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Título Específico del Formulario";
                lbMensaje.Text = "";

                // Obtiene valores de la query string
                if (Request.QueryString["id"] != null)
                {
                    sId = Request.QueryString["id"].ToString();
                }
                if (Request.QueryString["opcion"] != null)
                {
                    sOpcion = Request.QueryString["opcion"].ToString();
                    ConfigurarTituloSegunOpcion(masterPage); // Configura el título y operación
                }
            }
        }

        // Método que configura el título de la página según la opción seleccionada
        private void ConfigurarTituloSegunOpcion(Ms masterPage)
        {
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

        // Método que carga las listas desplegables con datos
        private void LoadCombos()
        {
            CargarCombo(ddEditorial, DEditorial.GetList(), "Descripcion", "IdEditorial", "Seleccione una Editorial...");
            CargarCombo(ddIdioma, DIdioma.GetList(), "Descripcion", "IdIdioma", "Seleccione un Idioma...");
            CargarCombo(ddObra, DObra.GetList(), "Titulo", "IdObra", "Seleccione una Obra...");
            CargarComboUbicacion();
        }

        // Método genérico para cargar datos en un dropdownlist
        private void CargarCombo(DropDownList ddl, object dataSource, string textField, string valueField, string textoInicial)
        {
            ddl.DataSource = dataSource;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(textoInicial, ""));
        }

        // Método específico para cargar el combo de ubicaciones
        private void CargarComboUbicacion()
        {
            ddUbicacion.Items.Clear();
            ddUbicacion.Items.Add(new ListItem("Seleccione una ubicacion...", ""));
            foreach (var ubicacion in DUbicacion.GetList())
            {
                string text = $"E:{ubicacion.Estanteria} F:{ubicacion.Fila} C:{ubicacion.Columna}";
                ddUbicacion.Items.Add(new ListItem(text, ubicacion.IdUbicacion.ToString()));
            }
        }

        // Método que obtiene el ejemplar seleccionado y llena los campos
        private void GetSelectedEjemplar()
        {
            Ejemplar = DEjemplar.GetById(int.Parse(sId));
            AsignarValoresAControles();
        }

        // Método que asigna los valores del ejemplar a los controles de la página
        private void AsignarValoresAControles()
        {
            txtCodBarras.Text = Ejemplar.CodigoBarras;
            txtIsbn.Text = Ejemplar.ISBN;
            ddEstado.SelectedValue = Ejemplar.EstaBuenEstado ? "1" : "0";
            txtNumPaginas.Text = Ejemplar.NumPaginas.ToString();
            ddAlquilado.SelectedValue = Ejemplar.EstaAlquilado ? "1" : "0";
            txtAnioPublicacion.Text = Ejemplar.AnioPublicacion.ToString();
            ddEditorial.SelectedValue = Ejemplar.FKEditorial.ToString();
            ddObra.SelectedValue = Ejemplar.FKObra.ToString();
            ddIdioma.SelectedValue = Ejemplar.FkIdioma.ToString();
            ddUbicacion.SelectedValue = Ejemplar.FkUbicacion.ToString();
            ddActivo.SelectedValue = (bool)Ejemplar.EstaActivo ? "1" : "0";
        }

        // Botón para regresar al listado de ejemplares
        protected void btnRetornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoEjemplares.aspx");
        }

        // Botón para guardar los cambios realizados en el ejemplar
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out string mensajeError)) // Validación de campos
            {
                lbMensaje.Text = mensajeError;
                return;
            }

            AsignarValoresAEjemplar(); // Asignar valores desde controles

            // Guardar según la operación (crear o editar)
            if ((string)Session["TipoOperacion"] == "edicion")
            {
                ProcesarGuardado(DEjemplar.Update(Ejemplar), "actualizar");
            }
            else
            {
                ProcesarGuardado(DEjemplar.Insert(Ejemplar), "insertar");
            }
        }

        // Método que procesa el resultado del guardado
        private void ProcesarGuardado(bool operacionExitosa, string tipoOperacion)
        {
            if (operacionExitosa)
            {
                Response.Redirect("ListadoEjemplares.aspx");
            }
            else
            {
                lbMensaje.Text = $"No se pudo realizar la {tipoOperacion} del registro.";
            }
        }

        // Método que valida los campos antes de guardar
        private bool ValidarCampos(out string mensajeError)
        {
            mensajeError = string.Empty;

            if (string.IsNullOrEmpty(ddObra.Text)) return MensajeError("La obra es obligatoria.", out mensajeError);
            if (string.IsNullOrEmpty(ddEditorial.Text)) return MensajeError("La editorial es obligatoria", out mensajeError);
            if (string.IsNullOrEmpty(ddIdioma.Text)) return MensajeError("El idioma es obligatorio", out mensajeError);

            if (!short.TryParse(txtAnioPublicacion.Text, out short anioPublicacion) || anioPublicacion <= 1800)
                return MensajeError("El año de publicación debe ser mayor a 1800.", out mensajeError);

            if (!EsSeleccionValida(ddAlquilado.SelectedValue)) return MensajeError("Esta alquilado?: debe tener un valor.", out mensajeError);
            if (!EsSeleccionValida(ddEstado.SelectedValue)) return MensajeError("Seleccione un estado del ejemplar válido.", out mensajeError);
            if (!short.TryParse(txtNumPaginas.Text, out _)) return MensajeError("El número de páginas debe ser un número válido.", out mensajeError);

            return true;
        }

        // Método auxiliar para asignar mensajes de error
        private bool MensajeError(string mensaje, out string mensajeError)
        {
            mensajeError = mensaje;
            return false;
        }

        // Método que asigna valores desde los controles al objeto Ejemplar
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
            if (int.TryParse(ddUbicacion.SelectedValue, out int ubicacionId))
                Ejemplar.FkUbicacion = ubicacionId;
            else
                Ejemplar.FkUbicacion = null; // se asigna null si no se ha elegido una ubicacion
            Ejemplar.FkIdioma = int.Parse(ddIdioma.SelectedValue);
            Ejemplar.EstaActivo = (ddActivo.SelectedValue == "1");
        }

        // Método auxiliar para validar valores booleanos en dropdowns
        private bool EsSeleccionValida(string valor)
        {
            return valor == "1" || valor == "0";
        }
    }
}
