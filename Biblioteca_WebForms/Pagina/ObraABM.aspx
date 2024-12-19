<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="ObraABM.aspx.cs" Inherits="Biblioteca_WebForms.Pagina.ObraABM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <br/>
    <section id="ABM-libro">
        <div>
            <asp:Label runat="server" for="mensaje" Style="color: red" ID="lbMensaje">mensaje:</asp:Label>
        </div>
        <div class="campo-form col-md-5 mb-4">
            <br />
            <asp:Label runat="server" for="tituloLibro">Título del Libro:</asp:Label>
            <asp:TextBox runat="server" ID="txtTitulo" name="titulo" class="form-control" placeholder="Ingrese el título de la Obra"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvTitulo" ControlToValidate="txtTitulo" ErrorMessage="El título es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="sinopsis">Sinopsis:</asp:Label>
            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtSinopsis" name="sinopsis" class="form-control" placeholder="Ingrese la sinopsis" Rows="5"></asp:TextBox>
        </div>
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="autor">Autor:</asp:Label>
            <asp:DropDownList ID="ddAutor" runat="server" name="autor" Style="width: 250px" class="form-control"></asp:DropDownList>
        </div>
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="genero">Genero:</asp:Label>
            <asp:DropDownList ID="ddGenero" runat="server" name="genero" Style="width: 250px" class="form-control"></asp:DropDownList>
        </div>
        <div class="botones-form mb-4">
            <asp:Button ID="grabar" runat="server" type="submit" class="btn-grabar" Text="Grabar" OnClick="grabar_Click" Visible="false" />
            <asp:Button ID="actualizar" runat="server" type="submit" class="btn-grabar" Text="Actualizar" OnClick="actualizar_Click" Visible="false" />
            <asp:Button ID="retornar" runat="server" type="submit" class="btn-retornar" Text="Retornar" OnClick="retornar_Click" Visible="true" CausesValidation="False" />
            <%--<asp:button runat="server" type="button" class="btn-retornar" onclick="window.history.back();">Retornar</asp:button>--%>
        </div>
    </section>

</asp:Content>
