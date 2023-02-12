<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="InicioInstructor.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_instructor.InicioInstructor" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lbBienvenida" runat="server" Text="" CssClass="h3"></asp:Label>


    <asp:Label ID="lbIstruccion" runat="server" Text="Selecciona el curso a calificar" CssClass=""></asp:Label>
    <asp:DropDownList id="DDLCursosInpartidos" runat="server"></asp:DropDownList>

    <asp:Button id="btnAceptar" runat="server" Text="Aceptar" />

</asp:Content>
