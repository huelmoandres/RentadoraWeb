using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentadoraWeb.Paginas
{
    public partial class AltaAlquilerDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                if ((byte)Session["rol"] == 0)
                {
                    if (Request.QueryString["doc"] != null && Request.QueryString["cliente"] != null &&
                            !string.IsNullOrEmpty(Request.QueryString["doc"].ToString()) && !string.IsNullOrEmpty(Request.QueryString["cliente"].ToString()))
                    {
                        Cliente c = null;
                        if (Request.QueryString["cliente"].ToString() == "particular")
                        {
                            c = Rentadora.Instancia.ExisteParticular(Request.QueryString["doc"].ToString());
                        }
                        else if (Request.QueryString["cliente"].ToString() == "empresa")
                        {
                            int rut;
                            if (int.TryParse(Request.QueryString["doc"].ToString(), out rut))
                            {
                                c = Rentadora.Instancia.ExisteEmpresa(rut);
                            }
                        }

                        if(c != null)
                        {
                            if (!IsPostBack)
                            {
                                List<TipoVehiculo> marcas = Rentadora.Instancia.ListadoTipos();
                                this.listMarca.DataTextField = "Marca";
                                this.listMarca.DataValueField = "Marca";
                                this.listMarca.DataSource = marcas;
                                this.listMarca.DataBind();
                                List<TipoVehiculo> modelos = Rentadora.Instancia.ObtenerModeloMismaMarca(this.listMarca.SelectedValue);
                                this.listModelo.DataTextField = "Modelo";
                                this.listModelo.DataValueField = "Modelo";
                                this.listModelo.DataSource = modelos;
                                this.listModelo.DataBind();
                                this.lblError.Text = "";
                                this.lblExito.Text = "";
                            }
                        }
                        else
                        {
                            Response.Redirect("AltaAlquiler.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("AltaAlquiler.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void listMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = this.listMarca.SelectedValue;
            if (option != "")
            {
                List<TipoVehiculo> modelos = Rentadora.Instancia.ObtenerModeloMismaMarca(option);
                this.listModelo.DataTextField = "Modelo";
                this.listModelo.DataValueField = "Modelo";
                this.listModelo.DataSource = modelos;
                this.listModelo.DataBind();
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["doc"] != null && Request.QueryString["cliente"] != null &&
                            !string.IsNullOrEmpty(Request.QueryString["doc"].ToString()) && !string.IsNullOrEmpty(Request.QueryString["cliente"].ToString()))
            {
                string cliente = Request.QueryString["cliente"].ToString();
                string documento = Request.QueryString["doc"].ToString();
                int rut;
                Cliente c = null;
                if (cliente == "particular")
                {
                    c = Rentadora.Instancia.ExisteParticular(documento);
                }
                else if (cliente == "empresa")
                {
                    if (int.TryParse(documento, out rut))
                    {
                        c = Rentadora.Instancia.ExisteEmpresa(rut);
                    } else
                    {

                    }
                }
                
                DateTime fechaInicio;
                DateTime fechaFin;
                int horaInicio;
                int horaEntrega;
                string marca = this.listMarca.SelectedValue;
                string modelo = this.listModelo.SelectedValue;
                TipoVehiculo tv = Rentadora.Instancia.ExisteTipo(marca, modelo);

                if (!DateTime.TryParse(this.fechaI.Text, out fechaInicio))
                {
                    this.lblError.Text = "Formato de fecha incorrecto.";
                }
                else if (!DateTime.TryParse(this.fechaE.Text, out fechaFin))
                {
                    this.lblError.Text = "Formato de fecha incorrecto.";
                }
                else if (!int.TryParse(this.txtHoraI.Text, out horaInicio))
                {
                    this.lblError.Text = "Formato de hora incorrecto.";
                }
                else if (!int.TryParse(this.txtHoraI.Text, out horaEntrega))
                {
                    this.lblError.Text = "Formato de hora incorrecto.";
                }
                else
                {
                    Alquiler.ErroresAlta alta = Rentadora.Instancia.AltaAlquiler(fechaInicio, fechaFin, horaInicio, horaEntrega, tv, c);
                    if (alta == Alquiler.ErroresAlta.ErrorFecha)
                    {
                        this.lblError.Text = "Debe ingresar una fecha correcta.";
                    }
                    else if (alta == Alquiler.ErroresAlta.ErrorHora)
                    {
                        this.lblError.Text = "Debe ingresar una hora entre 0 y 23.";
                    }
                    else if (alta == Alquiler.ErroresAlta.ErrorVehiculo)
                    {
                        this.lblError.Text = "El tipo de vehículo no existe.";
                    }
                    else if (alta == Alquiler.ErroresAlta.ErrorResponsable)
                    {
                        this.lblError.Text = "El cliente ingresado no existe.";
                    }
                    else
                    {
                        this.fechaI.Text = "";
                        this.fechaE.Text = "";
                        this.txtHoraI.Text = "";
                        this.txtHoraE.Text = "";
                        this.lblError.Text = "";
                        lblExito.Text = "Se ingresó alquiler correctamente.";
                    }
                }
            }
        }
    }
}