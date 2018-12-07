using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    class Xml<T>
    {
        public void Guardar(string destino, T dato)
        {
            XmlTextWriter xtw = null;
            xtw = new XmlTextWriter(destino, Encoding.UTF8);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            ser.Serialize(xtw, dato);
            xtw.Close();
        }

        public T Leer(string origen)
        {
            XmlTextReader xtr = new XmlTextReader(origen);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            T aux = (T)ser.Deserialize(xtr);
            xtr.Close();
            return aux;
        }
    }
}
