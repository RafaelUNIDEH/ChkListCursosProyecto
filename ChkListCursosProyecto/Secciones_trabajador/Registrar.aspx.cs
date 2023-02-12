using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_trabajador
{
    public partial class Registrar : System.Web.UI.Page
    {
        public static string reg_nom;
        public static string reg_fecha;
        public static string reg_hora;

        public static int id_curso = 0;
        public static int id_empleado = 0;

        public static int page = 0;
        public static int idInstructor = 0;
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

                if (cursosdisponibles.id_global.ToString() != "0")
                {
                    idInstructor = cursosdisponibles.id_global;
                    cursosdisponibles.id_global = 0;
                    page = 1;
                }
                else
                {
                    if (cursosdisponibles.id_global_bus.ToString() != "0")
                    {
                        idInstructor = cursosdisponibles.id_global_bus;
                        cursosdisponibles.id_global_bus = 0;
                        page = 2;
                    }
                    else
                    {
                        if (RegistroAcurso.id_global.ToString() != "0")
                        {
                            idInstructor = RegistroAcurso.id_global;
                            RegistroAcurso.id_global = 0;
                            page = 3;
                        }
                    }
                }

                Curso datosCurso = new Curso(idInstructor);
                Trabajador datosTrabajador = new Trabajador((int)Session["id"],"");
                Instructor datosIntructor = new Instructor(datosCurso.getIdInstructor());

                string nombreUsuario = datosTrabajador.getNombreEmpleado();
                string nombreInstructor = datosIntructor.getNombreInstructor();

                lbname.Text = nombreUsuario;
                lbcurso.Text = datosCurso.getNombreCurso();
                lbinstructor.Text = datosIntructor.getNombreInstructor();
                lbdirigidoa.Text = datosCurso.getDirigidoA();
                lblugaresdisp.Text = datosCurso.getCapacidad().ToString();
                lbfecha.Text = datosCurso.getFechaInicio();
                lbhora.Text = datosCurso.getHora();
                lbduracion.Text = datosCurso.getDuracion();

                reg_nom = nombreUsuario;
                reg_fecha = datosCurso.getFechaInicio();
                reg_hora = datosCurso.getHora();

                id_curso = datosCurso.getIdCurso();
                id_empleado = datosTrabajador.getIdEmpleado();

            }

        }

        protected void confirmar_registro(object sender, EventArgs e)
        {
            Curso datosCurso = new Curso(idInstructor);
            RegistroCurso validacion = new RegistroCurso();

            if (validacion.ComprobarNoRegistro(id_empleado, id_curso)) {
                if (validacion.RestarLugar(id_curso))
                {
                    if (validacion.RealizarRgistro(id_empleado,id_curso, datosCurso.getIdInstructor()))
                    {
                        Response.Redirect("registroCorrecto.aspx");
                    }
                    else {
                        string JavaScript = "msj_error_registrar_a_curso();";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", JavaScript, true);
                    }
                }
                else {
                    string JavaScript = "msj_error_disminuir_capacidad();";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", JavaScript, true);
                }
            }
            else {
                string JavaScript = "msj_error_registro_a_curso();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", JavaScript, true);
            }
        }

        protected void Cancelar(object sender, EventArgs e)
        {
            if (page == 1)
            {
                Response.Redirect("cursosdisponibles.aspx");
            }
            else
            {
                if (page == 2)
                {
                    Response.Redirect("Buscador.aspx");
                }
                else
                {
                    if (page == 3)
                    {
                        Response.Redirect("RegistroAcurso.aspx");
                    }
                }
            }

        }

    }
}