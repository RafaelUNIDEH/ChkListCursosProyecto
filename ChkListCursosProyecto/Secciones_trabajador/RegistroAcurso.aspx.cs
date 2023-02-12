using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_trabajador
{
    public partial class RegistroAcurso : System.Web.UI.Page
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
                CargaCursos_combo();
            }
        }

        protected void VolverMenubus_Click(object sender, EventArgs e)
        {
            Response.Redirect("Opciones_busqueda.aspx");
        }

        public static int id_global = 0;
        protected void CargaCursos_combo()
        {
            Curso list = new Curso();

            DataSet ds = list.cargarDrowDownList();

            DDLCursos.DataSource = ds;
            DDLCursos.DataTextField = "NombreCurso";
            DDLCursos.DataValueField = "idCurso";
            DDLCursos.DataBind();
            DDLCursos.Items.Insert(0, new ListItem("<Selecciona el curso deseado>", "0"));

        }

        protected void Registrar(object sender, EventArgs e)
        {
            if (DDLCursos.Text == "0")
            {
                string JavaScript = "Selecciona_curso();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", JavaScript, true);
            }
            else
            {
                id_global = int.Parse(DDLCursos.Text);
                Response.Redirect("Registrar.aspx");
            }

        }
    }
}