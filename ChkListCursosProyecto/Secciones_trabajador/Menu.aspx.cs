using ChkListCursosProyecto.AccesoTrabajador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Login = ChkListCursosProyecto.AccesoTrabajador.Login;

namespace ChkListCursosProyecto.Secciones_trabajador
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] != null)
            {
                if (Session["rol"].ToString() == "Trabajador")
                {
                    String usuariologueado = Session["nombre"].ToString();
                    lblBienvenida.Text = "Bienvenido " + usuariologueado;
                }
                else {
                    Response.Redirect("../AccesoTrabajador/Login.aspx");
                }
            }
            else
            {
                Response.Redirect("../AccesoTrabajador/Login.aspx");
            }
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {

            Loguin usuarioLogueado = Login.usuarioLogueado;

            usuarioLogueado.CerrarSession();

            Session.Remove("id");
            Session.Remove("nombre");
            Session.Remove("rol");

            Response.Redirect("../Default.aspx");
        }

        protected void Disponbles_Click(object sender, EventArgs e)
        {
            Response.Redirect("cursosdisponibles.aspx");
        }

        protected void BtnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Opciones_busqueda.aspx");
        }

        protected void BtnMisCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisCursos.aspx");
        }

        protected void BtnMiQR(object sender, EventArgs e)
        {
            Response.Redirect("VerQR.aspx");
        }

    }
}