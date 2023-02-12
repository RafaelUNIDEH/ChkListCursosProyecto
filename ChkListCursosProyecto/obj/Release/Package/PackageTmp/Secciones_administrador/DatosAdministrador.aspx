<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="DatosAdministrador.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_administrador.DatosAdministrador" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" align="center">
        <h1 id="instruccion">Inserta los datos del Administrador agregar</h1>


        <label>Nombre del administrador</label><br />
        <asp:TextBox id="nombre" type="text" placeholder="Ingresa el nombre" runat="server"></asp:TextBox><br /><br />

        <label>Numero de empleado</label><br />
        <asp:TextBox id="numEmpleado" type="number" placeholder="Ingresa el numero" runat="server"></asp:TextBox><br /><br />

        <label>Area</label><br />
        <asp:DropDownList ID="area" runat="server"></asp:DropDownList><br /><br />
        
        <label>Correo del Administrador</label><br />
        <asp:TextBox id="correo" type="text" placeholder="Ingresa el correo" runat="server"></asp:TextBox><br /><br />

        <label>Contraseña del Administrador</label><br />
        <asp:TextBox id="contra" type="password" placeholder="Ingresa una contraseña" runat="server"></asp:TextBox><br /><br />

         <label>Confirma contraseña</label><br />
        <asp:TextBox id="confirmacionContra" type="password" placeholder="Confirma contraseña" runat="server"></asp:TextBox><br /><br />

        <div class="alert alert-danger alert-dismissible fade show col-4" role="alert" id="mostrarerror" runat="server" visible="false">
          <strong>Error: </strong> <asp:label id="msgerror" runat="server"></asp:label>
          <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>

        <asp:Button ID="Cancelar" runat="server" Text="Cancelar" class="btn btn-danger col-2" OnClick="CancelarClick"/>
        <asp:Button ID="Ingresar" runat="server" Text="Agregar Administrador" class="btn btn-primary col-2" OnClick="AgregarAdministrador" Visible="false"/>
        <asp:Button ID="btnModificar" runat="server" Text="Modificar Trabajador" class="btn btn-primary col-2" onclick="ModificarAdministrador" Visible="false"/><br /><br />

    </div>

</asp:Content>
