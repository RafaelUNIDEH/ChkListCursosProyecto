<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="DatosCurso.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_administrador.DatosCurso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" align="center">
        <h1 id="instruccion">Inserta los datos del curso a agregar</h1>


        <label>Nombre del curso</label><br />
        <asp:TextBox id="nombre" type="text" placeholder="Ingresa el nombre" runat="server"></asp:TextBox><br /><br />

        <label>Nombre del instructor a asignar</label><br />
        <asp:DropDownList ID="nombreInstructor" runat="server"></asp:DropDownList><br /><br />

        <label>Capacidad</label><br />
        <asp:TextBox id="capacidad" type="number" placeholder="Ingresa la capacidad" runat="server"></asp:TextBox><br /><br />
        
        <label>Duracion del curso (letras)</label><br />
        <asp:TextBox id="duracion" type="text" placeholder="ejemplo (1 hora)" runat="server"></asp:TextBox><br /><br />
               
        <label>Dirigido a</label><br />
        <asp:DropDownList ID="area" runat="server"></asp:DropDownList><br /><br />

        <label>Fecha de curso</label><br />
        <asp:TextBox id="fecha" type="date" placeholder="Ingresa la fecha" runat="server"></asp:TextBox><br /><br />

        <label>Hora del curso</label><br />
        <asp:TextBox id="hora" type="time" placeholder="Ingresa la hora" runat="server"></asp:TextBox><br /><br />

        <div class="alert alert-danger alert-dismissible fade show col-4" role="alert" id="mostrarerror" runat="server" visible="false">
          <strong>Error: </strong> <asp:label id="msgerror" runat="server"></asp:label>
          <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>

        <asp:Button ID="Cancelar" runat="server" Text="Cancelar" class="btn btn-danger col-2" OnClick="CancelarClick"/>
        <asp:Button ID="Ingresar" runat="server" Text="Agregar Curso" class="btn btn-primary col-2" OnClick="AgregarCurso" Visible="false"/>
        <asp:Button ID="btnModificar" runat="server" Text="Modificar Trabajador" class="btn btn-primary col-2" onclick="ModificarInstructor" Visible="false"/><br /><br />
    </div>

</asp:Content>
