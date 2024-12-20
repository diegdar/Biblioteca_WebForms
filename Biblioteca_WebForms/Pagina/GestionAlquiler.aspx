<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="GestionAlquiler.aspx.cs" Inherits="Biblioteca_WebForms.Pagina.GestionAlquiler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
<br />
<br />
<div class="container">
    <div class="row">

         <div class="campo-form col-md-5 mb-4">
             <asp:label runat="server" for="socio">Socio:</asp:label>
             <asp:DropDownList ID="ddSocio" runat="server" name="socio" style="Width:250px" class="form-control"></asp:DropDownList>
         </div>
         <div class="mt-3 mb-4">
             <asp:TextBox ID="txtBuscarEjemplar" runat="server" placeholder="Introduce codigo del Ejemplar..." Cssclass="busqueda-input"></asp:TextBox>
             <asp:Button ID="btBuscar" runat="server" Text="Buscar" CssClass="busqueda-btn" OnClick="btBuscar_Click" />
         </div>
        <div>
            <asp:Label ID="lbMensaje" runat="server" Style="color: red"></asp:Label>
        </div>
        <br />
        <!-- GridView con enlaces para Editar y Borrar -->
        <asp:GridView ID="dgvAlquiler" runat="server" AutoGenerateColumns="False" 
            AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="80%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                 <asp:BoundField DataField="IdEjemplar" HeaderText="Id" />
                 <asp:BoundField DataField="Obra.Titulo" HeaderText="Titulo" />
                 <asp:BoundField DataField="Obra.Autor.Apellido1" HeaderText="Autor" />
                 <asp:BoundField DataField="Editorial.Descripcion" HeaderText="Editorial" />
                 <asp:BoundField DataField="CodigoBarras" HeaderText="Cod.Barras" />
                 <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                 <asp:BoundField DataField="AnioPublicacion" HeaderText="Año Publicacion" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBorrar" runat="server" Text="Borrar" CommandName="Borrar" CommandArgument='<%# Eval("IdEjemplar") + ",U" %>' OnCommand="lnkBorrar_Command"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="False" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <br />
        <br />
         <div class="botones-form mb-4 mt-3">
             <asp:Button ID="Button1" runat="server" Text="Grabar" class="btn-grabar" CommandArgument='<%# Eval("IdEjemplar") + ",U" %>' 
                OnClientClick="return confirm('¿Está seguro de que desea grabar?');" 
                OnClick="btGrabar_Click" />
             <asp:Button type="submit" ID="btRegresar" runat="server" class="btn-retornar" Text="Regresar" OnClick="btRegresar_Click" />
        </div>
    </div>
</div>
</asp:Content>
