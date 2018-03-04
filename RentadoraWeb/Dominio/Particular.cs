﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Particular : Cliente
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

        public static bool ValidoCi(string ci)
        {
            bool resultado = false;
            if (ci.Length >= 7 && ci.Length <=9)
            {
                resultado = true;
            }
            return resultado;
        }

        //Consultar
        /*public static bool ValidoTipoDoc(string documento)
        {
            bool resultado = false;
            if (EnumTipoDocumento)
            {
                resultado = true;
            }
            return resultado;
        }*/

        public static bool ValidoPaisDoc(string pais)
        {
            bool resultado = false;
            if (pais.Length > 3)
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoNombre(string nombre)
        {
            bool resultado = false;
            if (nombre != "")
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoApellido(string apellido)
        {
            bool resultado = false;
            if (apellido != "")
            {
                resultado = true;
            }
            return resultado;
        }

        public enum EnumTipoDocumento
        {
            Cedula,
            Pasaporte,
            DNI,
            RUT
        }
    }
}
