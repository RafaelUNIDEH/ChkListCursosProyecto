﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="RegistroAcurso.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_trabajador.RegistroAcurso" EnableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form>
  
      <div class="form-group">
          <label for="exampleFormControlSelect1">Selecciona el curso deseado</label><br /><br />

          <asp:DropDownList ID="DDLCursos" runat="server" class="btn btn-secondary btn-lg dropdown-toggle col-lg-12">

          </asp:DropDownList>

      </div><br/>

      <p><button type="submit" class="btn btn-primary" runat="server" onserverclick="Registrar">Registrarme en curso</button></p><br /><br />

    
       <p><button href="https://asp.net" heigth="1000 " class="btn btn-primary col-4" ID="Volver" runat="server" Text="Cerrar sesion" onserverclick="VolverMenubus_Click"> <img src="https://cdn-icons-png.flaticon.com/512/17/17699.png" height="40" width="50"/> <br /> Volver atras &raquo;</button></p>
 
   </form><br/><br/>
    <script src="JavaTrabajador.js"></script>
</asp:Content>
