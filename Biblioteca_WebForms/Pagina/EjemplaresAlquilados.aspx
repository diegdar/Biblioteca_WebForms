<%@ Page Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="EjemplaresAlquilados.aspx.cs" Inherits="Biblioteca_WebForms.Pagina.EjemplaresAlquilados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
<br />
<br />
<div class="container">
    <div class="row">

        <div>
            <asp:Label ID="lbMensaje" runat="server" Style="color: red"></asp:Label>
        </div>
         <div class="campo-form col-md-5 mb-4">
             <asp:label runat="server" for="socio">Socio:</asp:label>
             <asp:DropDownList ID="ddSocio" runat="server" name="socio" style="Width:250px" class="form-control"></asp:DropDownList>
         </div>
        <br />
        <!-- GridView con enlaces para Editar y Borrar -->
            <asp:GridView ID="dgvAlquiler" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" PageSize="5" OnPageIndexChanging="Gv_PageIndexChanging" 
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="IdEjemplar" HeaderText="Id" />
                    <asp:BoundField DataField="Obra.Titulo" HeaderText="Titulo" />
                    <asp:BoundField DataField="CodigoBarras" HeaderText="Cod. Barras" />
                    <asp:BoundField DataField="AlquilerEjemplars.Id" HeaderText="Nom. Socio" />
<%--                    <asp:BoundField DataField="Socio.Apellido" HeaderText="Ape. Socio" />
                    <asp:BoundField DataField="Alquiler.FechaDevProbable" HeaderText="Fecha Prev. Dev." />--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDevolver" runat="server" Text="Devolver" CommandName="Devolver" CommandArgument='<%# Eval("IdEjemplar") + ",U" %>' OnCommand="lnkDevolver_Command" Enabled="true"></asp:LinkButton>
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
         <div class="botones-form mb-4">
             <asp:Button id="btGrabar" runat="server" type="submit" class="btn-grabar" Text="Grabar" onclick="btGrabar_Click" Visible="true"/>
             <asp:Button type="submit" ID="btRegresar" runat="server" class="btn-retornar" Text="Regresar" OnClick="btRegresar_Click" />
        </div>
    </div>
</div>
</asp:Content>
