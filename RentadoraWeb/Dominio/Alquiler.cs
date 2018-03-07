using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Serializable]
    public class Alquiler : IComparable<Alquiler>
    {
        private DateTime fechaInicio;
        private DateTime fechaFinal;
        private int horaInicio;
        private int horaFinal;
        private Vehiculo vehiculo;
        private Cliente responsable;
        private bool devuelto;

        public Alquiler(DateTime fechaInicio, DateTime fechaFinal, int horaInicio, int horaFinal, Vehiculo vehiculo, Cliente cliente, bool devuelto)
        {
            this.FechaInicio = fechaInicio;
            this.FechaFinal = fechaFinal;
            this.HoraInicio = horaInicio;
            this.HoraFinal = horaFinal;
            this.Vehiculo = vehiculo;
            this.Responsable = cliente;
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

        public Vehiculo Vehiculo
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

        public string AlquilerMatricula
        {
            get
            {
                return Vehiculo.Matricula;
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
            double costoFijo = vehiculo.Tipo.PrecioDiario * cantidadDias;
            costoTotal = costoFijo - ((costoFijo * responsable.CalcularDescuento()) / 100);
            return costoTotal;
        }

        public int CompareTo(Alquiler otro)
        {
            int resultado = 0;
            if (otro != null)
            {
                resultado = otro.FechaFinal.CompareTo(this.FechaFinal);
                if (resultado == 0)
                {
                    resultado = this.Vehiculo.Matricula.CompareTo(otro.Vehiculo.Matricula);
                }
            }
            return resultado;
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
            ret += "<Br /><b>Datos del Alquiler: </b></br>";
            ret += "Fecha de inicio: " + this.fechaInicio.ToShortDateString() + "<Br />";
            ret += "Fecha de entrega: " + this.fechaFinal.ToShortDateString()  + "<Br />";
            ret += "Hora de inicio: " + this.horaInicio + "<Br />";
            ret += "Hora de final: " + this.horaFinal + "<Br />";
            ret += "<Br /><b>Datos del Vehículo: </b></br>";
            ret += vehiculo.ToString();
            ret += "<Br /><b>Datos del Cliente: </b></br>";
            ret += responsable.ToString();
            return ret;
        }
    }
}
