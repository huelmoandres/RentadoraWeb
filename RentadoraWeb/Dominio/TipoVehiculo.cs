using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Serializable]
    public class TipoVehiculo
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

        public static bool ValidoMarca(string marca)
        {
            bool resultado = false;
            if(marca != "")
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoModelo(string modelo)
        {
            bool resultado = false;
            if (modelo != "")
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoPrecio(double precio)
        {
            bool resultado = false;
            if (precio > 0)
            {
                resultado = true;
            }
            return resultado;
        }

        public enum ErroresAlta
        {
            Ok,
            ErrorMarca,
            ErrorModelo,
            ErrorPrecioDiario,
            ErrorExiste
        }

        public override string ToString()
        {
            string ret = "";
            ret += "Marca: " + this.marca + "/n";
            ret += "Modelo: " + this.Modelo + "/n";
            ret += "Precio diario: $" + this.precioDiario + "/n";
            return ret;
        }
    }
}
