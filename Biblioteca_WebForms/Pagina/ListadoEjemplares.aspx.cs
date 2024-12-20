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
    public partial class ListadoEjemplares : System.Web.UI.Page
    {
        private CommonMethods comMethods;
        private DALEjemplar dALEjemplar;
        
        public ListadoEjemplares()
        {
            comMethods = new CommonMethods();
            dALEjemplar = new DALEjemplar();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Listado de los Ejemplares";
                BindGrid();
            }
        }
        private void BindGrid()
        {
            //var listEjemps = GetEjempListForView();
            dgvEjemplar.DataSource = dALEjemplar.GetList();
            dgvEjemplar.DataBind();
        }

        // Evento del botón "Crear"
        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            string opcion = "C";
            string id = "-1";
            Response.Redirect($"EjemplarAbm.aspx?id={id}&opcion={opcion}");
            BindGrid();
        }

        // Evento para paginación
        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            dgvEjemplar.PageIndex = e.NewPageIndex;
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

        protected void lnkEditar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string[] args = e.CommandArgument.ToString().Split(',');


                if (args.Length == 2)
                {
                    string id = args[0];
                    string opcion = args[1];
                    Response.Redirect($"EjemplarAbm.aspx?id={id}&opcion={opcion}");
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
                    DeleteEjemplar(id);
                }
            }
        }

        private void DeleteEjemplar(int ejemplarId)
        {
            if (!comMethods.IsEjemplarRented(ejemplarId))
            {
                dALEjemplar.Delete(ejemplarId);
                BindGrid();
                txtmensaje.Text = $"El libro con id {ejemplarId}" +
                    $" ha sido eliminado!";

            }
            else
            {
                txtmensaje.Text = $"No se puede eliminar el libro {ejemplarId}" +
                    $" pues esta actualmente alquilado!";
            }
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Encuentra el LinkButton con ID "lnkEditar"
                LinkButton lnkEditar = (LinkButton)e.Row.FindControl("lnkEditar");
                LinkButton lnkBorrar = (LinkButton)e.Row.FindControl("lnkBorrar");

                //if (Session["bibliotecarioAct"] == null || Session["bibliotecarioAct"].ToString() == "")
                //{ 
                //    // Deshabilita las opciones LinkButton
                //    lnkEditar.Visible = false;
                //    lnkBorrar.Visible = false;
                //    BtnCrear.Visible = false;
                //}
            }
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            dgvEjemplar.DataSource = dALEjemplar.GetFilter(txtBuscar.Text);
            dgvEjemplar.DataBind();
        }
    }
}
