<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="TrabajadorAmodificar.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_administrador.TrabajadorAmodificar" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" align="center">

        <h1 id="instruccion">Ingresa el numero de trabajador a modificar</h1>


        <label>Numero de empleado</label><br />
        <asp:TextBox ID="numeroEmpleado" type="number" placeholder="Ingresa el numero" runat="server"></asp:TextBox><br /><br />

        <div class="alert alert-danger alert-dismissible fade show col-4" role="alert" id="mostrarerror" runat="server" visible="false">
            <strong>Error: </strong> <asp:label id="msgerror" runat="server"></asp:label>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
         </div>

        <asp:Button ID="Cancelar" runat="server" Text="Cancelar" class="btn btn-danger col-2" OnClick="VolverMenu_Click"/>
        <asp:Button ID="Modificar" runat="server" Text="Modificar trabajador" class="btn btn-primary col-2" OnClick="btn_Modificar_Click"/><br /><br />

    </div>

</asp:Content>
