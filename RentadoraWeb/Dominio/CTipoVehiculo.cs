using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio
{
    [Serializable]
    public class CTipoVehiculo : ISerializable
    {
        private static CTipoVehiculo instancia = new CTipoVehiculo();
        private List<TipoVehiculo> tipos = new List<TipoVehiculo>();

        private CTipoVehiculo() { }

        public static CTipoVehiculo Instancia
        {
            get { return instancia; }
        }

        public TipoVehiculo.ErroresAlta AltaTipoVehiculo(string marca, string modelo, double precioDiario)
        {
            TipoVehiculo.ErroresAlta resultado = TipoVehiculo.ErroresAlta.Ok;
            if (!TipoVehiculo.ValidoMarca(marca))
            {
                resultado = TipoVehiculo.ErroresAlta.ErrorMarca;
            }
            else if (!TipoVehiculo.ValidoModelo(modelo))
            {
                resultado = TipoVehiculo.ErroresAlta.ErrorModelo;
            }
            else if (!TipoVehiculo.ValidoPrecio(precioDiario))
            {
                resultado = TipoVehiculo.ErroresAlta.ErrorPrecioDiario;
            }
            else
            {
                TipoVehiculo tv = new TipoVehiculo(marca, modelo, precioDiario);
                tipos.Add(tv);
            }
            return resultado;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //usa cuando serializa
            info.AddValue("listaTipoVehiculos", this.tipos, typeof(List<TipoVehiculo>));
        }
    }
}
