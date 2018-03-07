using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Aplicacion;
using System.Data;

namespace RentadoraWeb.Paginas
{
    public partial class ListadoVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                if ((byte)Session["rol"] != 2)
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
            this.txtError.Text = "";
            string rutaArchivo = HttpRuntime.AppDomainAppPath + @"Bitacoras\log.txt";
            List<Alquiler> alquilados = Rentadora.Instancia.VehiculosRetrasados();
            GvRetrasados.DataSource = alquilados;
            GvRetrasados.DataBind();
            if(alquilados != null)
            {
                string fecha = "";
                foreach(Alquiler a in alquilados)
                {
                    fecha = "" + a.FechaFinal.Year + a.FechaFinal.Month + a.FechaFinal.Day;
                    Rentadora.Instancia.GrabarLog(rutaArchivo, fecha, (string)Session["email"]);
                }
            }
            this.GvRetrasados.Visible = true;
        }

        protected void GvRetrasados_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtMsg.Text = "";
            this.txtError.Text = "";
            string mat = GvRetrasados.SelectedRow.Cells[0].Text;
            Alquiler al = Rentadora.Instancia.BuscarAlquiler(mat);
            if (al != null)
            {
                string faltante = "";
                double costoFaltante = 0;
                TimeSpan ts = DateTime.Today - al.FechaFinal;
                int cantidadDias = ts.Days;
                costoFaltante = al.Vehiculo.Tipo.PrecioDiario * cantidadDias;
                faltante = "<br />Costo faltante: " + costoFaltante + "<Br />";
                this.txtMsg.Text = al.ToString() + faltante;
            }
            else
            {
                this.txtError.Text = "No se encontró el alquiler";
                this.GvRetrasados.Visible = false;
            }
        }
    }
}