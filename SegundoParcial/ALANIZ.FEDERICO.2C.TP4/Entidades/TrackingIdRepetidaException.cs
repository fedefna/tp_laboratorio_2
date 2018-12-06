using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidaException:Exception
    {
        /// <summary>
        /// Constructor que llama pasa el mensaje al constructor que recibe un mensaje y una Exception
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidaException(string mensaje):this(mensaje,null)
        {

        }

        /// <summary>
        /// Constructor que recibe un mensaje y una inner Exception y los pasa al base
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="inner"></param>
        public TrackingIdRepetidaException(string mensaje, Exception inner):base (mensaje,inner)
        {

        }
    }
}
