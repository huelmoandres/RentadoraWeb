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
    public partial class AltaClienteEmpresa : System.Web.UI.Page
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

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            this.lblError.Text = "";
            this.lblExito.Text = "";
            string nombre = this.txtNombre.Text;
            string telefono = this.txtTelefono.Text;
            int anio;
            int rut;
            string razonSocial = this.txtRazon.Text;
            
            if (!int.TryParse(this.txtAnio.Text, out anio))
            {
                this.lblError.Text = "El año debe ser un número.";
            }
            else if (!int.TryParse(this.txtRut.Text, out rut))
            {
                this.lblError.Text = "El RUT solo puede contener números.";
            }
            else
            {
                Empresa.ErroresAlta alta = Rentadora.Instancia.AltaEmpresa(telefono, anio, rut, razonSocial, nombre);
                if (alta == Empresa.ErroresAlta.ErrorNombre)
                {
                    this.lblError.Text = "Debe ingresar un nombre de contacto.";
                }
                else if (alta == Empresa.ErroresAlta.ErrorRut)
                {
                    this.lblError.Text = "Debe ingresar un número de RUT.";
                }
                else if (alta == Empresa.ErroresAlta.ErrorTelefono)
                {
                    this.lblError.Text = "Debe ingresar un teléfono.";
                }
                else if (alta == Empresa.ErroresAlta.ErrorAnioInicio)
                {
                    this.lblError.Text = "Debe ingresar un año de inicio.";
                }
                else if (alta == Empresa.ErroresAlta.ErrorRazonSocial)
                {
                    this.lblError.Text = "Debe ingresar razón social.";
                }
                else if (alta == Empresa.ErroresAlta.ErrorExiste)
                {
                    this.lblError.Text = "La empresa ya se encuentra en nuestros registros.";
                }
                else
                {
                    this.txtNombre.Text = "";
                    this.txtRut.Text = "";
                    this.txtAnio.Text = "";
                    this.txtTelefono.Text = "";
                    this.txtRazon.Text = "";
                    this.lblError.Text = "";
                    lblExito.Text = "Se ingresó el cliente correctamente.";
                }
            }
        }
    }
}