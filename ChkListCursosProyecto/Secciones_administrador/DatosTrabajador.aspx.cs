using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_administrador
{
    public partial class DatosTrabajador : System.Web.UI.Page
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

            if (!IsPostBack) {
                CargarAreas();

                if (GestionTrabajador.agregar != 1)
                {
                    if (TrabajadorAmodificar.modificar == 1)
                    {
                        cargarDatosAmodificar();
                        btnModificar.Visible = true;
                    }
                }
                else {
                    btnAgregar.Visible = true;
                }


            }
        }

        protected void CargarAreas() {
            Area list = new Area();

            DataSet ds = list.cargarDrowAreas();

            area.DataSource = ds;
            area.DataTextField = "NombreArea";
            area.DataValueField = "idArea";
            area.DataBind();
            area.Items.Insert(0, new ListItem("<Selecciona el area>", "0"));
        }

        public static int pagTrabajador = 0; 
        protected void btnAgregarTrabajador(object sender, EventArgs e)
        {
            if ((nombre.Text != "") && (numeroEmpleado.Text != "") && (area.Text != "0") && (correo.Text != "") && (contra.Text != "") && (confirmacionContra.Text != ""))
            {
                if (contra.Text == confirmacionContra.Text)
                {
                    Administrador datos = new Administrador();

                    string result = datos.InsertarEmpleado(nombre.Text, int.Parse(numeroEmpleado.Text), int.Parse(area.Text), correo.Text, contra.Text);

                    if (result == "correcto")
                    {
                        GestionTrabajador.agregar = 0;
                        pagTrabajador = 1;
                        Response.Redirect("ModificacionExitosa.aspx");
                    }
                    else {
                        msgerror.Text = result;
                        mostrarerror.Visible = true;
                    }

                }
                else {
                    msgerror.Text = "La contraseña no coincide";
                    mostrarerror.Visible = true;
                }
            }
            else {
                msgerror.Text = "Hay campos vacios, todos son necesarios";
                mostrarerror.Visible = true;
            }

        }

        protected void cargarDatosAmodificar() {
            Trabajador datos = new Trabajador(TrabajadorAmodificar.numTrabajador);

            nombre.Text = datos.getNombreEmpleado();
            numeroEmpleado.Enabled = true;
            numeroEmpleado.Text = datos.getNoEmpleado().ToString();
            numeroEmpleado.Enabled = false;
            area.SelectedValue = datos.getIdArea().ToString();
            correo.Text = datos.getEmail();
        }

        protected void btnModificarTrabajador(object sender, EventArgs e) {
            if ((nombre.Text != "") && (area.Text != "0") && (correo.Text != "") && (contra.Text != "") && (confirmacionContra.Text != ""))
            {
                if (contra.Text == confirmacionContra.Text)
                {
                    Trabajador datos = new Trabajador(TrabajadorAmodificar.numTrabajador);

                    Administrador datosAdmin = new Administrador();

                    string result = datosAdmin.ModificarEmpleado(nombre.Text, datos.getNoEmpleado(), int.Parse(area.Text), correo.Text, contra.Text,datos.getEmail());

                    if (result == "correcto")
                    {
                        TrabajadorAmodificar.modificar = 0;
                        pagTrabajador = 1;
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

        protected void VolverMenu_Click(object sender, EventArgs e)
        {
            GestionTrabajador.agregar = 0;
            TrabajadorAmodificar.modificar = 0;
            Response.Redirect("GestionTrabajador.aspx");
        }

        
    }
}