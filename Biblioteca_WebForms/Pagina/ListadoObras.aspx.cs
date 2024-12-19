using Biblioteca_WebForms;
using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.Pagina
{
    public partial class ListaObras : System.Web.UI.Page
    {
        private DALObra obra = new DALObra();
        CommonMethods comMethods = new CommonMethods();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Listar Obras";
                BindGrid();
            }
        }

        private void BindGrid()
        {

            dgvObra.DataSource = obra.GetList();
            dgvObra.DataBind();
        }

        // Evento del botón "Crear"
        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            string opcion = "C";
            string id = "-1";
            Response.Redirect($"ObraABM.aspx?id={id}&opcion={opcion}");
        }

        // Evento para paginación
        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            dgvObra.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        // Evento para manejar acciones de editar/borrar
        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            //int id = Convert.ToInt32(e.CommandArgument);

            //if (e.CommandName == "Editar")
            //{
            //    // Lógica para editar
            //    Response.Write($"Editar: {id}");
            //}
            //else if (e.CommandName == "Borrar")
            //{
            //    // Lógica para borrar
            //    //items.RemoveAll(i => i.Id == id);
            //    //DeleteEjemplar(id);

            //    BindGrid();
            //}
        }
        
        private void Delete(int idObra)
        {
            if (!obra.VerifyExist(idObra))
            {
                obra.Delete(idObra);

                BindGrid();
                lbMensaje.Text = $"La obra con id {idObra}" +
                                 $" ha sido eliminada!";
            }
            else
            {
                lbMensaje.Text = $"No se puede eliminar la obra {idObra}" +
                    $" esta actualmente alquilada!";
            }
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            dgvObra.DataSource = obra.FilterObra(txtBuscar.Text);
            dgvObra.DataBind();
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
                    Response.Redirect($"ObraAbm.aspx?id={id}&opcion={opcion}");
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
    }

}
