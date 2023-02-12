using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_administrador
{
    public partial class DatosAdministrador : System.Web.UI.Page
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

                if (GestionAdministrador.agregar != 1)
                {
                    if (GestionAdministrador.modificar == 1)
                    {
                        btnModificar.Visible = true;
                        CargarAreas();
                        CargarDatos();
                    }
                }
                else
                {
                    Ingresar.Visible = true;
                    CargarAreas();
                }

            }
        }

        protected void CargarAreas()
        {
            Area list = new Area();

            DataSet ds = list.cargarDrowAreas();

            area.DataSource = ds;
            area.DataTextField = "NombreArea";
            area.DataValueField = "idArea";
            area.DataBind();
            area.Items.Insert(0, new ListItem("<Selecciona el area>", "0"));
        }

        public static int pagAdministrador = 0;
        protected void AgregarAdministrador(object sender, EventArgs e)
        {
            if ((nombre.Text != "") && (numEmpleado.Text != "") && (area.Text != "") && (correo.Text != "") && (contra.Text != "") && (confirmacionContra.Text != ""))
            {
                if (contra.Text == confirmacionContra.Text)
                {
                    Administrador datos = new Administrador();

                    string result = datos.InsertarAdministrador(nombre.Text, int.Parse(numEmpleado.Text),int.Parse(area.Text), correo.Text, contra.Text);

                    if (result == "correcto")
                    {
                        GestionAdministrador.agregar = 0;
                        pagAdministrador = 1;
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
            Administrador datos = new Administrador(GestionAdministrador.idAdmin);

            nombre.Text = datos.getNombreAdministrador();
            numEmpleado.Enabled = true;
            numEmpleado.Text = datos.getNoEmpleado().ToString();
            numEmpleado.Enabled = false;
            area.Text = datos.getIdArea().ToString();
            correo.Text = datos.getEmail();

        }

        protected void ModificarAdministrador(object sender, EventArgs e)
        {
            if ((nombre.Text != "") && (numEmpleado.Text != "") && (correo.Text != "") && (contra.Text != "") && (confirmacionContra.Text != ""))
            {
                if (contra.Text == confirmacionContra.Text)
                {
                    Administrador datos = new Administrador(GestionAdministrador.idAdmin);
                    Administrador datosadmin = new Administrador();

                    string result = datosadmin.ModificarAdministrador(datos.getIdAdministrador(), nombre.Text, datos.getNoEmpleado(), int.Parse(area.Text),correo.Text,contra.Text,datos.getEmail());

                    if (result == "correcto")
                    {
                        GestionAdministrador.modificar = 0;
                        pagAdministrador = 1;
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
            GestionAdministrador.agregar = 0;
            GestionAdministrador.modificar = 0;
            Response.Redirect("GestionAdministrador.aspx");
        }
    }
}