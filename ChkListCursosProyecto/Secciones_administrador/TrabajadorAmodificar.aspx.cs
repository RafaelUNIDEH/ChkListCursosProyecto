using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_administrador
{
    public partial class TrabajadorAmodificar : System.Web.UI.Page
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

        public static int modificar = 0;
        public static int numTrabajador = 0;
        protected void btn_Modificar_Click(object sender, EventArgs e) {

            Trabajador verificar = new Trabajador(int.Parse(numeroEmpleado.Text));

            if (verificar.getNoEmpleado() == int.Parse(numeroEmpleado.Text))
            {
                modificar = 1;
                numTrabajador = int.Parse(numeroEmpleado.Text);
                Response.Redirect("DatosTrabajador.aspx");
            }
            else {
                msgerror.Text = "No existe un trabajador con ese numero";
                mostrarerror.Visible = true;
            }

            
        }

        protected void VolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionTrabajador.aspx");
        }

    }
}