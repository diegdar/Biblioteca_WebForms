<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="EditGenero.aspx.cs" Inherits="Biblioteca.EditGenero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <br/>
    <section id="ABM-genero
        ">
        <div>
            <asp:label runat="server" for="mensaje" style="color:red" ID="lbMensaje">mensaje:</asp:label>
        </div>    
        <div class="campo-form col-md-5 mb-4">
                 
                 <br />
                 <asp:label  runat="server" for="tituloGenero">Descripción</asp:label>
                 <asp:TextBox runat="server" id="txtDescripcion"  name="titulo" class="form-control" placeholder="Ingrese la descripción" Width="221px"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtDescripcion" ErrorMessage="La descripción es obligatoria" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
             </div>

             <div class="campo-form col-md-5 mb-4">
                 <br />
             </div>
             <div class="botones-form mb-4">
                 <asp:Button id="grabar" runat="server" type="submit" class="btn-grabar" Text="Grabar" onclick="grabar_Click" Visible="false"/>
                 <asp:Button id="actualizar" runat="server" type="submit" class="btn-grabar" Text="Actualizar" OnClick="actualizar_Click" Visible="false" />
                 <asp:Button id="borrar" runat="server" type="submit" class="btn-grabar" Text="Borrar" OnClick="borrar_Click" Visible="false"/>
                 <asp:Button id="retornar" runat="server" type="submit" class="btn-retornar" Text="Retornar" onclick="retornar_Click" Visible="true" CausesValidation ="false"/>
                 <%--<asp:button runat="server" type="button" class="btn-retornar" onclick="window.history.back();">Retornar</asp:button>--%>
             </div>
    </section>
</asp:Content>
 