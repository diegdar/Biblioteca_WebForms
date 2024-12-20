using Biblioteca.Pagina;
using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.Pagina
{
    public partial class Alquiler : System.Web.UI.Page
    {

        private CommonMethods comMethods;
        private DALEjemplar dEjemplar=new DALEjemplar();

        List<Ejemplar> listaEjemplares;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Realizar una Alquiler de Libros";
                Session["listaEjemplares"] = new List<Ejemplar>();
                CargarSocio();
            }
            listaEjemplares = Session["listaEjemplares"] as List<Ejemplar>;
        }

        private void CargarSocio()
        {
            DALSocio daSocio = new DALSocio();
            List<Socio> listaSocios = daSocio.GetList();

            var listaNombresCompletos = listaSocios
                .Select(s => new {
                    Texto = $"{s.Apellido}, {s.Nombre ?? ""}",
                    Valor = s.IdSocio
                });

            ddSocio.DataSource = listaNombresCompletos;
            ddSocio.DataTextField = "Texto";
            ddSocio.DataValueField = "Valor";
            ddSocio.DataBind();
        }

        private void BindGrid()
        {
            dgvAlquiler.DataSource =  listaEjemplares;
            dgvAlquiler.DataBind();
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
           string codigoBarra = txtBuscarEjemplar.Text;
           Ejemplar ejemplar=dEjemplar.GetByCodigoBarra(codigoBarra);

            if(ejemplar!=null)
            {
                if(!BuscarEjemplarRepetido(codigoBarra))
                {
                    listaEjemplares.Add(ejemplar);
                    Session["listaEjemplares"] = listaEjemplares;
                    BindGrid();
                }
                else
                {
                    lbMensaje.Text = "Este libro ya fue ingresado";
                }
            }
            else
            {
                lbMensaje.Text = "No existe el libro, vuela a intentar con otro codigo";
            }
        }

        protected void btRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void lnkBorrar_Command(object sender, CommandEventArgs e)
        {
            int idEje=0;
            if (e.CommandName == "Borrar")
            {
                string[] args = e.CommandArgument.ToString().Split(',');
                if (args.Length == 2)
                {
                   idEje = int.Parse(args[0]);
                }
            }

            var resul = listaEjemplares.Where(ej => ej.IdEjemplar == idEje).FirstOrDefault();

            listaEjemplares = Session["listaEjemplares"] as List<Ejemplar>;

            listaEjemplares.Remove(resul);
            Session["listaEjemplares"] = listaEjemplares;
            BindGrid();
        }

        private bool BuscarEjemplarRepetido(string codigobarra)
        {
            if (codigobarra.Length != 0 && listaEjemplares!=null)
            {
                var resul = listaEjemplares.Where(ej => ej.CodigoBarras == codigobarra).FirstOrDefault();
                if (resul == null)
                {
                    return false;
                }
                return true;
            }
            else
            { 
                return false; 
            }

        }

        protected void btGrabar_Click(object sender, EventArgs e)
        {

        }
    }
}