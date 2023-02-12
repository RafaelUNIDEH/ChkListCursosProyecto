<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="ConfirmacionExito.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_instructor.ConfirmacionExito" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div alingn="center">
        <asp:Label ID="lbCorrecto" runat="server" Text="Curso Calificado con exito" CssClass="h5"></asp:Label><br>
       
        <img src="https://esoft-ibm.gevents.co/images/check.png" height="300" width="300"/><br><br><br>
        <button type="button" class="btn btn-primary" runat="server" >Volver a menu</button>
    </div>

</asp:Content>
