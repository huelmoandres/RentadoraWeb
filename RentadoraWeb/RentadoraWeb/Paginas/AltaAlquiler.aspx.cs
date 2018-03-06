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
    public partial class AltaAlquiler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            else if ((byte)Session["rol"] == 1 || (byte)Session["rol"] == 2)
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        protected void btnVerificarUsuario_Click(object sender, EventArgs e)
        {
            string opcion = this.dwTipoCliente.SelectedValue;
            string documento = this.txtBuscarUsuario.Text;
            int rut;
            if(opcion == "Particular")
            {
                if(Rentadora.Instancia.ExisteParticular(documento) != null)
                {
                    Response.Redirect("AltaAlquilerDatos.aspx?doc=" + documento + "&cliente=particular");
                }
                else
                {
                    this.lblError.Text = "No se encontró un cliente particular con documento: " + documento;
                }
            }
            else if(opcion == "Empresa")
            {
                if (!int.TryParse(this.txtBuscarUsuario.Text, out rut))
                {
                    this.lblError.Text = "Formato de RUT inválido.";
                }
                else if (Rentadora.Instancia.ExisteEmpresa(rut) != null)
                {
                    Response.Redirect("AltaAlquilerDatos.aspx?rut=" + rut + "&cliente=empresa");
                }
                else
                {
                    this.lblError.Text = "No se encontró una empresa con RUT: " + rut;
                }
            }
        }
    }
}