using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Vehiculo
    {
        private string matricula;
        private TipoVehiculo tipo;
        private int anio;
        private int kilometraje;
        List<string> fotos = new List<string>();

        public Vehiculo(string matricula, TipoVehiculo tipo, int anio, int kilometraje, string ruta)
        {
            this.Matricula = matricula;
            this.Tipo = tipo;
            this.Anio = anio;
            this.Kilometraje = kilometraje;
            fotos.Add(ruta);
        }

        public string Matricula
        {
            get
            {
                return matricula;
            }

            set
            {
                matricula = value;
            }
        }

        internal TipoVehiculo Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public int Anio
        {
            get
            {
                return anio;
            }

            set
            {
                anio = value;
            }
        }

        public int Kilometraje
        {
            get
            {
                return kilometraje;
            }

            set
            {
                kilometraje = value;
            }
        }
    }
}
