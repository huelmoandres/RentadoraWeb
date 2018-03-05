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
            } else if (this.ExisteTipo(marca, modelo))
            {
                resultado = TipoVehiculo.ErroresAlta.ErrorExiste;
            }
            else
            {
                TipoVehiculo tv = new TipoVehiculo(marca, modelo, precioDiario);
                tipos.Add(tv);
            }
            return resultado;
        }

        public List<TipoVehiculo> ListadoTipos()
        {
            return this.tipos;
        }

        public bool ExisteTipo(string marca, string modelo)
        {
            bool existe = false;
            int i = 0;
            while(i < this.tipos.Count && !existe)
            {
                if(tipos[i].Marca == marca && tipos[i].Modelo == modelo)
                {
                    existe = true;
                }
                i++;
            }
            return existe;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("listaTipoVehiculos", this.tipos, typeof(List<TipoVehiculo>));
        }

        public CTipoVehiculo(SerializationInfo info, StreamingContext context)
        {
            this.tipos = info.GetValue("listaTipoVehiculos", typeof(List<TipoVehiculo>)) as List<TipoVehiculo>;
            CTipoVehiculo.instancia = this;
        }
    }
}
