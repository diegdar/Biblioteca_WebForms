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
    public partial class EjemplaresAlquilados : System.Web.UI.Page
    {
        protected DALSocio DSocio;
        protected DALAlquilerEjemplar DEjempAlquileres;
        protected List<v_ListadoAlquilere> listadoEjemplares;

        public EjemplaresAlquilados()
        {
            DSocio = new DALSocio();
            DEjempAlquileres = new DALAlquilerEjemplar();
            listadoEjemplares = new List<v_ListadoAlquilere>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Ejemplares Alquilados";
                listadoEjemplares = DEjempAlquileres.GetListadoAlquilados();
                BindGrid();
                CargarSocio();
            }
        }

        private void CargarSocio()
        {
            var listaNombresCompletos = DSocio.GetList()
                .Select(s => new {
                    Texto = $"{s.Apellido}, {s.Nombre ?? ""}",
                    Valor = s.IdSocio
                });

            ddSocio.DataSource = listaNombresCompletos;
            ddSocio.DataTextField = "Texto";
            ddSocio.DataValueField = "Valor";
            ddSocio.DataBind();
            ddSocio.Items.Insert(0, new ListItem("Seleccione un socio...", "-1"));


        }

        private void BindGrid()
        {
            dgvAlquiler.DataSource = listadoEjemplares;
            dgvAlquiler.DataBind();
        }

        protected void Gv_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            dgvAlquiler.PageIndex = e.NewPageIndex;
            BindGrid();

        }
        protected void btBuscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddSocio.SelectedValue.ToString());
            if (ddSocio.SelectedIndex == 0)
                listadoEjemplares = DEjempAlquileres.GetListadoAlquilados();
            else
                listadoEjemplares = DEjempAlquileres.FilterByIdSocio(id);
                
            
            BindGrid();
        }


        protected void lnkDevolver_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Devolver")
            {
                string[] args = e.CommandArgument.ToString().Split(',');
                if (args.Length == 2)
                {
                    int id = int.Parse(args[0]);
                    DevolverEjemplar(id);
                }
            }
        }

        private void DevolverEjemplar(int ejemplarId)
        {

        }

        protected void btRegresar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}