<%@ Page Title="" Language="C#" MasterPageFile="~/Mp.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Biblioteca.Pagina.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <div class="imagen-header">
            <h1>Biblioteca Moderna</h1>
            <p>Descubre, presta y disfruta de tus libros favoritos</p>
        </div>
    </header>
    
    <nav class="menu">
        <ul>
            <li><a href="#buscar-libro-contenido" onclick="mostrarBuscarLibro()">Buscar Libro</a></li>
            <li><a href="GestionAlquiler.aspx">Prestar</a></li>
            <li><a href="#devolver-libro">Devolver Libro</a></li>
            <li><a href="ListadoEjemplares.aspx">Gestionar Ejemplar</a></li>
            <li><a href="ListadoObras.aspx">Gestionar Obra</a></li>
            <li><a href="#administracion">Administración</a>
                <ul class="submenu">
                    <li><a href="#autores">Autores</a></li>
                    <li><a href="#genero">Género</a></li>
                    <li><a href="ListadoSocios.aspx">Socio</a></li>
                    <li><a href="#ejemplares">Ejemplares</a></li>
                    <li><a href="#editorial">Editorial</a></li>
                    <li><a href="#ubicaciones">Ubicaciones</a></li>
                    <li><a href="ListadoBibliotecarios.aspx">Bibliotecario</a></li>
                </ul>
            </li>
        </ul>
    </nav>
    
    <!-- Aquí irían las secciones de contenido -->
    <section id="buscar-libro-contenido" class="activo">
        <h2>Buscar Libro</h2>
        <div class="busqueda-container">
            <input type="text" id="buscar-input" placeholder="Introduce el título o autor..." class="busqueda-input">
            <button id="buscar-btn" class="busqueda-btn">Buscar</button>
        </div>
        <div id="resultados" class="resultados-container">
            <p>Resultados</p>
            <!-- Los resultados se mostrarán aquí -->
        </div>
    </section>

</asp:Content>
