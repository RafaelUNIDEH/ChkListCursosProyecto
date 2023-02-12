using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_administrador
{
    public partial class TrabajadorAeliminar : System.Web.UI.Page
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
        }

        public static int pagTrabajador = 0;
        protected void Eliminar_Click(object sender, EventArgs e) {

            Trabajador datos = new Trabajador(int.Parse(numeroEmpleado.Text));

            if (datos.getNoEmpleado() == int.Parse(numeroEmpleado.Text))
            {
                Administrador seleccionado = new Administrador();

                seleccionado.EliminarEmpleado(datos.getIdEmpleado());

                pagTrabajador = 1;

                Response.Redirect("ModificacionExitosa.aspx");
            }
            else
            {
                msgerror.Text = "No existe un trabajador con ese numero";
                mostrarerror.Visible = true;
            }

            
        }

        protected void VolverClick(object sender, EventArgs e) {
            Response.Redirect("GestionTrabajador.aspx");
        }

    }
}