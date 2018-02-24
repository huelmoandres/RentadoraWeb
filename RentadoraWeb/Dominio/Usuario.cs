using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Usuario
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
    }
}
