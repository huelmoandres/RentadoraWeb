using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Serializable]
    public class CUsuario : ISerializable
    {
        private static CUsuario instancia = new CUsuario();
        private List<Usuario> usuarios = new List<Usuario>();

        private CUsuario() { }

        public static CUsuario Instancia
        {
            get { return instancia; }
        }

        public List<Usuario> Usuarios
        {
            get
            {
                return usuarios;
            }

            set
            {
                usuarios = value;
            }
        }

        public Usuario Login(string mail, string pass)
        {
            Usuario logueado = this.BuscarUsuario(mail); //Busco el usuario
            if (logueado != null) //verifico que el usuario exista
            {
                if (logueado.Pass != pass) logueado = null; //verifico que la pass coincida
            }

            return logueado;
        }

        public Usuario BuscarUsuario(string mailUsu)
        {
            Usuario usu = null;
            int i = 0;
            while (i < usuarios.Count && usu == null)
            {
                if (usuarios[i].Mail == mailUsu) usu = usuarios[i];
                i++;
            }
            return usu;
        }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //usa cuando serializa
            info.AddValue("listaUsuarios", this.usuarios, typeof(List<Usuario>));
        }
    }
}
