using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio; 

namespace Aplicacion
{
    public class Rentadora
    {
        private static Rentadora instancia = new Rentadora();

        public static Rentadora Instancia
        {
            get
            {
                return instancia;
            }
        }

        public Usuario Login(string email, string pass)
        {
            return CUsuario.Instancia.Login(email, pass);
        }

        public void CargarDatosPrueba()
        {

        }
    }
}
