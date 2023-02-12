using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_administrador
{
    public partial class DatosInstructor : System.Web.UI.Page
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

                if (GestionInstructor.agregar != 1)
                {
                    if (GestionInstructor.modificar == 1)
                    {
                        btnModificar.Visible = true;
                        CargarDatos();
                    }
                }
                else
                {
                    Ingresar.Visible = true;
                }

            }
        }

        public static int pagInstructor = 0;
        protected void AgregarInstructor(object sender, EventArgs e) {
            if ((nombre.Text != "") && (numeroInstructor.Text != "") &&  (correo.Text != "") && (contra.Text != "") && (confirmacionContra.Text != ""))
            {
                if (contra.Text == confirmacionContra.Text)
                {
                    Administrador datos = new Administrador();

                    string result = datos.InsertarInstructor(nombre.Text, int.Parse(numeroInstructor.Text), correo.Text, contra.Text);

                    if (result == "correcto")
                    {
                        GestionInstructor.agregar = 0;
                        pagInstructor = 1;
                        Response.Redirect("ModificacionExitosa.aspx");
                    }
                    else
                    {
                        msgerror.Text = result;
                        mostrarerror.Visible = true;
                    }

                }
                else
                {
                    msgerror.Text = "La contraseña no coincide";
                    mostrarerror.Visible = true;
                }
            }
            else
            {
                msgerror.Text = "Hay campos vacios, todos son necesarios";
                mostrarerror.Visible = true;
            }
        }

        protected void CargarDatos()
        {
            Instructor datos = new Instructor(GestionInstructor.idInstructor);

            nombre.Text = datos.getNombreInstructor();
            numeroInstructor.Enabled = true;
            numeroInstructor.Text = datos.getNoInstructor().ToString();
            numeroInstructor.Enabled = false;
            correo.Text = datos.getEmail();

        }

        protected void ModificarInstructor(object sender, EventArgs e) {
            if ((nombre.Text != "") && (correo.Text != "") && (contra.Text != "") && (confirmacionContra.Text != ""))
            {
                if (contra.Text == confirmacionContra.Text)
                {
                    Instructor datos = new Instructor(GestionInstructor.idInstructor);
                    Administrador datosadmin = new Administrador();

                    string result = datosadmin.ModificarInstructor(datos.getIdInstructor(), nombre.Text, int.Parse(numeroInstructor.Text), correo.Text, contra.Text,datos.getEmail());

                    if (result == "correcto")
                    {
                        GestionInstructor.modificar = 0;
                        pagInstructor = 1;
                        Response.Redirect("ModificacionExitosa.aspx");
                    }
                    else
                    {
                        msgerror.Text = result;
                        mostrarerror.Visible = true;
                    }

                }
                else
                {
                    msgerror.Text = "La contraseña no coincide";
                    mostrarerror.Visible = true;
                }
            }
            else
            {
                msgerror.Text = "Hay campos vacios, todos son necesarios";
                mostrarerror.Visible = true;
            }
        }

        protected void CancelarClick(object sender, EventArgs e)
        {
            GestionInstructor.agregar = 0;
            GestionInstructor.modificar = 0;
            Response.Redirect("GestionInstructor.aspx");
        }
    }
}