<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="ListadoBibliotecarios.aspx.cs" Inherits="Biblioteca_WebForms.Pagina.ListadoBibliotecarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
<br />
<div class="container">
    <div class="row">
         <div class="mt-3">
             <asp:TextBox ID="txtBuscar" runat="server" placeholder="Introduce nombre usuario..." Cssclass="busqueda-input"></asp:TextBox>
             <asp:Button ID="btBuscar" runat="server" Text="Buscar" CssClass="busqueda-btn" OnClick="btBuscar_Click" />
         </div>
        <div class="botones-form mb-4 mt-4">
            <div class="botones-form">
                <!-- Botón Crear -->
                <asp:Button type="submit" ID="BtnCrear" runat="server" class="btn btn-primary" Text="Crear" OnClick="BtnCrear_Click" />
            </div>
        </div>
        <div>
            <asp:Label ID="lbMensaje" runat="server" Style="color: red"></asp:Label>
        </div>
        <br />
        <!-- GridView con enlaces para Editar y Borrar -->
        <asp:GridView ID="dgvBibliotecario" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
            AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <%--<asp:BoundField DataField="IdObra" HeaderText="Id" />--%>
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("IdBibliotecario") + ",U" %>' OnCommand="lnkEditar_Command"></asp:LinkButton>
                        <asp:LinkButton ID="lnkBorrar" runat="server" Text="Borrar" CommandName="Borrar" CommandArgument='<%# Eval("IdBibliotecario") + ",D" %>' OnCommand="lnkBorrar_Command" OnClientClick='<%# "return confirm(\"¿Estás seguro de que deseas borrar el registro # " + Eval("IdBibliotecario") + "?\");" %>'></asp:LinkButton>
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
        <br />
        <div class="botones-form mb-4 mt-4">
            <asp:Button type="submit" ID="btRegresar" runat="server" class="btn btn-secondary" Text="Regresar" OnClick="regresar_Click" />
        </div>
    </div>
</div>
</asp:Content>
