using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.IO;

namespace Aplicacion
{
    public class Rentadora
    {
        private static Rentadora instancia = new Rentadora();

        public static Rentadora Instancia
        {
            get
            {
                return instancia;
            }
        }

        private Rentadora() { }

        public void CargarDatosPrueba()
        {
            
        }

        #region Ingreso de usuarios
        public Usuario Login(string email, string pass)
        {
            return CUsuario.Instancia.Login(email, pass);
        }
        #endregion

        #region Controlador CCliente
        public Particular.ErroresAlta AltaParticular(string tel, int anio, string ci, string documento, string paisDoc, string nombre, string apellido)
        {
            return CCliente.Instancia.AltaParticular(tel, anio, ci, documento, paisDoc, nombre, apellido);
        }

        public Empresa.ErroresAlta AltaEmpresa(string tel, int anio, int rut, string razonSocial, string nombreContacto)
        {
            return CCliente.Instancia.AltaEmpresa(tel, anio, rut, razonSocial, nombreContacto);
        }
        #endregion

        #region Controlador CTipoVehiculo
        public void AltaTipoVehiculo(string marca, string modelo, double precioDiario)
        {
            CTipoVehiculo.Instancia.AltaTipoVehiculo(marca, modelo, precioDiario);
        }

        public List<TipoVehiculo> ListadoTipos()
        {
            return CTipoVehiculo.Instancia.ListadoTipos();
        }

        public List<TipoVehiculo> ObtenerModeloMismaMarca(string marca)
        {
            return CTipoVehiculo.Instancia.ObtenerModeloMismaMarca(marca);
        }
        #endregion

        #region Controlador CVehiculo
        public Vehiculo.ErroresAlta AltaVehiculo(string matricula, TipoVehiculo tipo, int anio, int kilometraje, string foto)
        {
            return CVehiculo.Instancia.AltaVehiculo(matricula, tipo, anio, kilometraje, foto);
        }
        #endregion

        #region Controlador CAlquiler
        public Alquiler.ErroresAlta AltaAlquiler(DateTime fechaInicio, DateTime fechaFinal, int horaInicio, int horaFinal, TipoVehiculo vehiculo, Cliente cliente)
        {
            return CAlquiler.Instancia.AltaAlquiler(fechaInicio, fechaFinal, horaInicio, horaFinal, vehiculo, cliente);
        }
        #endregion

        #region Metodos de lectura de archivos .txt
        public void LeerDatosTipoVehiculos(string rutaArchivo)
        {
            StreamReader str = null;
            try
            {
                str = new StreamReader(rutaArchivo);
                string linea = "";
                while ((linea = str.ReadLine()) != null)
                {
                    string[] datos = linea.Split('@');
                
                    string marca = datos[0];
                    string modelo = datos[1];
                    string precioDiario = datos[2];
                    CTipoVehiculo.Instancia.AltaTipoVehiculo(marca, modelo, Convert.ToDouble(precioDiario));
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (str != null)
                    str.Close();
            }

        }

        /*public void LeerDatosVehiculos(string rutaArchivo)
        {
            StreamReader str = null;
            try
            {
                str = new StreamReader(rutaArchivo);
                string linea = "";
                while ((linea = str.ReadLine()) != null)
                {
                    string[] datos = linea.Split('#');
                    string matricula = datos[0];
                    string marca = datos[1];
                    string modelo = datos[2];
                    string anio = datos[2];
                    string kilometraje = datos[2];
                    CTipoVehiculo.Instancia.AltaTipoVehiculo(marca, modelo, Convert.ToDouble(precioDiario));
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (str != null)
                    str.Close();
            }

        }*/
        #endregion
    }
}
