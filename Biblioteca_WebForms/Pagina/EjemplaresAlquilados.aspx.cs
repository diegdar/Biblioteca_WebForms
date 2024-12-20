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
        protected DALEjemplar DEjemplar;
        //protected List<Ejemplar> listadoEjemplares;

        public EjemplaresAlquilados()
        {
            DSocio = new DALSocio();
            DEjemplar = new DALEjemplar();
            //listadoEjemplares = new List<Ejemplar>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Ejemplares Alquilados";
            }
            BindGrid();
            CargarSocio();
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
        }

        private void BindGrid()
        {
            dgvAlquiler.DataSource = DEjemplar.GetList();
            dgvAlquiler.DataBind();
        }



        protected void Gv_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            dgvAlquiler.PageIndex = e.NewPageIndex;
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



        protected void lnkDevolver_Command(object sender, EventArgs e)
        {

        }
        protected void btGrabar_Click(object sender, EventArgs e)
        {

        }
        protected void btRegresar_Click(object sender, EventArgs e)
        {

        }
    }
}