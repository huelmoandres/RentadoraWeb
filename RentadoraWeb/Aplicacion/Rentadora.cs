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
            this.AltaUsuario("vendedor1", "vendedor1", 0);
            this.AltaUsuario("vendedor2", "vendedor2", 0);
            this.AltaUsuario("administrador1", "administrador1", 1);
            this.AltaUsuario("administrador2", "administrador2", 1);
            this.AltaUsuario("gerente1", "gerente1", 2);
            this.AltaUsuario("gerente2", "gerente2", 2);
            this.AltaParticular("091383578", 1996, "46801321", "Cedula", "Uruguay", "Andres", "Huelmo");
            this.AltaAlquiler(Convert.ToDateTime("06/03/2018"), Convert.ToDateTime("16/03/2018"), 0, 20, ExisteTipo("Fiat", "Uno"), ExisteParticular("46801321"), "123456");
        }

        #region Ingreso de usuarios
        public Usuario Login(string email, string pass)
        {
            return CUsuario.Instancia.Login(email, pass);
        }
        #endregion

        #region Controlador CUsuario
        public Usuario.ErroresAlta AltaUsuario(string mail, string pass, byte rol)
        {
            return CUsuario.Instancia.AltaUsuario(mail, pass, rol);
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

        public Particular ExisteParticular(string ci)
        {
            return CCliente.Instancia.ExisteParticular(ci);
        }

        public Empresa ExisteEmpresa(int rut)
        {
            return CCliente.Instancia.ExisteEmpresa(rut);
        }

        public string[] TipoDocumentos()
        {
            return CCliente.Instancia.TipoDocumentos();
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

        public TipoVehiculo ExisteTipo(string marca, string modelo)
        {
            return CTipoVehiculo.Instancia.ExisteTipo(marca, modelo);
        }
        #endregion

        #region Controlador CVehiculo
        public Vehiculo.ErroresAlta AltaVehiculo(string matricula, TipoVehiculo tipo, int anio, int kilometraje, List<string> fotos)
        {
            return CVehiculo.Instancia.AltaVehiculo(matricula, tipo, anio, kilometraje, fotos);
        }

        public List<string> MatriculasPorMarcaModelo(string marca, string modelo)
        {
            return CVehiculo.Instancia.MatriculasPorMarcaModelo(marca, modelo);
        }

        public List<Vehiculo> VehiculosDisponibles(List<string> matriculas)
        {
            return CVehiculo.Instancia.VehiculosDisponibles(matriculas);
        }
        #endregion

        #region Controlador CAlquiler
        public Alquiler.ErroresAlta AltaAlquiler(DateTime fechaInicio, DateTime fechaFinal, int horaInicio, int horaFinal, TipoVehiculo vehiculo, Cliente cliente, string matricula)
        {
            return CAlquiler.Instancia.AltaAlquiler(fechaInicio, fechaFinal, horaInicio, horaFinal, vehiculo, cliente, matricula);
        }

        public List<string> MatriculasDisponibles(List<string> matriculas, DateTime fechaI, DateTime fechaF)
        {
            return CAlquiler.Instancia.MatriculasDisponibles(matriculas, fechaI, fechaF);
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

        public void LeerDatosVehiculos(string rutaArchivo)
        {
            StreamReader str = null;
            try
            {
                str = new StreamReader(rutaArchivo);
                string linea = "";
                while ((linea = str.ReadLine()) != null)
                {
                    string[] datos = linea.Split('@');
                    string[] datosFotos = datos[5].Split('#');
                    List<string> fotos = new List<string>();
                    string matricula = datos[0];
                    string marca = datos[1];
                    string modelo = datos[2];
                    int anio;
                    int kilometraje;
                    TipoVehiculo tipo = this.ExisteTipo(marca, modelo);
                    if(int.TryParse(datos[3], out anio))
                    {
                        if (int.TryParse(datos[4], out kilometraje))
                        {
                            for (int i = 0; i < datosFotos.Length; i++)
                            {
                                fotos.Add(datosFotos[i]);
                            }
                            CVehiculo.Instancia.AltaVehiculo(matricula, tipo, anio, kilometraje, fotos);
                        }
                    }
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
        #endregion
    }
}
