using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class CCliente
    {
        private static CCliente instanciaC = new CCliente();
        private CCliente(){}

        public static CCliente InstanciaC
        {
            get
            {
                return instanciaC;
            }
        }

        public Cliente.ErroresAlta AltaParticular(string ci, string documento, string paisDoc, string nombre, string apellido)
        {
            Cliente.ErroresAlta resultado = Cliente.ErroresAlta.Ok;

            return resultado;
        } 

    }
}
