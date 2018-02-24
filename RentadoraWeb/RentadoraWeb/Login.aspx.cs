using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentadoraWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    Session["email"] = u.Email;
                    Session["rol"] = u.Rol;
                    if (u.Rol == 1)
                    {
                        Organizador o = (Organizador)u;
                        Session["nombre"] = o.Nombre;
                    }
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    this.lblError.Text = "Usuario y/o contraseña inválido";
                }
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {

        }
    }
}