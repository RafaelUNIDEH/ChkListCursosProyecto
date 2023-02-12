<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="AsignacionCalificacion.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_instructor.AsignacionCalificacion" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:Label ID="lbindicacion" runat="server" Text="Porfavor asigna la calificacion obtenida por cada participante" CssClass="h3"></asp:Label>

    <asp:GridView ID="PaticipantesCurso" runat="server">
        <Columns>
            <asp:TemplateField  HeaderText="Mas informacion" >
                <ItemTemplate >
                    <select id="Estatus" >
                        <option value="No aprobado">No aprobado</option>
                        <option value="Aprobado">Aprobado</option>
                    </select>
                </ItemTemplate>
            </asp:TemplateField>  
        </Columns>
    </asp:GridView><br /><br />

            

    <asp:Label ID="lbVencimiento" runat="server" Text="Selecciona la fecha en la que el curso dejara de tene validez"></asp:Label>
    <asp:TextBox ID="tbVencimiento" runat="server" Type="date"></asp:TextBox><br />

    <asp:Label ID="Label1" runat="server" Text="Agrega una imagen de tu firma"></asp:Label>
    <asp:FileUpload ID="imgFirma" runat="server" acept=".jpg"/><br /><br />


    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />


</asp:Content>
