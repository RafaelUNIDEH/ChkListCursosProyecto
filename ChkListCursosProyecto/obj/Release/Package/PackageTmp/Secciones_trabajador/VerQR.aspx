<%@ Page Title="Mi codigo QR" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="VerQR.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_trabajador.VerQR" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" >

        <h1 id="nombreuser" runat="server"></h1><br /><br />

        <img id="codigo" height="300" width="300" runat="server"/>
        <a ID="descargar" runat="server" Text="Descargar QR" class="btn btn-primary" >Descargar</a><br /><br />

        <p><button href="https://asp.net" heigth="1000 " class="btn btn-primary col-4" ID="Volver" runat="server" Text="Cerrar sesion" onServerClick="Volver_ServerClick"> <img src="https://cdn-icons-png.flaticon.com/512/17/17699.png" height="40" width="50"/> <br /> Volver atras &raquo;</button></p>
    </div>

</asp:Content>
