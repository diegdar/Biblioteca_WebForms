<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="EditAutor.aspx.cs" Inherits="Biblioteca.EditAutor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <br/>
    <section id="ABM-autor">
        <div>
            <asp:label runat="server" for="mensaje" style="color:red" ID="lbMensaje">mensaje:</asp:label>
        </div>    
        <div class="campo-form col-md-5 mb-4">                 
                 <br />
                 <asp:label  runat="server" for="apellido1Autor">Apellido1:</asp:label>
                 <asp:TextBox runat="server" id="txtApellido1"  name="apellido1" class="form-control" placeholder="Ingrese el primer apellido del Autor"></asp:TextBox>
             </div>

             <div class="campo-form col-md-5 mb-4">
                 <asp:label runat="server" for="apellido2Autor">Apellido2:</asp:label>
                 <asp:TextBox runat="server" id="txtApellido2"  name="apellido2" class="form-control" placeholder="Ingrese el segundo apellido del autor"></asp:TextBox>                
                 <br />
             </div>
             <div class="campo-form col-md-5 mb-4">
                 <asp:label runat="server" for="autor">Nombre:</asp:label>
                 <asp:TextBox runat="server" id="txtNombre"  name="nombre" class="form-control" placeholder="Ingrese el nombre del Autor"></asp:TextBox>
             </div>
             <div class="campo-form col-md-5 mb-4">
             </div>
             <div class="botones-form mb-4">
                 <asp:Button id="grabar" runat="server" type="submit" class="btn-grabar" Text="Grabar" onclick="grabar_Click" Visible="false"/>
                 <asp:Button id="actualizar" runat="server" type="submit" class="btn-grabar" Text="Actualizar" OnClick="actualizar_Click" Visible="false" />
                 <asp:Button id="borrar" runat="server" type="submit" class="btn-grabar" Text="Borrar" OnClick="borrar_Click" Visible="false"/>
                 <asp:Button id="retornar" runat="server" type="submit" class="btn-retornar" Text="Retornar" onclick="retornar_Click" Visible="true"/>
                 <%--<asp:button runat="server" type="button" class="btn-retornar" onclick="window.history.back();">Retornar</asp:button>--%>
             </div>
    </section>
</asp:Content>
 