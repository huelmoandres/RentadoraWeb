﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Serializable]
    public class Empresa : Cliente
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

        public static bool ValidoRazonSocial(string razonSocial)
        {
            bool resultado = false;
            if (razonSocial != "")
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoNombreContacto(string nomContacto)
        {
            bool resultado = false;
            
            if (nomContacto != "")
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoRut(int rut)
        {
            bool resultado = false;
            if (rut > 0)
            {
                resultado = true;
            }
            return resultado;
        }

        public override int CalcularDescuento()
        {
            int descuento = base.AnioInicio * 2;
            if (descuento > 20)
            {
                descuento = 20;
            }
            return descuento;
        }
    }
}
