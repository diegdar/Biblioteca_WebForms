<%@ Page Title="" Language="C#" MasterPageFile="~/Ms.Master" AutoEventWireup="true" CodeBehind="ObraAbm.aspx.cs" Inherits="Biblioteca.ObraAbm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <br/>
    <section id="ABM-libro">
            <div class="campo-form col-md-5 mb-4">
                 <asp:label  runat="server" for="titulo">Título del Libro:</asp:label>
                 <asp:TextBox runat="server" id="titulo"  name="titulo" class="form-control" placeholder="Ingrese el título del libro"></asp:TextBox>
             </div>

             <div class="campo-form col-md-5 mb-4">
                 <asp:label runat="server" for="sinopsis">Sinopsis:</asp:label>
                 <asp:TextBox runat="server" TextMode="MultiLine" id="sinopsis" name="sinopsis" class="form-control" placeholder="Ingrese la sinopsis" rows="5"></asp:TextBox>
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
 
