<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Master_Trabajador.Master" AutoEventWireup="true" CodeBehind="MisCursos.aspx.cs" Inherits="ChkListCursosProyecto.Secciones_trabajador.MisCursos" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
    <div class="modal fade" id="ModalMisCursos" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div id="Modal_mas" class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Informacion de curso</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="titleEmpleado" runat="server" Text="" CssClass="h5"><Strong>Trabajador: </Strong></asp:Label><br>
                    <asp:Label ID="lbempleado" runat="server" Text="" Style="font-weight: 100; font-size: xx-large; color: dimgray;" CssClass="a"></asp:Label><br>
                    <asp:Label ID="titleCurso" runat="server" Text="" CssClass="h5"><Strong>Curso: </Strong></asp:Label><br>
                    <asp:Label ID="lbcurso" runat="server" Text="" Style="font-weight: 100; font-size: xx-large; color: dimgray;" CssClass="a"></asp:Label><br>
                    <asp:Label ID="titleIntructor" runat="server" Text="" CssClass="h5"><Strong>Instructor: </Strong></asp:Label><br>
                    <asp:Label ID="lbinstructor" runat="server" Text="" Style="font-weight: 100; font-size: xx-large; color: dimgray;" CssClass="a"></asp:Label><br>
                    <asp:Label ID="titlefechacapa" runat="server" Text="" CssClass="h5"><Strong>Fecha capacitacion:</Strong></asp:Label><br>
                    <asp:Label ID="lbfechacapa" runat="server" Text="" Style="font-weight: 100; font-size: xx-large; color: dimgray;" CssClass="a"></asp:Label><br>
                    <asp:Label ID="titlefechavenc" runat="server" Text="" CssClass="h5"><Strong>Fecha de vencimiento:</Strong></asp:Label><br>
                    <asp:Label ID="lbfechavenc" runat="server" Text="" Style="font-weight: 100; font-size: xx-large; color: dimgray;" CssClass="a"></asp:Label><br>
                    <asp:Label ID="titltestatus" runat="server" Text="" CssClass="h5"><Strong>Estatus:</Strong></asp:Label><br>
                    <asp:Label ID="lbstatus" runat="server" Text="" Style="font-weight: 100; font-size: xx-large; color: dimgray;" CssClass="a"></asp:Label><br>
                </div>
                <div class="modal-footer">
                    <button id="prueba" type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button id="btnImprimir" type="button" class="btn btn-primary" runat="server">Imprimir certificado</button>
                </div>
              </div>
            </div>
        </div>

        <h1>Mis cursos</h1>

        <asp:GridView ID="gvdmiscursos" runat="server" CellPadding="3" OnRowCommand="Vermas_Click" >
            <Columns>
                <asp:TemplateField HeaderText="Mas informacion">
                    <ItemTemplate>
                        <asp:Button type="button" ID="Vermas" Text="Ver mas" HeaderText="Mas informacion" data-bs-toggle="modal" data-bs-target="#staticBackdrop" runat="server" CommandName="Mostrar" CommandArgument='<%# Bind("ID") %>' autopostback="true" />
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
    </div>
    <br />

    
    

    <p><button href="https://asp.net" heigth="1000 " class="btn btn-primary col-4" id="Volver" runat="server" text="Cerrar sesion" onserverclick="VolverMenu_Click"><img src="https://cdn-icons-png.flaticon.com/512/17/17699.png" height="40" width="50" /><br />Volver atras &raquo;</button></p>

    <script src="JavaTrabajador.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
        });


        $('#Vermas').css("background", "green")
    </script>

</asp:Content>
