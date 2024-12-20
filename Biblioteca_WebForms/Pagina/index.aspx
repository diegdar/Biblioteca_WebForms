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
					<li><a href="ListadoEditorial.aspx">Editoriales</a></li>
                    <li><a href="ListadoGenero.aspx">Géneros</a></li>
					<li><a href="ListadoIdioma.aspx">Idiomas</a></li>
                    <li><a href="obra-literaria">Obra Literaria</a></li>
                    <li><a href="#ejemplares">Ejemplares</a></li>
                    <li><a href="#bibliotecario">Bibliotecarios</a></li>
					<li><a href="#Socio">Socios</a></li>
					<li><a href="ListadoUbicacion.aspx">Ubicaciones</a></li>
                </ul>
            </li>
        </ul>
    </nav>
    
    <!-- Aquí irían las secciones de contenido -->
    <section id="presentacion-biblioteca" class="activo">
        <h1>Bievenidos a Biblioteca Moderna</h1>
	<p>Biblioteca Moderna, un lugar encantador ubicado en el corazón de Madrid, España.</p>
	<p>No sólo es un lugar para leer, sino también un espacio donde se organizan charlas, presentaciones de libros y actividades para niños, 
	promoviendo así un ambiente comunitario y enriquecedor. ¡Es un lugar que vale la pena visitar!</p>
 
<h2> 1. Historia:</h2>
	<p>La Biblioteca Moderna fue inaugurada en 1995 en la ciudad de Madrid, un lugar conocido por su rica herencia cultural y su compromiso 
	con la educación.
	<br>
	<br>
	Fundada por un grupo de entusiastas de la literatura y la educación, nació con el objetivo de ser un espacio accesible para todos, 
	promoviendo la lectura y el aprendizaje continuo. Desde su apertura, ha crecido significativamente, ampliando su colección y 
	servicios para adaptarse a las necesidades de la comunidad.</p>
	<p>Se organiza como una entidad sin ánimo de lucro, dedicada a fomentar la lectura y el acceso a la información para toda la comunidad.</p>
	<img src="../Imagen/book-1052014_640.jpg" alt="Imagen de la Biblioteca Moderna Interior" width="200" height="200">
<h2>2. Objetivos:</h2>
	<p>La Biblioteca Moderna tiene varios objetivos clave:</p>
		<ul>
		<li>Fomentar el amor por la lectura entre todas las edades.</li>
		<li>Proporcionar un espacio seguro y acogedor para el estudio y la investigación.</li>
		<li>Ofrecer programas educativos y talleres que promuevan el desarrollo personal y profesional.</li>
		<li>Facilitar el acceso a la información y la tecnología, asegurando que todos los miembros de la comunidad puedan beneficiarse 
			de los recursos disponibles.</li>
		</ul>
	<img src="../Imagen/books-2463779_640.jpg" alt="Imagen de la Biblioteca Moderna Interior" width="300" height="300">
<h2>3. Ubicación:</h2>
	<p>La Biblioteca Moderna se encuentra en el corazón de Madrid, en la Avenida de la Cultura, 123. Su ubicación estratégica la hace fácilmente
	accesible para todos los ciudadanos, con transporte público cercano y estacionamiento disponible. El edificio es moderno y acogedor, diseñado 
	para ser un espacio inspirador donde las personas puedan reunirse, aprender y crecer.</p>
	<p> Su sede encuentra en un edificio histórico restaurado, con amplios espacios de lectura, salas de estudio y un área dedicada a actividades 
	culturales y talleres. Su ubicación es ideal, ya que está cerca de varias universidades y centros culturales, lo que la convierte en un punto 
	de encuentro para estudiantes, investigadores y amantes de la literatura.</p>
<h2>4. Financiación:</h2>
	<p>La Biblioteca Moderna se financia a través de una combinación de fondos públicos y donaciones privadas. Recibe apoyo del gobierno local, 
	así como de organizaciones sin fines de lucro y empresas locales que creen en la importancia de la educación y la cultura. Además, organiza 
	eventos comunitarios y campañas de recaudación de fondos para mantener y expandir sus servicios.</p>
	<p>Además, para mantener sus servicios y actividades, la biblioteca solicita una pequeña cuota anual a sus socios, pero también ofrece 
	membresías gratuitas para estudiantes y personas en situación de desempleo, asegurando que todos tengan acceso a sus recursos.</p>
<h2>5. Público:</h2>
	<p>La biblioteca está abierta a todos los miembros de la comunidad, desde niños hasta adultos mayores. Se enfoca especialmente en estudiantes, 
	investigadores y familias, ofreciendo programas específicos para cada grupo. Además, se realizan actividades inclusivas para personas con 
	discapacidades, garantizando que todos puedan disfrutar de los recursos y servicios.</p>
	<img src="../Imagen/books-5211309_1280.jpg" alt="Imagen de la Biblioteca Moderna Interior" width="200" height="200">
        <h2>6. Tipos de Libros Ofrecidos:</h2>
	<p>Cuenta con una amplia y variada colección de libros para satisfacer los intereses y necesidades de su diverso público. 
	<br>
	<br>
	Algunos de los tipos de libros que puedes encontrar son:</p>
	<ul>
	<li>Literatura Infantil y Juvenil: Una selección encantadora de cuentos, novelas y libros ilustrados que fomentan la lectura desde una 
	edad temprana.</li>
	<li>Ficción y No Ficción: Novelas contemporáneas y clásicas, así como biografías, ensayos y obras de no ficción que abordan una variedad de temas.</li>
	<li>Ciencia y Tecnología: Libros que exploran los últimos avances en ciencia, tecnología, ingeniería y matemáticas, ideales para estudiantes y 
	entusiastas.</li>
	<li>Historia y Cultura: Obras que cubren diferentes períodos históricos, culturas y civilizaciones, perfectas para quienes buscan entender el pasado.
	<li>Autoayuda y Desarrollo Personal: Títulos que ofrecen consejos y estrategias para el crecimiento personal, la motivación y el bienestar emocional.
	<li>Arte y Diseño: Libros que celebran la creatividad, incluyendo monografías de artistas, guías de diseño y libros de fotografía.
	<li>Literatura en Idiomas Extranjeros: Una colección de libros en varios idiomas, que incluye novelas, cuentos y textos académicos, para apoyar a la 
	comunidad multicultural.
	<li>Revistas y Periódicos: Acceso a una variedad de publicaciones periódicas que cubren temas de actualidad, cultura, ciencia y más.</ul>
	<p>Con esta variedad de libros, la Biblioteca Moderna se esfuerza por ser un recurso valioso para todos los miembros de la comunidad, promoviendo 
	el aprendizaje y la exploración en múltiples áreas del conocimiento. Si necesitas más detalles o información adicional, ¡estaremos encantados de 
	ayudarle!</p>
	<h2>Información de Contacto:</h2>
		<p>
		<strong>Dirección:</strong>&nbsp;&nbsp;Avenida de la Cultura, 123, 28053 MADRID
		<br>
		<strong>Horario:</strong>&nbsp;&nbsp;&nbsp;&nbsp;De lunes a vierenes de 8:00 a 20:00, sábados y domingos de 10:00 a 13:00, festivos cerrado.
		<br>
		<strong>Mail:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<a href="mailto:biblioteca.moderna@mygreatnewblog.com">biblioteca.moderna@mygreatnewblog.com</a>
	</p>
	<h3>Protección de datos:</h3>
	<p>Esta página cumple con la Ley Orgánica de Protección de Datos Personales y garantía de los derechos digitales 
		(LOPDGDD 3/2018).</p>
    </section>
</asp:Content>
