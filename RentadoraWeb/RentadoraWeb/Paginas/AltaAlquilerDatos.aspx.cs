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
            //if (Session["usuario"] != null)
            //{
            //    if ((byte)Session["rol"] == 0)
            //    {
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
            }
            //    }
            //    else
            //    {
            //        Response.Redirect("Inicio.aspx");
            //    }
            //}
            //else
            //{
            //    Response.Redirect("Login.aspx");
            //}
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
    }
}