<%@ Page Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="EjemplarAbm.aspx.cs" Inherits="Biblioteca_WebForms.Pagina.EjemplarAbm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <section id="ABM-libro">
        <%-- Mensaje --%>
        <div>
            <asp:Label runat="server" for="mensaje" Style="color: red" ID="lbMensaje">mensaje:</asp:Label>
        </div>
        <div class="row mt-4">
            <!-- Campo Código de Barras -->
            <div class="col-3">
                <asp:Label runat="server" for="codBarras">Código de Barras:</asp:Label>
                <asp:TextBox CssClass="form-control mt-2" runat="server" ID="txtCodBarras" name="codBarras" placeholder="Ingrese el Código de Barras"></asp:TextBox>
            </div>
            <!-- Campo Año de Publicación -->
            <div class="col-3">
                <asp:Label runat="server" AssociatedControlID="txtAnioPublicacion" Text="Año de Publicación:" CssClass="form-label"></asp:Label>
                <div class="input-group">
                    <button class="btn btn-outline-secondary" type="button" onclick="adjustValue('txtAnioPublicacion', -1)">-</button>
                    <asp:TextBox runat="server" ID="txtAnioPublicacion" CssClass="form-control text-center"  />
                    <button class="btn btn-outline-secondary" type="button" onclick="adjustValue('txtAnioPublicacion', 1)">+</button>
                </div>
            </div>
            <!-- Campo Número de Páginas -->
            <div class="col-3">
                <asp:Label runat="server" AssociatedControlID="txtNumPaginas" Text="Número de Páginas:" CssClass="form-label"></asp:Label>
                <div class="input-group">
                    <button class="btn btn-outline-secondary" type="button" onclick="adjustValue('txtNumPaginas', -1)">-</button>
                    <asp:TextBox runat="server" ID="txtNumPaginas" CssClass="form-control text-center" Text="1" />
                    <button class="btn btn-outline-secondary" type="button" onclick="adjustValue('txtNumPaginas', 1)">+</button>
                </div>
            </div>
        </div>
        <div class="row mt-4">
            <!-- Dropdown para Editorial -->
            <%--<div class="campo-form col-md-1 m-4">--%>
            <div class="col-3">
                <asp:Label runat="server" for="editorial">Editorial:</asp:Label>
                <asp:DropDownList runat="server" ID="ddlEditorial" CssClass="form-control">
                    <asp:ListItem Text="Seleccione una Editorial" Value="" />
                </asp:DropDownList>
            </div>
            <!-- Dropdown para Idioma -->
            <div class="col-3">
                <asp:Label runat="server" for="idioma">Idioma:</asp:Label>
                <asp:DropDownList runat="server" ID="ddlIdioma" CssClass="form-control">
                    <asp:ListItem Text="Seleccione un Idioma" Value="" />
                </asp:DropDownList>
            </div>
            <!-- Campo para Ubicación -->
            <div class="col-3">
                <asp:Label runat="server" for="ubicacion">Ubicación (Estantería, Fila, Columna):</asp:Label>
                <asp:TextBox runat="server" ID="txtUbicacion" name="ubicacion" class="form-control" placeholder="Ej: E:5 F:3 C:2"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-4">
            <!-- Dropdown para Estado -->
            <div class="col-3">
                <asp:Label runat="server" for="ddEstado">Estado del Ejemplar:</asp:Label>
                <asp:DropDownList runat="server" ID="ddEstado" CssClass="form-control">
                    <asp:ListItem Text="Seleccione..." Value="" />
                    <asp:ListItem Text="Bueno" Value="1" />
                    <asp:ListItem Text="Malo" Value="0" />
                </asp:DropDownList>
            </div>
            <!-- Dropdown para Activo -->
            <div class="col-3">
                <asp:Label runat="server" for="ddActivo">¿Está Activo?</asp:Label>
                <asp:DropDownList runat="server" ID="ddActivo" CssClass="form-control">
                    <asp:ListItem Text="Seleccione..." Value="" />
                    <asp:ListItem Text="Si" Value="1" />
                    <asp:ListItem Text="No" Value="0" />
                </asp:DropDownList>
            </div>
        </div>
        <!-- Botones -->
        <div class="row botones-form mt-4">
            <div class="col-1">
                <asp:Button ID="btnGrabar" runat="server" type="submit" class="btn-grabar" Text="Grabar" OnClick="btnGrabar_Click" />
            </div>
            <div class="col-1">
                <asp:Button ID="btnRetornar" runat="server" type="submit" class="btn-retornar" Text="Retornar" OnClick="btnRetornar_Click" />
            </div>
        </div>
    </section>
    <!--Script botones incremento/decremento -->
    <script>
        function adjustValue(fieldId, delta) {
            const input = document.querySelector(`[id$="${fieldId}"]`);//**Nota
            if (input) {
                const currentValue = parseInt(input.value) || 0;
                const newValue = currentValue + delta;
                if (newValue >= 0) { // Evitar valores negativos
                    input.value = newValue;
                }
            }
        }
        //Nota: El problema parece ser que los controles de servidor de ASP.NET (<asp:TextBox>) 
        //no generan directamente un atributo id en el HTML resultante si están dentro de un 
        //contenedor(como un formulario maestro, una vista parcial, etc.).En su lugar, el id generado se basa en un prefijo,
        //lo que puede dificultar que tu función JavaScript encuentre el campo correctamente.
    </script>
</asp:Content>
