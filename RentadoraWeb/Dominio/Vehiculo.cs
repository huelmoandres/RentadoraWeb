using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Serializable]
    public class Vehiculo
    {
        private string matricula;
        private TipoVehiculo tipo;
        private int anio;
        private int kilometraje;
        List<string> fotos;

        public Vehiculo(string matricula, TipoVehiculo tipo, int anio, int kilometraje, List<string> fotos)
        {
            this.Matricula = matricula;
            this.Tipo = tipo;
            this.Anio = anio;
            this.Kilometraje = kilometraje;
            this.Fotos = fotos;
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

        public List<string> Fotos
        {
            get
            {
                return fotos;
            }

            set
            {
                fotos = value;
            }
        }

        public string FotoPrincipal
        {
            get
            {
                return this.fotos[0];
            }
        }

        public static bool ValidoMatricula(string matricula)
        {
            bool resultado = false;
            if(matricula != "")
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoTipo(TipoVehiculo tipo)
        {
            bool resultado = false;
            if (tipo != null)
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoAnio(int anio)
        {
            bool resultado = false;
            if (anio > 1950)
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoKilometraje(int kilometraje)
        {
            bool resultado = false;
            if (kilometraje > 0)
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoFoto(List<string> fotos)
        {
            bool resultado = false;
            if (fotos != null)
            {
                resultado = true;
            }
            return resultado;
        }

        public enum ErroresAlta
        {
            Ok,
            ErrorMatricula,
            ErrorTipo,
            ErrorAnio,
            ErrorKilometraje,
            ErrorFoto,
            ErrorExiste
        }
    }
}
