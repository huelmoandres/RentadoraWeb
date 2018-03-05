using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio
{
    [Serializable]
    public class CCliente : ISerializable
    {
        private static CCliente instancia = new CCliente();
        private List<Cliente> clientes = new List<Cliente>();

        private CCliente(){}

        public static CCliente Instancia
        {
            get
            {
                return instancia;
            }
        }

        public Particular.ErroresAlta AltaParticular(string tel, int anio, string ci, string documento, string paisDoc, string nombre, string apellido)
        {
            Particular.ErroresAlta resultado = Particular.ErroresAlta.Ok;
            if (!Particular.ValidoTel(tel))
            {
                resultado = Particular.ErroresAlta.ErrorTelefono;
            }
            else if (!Particular.ValidoAnio(anio))
            {
                resultado = Particular.ErroresAlta.ErrorAnioInicio;
            }
            else if (!Particular.ValidoCi(ci))
            {
                resultado = Particular.ErroresAlta.ErrorCi;
            }
            else if (!Particular.ValidoNombre(nombre))
            {
                resultado = Particular.ErroresAlta.ErrorNombre;
            }
            else if (!Particular.ValidoApellido(apellido))
            {
                resultado = Particular.ErroresAlta.ErrorApellido;
            }
            else if (!Particular.ValidoTipoDoc(documento))
            {
                resultado = Particular.ErroresAlta.ErrorDocumento;
            }
            else if (!Particular.ValidoPaisDoc(paisDoc))
            {
                resultado = Particular.ErroresAlta.ErrorPaisDoc;
            }
            else if (this.ExisteParticular(ci) != null)
            {
                resultado = Particular.ErroresAlta.ErrorExiste;
            }
            else
            {
                Particular.EnumTipoDocumento doc = (Particular.EnumTipoDocumento) Enum.Parse(typeof(Particular.EnumTipoDocumento), documento);
                Particular p = new Particular(tel, anio, ci, doc, paisDoc, nombre, apellido);
                clientes.Add(p);
            }
            return resultado;
        }

        public Empresa.ErroresAlta AltaEmpresa(string tel, int anio, int rut, string razonSocial, string nombreContacto)
        {
            Empresa.ErroresAlta resultado = Empresa.ErroresAlta.Ok;
            if (!Empresa.ValidoTel(tel))
            {
                resultado = Empresa.ErroresAlta.ErrorTelefono;
            }
            else if (!Empresa.ValidoAnio(anio))
            {
                resultado = Empresa.ErroresAlta.ErrorAnioInicio;
            }
            else if (!Empresa.ValidoRazonSocial(razonSocial))
            {
                resultado = Empresa.ErroresAlta.ErrorRazonSocial;
            }
            else if (!Empresa.ValidoNombreContacto(nombreContacto))
            {
                resultado = Empresa.ErroresAlta.ErrorNomContacto;
            }
            else if (this.ExisteEmpresa(rut) != null)
            {
                resultado = Empresa.ErroresAlta.ErrorExiste;
            }
            else
            {
                Empresa e = new Empresa(tel, anio, rut, razonSocial, nombreContacto);
                clientes.Add(e);
            }
            return resultado;
        }

        public Particular ExisteParticular(string ci)
        {
            Particular particular = null;
            bool existe = false;
            int i = 0;
            while (i < this.clientes.Count && !existe)
            {
                if (clientes[i] is Particular)
                {
                    Particular p = clientes[i] as Particular;
                    if (p.Ci == ci)
                    {
                        existe = true;
                        particular = p;
                    }
                }
                i++;
            }
            return particular;
        }

        public Empresa ExisteEmpresa(int rut)
        {
            Empresa empresa = null;
            bool existe = false;
            int i = 0;
            while (i < this.clientes.Count && !existe)
            {
                if (clientes[i] is Empresa)
                {
                    Empresa e = clientes[i] as Empresa;
                    if(e.Rut == rut)
                    {
                        existe = true;
                        empresa = e;
                    }
                }
                i++;
            }
            return empresa;
        }

        public string[] TipoDocumentos()
        {
           return Enum.GetNames(typeof(Particular.EnumTipoDocumento));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("listaClientes", this.clientes, typeof(List<Cliente>));
        }

        public CCliente(SerializationInfo info, StreamingContext context)
        {
            this.clientes = info.GetValue("listaClientes", typeof(List<Cliente>)) as List<Cliente>;
            CCliente.instancia = this;
        }
    }
}
