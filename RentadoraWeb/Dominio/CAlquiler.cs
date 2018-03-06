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

        public Alquiler.ErroresAlta AltaAlquiler(DateTime fechaInicio, DateTime fechaFinal, int horaInicio, int horaFinal, TipoVehiculo vehiculo, Cliente cliente, string matricula)
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
                Alquiler a = new Alquiler(fechaInicio, fechaFinal, horaInicio, horaFinal, vehiculo, cliente, matricula, false);
                alquileres.Add(a);
            }
            return resultado;
        }

        public List<string> MatriculasDisponibles(List<string> matriculas, DateTime fechaI, DateTime fechaF)
        {
            List<string> matriculasDisp = new List<string>();
            if(matriculas.Count > 0)
            {
                if(alquileres.Count > 0)
                {
                    for (int i = 0; i < alquileres.Count; i++)
                    {
                        if (matriculas.Contains(alquileres[i].Matricula))
                        {
                            if (!((alquileres[i].FechaInicio >= fechaI && alquileres[i].FechaInicio <= fechaF) ||
                                (alquileres[i].FechaFinal >= fechaI && alquileres[i].FechaFinal <= fechaF)))
                            {
                                matriculasDisp.Add(alquileres[i].Matricula);
                            } 
                        }
                        else
                        {
                            matriculasDisp.Add(alquileres[i].Matricula);
                        }
                    }
                }
                else
                {
                    matriculasDisp = matriculas;
                }
            }
            return matriculasDisp;
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
