using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Alquiler
    {
        private DateTime fechaInicio;
        private DateTime fechaFinal;
        private int horaInicio;
        private int horaFinal;
        private TipoVehiculo vehiculo;
        private Cliente responsable;

        public Alquiler(DateTime fechaInicio, DateTime fechaFinal, int horaInicio, int horaFinal, TipoVehiculo vehiculo, Cliente cliente)
        {
            this.FechaInicio = fechaInicio;
            this.FechaFinal = fechaFinal;
            this.HoraInicio = horaInicio;
            this.HoraFinal = horaFinal;
            this.Vehiculo = vehiculo;
            this.Responsable = responsable;
        }

        public DateTime FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }

        public DateTime FechaFinal
        {
            get
            {
                return fechaFinal;
            }

            set
            {
                fechaFinal = value;
            }
        }

        public int HoraInicio
        {
            get
            {
                return horaInicio;
            }

            set
            {
                horaInicio = value;
            }
        }

        public int HoraFinal
        {
            get
            {
                return horaFinal;
            }

            set
            {
                horaFinal = value;
            }
        }

        public TipoVehiculo Vehiculo
        {
            get
            {
                return vehiculo;
            }

            set
            {
                vehiculo = value;
            }
        }

        public Cliente Responsable
        {
            get
            {
                return responsable;
            }

            set
            {
                responsable = value;
            }
        }

        public static bool ValidoFecha(DateTime fecha)
        {
            bool resultado = false;
            if(fecha != null)
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool ValidoHora(int hora)
        {
            bool resultado = false;
            if (hora > 0 && hora <= 24)
            {
                resultado = true;
            }
            return resultado;
        }

        public double CalcularCosto()
        {
            double costoTotal = 0;
            TimeSpan ts = fechaInicio - fechaFinal;
            int cantidadDias = ts.Days;
            costoTotal = (vehiculo.PrecioDiario * cantidadDias)

        }

        public enum ErroresAlta
        {
            Ok,
            ErrorFecha,
            ErrorHora,
            ErrorVehiculo,
            ErrorResponsable
        }
    }
}
