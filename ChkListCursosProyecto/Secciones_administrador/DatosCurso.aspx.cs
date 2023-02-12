using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ChkListCursosProyecto.Secciones_administrador
{
    public partial class DatosCurso : System.Web.UI.Page
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

            if (!IsPostBack)
            {

                if (GestionCurso.agregar != 1)
                {
                    if (GestionCurso.modificar == 1)
                    {
                        btnModificar.Visible = true;
                        CargarDrows();
                        CargarDatos();
                    }
                }
                else
                {
                    CargarDrows();
                    Ingresar.Visible = true;
                }

                

            }
        }

        protected void CargarDrows()
        {
            Instructor Instructores = new Instructor();
            DataSet listasInst = Instructores.cargarDrowinstructores();

            nombreInstructor.DataSource = listasInst;
            nombreInstructor.DataTextField = "NombreInstructor";
            nombreInstructor.DataValueField = "idInstructor";
            nombreInstructor.DataBind();
            nombreInstructor.Items.Insert(0, new ListItem("<Selecciona al instructor>", "0"));


            Area list = new Area();
            DataSet ds = list.cargarDrowAreas();

            int i = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i++;
            }

            area.DataSource = ds;
            area.DataTextField = "NombreArea";
            area.DataValueField = "NombreArea";
            area.DataBind();
            area.Items.Insert(0, new ListItem("<Selecciona el area>", "0"));
            area.Items.Insert(i+1, new ListItem("Todos", "Todos"));

        }

        public static int pagCurso = 0;
        protected void AgregarCurso(object sender, EventArgs e)
        {
            if ((nombre.Text != "") && (nombreInstructor.Text != "") && (capacidad.Text != "") && (duracion.Text != "") && (area.Text != "0") && (fecha.Text != "") && (hora.Text != ""))
            {
                Administrador datos = new Administrador();
                
                datos.InsertarCurso(nombre.Text,int.Parse(nombreInstructor.Text),int.Parse(capacidad.Text),duracion.Text, DateTime.Parse(fecha.Text),area.Text,hora.Text);

                GestionCurso.agregar = 0;
                pagCurso = 1;
                Response.Redirect("ModificacionExitosa.aspx");
            }
            else
            {
                msgerror.Text = "Hay campos vacios, todos son necesarios";
                mostrarerror.Visible = true;
            }
        }

        protected void CargarDatos()
        {
            Curso datos = new Curso(GestionCurso.idCurso);

            nombre.Text = datos.getNombreCurso();
            nombreInstructor.Text = datos.getIdInstructor().ToString();
            capacidad.Text = datos.getCapacidad().ToString();
            duracion.Text = datos.getDuracion();
            area.Text = datos.getDirigidoA();
            fecha.Text = datos.getFechaInicio();
            hora.Text = datos.getHora();

        }

        protected void ModificarInstructor(object sender, EventArgs e)
        {
            if ((nombre.Text != "") && (nombreInstructor.Text != "") && (capacidad.Text != "") && (duracion.Text != "") && (area.Text != "0") && (fecha.Text != "") && (hora.Text != ""))
            {
                
                Administrador datosadmin = new Administrador();

                datosadmin.ModificarCurso(GestionCurso.idCurso, nombre.Text, int.Parse(nombreInstructor.Text), int.Parse(capacidad.Text), duracion.Text, DateTime.Parse(fecha.Text), area.Text, hora.Text);

                GestionCurso.idCurso = 0;
                pagCurso = 1; 
                Response.Redirect("ModificacionExitosa.aspx");
            }
            else
            {
                msgerror.Text = "Hay campos vacios, todos son necesarios";
                mostrarerror.Visible = true;
            }
        }

        protected void CancelarClick(object sender, EventArgs e)
        {
            GestionCurso.agregar = 0;
            GestionCurso.modificar = 0;
            Response.Redirect("GestionCurso.aspx");
        }


    }
}