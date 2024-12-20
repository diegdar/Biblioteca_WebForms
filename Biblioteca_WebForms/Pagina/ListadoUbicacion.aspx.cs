﻿using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.Pagina
{
    public partial class ListadoUbicacion : System.Web.UI.Page
    {
        private CommonMethods comMethods;
        private DALUbicacion dALUbicacion;

        public ListadoUbicacion()
        {
            comMethods = new CommonMethods();
            dALUbicacion = new DALUbicacion();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Explorar todas las Ubicaciones";
                BindGrid();
            }
        }
        private void BindGrid()
        {
            //var listEjemps = GetEjempListForView();
            GridView1.DataSource = dALUbicacion.GetList();
            GridView1.DataBind();
        }
        // Evento del botón "Crear"
        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            string opcion = "C";
            string id = "-1";
            Response.Redirect($"EditUbicacion.aspx?id={id}&opcion={opcion}");
            BindGrid();
        }
        // Evento para paginación
        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
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
            //    //DeleteUbicacion(id);

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
                    Response.Redirect($"EditUbicacion.aspx?id={id}&opcion={opcion}");
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
                    DeleteUbicacion(id);
                }
            }
        }
        private void DeleteUbicacion(int ubicacionId)
        {
            if (!comMethods.IsUbicacionInEjemplar(ubicacionId))
            {
                dALUbicacion.Delete(ubicacionId);
                BindGrid();
                txtmensaje.Text = $"La ubicación con id {ubicacionId}" +
                    $" ha sido eliminada!";

            }
            else
            {
                txtmensaje.Text = $"No se puede eliminar la ubicación {ubicacionId}" +
                    $" pues está actualmente vinculada a un ejemplar!";
            }
        }
        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}