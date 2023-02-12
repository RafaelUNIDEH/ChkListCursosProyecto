<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_administrador.MenuAdmin" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblBienvenida" runat="server" Text="" CssClass="h3"></asp:Label>

    <p><button href="" heigth="1000 " class="btn btn-primary col-12" ID="BtnTrabajador" runat="server" onserverclick="btnGestionTrabajador"> <img src="https://www.pngmart.com/files/17/Vector-Worker-PNG-Free-Download.png" height="80" width="100"/> <br /> Gestionar Trabajador &raquo;</button></p>
    <p><button href="" heigth="1000 " class="btn btn-primary col-12" ID="BtnIntructor" runat="server" onserverclick="btnGestionInstructor"> <img src="https://cdn-icons-png.flaticon.com/512/5234/5234582.png" height="80" width="100"/> <br /> Gestionar Instructor &raquo;</button></p>
    <p><button href="" heigth="1000 " class="btn btn-primary col-12" ID="BtnAdministrador" runat="server" onserverclick="btnGestionAdministrador"> <img src="https://cdn-icons-png.flaticon.com/512/2942/2942813.png" height="80" width="100"/> <br /> Gestionar Administrador &raquo;</button></p>
    <p><button href="" heigth="1000 " class="btn btn-primary col-12" ID="BtnCursos" runat="server" onserverclick="btnGestionCurso"> <img src="https://cdn-icons-png.flaticon.com/512/2029/2029174.png" height="80" width="100"/> <br /> Gestionar cursos &raquo;</button></p>
    <p><button href="" heigth="1000 " class="btn btn-primary col-12" ID="BtnCerrar" runat="server" onserverclick="btnCerrarSesion"> <img src="https://www.pngall.com/wp-content/uploads/10/Power-Off-Logo-PNG.png" height="80" width="100"/> <br /> Cerrar sesion &raquo;</button></p>

</asp:Content>
