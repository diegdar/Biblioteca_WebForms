﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="BibliotecarioABM.aspx.cs" Inherits="Biblioteca_WebForms.Pagina.BibliotecarioABM" %>
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
            <asp:Label runat="server" for="txtApellido">Apellido:</asp:Label>
            <asp:TextBox runat="server" ID="txtApellido" name="apellido" class="form-control" placeholder="Ingrese el Apellido"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvApellido" ControlToValidate="txtApellido" ErrorMessage="El apellido es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="nombre">Nombre:</asp:Label>
            <asp:TextBox runat="server" ID="txtNombre" name="nombre" class="form-control" placeholder="Ingrese el Nombre"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="email">Email:</asp:Label>
            <asp:TextBox runat="server" ID="txtEmail" name="email" class="form-control" placeholder="Ingrese su email"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtEmail" ErrorMessage="El email es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="campo-form col-md-5 mb-4">
            <asp:Label runat="server" for="contrasenia">Contraseña:</asp:Label>
            <asp:TextBox runat="server" ID="txtContrasenia" name="contrasenia" TextMode="Password" class="form-control" placeholder="Ingrese su contraseña"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtContrasenia" ErrorMessage="La contraseña es obligatoria" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="botones-form mb-4">
            <asp:Button ID="btGrabar" runat="server" type="submit" class="btn-grabar" Text="Grabar" OnClick="btGrabar_Click" Visible="false" />
            <asp:Button ID="btActualizar" runat="server" type="submit" class="btn-grabar" Text="Actualizar" OnClick="btActualizar_Click" Visible="false" />
            <asp:Button ID="btRetornar" runat="server" type="submit" class="btn-retornar" Text="Retornar" OnClick="btRetornar_Click" Visible="true" CausesValidation="False" />
            <%--<asp:button runat="server" type="button" class="btn-retornar" onclick="window.history.back();">Retornar</asp:button>--%>
        </div>
    </section>
</asp:Content>