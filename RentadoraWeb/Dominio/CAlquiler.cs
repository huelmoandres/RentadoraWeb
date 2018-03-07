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

        public Alquiler.ErroresAlta AltaAlquiler(DateTime fechaInicio, DateTime fechaFinal, int horaInicio, int horaFinal, Vehiculo vehiculo, Cliente cliente)
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
            else if(vehiculo == null)
            {
                resultado = Alquiler.ErroresAlta.ErrorVehiculo;
            }
            else if(cliente == null)
            {
                resultado = Alquiler.ErroresAlta.ErrorResponsable;
            }
            else
            {
                Alquiler a = new Alquiler(fechaInicio, fechaFinal, horaInicio, horaFinal, vehiculo, cliente, false);
                alquileres.Add(a);
            }
            return resultado;
        }


        public Alquiler BuscarAlquiler(string mat)
        {
            Alquiler buscado = null;
            bool esta = false;
            int i = 0;
            while(i < alquileres.Count && !esta)
            {
                if(alquileres[i].Vehiculo.Matricula == mat)
                {
                    buscado = alquileres[i];
                    esta = true;
                }
                i++;
            }
            return buscado;
        }

        public List<Vehiculo> VehiculosDisponibles(string marca, string modelo, DateTime fechaI, DateTime fechaE)
        {
            List<Vehiculo> lv = new List<Vehiculo>();
            List<Vehiculo> vehiculos = CVehiculo.Instancia.ListadoVehiculoMarcaModelo(marca, modelo);
            if(alquileres.Count > 0)
            {
                foreach (Vehiculo v in vehiculos) {
                    Alquiler a = BuscarAlquiler(v.Matricula);
                    if (a != null) {
                        if (!((a.FechaInicio >= fechaI && a.FechaInicio <= fechaE) ||
                            (a.FechaFinal >= fechaI && a.FechaFinal <= fechaE)) && (!a.Devuelto))
                        {
                            lv.Add(a.Vehiculo);
                        }
                    } else
                    {
                        lv.Add(v);
                    }
                }
            }
            else
            {
                lv = vehiculos;
            }
            return lv;
        }

        public List<Alquiler> VehiculosRetrasados()
        {
            List<Alquiler> retrasados = new List<Alquiler>();
            DateTime fechaActual = DateTime.Now;
            foreach(Alquiler a in alquileres)
            {
                if(a.FechaFinal < fechaActual && !a.Devuelto)
                {
                    retrasados.Add(a);
                }
            }
            retrasados.Sort();
            return retrasados;
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
