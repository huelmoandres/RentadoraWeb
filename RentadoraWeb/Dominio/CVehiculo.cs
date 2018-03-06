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
            else if (this.ExisteVehiculo(matricula))
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

        public bool ExisteVehiculo(string matricula)
        {
            bool existe = false;
            int i = 0;
            while (i < this.vehiculos.Count && !existe)
            {
                if (vehiculos[i].Matricula == matricula)
                {
                    existe = true;
                }
                i++;
            }
            return existe;
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

        public List<string> MatriculasPorMarcaModelo(string marca, string modelo)
        {
            List<string> matriculas = new List<string>();
            if(this.vehiculos.Count > 0)
            {
                for (int i = 0; i < vehiculos.Count; i++)
                {
                    if (vehiculos[i].Tipo.Marca == marca && vehiculos[i].Tipo.Modelo == modelo)
                    {
                        matriculas.Add(vehiculos[i].Matricula);
                    }
                }
            }
            return matriculas;
        }

        public List<Vehiculo> VehiculosDisponibles(List<string> matriculas)
        {
            List<Vehiculo> vehiculosDisp = new List<Vehiculo>();
            if(matriculas.Count > 0)
            {
                for (int i = 0; i < this.vehiculos.Count; i++)
                {
                    if (matriculas.Contains(vehiculos[i].Matricula))
                    {
                        vehiculosDisp.Add(vehiculos[i]);
                    }
                }
            }
            return vehiculosDisp;
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
