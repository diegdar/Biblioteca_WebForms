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
            <li><asp:Label ID="LblLogin" runat="server" Text="Si eres bibliotecario haz login" ForeColor="#999966"></asp:Label>
            </li>
            <li><form runat="server">
                <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click">Login</asp:LinkButton>
                </form></li>
            <li><a href="#buscar-libro-contenido" onclick="mostrarBuscarLibro()">Buscar Libro</a></li>
            <li><a href="#prestar-libro">Prestar Libro</a></li>
            <li><a href="#devolver-libro">Devolver Libro</a></li>
            <li><a href="#gestion-libro">Gestionar Libros</a>
                <ul class="submenu">
                    <li><a href="ListadoTitulos.aspx">Ver Libros</a></li>
                    <li><a href="#estadistica-libros">Estadisticas</a></li>
                    <li><a href="#ubicar-libros">Ubicar Libros</a></li>
                </ul>
            </li>
            <li><a href="#administracion">Administración</a>
                <ul class="submenu">
                    <li><a href="ListadoAutor.aspx">Autores</a></li>
                    <li><a href="ListadoGenero">Género</a></li>
                    <li><a href="#obra-literaria">Obra Literaria</a></li>
                    <li><a href="#ejemplares">Ejemplares</a></li>
                    <li><a href="ListadoEditorial.aspx">Editorial</a></li>
                    <li><a href="#ubicaciones">Ubicaciones</a></li>
                    <li><a href="#bibliotecario">Bibliotecario</a></li>
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
        <div id="presentacion" class="presentacion-container">
            <p align="justified">Biblioteca Moderna es una entidad sin ánimo de lucro cuyo objetivo es fomentar
                <br />la lectura.
                <br />
                Dispone de un amplio catálogo de libros de variada temática incluyendo libros
                <br />técnicos, de texto, novelas, ensayos, teatro, poesía, biografías, etc..
                <br />
                Otro de sus objetivos es la conservación de obras para evitar su pérdida.
                <br />
                El catálogo se nutre de donaciones tanto privadas como públicas pero también se
                <br />dispone de algunos estrenos en diversos campos.
                <br />
                Los libros pueden consultarse en el local o también pueden alquilarse durante
                <br />15 días sin coste.
                <br />
            </p>
        </div>
    </section>

</asp:Content>
