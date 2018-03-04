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

        public Particular.ErroresAlta AltaParticular(string tel, int anio, string ci, Particular.EnumTipoDocumento documento, string paisDoc, string nombre, string apellido)
        {
            Particular.ErroresAlta resultado = Particular.ErroresAlta.Ok;
            if (!Particular.ValidoTel(tel))
            {
                resultado = Particular.ErroresAlta.ErrorTelefono;
            } else if (!Particular.ValidoAnio(anio))
            {
                resultado = Particular.ErroresAlta.ErrorAnioInicio;
            } else if (!Particular.ValidoCi(ci))
            {
                resultado = Particular.ErroresAlta.ErrorCi;
            } else if (!Particular.ValidoNombre(nombre))
            {
                resultado = Particular.ErroresAlta.ErrorNombre;
            } else if (!Particular.ValidoApellido(apellido))
            {
                resultado = Particular.ErroresAlta.ErrorApellido;
            } else if (!Particular.ValidoPaisDoc(paisDoc))
            {
                resultado = Particular.ErroresAlta.ErrorPaisDoc;
            } else
            {
                Particular p = new Particular(tel, anio, ci, documento, paisDoc, nombre, apellido);
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
            else
            {
                Empresa e = new Empresa(tel, anio, rut, razonSocial, nombreContacto);
                clientes.Add(e);
            }
            return resultado;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //usa cuando serializa
            info.AddValue("listaClientes", this.clientes, typeof(List<Cliente>));
        }
    }
}
