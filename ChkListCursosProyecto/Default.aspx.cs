using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChkListCursosProyecto
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void irLoguin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccesoTrabajador/Login.aspx");
        }

    }
}