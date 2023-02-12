using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto.Secciones_trabajador
{
    public partial class VerQR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CargarQR();
            }
        }

        public static string url;
        public void CargarQR() {

            string nombre = Session["nombre"].ToString();
            int id = int.Parse(Session["id"].ToString());

            Trabajador user = new Trabajador();

            url = user.ConsultarQR(id);

            nombreuser.InnerText = nombre;
            codigo.Src = url;
            descargar.HRef = url;
            this.descargar.Attributes.Add("Download", nombre + " QR");

        }

        public void VolverMenu_Click() {
            Response.Redirect("Menu.aspx");
        }

        protected void Volver_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        
    }
}