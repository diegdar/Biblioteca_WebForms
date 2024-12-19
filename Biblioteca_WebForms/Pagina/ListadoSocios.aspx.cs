using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.Pagina
{
    public partial class ListadoSocios : System.Web.UI.Page
    {
        private DALSocio socio = new DALSocio();
        CommonMethods comMethods = new CommonMethods();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Listar Bibliotecarios";
                BindGrid();
            }
        }

        private void BindGrid()
        {
            dgvSocio.DataSource = socio.GetList();
            dgvSocio.DataBind();
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            string opcion = "C";
            string id = "-1";
            Response.Redirect($"SocioABM.aspx?id={id}&opcion={opcion}");
            BindGrid();
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            dgvSocio.DataSource = socio.GetFilter(txtBuscar.Text);
            dgvSocio.DataBind();
        }

        protected void lnkEditar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string[] args = e.CommandArgument.ToString().Split(',');


                if (args.Length == 2)
                {
                    string id = args[0];
                    string opcion = args[1];
                    Response.Redirect($"SocioABM.aspx?id={id}&opcion={opcion}");
                }
            }
        }

        protected void lnkBorrar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                string[] args = e.CommandArgument.ToString().Split(',');
                if (args.Length == 2)
                {
                    int id = int.Parse(args[0]);
                    Delete(id);
                }
            }

        }

        private void Delete(int idBiblio)
        {
            if (!socio.VerifyExist(idBiblio))
            {
                socio.Delete(idBiblio);

                BindGrid();
                lbMensaje.Text = $"El socio con id {idBiblio}" +
                                 $" ha sido eliminada!";
            }
            else
            {
                lbMensaje.Text = $"No se puede eliminar el socio {idBiblio}" +
                    $" porque hizo operaciones de alquile!";
            }
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSocio.PageIndex = e.NewPageIndex;
            BindGrid();
        }

    }
}