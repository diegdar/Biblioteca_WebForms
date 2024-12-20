﻿using Biblioteca_WebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca_WebForms.Pagina
{
    public partial class ListadoGenero : System.Web.UI.Page
    {
        private CommonMethods comMethods;
        private DALGenero DALGenero;

        public ListadoGenero()
        {
            comMethods = new CommonMethods();
            DALGenero = new DALGenero();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ms masterPage = (Ms)this.Master;
                masterPage.Titulo = "Explorar todos los Géneros";
                BindGrid();
            }
        }
        private void BindGrid()
        {
            //var listEjemps = GetEjempListForView();
            GridView1.DataSource = DALGenero.GetList();
            GridView1.DataBind();
        }

        // Evento del botón "Crear"
        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            string opcion = "C";
            string id = "-1";
            Response.Redirect($"EditGenero.aspx?id={id}&opcion={opcion}");
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
                    Response.Redirect($"EditGenero.aspx?id={id}&opcion={opcion}");
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
        private void DeleteEjemplar(int generoId)
        {
            if (!comMethods.IsGeneroInBook(generoId))
            {
                DALGenero.Delete(generoId);
                BindGrid();
                txtmensaje.Text = $"El género con id {generoId}" +
                    $" ha sido eliminado!";
            }
            else
            {
                txtmensaje.Text = $"No se puede eliminar el genero {generoId}" +
                    $" pues esta actualmente alquilado!";
            }
        }
        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}