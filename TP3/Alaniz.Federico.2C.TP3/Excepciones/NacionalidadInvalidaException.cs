using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mensaje">Mensaje de la Exception</param>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        public NacionalidadInvalidaException():this("Nacionalidad Invalida")
        {

        }
    }
}
