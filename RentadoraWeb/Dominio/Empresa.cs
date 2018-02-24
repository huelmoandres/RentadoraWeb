using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Empresa : Cliente
    {
        private int rut;
        private string razonSocial;
        private string nombreContacto;

        public Empresa(string telefono, int anioInicio, int rut, string razonSocial, string nombreContacto) : base(telefono, anioInicio)
        {
            this.Rut = rut;
            this.RazonSocial = razonSocial;
            this.NombreContacto = nombreContacto;
        }

        public int Rut
        {
            get
            {
                return rut;
            }

            set
            {
                rut = value;
            }
        }

        public string RazonSocial
        {
            get
            {
                return razonSocial;
            }

            set
            {
                razonSocial = value;
            }
        }

        public string NombreContacto
        {
            get
            {
                return nombreContacto;
            }

            set
            {
                nombreContacto = value;
            }
        }
    }
}
