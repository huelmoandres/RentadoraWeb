using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Aplicacion;

namespace RentadoraWeb.Paginas
{
    public partial class ListadoDevolucion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario"] != null)
            {
                if ((byte)Session["rol"] != 0)
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void txtButton_Click(object sender, EventArgs e)
        {
            this.txtMsg.Text = "";
            string mat = this.txtMatricula.Text;
            Alquiler al = Rentadora.Instancia.BuscarAlquiler(mat);
            if (al != null)
            {
                string faltante = "";
                if (DateTime.Today > al.FechaFinal && !al.Devuelto)
                {
                    al.Devuelto = true;
                    double costoFaltante = 0;
                    TimeSpan ts = DateTime.Today - al.FechaFinal;
                    int cantidadDias = ts.Days;
                    costoFaltante = al.Vehiculo.PrecioDiario * cantidadDias;
                    faltante = "Costo faltante: " + costoFaltante + "/n";
                }
                this.txtMsg.Text = al.ToString() + faltante;
            }
            else
            {
                this.txtMsg.Text = "No se encontró el alquiler";
            }
        }
    }
}