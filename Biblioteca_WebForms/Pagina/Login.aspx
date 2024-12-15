<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Biblioteca_WebForms.Pagina.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title></title>
   <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
   <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
   <link rel="stylesheet" href="../Estilo/estilos.css"/>

    <style> 
        .form-container { 
            margin-top: 4rem; /* 4 posiciones más abajo */ 
            background-color: #f8f9fa; /* Fondo gris claro */ 
            padding: 2rem; 
            border-radius: 0.5rem; 
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* Sombra suave */ 
        } 
        .form-title { font-size: 1.5rem; margin-bottom: 1.5rem; 
        } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="form-container">
                        <div class="form-title text-center">Inicio de Sesión</div>
                        <asp:Panel runat="server">
                            <div class="form-group row">
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="col-sm-4 col-form-label mb-4"></asp:Label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" Placeholder="Usuario"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="lblClave" runat="server" Text="Clave" CssClass="col-sm-4 col-form-label mb-4"></asp:Label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Clave"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-12 text-center">
                                    <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" CssClass="btn-grabar" OnClick="btnIniciarSesion_Click" />
                                </div>
                                <div class="col-sm-12 text-center mt-4" style="color:red"> 
                                    <asp:Label ID="lblMensaje" runat="server" Text="El usuario o la contraseña no son válidos" CssClass="col-sm-4 col-form-label mt-4"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
