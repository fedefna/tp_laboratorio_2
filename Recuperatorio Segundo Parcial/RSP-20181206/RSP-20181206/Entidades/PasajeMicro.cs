using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PasajeMicro : Pasaje
    {
        #region Campos
        public Servicio.EServicio servicio;
        #endregion

        #region Properties
        public override float PrecioFinal
        {
            get
            {
                float retorno = 0;
                float aux = 0;
                switch (this.servicio)
                {
                    case Servicio.EServicio.SemiCama:
                        aux = (this.Precio * 10) / 100;
                        retorno = this.Precio + aux;
                        break;
                    case Servicio.EServicio.Ejecutivo:
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
            sb.AppendFormat("Servicio: {0}.", this.servicio);
            return sb.ToString();
        }
        #endregion

    }
}
