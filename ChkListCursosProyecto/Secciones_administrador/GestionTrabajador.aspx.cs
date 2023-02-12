using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_administrador
{
    public partial class GestionTrabajador : System.Web.UI.Page
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

        public static int agregar = 0;
        protected void btn_AgregarClick(object sender, EventArgs e) {
            agregar = 1;
            Response.Redirect("DatosTrabajador.aspx");
        }

        protected void btn_ModificarClick(object sender, EventArgs e)
        {
            Response.Redirect("TrabajadorAmodificar.aspx");
        }

        protected void btn_EliminarClick(object sender, EventArgs e)
        {
            Response.Redirect("TrabajadorAeliminar.aspx");
        }


        protected void volverAtras(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }

    }
}