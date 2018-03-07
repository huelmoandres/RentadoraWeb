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
                                List<string> marcas = Rentadora.Instancia.MarcasSinRepetir();
                                this.listMarca.DataSource = marcas;
                                this.listMarca.DataBind();
                                List<TipoVehiculo> modelos = Rentadora.Instancia.ObtenerModeloMismaMarca(this.listMarca.SelectedValue);
                                this.listModelo.DataTextField = "Modelo";
                                this.listModelo.DataValueField = "Modelo";
                                this.listModelo.DataSource = modelos;
                                this.listModelo.DataBind();
                                this.lblError.Text = "";
                                this.lblExito.Text = "";
                                this.fechaI.Text = DateTime.Today.ToShortDateString();
                                this.fechaE.Text = DateTime.Today.ToShortDateString();
                                CargarGrilla();
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
            this.lblError.Text = "";
            this.lblExito.Text = "";
            this.GvDisponibles.Visible = false;
            string option = this.listMarca.SelectedValue;
            if (option != "")
            {
                List<TipoVehiculo> modelos = Rentadora.Instancia.ObtenerModeloMismaMarca(option);
                this.listModelo.DataTextField = "Modelo";
                this.listModelo.DataValueField = "Modelo";
                this.listModelo.DataSource = modelos;
                this.listModelo.DataBind();
                CargarGrilla();
            }
        }

        protected void listModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GvDisponibles.Visible = false;
            this.lblError.Text = "";
            this.lblExito.Text = "";
            string marca = this.listMarca.SelectedValue;
            string modelo = this.listModelo.SelectedValue;
            DateTime fechaI;
            DateTime fechaF;
            if (marca != "" && modelo != "")
            {
                if (DateTime.TryParse(this.fechaI.Text, out fechaI))
                {
                    if (DateTime.TryParse(this.fechaE.Text, out fechaF))
                    {
                        List<string> matriculas = Rentadora.Instancia.MatriculasPorMarcaModelo(marca, modelo);
                        List<string> disponibles = Rentadora.Instancia.MatriculasDisponibles(matriculas, fechaI, fechaF);
                        List<Vehiculo> vehiculos = Rentadora.Instancia.VehiculosDisponibles(disponibles);
                        if (vehiculos.Count > 0) {
                            this.lblError.Text = "";
                            this.GvDisponibles.DataSource = vehiculos;
                            this.GvDisponibles.DataBind();
                            this.GvDisponibles.Visible = true;
                        } else {
                            this.GvDisponibles.Visible = false;
                            this.lblError.Text = "No se encuentran vehículos disponibles para la marca: " + marca + ", modelo " + modelo;
                        }
                    }
                    else
                    {
                        this.lblError.Text = "Ingrese fecha correcta";
                    }
                }
                else
                {
                    this.lblError.Text = "Ingrese fecha correcta";
                }
            }
        }

        protected void GvDisponibles_SelectedIndexChanged(object sender, EventArgs e)
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
                string matricula = this.GvDisponibles.SelectedRow.Cells[0].Text;
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
                    Alquiler.ErroresAlta alta = Rentadora.Instancia.AltaAlquiler(fechaInicio, fechaFin, horaInicio, horaEntrega, tv, c, matricula);
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
                        this.GvDisponibles.Visible = false;
                        lblExito.Text = "Se ingresó alquiler correctamente.";
                    }
                }
            }
        }

        protected void CargarGrilla()
        {
            this.lblError.Text = "";
            this.GvDisponibles.Visible = false;
            lblExito.Text = "";
            string marca = this.listMarca.SelectedValue;
            string modelo = this.listModelo.SelectedValue;
            DateTime fechaI;
            DateTime fechaF;
            if (marca != "" && modelo != "")
            {
                if (DateTime.TryParse(this.fechaI.Text, out fechaI))
                {
                    if (DateTime.TryParse(this.fechaE.Text, out fechaF))
                    {
                        List<string> matriculas = Rentadora.Instancia.MatriculasPorMarcaModelo(marca, modelo);
                        List<string> disponibles = Rentadora.Instancia.MatriculasDisponibles(matriculas, fechaI, fechaF);
                        List<Vehiculo> vehiculos = Rentadora.Instancia.VehiculosDisponibles(disponibles);
                        if (vehiculos.Count > 0)
                        {
                            this.lblError.Text = "";
                            this.GvDisponibles.DataSource = vehiculos;
                            this.GvDisponibles.DataBind();
                            this.GvDisponibles.Visible = true;
                        }
                        else
                        {
                            this.lblError.Text = "No hay vehículos disponibles para esas fechas";
                        }
                    }
                    else
                    {
                        this.lblError.Text = "Ingrese fecha correcta";
                    }
                }
                else
                {
                    this.lblError.Text = "Ingrese fecha correcta";
                }
            }
        }
    }
}