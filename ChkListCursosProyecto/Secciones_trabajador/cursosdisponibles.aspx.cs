using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Policy;

namespace ChkListCursosProyecto.Secciones_trabajador
{
    public partial class cursosdisponibles : System.Web.UI.Page
    {
        public static Curso result = new Curso();
        public static string bus = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] != null)
            {
                if (Session["rol"].ToString() != "Trabajador")
                {
                    Response.Redirect("../AccesoTrabajador/Login.aspx");
                }                
            }
            else {
                Response.Redirect("../AccesoTrabajador/Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Buscador.busqueda != "")
                {
                    bus = Buscador.busqueda;
                    Buscador.busqueda = "";

                    DataTable lista = result.Busqueda(bus);

                    gvdcurso.DataSource = lista;
                    gvdcurso.DataBind();

                }
                else
                {
                    DataTable lista = result.CursosDisponibles(); 

                    gvdcurso.DataSource = lista;
                    gvdcurso.DataBind();

                }
            }
        }

        protected void VolverMenuTra_Click(object sender, EventArgs e)
        {
            if (bus == "")
            {
                Response.Redirect("Menu.aspx");
            }
            else
            {
                bus = "";
                Response.Redirect("Buscador.aspx");
            }
        }


        public static int id_global = 0;
        public static int id_global_bus = 0;
        public static int id_previa;
        //System.Web.UI.WebControls.GridViewCommandEventArgs e
        protected void Vermas_Click(object sender, GridViewCommandEventArgs e)
        {
            int row = int.Parse(e.CommandArgument.ToString());
            //string id = gvdcurso.Rows[row-1].Cells[1].Text;

            if (e.CommandName == "Mostrar")
            {
                result.DatosModal(row);

                Instructor capcitador = new Instructor(result.getIdInstructor());

                lbcurso.Text = result.getNombreCurso();
                lbinstructor.Text = capcitador.getNombreInstructor();
                lbdirigidoa.Text = result.getDirigidoA();
                lblugaresdisp.Text = result.getCapacidad().ToString();
                lbfecha.Text = result.getFechaInicio();
                lbhora.Text = result.getHora();
                lbduracion.Text = result.getDuracion();

                id_previa = row;


                string JavaScript = "java();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", JavaScript, true);

            }

        }

        protected void Registrar(object sender, EventArgs e)
        {
            if (bus == "")
            {
                id_global = id_previa;
            }
            else
            {
                id_global_bus = id_previa;
            }

            Response.Redirect("Registrar.aspx");
        }


    }
}