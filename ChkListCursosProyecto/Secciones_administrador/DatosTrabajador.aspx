<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="DatosTrabajador.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_administrador.DatosTrabajador" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" align="center">
        <h1 id="instruccion">Inserta los datos del trabajador a agregar</h1>


        <label>Nombre del trabajador</label><br />
        <asp:TextBox id="nombre" type="text" placeholder="Ingresa el nombre" runat="server"></asp:TextBox><br /><br />

        <label>Numero de empleado</label><br />
        <asp:TextBox ID="numeroEmpleado" type="number" placeholder="Ingresa el numero" runat="server" ></asp:TextBox><br /><br />
        
        <label>Selecciona el area del empleado</label><br />
        <asp:DropDownList ID="area" runat="server"></asp:DropDownList><br /><br />
        
        <label>Correo del trabajador</label><br />
        <asp:TextBox id="correo" type="text" placeholder="Ingresa el correo" runat="server"></asp:TextBox><br /><br />

        <label>Contraseña del trabajador</label><br />
        <asp:TextBox id="contra" type="password" placeholder="Ingresa una contraseña" runat="server"></asp:TextBox><br /><br />

         <label>Confirma contraseña</label><br />
        <asp:TextBox id="confirmacionContra" type="password" placeholder="Confirma contraseña" runat="server"></asp:TextBox><br /><br />

        <div class="alert alert-danger alert-dismissible fade show col-4" role="alert" id="mostrarerror" runat="server" visible="false">
          <strong>Error: </strong> <asp:label id="msgerror" runat="server"></asp:label>
          <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>

        <asp:Button ID="Cancelar" runat="server" Text="Cancelar" class="btn btn-danger col-2" onclick="VolverMenu_Click" />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Trabajador" class="btn btn-primary col-2" onclick="btnAgregarTrabajador" Visible="false"/>
        <asp:Button ID="btnModificar" runat="server" Text="Modificar Trabajador" class="btn btn-primary col-2" onclick="btnModificarTrabajador" Visible="false"/><br /><br />

    </div>

</asp:Content>
