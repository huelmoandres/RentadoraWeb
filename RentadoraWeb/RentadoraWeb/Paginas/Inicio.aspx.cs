using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentadoraWeb.Paginas
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                this.txtBienvenida.InnerText = "Bienvenido " + Session["email"].ToString();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}