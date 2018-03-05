using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentadoraWeb
{
    public partial class PaginaPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                if ((byte)Session["rol"] == 0)
                {
                    this.menuAdmin.Visible = false;
                    this.menuGerente.Visible = false;
                }
                else if ((byte)Session["rol"] == 1)
                {
                    this.menuVendedor.Visible = false;
                    this.menuGerente.Visible = false;
                }
                else if ((byte)Session["rol"] == 2)
                {
                    this.menuVendedor.Visible = false;
                    this.menuAdmin.Visible = false;
                }
            }
            else
            {
                this.menuVendedor.Visible = false;
                this.menuAdmin.Visible = false;
                this.menuGerente.Visible = false;
            }
        }
    }
}