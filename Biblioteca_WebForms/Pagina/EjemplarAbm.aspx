<%@ Page Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="EjemplarAbm.aspx.cs" Inherits="Biblioteca_WebForms.Pagina.EjemplarAbm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <section id="ABM-libro">
        <div>
            <asp:Label runat="server" for="mensaje" Style="color: red" ID="lbMensaje">mensaje:</asp:Label>
        </div>
        <!-- Campo Código de Barras -->
        <div class="campo-form col-md-5 mb-4">
            <br />
            <asp:Label runat="server" for="codBarras">Código de Barras:</asp:Label>
            <asp:TextBox runat="server" ID="txtCodBarras" name="codBarras" class="form-control" placeholder="Ingrese el Código de Barras"></asp:TextBox>
        </div>

        <!-- Campo Año de Publicación -->
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="anioPublicacion">Año de Publicación:</asp:Label>
            <asp:TextBox runat="server" ID="txtAnioPublicacion" name="anioPublicacion" class="form-control" placeholder="Ingrese el Año de Publicación"></asp:TextBox>
        </div>

        <!-- Campo Número de Páginas -->
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="numPaginas">Número de Páginas:</asp:Label>
            <asp:TextBox runat="server" ID="txtNumPaginas" name="numPaginas" class="form-control" placeholder="Ingrese el Número de Páginas"></asp:TextBox>
        </div>

        <!-- Dropdown para Editorial -->
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="editorial">Editorial:</asp:Label>
            <asp:DropDownList runat="server" ID="ddlEditorial" CssClass="form-control">
                <asp:ListItem Text="Seleccione una Editorial" Value="" />
                <%-- Las opciones se llenarán dinámicamente en el código detrás --%>
            </asp:DropDownList>
        </div>

        <!-- Dropdown para Idioma -->
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="idioma">Idioma:</asp:Label>
            <asp:DropDownList runat="server" ID="ddlIdioma" CssClass="form-control">
                <asp:ListItem Text="Seleccione un Idioma" Value="" />
                <%-- Las opciones se llenarán dinámicamente en el código detrás --%>
            </asp:DropDownList>
        </div>

        <!-- Campo Ubicación -->
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="ubicacion">Ubicación (Estantería, Fila, Columna):</asp:Label>
            <asp:TextBox runat="server" ID="txtUbicacion" name="ubicacion" class="form-control" placeholder="Ej: E:5 F:3 C:2"></asp:TextBox>
        </div>

        <!-- Checkbox Estado -->
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="estado">Estado del Ejemplar:</asp:Label>
            <asp:CheckBox runat="server" ID="chkEstado" Text="¿Está en buen estado?" CssClass="form-check-input" />
        </div>

        <!-- Checkbox Activo -->
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="activo">¿Está Activo?</asp:Label>
            <asp:CheckBox runat="server" ID="chkActivo" Text="Activo" CssClass="form-check-input" />
        </div>

        <!-- Botones -->
        <div class="botones-form mb-4">
            <asp:Button ID="btnGrabar" runat="server" type="submit" class="btn-grabar" Text="Grabar" OnClick="btnGrabar_Click" />
            <asp:Button ID="btnRetornar" runat="server" type="submit" class="btn-retornar" Text="Retornar" OnClick="btnRetornar_Click" />
        </div>
    </section>
</asp:Content>
