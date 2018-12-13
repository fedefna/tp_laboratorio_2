using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        public void Guardar(string destino, T dato)
        {
            XmlTextWriter xtw = null;
            xtw = new XmlTextWriter(destino, Encoding.UTF8);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            ser.Serialize(xtw, dato);
            if (!(xtw is null))
            {
                xtw.Close();
            }
        }

        public T Leer(string origen)
        {
            XmlTextReader xtr = new XmlTextReader(origen);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            T aux = (T)ser.Deserialize(xtr);
            if (!(xtr is null))
            {
                xtr.Close();
            }
            return aux;
        }
    }
}
