using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Particular : Cliente
    {
        private string ci;
        private EnumTipoDocumento documento;
        private string paisDocumento;
        private string nombre;
        private string apellido;

        public Particular(string telefono, int anioInicio, string ci, EnumTipoDocumento documento, string paisDocumento, string nombre, string apellido) : base(telefono, anioInicio)
        {
            this.Ci = ci;
            this.Documento = documento;
            this.PaisDocumento = paisDocumento;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public string Ci
        {
            get
            {
                return ci;
            }

            set
            {
                ci = value;
            }
        }

        internal EnumTipoDocumento Documento
        {
            get
            {
                return documento;
            }

            set
            {
                documento = value;
            }
        }

        public string PaisDocumento
        {
            get
            {
                return paisDocumento;
            }

            set
            {
                paisDocumento = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public enum EnumTipoDocumento
        {
            Cedula,
            Pasaporte,
            DNI
        }
    }
}
