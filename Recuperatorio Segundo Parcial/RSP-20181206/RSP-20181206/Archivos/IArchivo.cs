using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {
        void Guardar(string destino, T dato);
        T Leer(string origen);
    }
}
