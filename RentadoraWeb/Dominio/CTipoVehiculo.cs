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
            else if (this.ExisteTipo(marca, modelo) != null)
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

        public List<string> MarcasSinRepetir()
        {
            List<string> s = new List<string>();
            if (tipos.Count > 0)
            {
                foreach (TipoVehiculo t in tipos)
                {
                    if (!(s.Contains(t.Marca)))
                    {
                        s.Add(t.Marca);
                    }
                }
            }
            return s;
        }
        public TipoVehiculo ExisteTipo(string marca, string modelo)
        {
            TipoVehiculo tp = null;
            bool existe = false;
            int i = 0;
            while(i < this.tipos.Count && !existe)
            {
                if(tipos[i].Marca == marca && tipos[i].Modelo == modelo)
                {
                    existe = true;
                    tp = tipos[i];
                }
                i++;
            }
            return tp;
        }

        public List<TipoVehiculo> ObtenerModeloMismaMarca(string marca)
        {
            List<TipoVehiculo> retorno = new List<TipoVehiculo>();
            foreach(TipoVehiculo t in tipos)
            {
                if(t.Marca == marca)
                {
                    retorno.Add(t);
                }
            }
            return retorno;
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
