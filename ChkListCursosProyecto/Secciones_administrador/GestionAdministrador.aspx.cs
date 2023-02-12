using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_administrador
{
    public partial class GestionAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] != null)
            {
                if (Session["rol"].ToString() != "Administrador")
                {
                    Response.Redirect("../AccesoTrabajador/Login.aspx");
                }
            }
            else
            {
                Response.Redirect("../AccesoTrabajador/Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        protected void CargarGrid()
        {
            Administrador visualizar = new Administrador();

            DataTable lista = visualizar.VisualizarAdministradores();

            gvAdministradoes.DataSource = lista;
            gvAdministradoes.DataBind();
        }

        public static int modificar = 0;
        public static int idAdmin = 0;
        public static int pagAdministrador = 0;
        protected void Seleccion(object sender, GridViewCommandEventArgs e)
        {
            int fila = int.Parse(e.CommandArgument.ToString());
            //string id = gvdcurso.Rows[row-1].Cells[1].Text;

            if (e.CommandName == "Modificar")
            {
                modificar = 1;
                idAdmin = fila;
                Response.Redirect("DatosAdministrador.aspx");
            }

            if (e.CommandName == "Eliminar")
            {

                Administrador seleccionado = new Administrador();

                seleccionado.EliminarAdministrador(fila);

                pagAdministrador = 1;

                Response.Redirect("ModificacionExitosa.aspx");
            }
        }

        public static int agregar = 0;
        protected void AgregarAdministrador_Click(object sender, EventArgs e)
        {
            agregar = 1;
            Response.Redirect("DatosAdministrador.aspx");
        }

        protected void volverAtras(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }
    }
}