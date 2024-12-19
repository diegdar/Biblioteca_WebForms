using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.Pagina
{
    public partial class ListadoBibliotecarios : System.Web.UI.Page
    {
        private DALBibliotecario biblio = new DALBibliotecario();
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
            dgvBibliotecario.DataSource = biblio.GetList();
            dgvBibliotecario.DataBind();
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            string opcion = "C";
            string id = "-1";
            Response.Redirect($"BibliotecarioABM.aspx?id={id}&opcion={opcion}");
            BindGrid();
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            dgvBibliotecario.DataSource = biblio.GetFilter(txtBuscar.Text);
            dgvBibliotecario.DataBind();
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
                    Response.Redirect($"BibliotecarioABM.aspx?id={id}&opcion={opcion}");
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
            if (!biblio.VerifyExist(idBiblio))
            {
                biblio.Delete(idBiblio);

                BindGrid();
                lbMensaje.Text = $"El bibliotecario con id {idBiblio}" +
                                 $" ha sido eliminada!";
            }
            else
            {
                lbMensaje.Text = $"No se puede eliminar el bibliotecario {idBiblio}" +
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
            dgvBibliotecario.PageIndex = e.NewPageIndex;
            BindGrid();
        }

    }
}