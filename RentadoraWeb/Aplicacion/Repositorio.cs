using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Aplicacion
{
    [Serializable]
    class Repositorio
    {
        private string rutaArchivo;
        private CCliente ccliente;


        public Repositorio (string rutaArchivo)
        {
            this.rutaArchivo = rutaArchivo;
            this.ccliente = CCliente.Instancia;
        }

        public void Serializable()
        {
            FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void Desarizable()
        {
            FileStream fs = new FileStream(rutaArchivo, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Repositorio rep = bf.Deserialize(fs) as Repositorio;
            fs.Close();
        }
    }
}
