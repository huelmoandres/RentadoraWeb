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
            this.AltaParticular("098517013", 2018, "54004599", "Cedula", "Argentina", "Agustin", "Huelmo");
            this.AltaParticular("091816497", 1999, "86224975", "Cedula", "Paraguay", "Juan", "Perez");
            this.AltaParticular("091383578", 2007, "18006782", "Cedula", "Ecuador", "Gabriel", "Garcia");
            this.AltaParticular("091383578", 2011, "23459631", "Cedula", "Uruguay", "Jose", "Fernandez");
            this.AltaEmpresa("2408509", 2012, 591025479, "SomosLoQueSomos", "Juan");
            this.AltaEmpresa("2809506", 2017, 184357824, "MotelWA", "William");
            this.AltaEmpresa("2428716", 2016, 347821354, "Ferreteria", "Pedro");
            this.AltaEmpresa("2843657", 1998, 952147856, "Panaderia", "Pocho");
            this.AltaEmpresa("2762558", 2011, 842164865, "Supermercado", "Sonia");
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

        public List<string> MarcasSinRepetir()
        {
            return CTipoVehiculo.Instancia.MarcasSinRepetir();
        }
        #endregion

        #region Controlador CVehiculo
        public Vehiculo.ErroresAlta AltaVehiculo(string matricula, TipoVehiculo tipo, int anio, int kilometraje, List<string> fotos)
        {
            return CVehiculo.Instancia.AltaVehiculo(matricula, tipo, anio, kilometraje, fotos);
        }

        public Vehiculo ExisteVehiculo(string matricula)
        {
            return CVehiculo.Instancia.ExisteVehiculo(matricula);
        }
        #endregion

        #region Controlador CAlquiler
        public Alquiler.ErroresAlta AltaAlquiler(DateTime fechaInicio, DateTime fechaFinal, int horaInicio, int horaFinal, Vehiculo vehiculo, Cliente cliente)
        {
            return CAlquiler.Instancia.AltaAlquiler(fechaInicio, fechaFinal, horaInicio, horaFinal, vehiculo, cliente);
        }

        public Alquiler BuscarAlquiler(string mat)
        {
            return CAlquiler.Instancia.BuscarAlquiler(mat);
        }

        public List<Alquiler> VehiculosRetrasados()
        {
            return CAlquiler.Instancia.VehiculosRetrasados();
        }

        public List<Vehiculo> VehiculosDisponibles(string marca, string modelo, DateTime fechaI, DateTime fechaE)
        {
            return CAlquiler.Instancia.VehiculosDisponibles(marca, modelo, fechaI, fechaE);
        }
        #endregion

        #region Metodos de lectura y grabado de archivos .txt
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
                    if (int.TryParse(datos[3], out anio))
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

        public void GrabarLog(string rutaArchivo, string fechaEmision, string nombre)
        {
            if (File.Exists(rutaArchivo))
            {
                StreamWriter sw = File.AppendText(rutaArchivo);
                sw.WriteLine(fechaEmision + "-" + nombre);
                sw.Close();
            }
            else
            {
                FileStream fs = File.Create(rutaArchivo);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(fechaEmision + "-" + nombre);
                sw.Close();
            }
        }
        #endregion
    }
}
