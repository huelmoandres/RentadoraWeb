using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    abstract class Cliente
    {
        private string telefono;
        private int anioInicio;

        public Cliente(string telefono, int anioInicio)
        {
            this.Telefono = telefono;
            this.AnioInicio = anioInicio;
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public int AnioInicio
        {
            get
            {
                return anioInicio;
            }

            set
            {
                anioInicio = value;
            }
        }

        public static bool ValidoTel(string tel)
        {
            bool resultado = false;
            if(tel != "")
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoAnio(int anio)
        {
            bool resultado = false;
            if (anio > 0)
            {
                resultado = true;
            }
            return resultado;
        }

        public enum ErroresAlta
        {
            Ok,
            ErrorTelefono,
            ErrorAnioInicio,
            ErrorCi,
            ErrorDocumento,
            ErrorPaisDoc,
            ErrorNombre,
            ErrorApellido,
            ErrorRut,
            ErrorRazonSocial,
            ErrorNomContacto
        }
    }
}
