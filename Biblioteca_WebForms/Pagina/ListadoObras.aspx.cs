using Biblioteca_WebForms;
using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca.Pagina
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //private static List<v_Obras> items = new List<v_Obras>();
        DALObra obra = new DALObra();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Listar las Obras Literarias";
                BindGrid();
            }
        }

        private void BindGrid()
        {
            dvObras.DataSource = obra.GetList();
            dvObras.DataBind();
        }

        // Evento del botón "Crear"
        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            string opcion = "C";
            string id = "-1";
            Response.Redirect($"ObraAbm.aspx?id={id}&opcion={opcion}");
            BindGrid();
        }

        // Evento para paginación
        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            dvObras.PageIndex = e.NewPageIndex;
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
            //    items.RemoveAll(i => i.Id == id);
            //    BindGrid();
            //}
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
                    string id = args[0];
                    string opcion = args[1];
                    Response.Redirect($"ObraAbm.aspx?id={id}&opcion={opcion}");
                }
            }
        }
        
        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            dvObras.DataSource = obra.ObrasFiltrar(txtBuscar.Text);
            dvObras.DataBind();
        }
    }
}
