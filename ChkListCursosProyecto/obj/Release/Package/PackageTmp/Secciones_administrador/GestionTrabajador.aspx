<%@ Page Title="Gestion Trabajador" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="GestionTrabajador.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_administrador.GestionTrabajador" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestionar Trabajador</h1>

    <p><button href="" heigth="1000 " class="btn btn-primary col-12" ID="BtnAgregar" runat="server" onserverclick="btn_AgregarClick"> <img src="https://cdn-icons-png.flaticon.com/512/561/561230.png" height="80" width="100"/> <br /> Agregar Trabajador &raquo;</button></p>
    <p><button href="" heigth="1000 " class="btn btn-primary col-12" ID="BtnModificar" runat="server" onserverclick="btn_ModificarClick"> <img src="https://cdn-icons-png.flaticon.com/512/269/269074.png" height="80" width="100"/> <br /> Editar Trabajador &raquo;</button></p>
    <p><button href="" heigth="1000 " class="btn btn-primary col-12" ID="BtnEliminar" runat="server" onserverclick="btn_EliminarClick"> <img src="https://cdn-icons-png.flaticon.com/512/216/216658.png" height="80" width="100"/> <br /> Eliminar Trabajador &raquo;</button></p>

    <p><button href="https://asp.net" heigth="1000 " class="btn btn-primary col-12" ID="Volver" runat="server" Text="Volver" onserverclick="volverAtras"> <img src="https://cdn-icons-png.flaticon.com/512/17/17699.png" height="80" width="100"/> <br /> Volver atras &raquo;</button></p>
    
</asp:Content>
