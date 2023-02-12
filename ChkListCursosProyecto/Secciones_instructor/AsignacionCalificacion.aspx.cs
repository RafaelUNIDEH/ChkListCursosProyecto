using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ChkListCursosProyecto.Secciones_instructor
{
    public partial class AsignacionCalificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {
                CargarGrid();
            }
        }

        protected void CargarGrid() {

            Instructor participantes = new Instructor();
            DataTable lista = participantes.ParticipantesCurso(InicioInstructor.idCurso);

            PaticipantesCurso.DataSource = lista;
            PaticipantesCurso.DataBind();

        }

        protected void btnAceptar_Click() {
            DataTable dt = new DataTable();
            dt = PaticipantesCurso.DataSource as DataTable;

            Instructor Calificar = new Instructor();

            Calificar.AsignarCalificacion(dt);

            Response.Redirect("ConfirmacionExito.aspx");

        }
    }
}