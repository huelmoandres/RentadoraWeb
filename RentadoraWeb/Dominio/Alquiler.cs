using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Serializable]
    public class Alquiler
    {
        private DateTime fechaInicio;
        private DateTime fechaFinal;
        private int horaInicio;
        private int horaFinal;
        private TipoVehiculo vehiculo;
        private Cliente responsable;
        private bool devuelto;
        private string matricula;

        public Alquiler(DateTime fechaInicio, DateTime fechaFinal, int horaInicio, int horaFinal, TipoVehiculo vehiculo, Cliente cliente, string matricula, bool devuelto)
        {
            this.FechaInicio = fechaInicio;
            this.FechaFinal = fechaFinal;
            this.HoraInicio = horaInicio;
            this.HoraFinal = horaFinal;
            this.Vehiculo = vehiculo;
            this.Responsable = responsable;
            this.Matricula = matricula;
            this.Devuelto = devuelto;
        }

        #region Propiedades
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

        public bool Devuelto
        {
            get
            {
                return devuelto;
            }

            set
            {
                devuelto = value;
            }
        }

        public string Matricula
        {
            get
            {
                return matricula;
            }

            set
            {
                matricula = value;
            }
        }
        #endregion

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
            if (hora >= 0 && hora <= 23)
            {
                resultado = true;
            }
            return resultado;
        }

        public double CalcularCosto()
        {
            double costoTotal = 0;
            TimeSpan ts = fechaFinal - fechaInicio;
            int cantidadDias = ts.Days;
            double costoFijo = vehiculo.PrecioDiario * cantidadDias;
            costoTotal = costoFijo - ((costoFijo * responsable.CalcularDescuento()) / 100);
            return costoTotal;
        }

        public enum ErroresAlta
        {
            Ok,
            ErrorFecha,
            ErrorHora,
            ErrorVehiculo,
            ErrorResponsable,
        }

        public override string ToString()
        {
            string ret = "";
            ret += "Fecha de inicio: " + this.fechaInicio + "/n";
            ret += "Fecha de entrega: " + this.fechaFinal + "/n";
            ret += "Hora de inicio: " + this.horaInicio + "/n";
            ret += "Hora de final: " + this.horaFinal + "/n";
            ret += vehiculo.ToString();
            ret += responsable.ToString();
            ret += "Matricula: " + this.matricula + "/n";
            return ret;
        }
    }
}
