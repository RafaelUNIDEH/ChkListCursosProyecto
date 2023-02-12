using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_trabajador
{

    public partial class MisCursos : System.Web.UI.Page
    {
        public static StatusCurso cursos = new StatusCurso();
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
            if (!IsPostBack) {

                cursos.VerificarStatus(Session["nombre"].ToString());

                DataTable lista = cursos.MisCursos(Session["nombre"].ToString());

                /*
                //Crea la nueva columna con nombre y tipo de dato
                DataColumn newColumn = new DataColumn("Ver mas", typeof(System.String));
                //Asigna el valor por defecto para la columna

                newColumn.DefaultValue = "Boton";
                lista.Columns.Add(newColumn);

                */


                //this.adios.Attributes.Add("style", " background-color:black;");

                

                gvdmiscursos.DataSource = lista;
                gvdmiscursos.DataBind();
            }
        }

        protected void Vermas_Click(object sender, GridViewCommandEventArgs e)
        {
            int row = int.Parse(e.CommandArgument.ToString());
            //string id = gvdcurso.Rows[row-1].Cells[1].Text;

            if (e.CommandName == "Mostrar")
            {
                cursos.ModalMisCursos(row);

                lbempleado.Text = cursos.getNombreEmpleado();
                lbcurso.Text = cursos.getNombreCurso();
                lbinstructor.Text = cursos.getNombreInstructor();
                lbfechacapa.Text = cursos.getFechaInicio();
                lbfechavenc.Text = cursos.getVencimientoSting();
                lbstatus.Text = cursos.getStatus();

                if (cursos.getStatus()=="Aprobado") {
                    this.btnImprimir.Attributes.Add("style", " background-color:green; color:black");
                    this.btnImprimir.Disabled = false;
                }

                if (cursos.getStatus() == "Por vencer")
                {
                    this.btnImprimir.Attributes.Add("style", " background-color:yellow; color:black");
                    this.btnImprimir.Disabled = false;
                }

                if (cursos.getStatus() == "Vencido")
                {
                    this.btnImprimir.Attributes.Add("style", " background-color:red; color:black");
                    this.btnImprimir.Disabled = true;
                }


                string JavaScript = "modalMisCurso();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", JavaScript, true);

            }

        }

        protected void VolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}