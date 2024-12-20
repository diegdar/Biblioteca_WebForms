<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="ListadoEjemplares.aspx.cs" Inherits="Biblioteca.Pagina.ListadoEjemplares" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="mt-3">
                 <asp:TextBox ID="txtBuscar" runat="server" placeholder="Introduce el título, autor o ISBN..." Cssclass="busqueda-input"></asp:TextBox>
                <asp:Button ID="btBuscar" runat="server" Text="Buscar" CssClass="busqueda-btn" OnClick="btBuscar_Click" />
            </div>
            <br />
            <div>
                <asp:Label ID="txtmensaje" runat="server" Text="" Style="color: red"></asp:Label>
            </div>
            <div class="botones-form mb-4 mt-2">
                <!-- Botón Crear -->
                <asp:Button type="submit" ID="BtnCrear" runat="server" class="btn btn-primary" Text="Crear" OnClick="BtnCrear_Click" />
            </div>

            <!-- GridView con enlaces para Editar y Borrar -->
            <asp:GridView ID="dgvEjemplar" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" 
                CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="IdEjemplar" HeaderText="Id" />
                    <asp:BoundField DataField="Obra.Titulo" HeaderText="Titulo" />
                    <asp:BoundField DataField="Obra.Autor.Apellido1" HeaderText="Autor" />
                    <asp:BoundField DataField="Editorial.Descripcion" HeaderText="Editorial" />
                    <asp:BoundField DataField="CodigoBarras" HeaderText="Cod.Barras" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="AnioPublicacion" HeaderText="Año Publicacion" />
                    <%--<asp:BoundField DataField="EstaBuenEstado" HeaderText="Estado titulo" />--%>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <%# Eval("EstaBuenEstado") != null && (bool)Eval("EstaBuenEstado") 
                                    ? "Bueno" : "Malo" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NumPaginas" HeaderText="NºPag." />
                    <asp:TemplateField HeaderText="Alquilado?">
                        <ItemTemplate>
                            <%# Eval("EstaAlquilado") != null && (bool)Eval("EstaAlquilado") 
                                    ? "Si" : "No" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ubicación">
                        <ItemTemplate>
                            <%# "E:" + Eval("Ubicacion.Estanteria") + " F:" + Eval("Ubicacion.Fila") + " C:" + Eval("Ubicacion.Columna") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Idioma.Descripcion" HeaderText="Idioma" />
                    <asp:TemplateField HeaderText="Activo?">
                        <ItemTemplate>
                            <%# Eval("EstaActivo") != null && (bool)Eval("EstaActivo") ? "Si" : "No" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("IdEjemplar") + ",U" %>' OnCommand="lnkEditar_Command" Enabled="true"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBorrar" runat="server" Text="Borrar" CommandName="Borrar" CommandArgument='<%# Eval("IdEjemplar") + ",D" %>' OnCommand="lnkBorrar_Command" Enabled="true" OnClientClick='<%# "return confirm(\"¿Estás seguro de que deseas borrar el registro # " + Eval("IdEjemplar") + "?\");" %>' />
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
            <div class="botones-form mb-4 mt-2">
                <asp:Button type="submit" ID="regresar" runat="server" class="btn btn-secondary" Text="Regresar" OnClick="regresar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
