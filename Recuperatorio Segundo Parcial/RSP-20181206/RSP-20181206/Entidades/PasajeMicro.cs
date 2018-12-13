using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Servicio
    {
        Comun, SemiCama, Ejecutivo
    }

    public class PasajeMicro : Pasaje
    {
        #region Campos
        public Servicio tipoServicio;
        #endregion


        #region Constructor
        public PasajeMicro() { }

        public PasajeMicro(string origen, string destino, Pasajero pasajero, float precio, DateTime fecha, Servicio tipoServicio)
        : base(origen, destino, pasajero, precio, fecha)
        {
            this.tipoServicio = tipoServicio;
        }

        #endregion
        #region Properties
        public override float PrecioFinal
        {
            get
            {
                float retorno = 0;
                float aux = 0;
                switch (this.tipoServicio)
                {
                    case Servicio.SemiCama:
                        aux = (this.Precio * 10) / 100;
                        retorno = this.Precio + aux;
                        break;
                    case Servicio.Ejecutivo:
                        aux = (this.Precio * 20) / 100;
                        retorno = this.Precio + aux;
                        break;
                    default:
                        retorno = this.Precio;
                        break;
                }
                return retorno;
            }
        }
        #endregion

        #region Metodos
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.Mostrar());
            sb.AppendFormat("Servicio: {0}.", this.tipoServicio);
            return sb.ToString();
        }
        #endregion

    }
}
