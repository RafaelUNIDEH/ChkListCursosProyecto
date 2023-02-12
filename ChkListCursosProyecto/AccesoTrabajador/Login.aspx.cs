using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.AccesoTrabajador
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static Loguin usuarioLogueado;
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {

            usuarioLogueado = new Loguin(tbUsuario.Text, tbPassword.Text);

            if (usuarioLogueado.Ingresar())
            {
                Trabajador id = new Trabajador(usuarioLogueado.getCorreo());

                string rol = usuarioLogueado.getRol();
                Session["id"] = id.getIdEmpleado();
                Session["correo"] = usuarioLogueado.getCorreo();
                Session["nombre"] = usuarioLogueado.getNombre();
                Session["rol"] = rol;

                if (rol == "Administrador")
                {
                    Response.Redirect("../Secciones_administrador/MenuAdmin.aspx");
                }
                else
                {
                    if (rol == "Instructor")
                    {
                        Response.Redirect("../Instructor");
                    }
                    else
                    {
                        if (rol == "Trabajador")
                        {
                            Response.Redirect("../Secciones_trabajador/Menu.aspx");
                        }
                    }
                }

            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos";
            }
        }
    }
}