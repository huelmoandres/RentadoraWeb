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

        public Vehiculo.ErroresAlta AltaVehiculo(string matricula, TipoVehiculo tipo, int anio, int kilometraje, string foto)
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
            else if (!Vehiculo.ValidoFoto(foto))
            {
                resultado = Vehiculo.ErroresAlta.ErrorFoto;
            }
            else
            {
                Vehiculo v = new Vehiculo(matricula, tipo, anio, kilometraje, foto);
                vehiculos.Add(v);
            }
            return resultado;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //usa cuando serializa
            info.AddValue("listaVehiculo", this.vehiculos, typeof(List<Vehiculo>));
        }
    }
}
