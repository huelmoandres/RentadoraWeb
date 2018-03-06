using Aplicacion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;


namespace RentadoraWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            string rutaArchivo = HttpRuntime.AppDomainAppPath + @"Binario\serial.bin";
            string rutaArchivoTipos = HttpRuntime.AppDomainAppPath + @"Vehiculos\tipos.txt";
            string rutaArchivoVehiculos = HttpRuntime.AppDomainAppPath + @"Vehiculos\vehiculos.txt";
            if (File.Exists(rutaArchivo))
            {
                Repositorio rep = new Repositorio(rutaArchivo);
                rep.Deserealizable();
            }
            else
            {
                Rentadora.Instancia.CargarDatosPrueba();
            }

            if (File.Exists(rutaArchivoTipos))
            {
                Rentadora.Instancia.LeerDatosTipoVehiculos(rutaArchivoTipos);
            }
            if (File.Exists(rutaArchivoVehiculos))
            {
                Rentadora.Instancia.LeerDatosVehiculos(rutaArchivoVehiculos);
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            Repositorio rep = new Repositorio(HttpRuntime.AppDomainAppPath + @"Binario\serial.bin");
            rep.Serializable();
        }
    }
}