    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aplicacion;
using Dominio;

namespace RentadoraWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario"] != null)
            {
                Response.Redirect("Paginas/Inicio.aspx");
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usu = this.txtUsuario.Text;
            string pass = this.txtPass.Text;
            if (usu != "" && pass != "")
            {
                Usuario u = Rentadora.Instancia.Login(usu, pass);
                
                if (u != null)
                {
                    Session["usuario"] = u;
                    Session["email"] = u.Mail;
                    Session["rol"] = u.Rol;
                    Response.Redirect("Paginas/Inicio.aspx");
                }
                else
                {
                    this.lblError.Text = "Usuario y/o contraseña inválido";
                }
            }
        }
    }
}