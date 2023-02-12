using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_administrador
{
    public partial class MenuAdmin : System.Web.UI.Page
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

        protected void btnGestionTrabajador(object sender, EventArgs e)
        {
            Response.Redirect("GestionTrabajador.aspx");
        }

        protected void btnGestionInstructor(object sender, EventArgs e)
        {
            Response.Redirect("GestionInstructor.aspx");
        }
        protected void btnGestionAdministrador(object sender, EventArgs e)
        {
            Response.Redirect("GestionAdministrador.aspx");
        }
        protected void btnGestionCurso(object sender, EventArgs e)
        {
            Response.Redirect("GestionCurso.aspx");
        }

        protected void btnCerrarSesion(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

    }
}