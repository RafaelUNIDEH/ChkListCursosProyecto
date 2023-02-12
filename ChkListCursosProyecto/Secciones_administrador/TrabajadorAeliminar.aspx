<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="TrabajadorAeliminar.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_administrador.TrabajadorAeliminar" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" align="center">

         <h1 id="instruccion">Ingresa el id del usuario a eliminar</h1>


        <label>Numero de empleado</label><br />
        <asp:TextBox ID="numeroEmpleado" type="number" placeholder="Ingresa el numero" runat="server"></asp:TextBox><br /><br />

        <div class="alert alert-danger alert-dismissible fade show col-4" role="alert" id="mostrarerror" runat="server" visible="false">
            <strong>Error: </strong> <asp:label id="msgerror" runat="server"></asp:label>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
         </div>

        <asp:Button ID="Cancelar" runat="server" Text="Cancelar" class="btn btn-danger col-2" OnClick="VolverClick"/>
        <asp:Button ID="Eliminar" runat="server" Text="Eliminar trabajador" class="btn btn-primary col-2" OnClick="Eliminar_Click" OnClientClick='return confirm ("¿Estas seguro que deseas eliminar a este trabajador?");'/><br /><br />

    </div>

</asp:Content>
