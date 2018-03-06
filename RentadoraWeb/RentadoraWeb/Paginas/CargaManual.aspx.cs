using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aplicacion;

namespace RentadoraWeb.Paginas
{
    public partial class CargaManual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            else if ((byte)Session["rol"] == 0 || (byte)Session["rol"] == 2)
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        protected void btnCargaTipos_Click(object sender, EventArgs e)
        {
            string rutaArchivoTipos = HttpRuntime.AppDomainAppPath + @"Vehiculos\tipos.txt";
            Rentadora.Instancia.LeerDatosTipoVehiculos(rutaArchivoTipos);
            this.lblExito.Text = "¡Carga de tipo de vehículos realizada correctamente!";
        }

        protected void btnCargaVehiculos_Click(object sender, EventArgs e)
        {
            string rutaArchivoVehiculos = HttpRuntime.AppDomainAppPath + @"Vehiculos\vehiculos.txt";
            Rentadora.Instancia.LeerDatosVehiculos(rutaArchivoVehiculos);
            this.lblExito.Text = "¡Carga de vehículos realizada correctamente!";
        }
    }
}