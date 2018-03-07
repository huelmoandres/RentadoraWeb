using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace RentadoraWeb.Paginas
{
    public partial class ListadoVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Alquiler> alquileres = CAlquiler.Instancia.ListadoAlquileres();
            GvDisponibles.DataSource = alquileres;
            GvDisponibles.DataBind();
        }
    }
}