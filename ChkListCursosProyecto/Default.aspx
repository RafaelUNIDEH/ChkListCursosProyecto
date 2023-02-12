<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChkListCursosProyecto.Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <h1>Bienvenido a ChkListCursos</h1>
        <p class="lead">Bienvenido, porfavor inicia sesión con tu usuario y contraseña</p>
    </div>

    <asp:Image ID="imgPrincipal" runat="server" src="https://static.vecteezy.com/system/resources/previews/008/479/932/non_2x/book-minimal-cartoon-style-3d-render-illustration-png.png" Width="300" Height="300" />

    <p><button runat="server" onserverclick="irLoguin_Click" heigth="1000 " class="btn btn-primary col-12"> <img src="https://cdn-icons-png.flaticon.com/512/349/349209.png" height="80" width="100" /> <br /> Iniciar sesión &raquo;</button></p>
</asp:Content>
