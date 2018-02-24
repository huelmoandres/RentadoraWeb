using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class TipoVehiculo
    {
        private string marca;
        private string modelo;
        private double precioDiario;

        public TipoVehiculo(string marca, string modelo, double precioDiario)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.PrecioDiario = precioDiario;
        }

        public string Marca
        {
            get
            {
                return marca;
            }

            set
            {
                marca = value;
            }
        }

        public string Modelo
        {
            get
            {
                return modelo;
            }

            set
            {
                modelo = value;
            }
        }

        public double PrecioDiario
        {
            get
            {
                return precioDiario;
            }

            set
            {
                precioDiario = value;
            }
        }
    }
}
