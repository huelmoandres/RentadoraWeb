﻿using System;
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
   public class Repositorio
    {
        private string rutaArchivo;
        private CTipoVehiculo ctipoVehiculo;

        public Repositorio(string rutaArchivo)
        {
            this.rutaArchivo = rutaArchivo;
            this.ctipoVehiculo = CTipoVehiculo.Instancia;
        }

        public void Serializable()
        {
            FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void Deserealizable()
        {
            FileStream fs = new FileStream(rutaArchivo, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Repositorio rep = bf.Deserialize(fs) as Repositorio;
            fs.Close();
        }
    }
}
