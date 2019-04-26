using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PasajeAvion : Pasaje
    {
        #region Campos
        public int cantidadEscalas;
        #endregion

        #region Properties
        public override float PrecioFinal
        {
            get
            {
                float retorno=0;
                float aux=0;
                switch (this.cantidadEscalas)
                {
                    case 1:
                        aux=(this.Precio * 10) / 100;
                        retorno = this.Precio - aux;
                        break;
                    case 2:
                        aux = (this.Precio * 20) / 100;
                        retorno = this.Precio - aux;
                        break;
                    default:
                        aux = (this.Precio * 30) / 100;
                        retorno = this.Precio - aux;
                        break;
                }
                return retorno;
            }
        }
        #endregion

        #region Constructor
        public PasajeAvion()
        {

        }

        public PasajeAvion(string origen, string destino, Pasajero pasajero,float precio, DateTime fecha, int cantidadEscalas):base(origen,destino,pasajero,precio,fecha)
        {
            this.cantidadEscalas = cantidadEscalas;
        }
        #endregion

        #region Metodos
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.Mostrar());
            sb.AppendFormat("CantidadEscalas de escalas: {0}.", this.cantidadEscalas);
            return sb.ToString();
        }
        #endregion


    }
}
