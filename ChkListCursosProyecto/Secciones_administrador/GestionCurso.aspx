<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="GestionCurso.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_administrador.GestionCurso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>lista de cursos</h1>

    <div class="container" align="right">
        <Button id="btnagregar" runat="server" class="btn btn-success" onserverclick="AgregarCurso_Click">Agregar curso</Button>
    </div><br />
    

    <div class="jumbotron" align="center">
        <asp:GridView ID="gvCursos" runat="server" cellpadding="3" OnRowCommand="Seleccion">
            <Columns>
                <asp:TemplateField  HeaderText="Modificar" >
                    <ItemTemplate >
                        <asp:Button type="button" ID="Modificar" Text="Modificar" Class="btn btn-primary" HeaderText="Modificacion"  runat="server" CommandName="Modificar"  CommandArgument='<%# Bind("ID") %>' autopostback="true"/> 
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField  HeaderText="Eliminar" >
                    <ItemTemplate >
                        <asp:Button type="button" ID="Eliminar" Text="Eliminar" class="btn btn-danger" HeaderText="Eliminacion"  runat="server" CommandName="Eliminar"  CommandArgument='<%# Bind("ID") %>' autopostback="true" OnClientClick='return confirm ("¿Estas seguro que deseas eliminar este curso?");'/> 
                    </ItemTemplate>
                </asp:TemplateField>  

            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            
        </asp:GridView>
    </div></br>

    <p><button href="https://asp.net" heigth="1000 " class="btn btn-primary col-4" ID="Volver" runat="server" Text="Cerrar sesion" onserverclick="volverAtras"> <img src="https://cdn-icons-png.flaticon.com/512/17/17699.png" height="40" width="50"/> <br /> Volver atras &raquo;</button></p>


</asp:Content>
