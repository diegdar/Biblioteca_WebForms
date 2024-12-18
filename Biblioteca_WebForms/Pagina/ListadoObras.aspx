<<<<<<<< HEAD:Biblioteca_WebForms/Pagina/ListadoObras.aspx
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="ListadoObras.aspx.cs" Inherits="Biblioteca.Pagina.WebForm1" %>
========
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="ListadoTitulos.aspx.cs" Inherits="Biblioteca.Pagina.WebForm1" %>

>>>>>>>> f04daebe30a48d738bef3be3436fc4cf1c9102db:Biblioteca_WebForms/Pagina/ListadoTitulos.aspx
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <div class="row">
            <br />
             <div class="">
                 <asp:TextBox ID="txtBuscar" runat="server" placeholder="Introduce el título o autor a buscar..." class="busqueda-input" ></asp:TextBox>
                 <asp:Button ID="btBuscar" runat="server" Text="Buscar" CssClass="busqueda-btn" onclick="btBuscar_Click"/>
             </div>
            <br />
<<<<<<<< HEAD:Biblioteca_WebForms/Pagina/ListadoObras.aspx
            <div class="botones-form mb-4 mt-4">
========
            <asp:Label ID="txtmensaje" runat="server" Text="" Style="color: red"></asp:Label>
            <div class="botones-form mb-4 mt-2">
>>>>>>>> f04daebe30a48d738bef3be3436fc4cf1c9102db:Biblioteca_WebForms/Pagina/ListadoTitulos.aspx
                <!-- Botón Crear -->
                <asp:Button type="submit" ID="BtnCrear" runat="server" class="btn btn-primary" Text="Crear" OnClick="BtnCrear_Click" />
            </div>

            <!-- GridView con enlaces para Editar y Borrar -->
            <asp:GridView ID="dvObras" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
<<<<<<<< HEAD:Biblioteca_WebForms/Pagina/ListadoObras.aspx
                    <asp:BoundField DataField="IdObra" HeaderText="Id" />
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                    <asp:BoundField DataField="Apellido1" HeaderText="Autor" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Género" />
                    <asp:TemplateField>
========
                    <asp:BoundField DataField="IdEjemplar" HeaderText="Id" />
                    <asp:BoundField DataField="CodigoBarras" HeaderText="Cod. Barras" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="AnioPublicacion" HeaderText="Año publicacion" />
                    <%--<asp:BoundField DataField="EstaBuenEstado" HeaderText="Estado titulo" />--%>
                    <asp:TemplateField HeaderText="Estado titulo">
>>>>>>>> f04daebe30a48d738bef3be3436fc4cf1c9102db:Biblioteca_WebForms/Pagina/ListadoTitulos.aspx
                        <ItemTemplate>
                            <%# Eval("EstaBuenEstado") != null && (bool)Eval("EstaBuenEstado") ? "Bueno" : "Malo" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NumPaginas" HeaderText="Num. Paginas" />
                    <asp:TemplateField HeaderText="Esta alquilado?">
                        <ItemTemplate>
                            <%# Eval("EstaAlquilado") != null && (bool)Eval("EstaAlquilado") ? "Si" : "No" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Editorial.Descripcion" HeaderText="Editorial" />
                    <asp:BoundField DataField="Obra.Titulo" HeaderText="Titulo" />
                    <asp:TemplateField HeaderText="Ubicacion">
                        <ItemTemplate>
                            <%# "E:" + Eval("Ubicacion.Estanteria") + " F:" + Eval("Ubicacion.Fila") + " C:" + Eval("Ubicacion.Columna") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Idioma.Descripcion" HeaderText="Idioma" />
                    <asp:TemplateField HeaderText="Esta Activo?">
                        <ItemTemplate>
                            <%# Eval("EstaActivo") != null && (bool)Eval("EstaActivo") ? "Si" : "No" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("Id") + ",U" %>' OnCommand="lnkEditar_Command"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBorrar" runat="server" Text="Borrar" CommandName="Borrar" CommandArgument='<%# Eval("Id") + ",D" %>' OnCommand="lnkBorrar_Command"></asp:LinkButton>
                            <%--OnClientClick="return confirm('¿Estás seguro de que deseas borrar este elemento?');"></asp:LinkButton>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <%--<RowStyle BackColor="#FFFBD6" ForeColor="#333333" />--%>
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="False" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <div class="botones-form mb-4 mt-4">
                <asp:Button type="submit" ID="regresar" runat="server" class="btn btn-secondary" Text="Regresar" OnClick="regresar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
