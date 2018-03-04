using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aplicacion;

namespace RentadoraWeb.Paginas
{
    public partial class ListadoTipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gvTipos.DataSource = Rentadora.Instancia.ListadoTipos();
            this.gvTipos.DataBind();
        }
    }
}