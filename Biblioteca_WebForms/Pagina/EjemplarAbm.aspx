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
    <%-- Fila 1: --%>
        <div class="row mt-4">
            <!-- Campo Código de Barras -->
            <div class="col-3">
                <asp:Label runat="server" for="txtCodBarras">Código de Barras:</asp:Label>
                <asp:TextBox CssClass="form-control mt-2" runat="server" ID="txtCodBarras" placeholder="Ingrese el Código de Barras"></asp:TextBox>
            </div>
            <!-- Campo ISBN -->
            <div class="col-3">
                <asp:Label runat="server" for="txtIsbn">ISBN:</asp:Label>
                <asp:TextBox CssClass="form-control mt-2" runat="server" ID="txtIsbn" placeholder="Ingrese el ISBN"></asp:TextBox>
            </div>
            <!-- Campo Año de Publicación -->
            <div class="col-3">
                <asp:Label CssClass="form-label" runat="server" AssociatedControlID="txtAnioPublicacion" Text="Año de Publicación:" ></asp:Label>
                <div class="input-group">
                    <button class="btn btn-outline-secondary" type="button" onclick="adjustValue('txtAnioPublicacion', -1)">-</button>
                    <asp:TextBox runat="server" ID="txtAnioPublicacion" CssClass="form-control text-center" />
                    <button class="btn btn-outline-secondary" type="button" onclick="adjustValue('txtAnioPublicacion', 1)">+</button>
                </div>
            </div>
            <!-- Dropdown Estado Ejem-->
            <div class="col-3">
                <asp:Label runat="server" for="ddEstado">Estado del Ejemplar:</asp:Label>
                <asp:DropDownList CssClass="form-control mt-2" runat="server" ID="ddEstado" >
                    <asp:ListItem Text="Seleccione..." Value="" />
                    <asp:ListItem Text="Bueno" Value="1" />
                    <asp:ListItem Text="Malo" Value="0" />
                </asp:DropDownList>
            </div>
        </div>

    <%-- Fila 2 --%>
        <div class="row mt-4">
            <!-- Campo Número de Páginas -->
            <div class="col-3">
                <asp:Label runat="server" AssociatedControlID="txtNumPaginas" Text="Número de Páginas:" CssClass="form-label"></asp:Label>
                <div class="input-group">
                    <button class="btn btn-outline-secondary" type="button" onclick="adjustValue('txtNumPaginas', -1)">-</button>
                    <asp:TextBox runat="server" ID="txtNumPaginas" CssClass="form-control text-center" Text="1" />
                    <button class="btn btn-outline-secondary" type="button" onclick="adjustValue('txtNumPaginas', 1)">+</button>
                </div>
            </div>
            <!-- Dropdown Esta Alquilado? -->
            <div class="col-3">
                <asp:Label runat="server" for="ddAlquilado">¿Está alquilado?</asp:Label>
                <asp:DropDownList CssClass="form-control mt-2" runat="server" ID="ddAlquilado" >
                    <asp:ListItem Text="Seleccione..." Value="" />
                    <asp:ListItem Text="Si" Value="1" />
                    <asp:ListItem Text="No" Value="0" />
                </asp:DropDownList>
            </div>
            <!-- Dropdown para Editorial -->
            <div class="col-3">
                <asp:Label runat="server" for="ddEditorial">Editorial:</asp:Label>
                    <asp:DropDownList CssClass="form-control mt-2" runat="server" ID="ddEditorial">
                    </asp:DropDownList>
            </div>
            <!-- Dropdown para Obra -->
            <div class="col-3">
                <asp:Label runat="server" for="ddObra">Obra:</asp:Label>
                <asp:DropDownList CssClass="form-control mt-2" runat="server" ID="ddObra" >
                </asp:DropDownList>
            </div>

    <%-- Fila 3: --%>
        <div class="row mt-4">
            <!-- Dropdown para Ubicacion -->
            <div class="col-3">
                <asp:Label runat="server" for="ddUbicacion">Ubicacion:</asp:Label>
                <asp:DropDownList CssClass="form-control mt-2" runat="server" ID="ddUbicacion" >
                </asp:DropDownList>
            </div>
            <!-- Dropdown para Idioma -->
            <div class="col-3">
                <asp:Label runat="server" for="idioma">Idioma:</asp:Label>
                <asp:DropDownList CssClass="form-control mt-2" runat="server" ID="ddIdioma">
                </asp:DropDownList>
            </div>
            <!-- Dropdown para Activo -->
            <div class="col-3">
                <asp:Label runat="server" for="ddActivo">¿Está Activo?</asp:Label>
                <asp:DropDownList CssClass="form-control mt-2" runat="server" ID="ddActivo">
                    <asp:ListItem Text="Seleccione..." Value="" />
                    <asp:ListItem Text="Si" Value="1" />
                    <asp:ListItem Text="No" Value="0" />
                </asp:DropDownList>
            </div>
        </div>
        <!-- Botones -->
        <div class="row botones-form mt-4">
            <div class="col-1">
                <asp:Button ID="btnGuardar" runat="server" type="submit" class="btn-grabar" Text="Guardar" OnClick="btnGuardar_Click" />
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
