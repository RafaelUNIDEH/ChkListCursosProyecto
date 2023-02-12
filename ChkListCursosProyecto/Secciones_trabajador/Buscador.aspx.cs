using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_trabajador
{
    public partial class Buscador : System.Web.UI.Page
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
        }

        [WebMethod]
        public static List<string> GetEmp(string empdetails)
        {
            
            List<string> emp = new List<string>();

            Curso sugerencias = new Curso();

            emp = sugerencias.Autocompeltado(empdetails);

            return emp;

        }

        public static string busqueda = "";
        protected void busqueda_Click(object sender, EventArgs e)
        {
            busqueda = palabra.Value;
            Response.Redirect("cursosdisponibles.aspx");
        }

        protected void VolverMenubus_Click(object sender, EventArgs e)
        {
            Response.Redirect("Opciones_busqueda.aspx");
        }

    }
}