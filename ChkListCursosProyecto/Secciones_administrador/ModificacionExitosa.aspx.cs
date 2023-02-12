using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_administrador
{
    public partial class ModificacionExitosa : System.Web.UI.Page
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

            Volver();
        }

        public static int user;
        public void Volver()
        {
            if (DatosTrabajador.pagTrabajador == 1 || TrabajadorAeliminar.pagTrabajador == 1)
            {
                DatosTrabajador.pagTrabajador = 0;
                TrabajadorAeliminar.pagTrabajador = 0;

                user = 1;

            }

            if (DatosInstructor.pagInstructor == 1 || GestionInstructor.pagInstructor == 1)
            {
                DatosInstructor.pagInstructor = 0;
                GestionInstructor.pagInstructor = 0;

                user = 2;
            }

            if (DatosAdministrador.pagAdministrador == 1 || GestionAdministrador.pagAdministrador == 1)
            {
                DatosAdministrador.pagAdministrador = 0;
                GestionAdministrador.pagAdministrador = 0;

                user = 3;

            }

            if (DatosCurso.pagCurso == 1 || GestionCurso.pagCurso == 1)
            {
                DatosCurso.pagCurso = 0;
                GestionCurso.pagCurso = 0;

                user = 4;

            }

        }

        public int Codigo
        {
            get { return user; }

        }
    }
}