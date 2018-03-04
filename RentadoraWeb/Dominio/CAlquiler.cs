using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio
{
    [Serializable]
    public class CAlquiler : ISerializable
    {
        private static CAlquiler instancia = new CAlquiler();
        private List<Alquiler> alquileres = new List<Alquiler>();

        private CAlquiler() { }

        public static CAlquiler Instancia
        {
            get
            {
                return instancia;
            }
        }

        public Alquiler.ErroresAlta AltaAlquiler(DateTime fechaInicio, DateTime fechaFinal, int horaInicio, int horaFinal, TipoVehiculo vehiculo, Cliente cliente)
        {
            Alquiler.ErroresAlta resultado = Alquiler.ErroresAlta.Ok;
            if (!Alquiler.ValidoFecha(fechaInicio))
            {
                resultado = Alquiler.ErroresAlta.ErrorFecha;
            }
            else if (!Alquiler.ValidoFecha(fechaFinal))
            {
                resultado = Alquiler.ErroresAlta.ErrorFecha;
            }
            else if (!Alquiler.ValidoHora(horaInicio))
            {
                resultado = Alquiler.ErroresAlta.ErrorHora;
            }
            else if (!Alquiler.ValidoHora(horaFinal))
            {
                resultado = Alquiler.ErroresAlta.ErrorHora;
            }
            else
            {
                Alquiler a = new Alquiler(fechaInicio, fechaFinal, horaInicio, horaFinal, vehiculo, cliente);
                alquileres.Add(a);
            }
            return resultado;
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("listaAlquileres", this.alquileres, typeof(List<Alquiler>));
        }

        public CAlquiler(SerializationInfo info, StreamingContext context)
        {
            this.alquileres = info.GetValue("listaAlquileres", typeof(List<Alquiler>)) as List<Alquiler>;
            CAlquiler.instancia = this;
        }
    }
}
