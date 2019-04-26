using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClaveInvalidaException : Exception
    {
        public ClaveInvalidaException(string mensaje) : this(mensaje, null)
        { }
        public ClaveInvalidaException(string mensaje, Exception innerException) : base(mensaje, innerException)
        { }
    }
}
