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

        public Usuario.ErroresAlta AltaUsuario(string mail, string pass, byte rol)
        {
            Usuario.ErroresAlta resultado = Usuario.ErroresAlta.Ok;
            if (!Usuario.ValidoMail(mail))
            {
                resultado = Usuario.ErroresAlta.ErrorMail;
            }
            else if (!Usuario.ValidoPass(pass))
            {
                resultado = Usuario.ErroresAlta.ErrorPass;
            }
            else if (!Usuario.ValidoRol(rol))
            {
                resultado = Usuario.ErroresAlta.ErrorRol;
            }
            else if (this.BuscarUsuario(mail) != null)
            {
                resultado = Usuario.ErroresAlta.ErrorExiste;
            }
            else
            {
                Usuario u = new Usuario(mail, pass, rol);
                usuarios.Add(u);
            }
            return resultado;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("listaUsuarios", this.usuarios, typeof(List<Usuario>));
        }

        public CUsuario(SerializationInfo info, StreamingContext context)
        {
            this.usuarios = info.GetValue("listaUsuarios", typeof(List<Usuario>)) as List<Usuario>;
            CUsuario.instancia = this;
        }
    }
}
