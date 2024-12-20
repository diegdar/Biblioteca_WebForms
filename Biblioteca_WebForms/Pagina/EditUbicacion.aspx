<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="EditUbicacion.aspx.cs" Inherits="Biblioteca_WebForms.Pagina.EditUbicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <br/>
    <section id="ABM-ubicacion">
        <div>
            <asp:label runat="server" for="mensaje" style="color:red" ID="lbMensaje">mensaje:</asp:label>
        </div>    
        <div class="campo-form col-md-5 mb-4">                 
                 <br />
                 <asp:label  runat="server" for="numeroEstanteria">Núm. Estantería:</asp:label>
                 &nbsp;
                 <asp:TextBox ID="txtEstanteria" runat="server" name="estanteria" class="form-control" placeholder="Ingrese el número de la estantería"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtEstanteria" ErrorMessage="El número de estantería es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
&nbsp;</div>
	         <div class="campo-form col-md-5 mb-4">                 
                 <br />
                 <asp:label  runat="server" for="fila">Fila:</asp:label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:TextBox ID="txtFila" runat="server" name="fila" class="form-control" placeholder="Ingrese las letras de la fila"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtFila" ErrorMessage="La fila es obligatoria" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
             </div>
        <div class="campo-form col-md-5 mb-4">                 
                 <br />
                 <asp:label  runat="server" for="columna">Columna:</asp:label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:TextBox ID="txtColumna" runat="server" name="apellido2" class="form-control" placeholder="Ingrese las letras de la columna"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtColumna" ErrorMessage="La columna es obligatoria" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
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
