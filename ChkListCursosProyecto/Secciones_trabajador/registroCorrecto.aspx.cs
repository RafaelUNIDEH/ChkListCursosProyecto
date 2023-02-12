using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_trabajador
{
    public partial class registroCorrecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] != null)
            {
                if (Session["rol"].ToString() != "Trabajador")
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
                String nombre = Registrar.reg_nom.ToString();
                String fecha = Registrar.reg_fecha.ToString();
                String hora = Registrar.reg_hora.ToString();

                nombre_user_registrado.Text = nombre;
                fechaAsistencia.Text = fecha;
                horaAsistencia.Text = hora;
            }
        }

        protected void Volver_menu(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}