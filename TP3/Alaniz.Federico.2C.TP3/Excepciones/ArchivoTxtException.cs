using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivoTxtException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ArchivoTxtException():this("Error al utilizar el achivo TXT.")
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        public ArchivoTxtException(string mensaje) :base(mensaje)
        {

        }


    }
}
