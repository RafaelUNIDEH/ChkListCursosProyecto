using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_instructor
{
    public partial class InicioInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CargarDrow();
            }
        }

        public static int idCurso;
        protected void CargarDrow() {
            Instructor obtener = new Instructor();

            DataSet listasInst = obtener.CargarCursosAsigados(int.Parse(Session["id"].ToString()));

            DDLCursosInpartidos.DataSource = listasInst;
            DDLCursosInpartidos.DataTextField = "NombreCurso";
            DDLCursosInpartidos.DataValueField = "idCurso";
            DDLCursosInpartidos.DataBind();
            DDLCursosInpartidos.Items.Insert(0, new ListItem("<Selecciona Curso a calificar>", "0"));

        }

        protected void btnAceptar() {
            idCurso = int.Parse(DDLCursosInpartidos.Text);
            Response.Redirect("AsignacionCalificacion.aspx");

        }
    }
}