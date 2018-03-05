using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aplicacion;
using Dominio;

namespace RentadoraWeb.Paginas
{
    public partial class AltaAlquilerParticular : System.Web.UI.Page
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
            else if((byte)Session["rol"] == 0)
            {
                string[] tipoDocumentos = Rentadora.Instancia.TipoDocumentos();
                this.dwTipoDocumento.DataSource = tipoDocumentos;
                this.dwTipoDocumento.DataBind();
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            this.lblError.Text = "";
            this.lblExito.Text = "";
            string nombre = this.txtNombre.Text;
            string apellido = this.txtApellido.Text;
            string telefono = this.txtTelefono.Text;
            int anio;
            string tipoDoc = this.dwTipoDocumento.SelectedValue;
            string ci = this.txtCi.Text;
            string paisDoc = this.txtPaisDoc.Text;
            

            if (!int.TryParse(this.txtAnio.Text, out anio))
            {
                this.lblError.Text = "Formato de año inválido.";
            }
            else
            {
                Particular.ErroresAlta alta = Rentadora.Instancia.AltaParticular(telefono, anio, ci, tipoDoc, paisDoc, nombre, apellido);
                if (alta == Particular.ErroresAlta.ErrorNombre)
                {
                    this.lblError.Text = "Debe ingresar un nombre.";
                }
                else if (alta == Particular.ErroresAlta.ErrorApellido)
                {
                    this.lblError.Text = "Debe ingresar un apellido.";
                }
                else if (alta == Particular.ErroresAlta.ErrorTelefono)
                {
                    this.lblError.Text = "Debe ingresar un teléfono.";
                }
                else if (alta == Particular.ErroresAlta.ErrorAnioInicio)
                {
                    this.lblError.Text = "Debe ingresar un año de inicio.";
                }
                else if (alta == Particular.ErroresAlta.ErrorDocumento)
                {
                    this.lblError.Text = "Tipo de documento inválido.";
                }
                else if (alta == Particular.ErroresAlta.ErrorCi)
                {
                    this.lblError.Text = "Documento ingresado incorrecto.";
                }
                else if (alta == Particular.ErroresAlta.ErrorPaisDoc)
                {
                    this.lblError.Text = "Debe ingresar el país del documento.";
                }
                else if (alta == Particular.ErroresAlta.ErrorExiste)
                {
                    this.lblError.Text = "El cliente ya se encuentra en nuestros registros.";
                }
                else
                {
                    this.txtNombre.Text = "";
                    this.txtApellido.Text = "";
                    this.txtAnio.Text = "";
                    this.txtTelefono.Text = "";
                    this.txtPaisDoc.Text = "";
                    this.txtCi.Text = "";
                    this.lblError.Text = "";
                    lblExito.Text = "Se ingresó el cliente correctamente.";
                }
            }
        }
    }
}