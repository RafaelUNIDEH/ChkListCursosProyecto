<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="ModificacionExitosa.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_administrador.ModificacionExitosa" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div alingn="center">

        <asp:Label ID="exitoso" runat="server" Text="" CssClass="h5"><Strong>Operacion realizada correctamente</Strong></asp:Label><br><br />
        <img src="https://esoft-ibm.gevents.co/images/check.png" height="300" width="300"/><br><br><br>

    </div>

    <script type="text/javascript">
        window.onload = function () {
            var user = "<%= this.Codigo%>";

            if (user == 1) {
                setTimeout(function () { window.location.href = "GestionTrabajador.aspx"; }, 1000);
            }

            if (user == 2) {
                setTimeout(function () { window.location.href = "GestionInstructor.aspx"; }, 1000);
            }

            if (user == 3) {
                setTimeout(function () { window.location.href = "GestionAdministrador.aspx"; }, 1000);
            }

            if (user == 4) {
                setTimeout(function () { window.location.href = "GestionCurso.aspx"; }, 1000);
            }

        };
            
    </script>
</asp:Content>
