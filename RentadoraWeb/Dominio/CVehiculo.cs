using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio
{
    [Serializable]
    public class CVehiculo : ISerializable
    {
        private static CVehiculo instancia = new CVehiculo();
        private List<Vehiculo> vehiculos = new List<Vehiculo>();

        private CVehiculo() { }

        public static CVehiculo Instancia
        {
            get { return instancia; }
        }

        public Vehiculo.ErroresAlta AltaVehiculo(string matricula, TipoVehiculo tipo, int anio, int kilometraje, List<string> fotos)
        {
            Vehiculo.ErroresAlta resultado = Vehiculo.ErroresAlta.Ok;
            if (!Vehiculo.ValidoMatricula(matricula))
            {
                resultado = Vehiculo.ErroresAlta.ErrorMatricula;
            }
            else if (!Vehiculo.ValidoTipo(tipo))
            {
                resultado = Vehiculo.ErroresAlta.ErrorTipo;
            }
            else if (!Vehiculo.ValidoAnio(anio))
            {
                resultado = Vehiculo.ErroresAlta.ErrorAnio;
            }
            else if (!Vehiculo.ValidoKilometraje(kilometraje))
            {
                resultado = Vehiculo.ErroresAlta.ErrorKilometraje;
            }
            else if (!Vehiculo.ValidoFoto(fotos))
            {
                resultado = Vehiculo.ErroresAlta.ErrorFoto;
            }
            else if (this.ExisteVehiculo(matricula) != null)
            {
                resultado = Vehiculo.ErroresAlta.ErrorExiste;
            }
            else
            {
                Vehiculo v = new Vehiculo(matricula, tipo, anio, kilometraje, fotos);
                vehiculos.Add(v);
            }
            return resultado;
        }

        public Vehiculo ExisteVehiculo(string matricula)
        {
            Vehiculo veh = null;
            bool existe = false;
            int i = 0;
            while (i < this.vehiculos.Count && !existe)
            {
                if (vehiculos[i].Matricula == matricula)
                {
                    existe = true;
                    veh = vehiculos[i];
                }
                i++;
            }
            return veh;
        }

        public List<string> ListarFotos(string matricula)
        {
            List<string> fotos = null;
            bool existe = false;
            int i = 0;
            while (i < this.vehiculos.Count && !existe)
            {
                if (vehiculos[i].Matricula == matricula)
                {
                    existe = true;
                    fotos = vehiculos[i].Fotos;
                }
                i++;
            }
            return fotos;
        }

        public List<Vehiculo> ListadoVehiculoMarcaModelo(string marca, string modelo)
        {
            List<Vehiculo> veh = new List<Vehiculo>();
            foreach(Vehiculo v in vehiculos)
            {
                if(v.Tipo.Marca == marca && v.Tipo.Modelo == modelo)
                {
                    veh.Add(v);
                }
            }
            return veh;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("listaVehiculo", this.vehiculos, typeof(List<Vehiculo>));
        }

        public CVehiculo(SerializationInfo info, StreamingContext context)
        {
            this.vehiculos = info.GetValue("listaVehiculo", typeof(List<Vehiculo>)) as List<Vehiculo>;
            CVehiculo.instancia = this;
        }
    }
}
