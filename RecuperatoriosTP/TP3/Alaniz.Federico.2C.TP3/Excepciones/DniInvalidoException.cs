using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DniInvalidoException()
        {
           
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="e">InnerException</param>
        public DniInvalidoException(Exception e) :this("DNI invalido",e)
        {

        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="mensaje">Mensaje ed la excepcion</param>
        public DniInvalidoException(string mensaje) : this(mensaje, null)
        {

        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="mensaje">Mensaje de la exception</param>
        /// <param name="e">InnerException</param>
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {

        }
    }
}
