<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="ListadoGenero.aspx.cs" Inherits="Biblioteca_WebForms.Pagina.ListadoGenero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <div class="row">
            <br />
            <br />
            <asp:Label ID="txtmensaje" runat="server" Text="" Style="color: red"></asp:Label>
            <div class="botones-form mb-4 mt-2">
                <!-- Botón Crear -->
                <asp:Button type="submit" ID="BtnCrear" runat="server" class="btn btn-primary" Text="Crear" OnClick="BtnCrear_Click" />
            </div>

            <!-- GridView con enlaces para Editar y Borrar -->
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="IdGenero" HeaderText="Id" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("IdGenero") + ",U" %>' OnCommand="lnkEditar_Command"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBorrar" runat="server" Text="Borrar" CommandName="Borrar" CommandArgument='<%# Eval("IdGenero") + ",D" %>' OnCommand="lnkBorrar_Command" OnClientClick='<%# "return confirm(\"¿Estás seguro de que deseas borrar el registro # " + Eval("IdGenero") + "?\");" %>' />
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
