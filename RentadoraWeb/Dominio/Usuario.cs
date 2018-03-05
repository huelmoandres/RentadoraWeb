using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    [Serializable]
    public class Usuario
    {
        private string mail;
        private string pass;
        private byte rol;

        public Usuario(string mail, string pass, byte rol)
        {
            this.Mail = mail;
            this.Pass = pass;
            this.rol = rol;
        }

        public string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
            }
        }

        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {
                pass = value;
            }
        }

        public byte Rol
        {
            get
            {
                return rol;
            }
        }

        /*public static bool ValidoMail(string mail)
        {
            bool resultado = false;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(mail);
            if (match.Success)
            {
                resultado = true;
            }
            return resultado;
        }*/

        public static bool ValidoMail(string mail)
        {
            bool resultado = false;
            if (mail.Length > 4)
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoPass(string pass)
        {
            bool resultado = false;
            if(pass.Length > 6)
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoRol(byte rol)
        {
            bool resultado = false;
            if (rol >= 0 && rol <= 2)
            {
                resultado = true;
            }
            return resultado;
        }

        public enum ErroresAlta
        {
            Ok,
            ErrorMail,
            ErrorPass,
            ErrorRol,
            ErrorExiste
        }
    }
}
