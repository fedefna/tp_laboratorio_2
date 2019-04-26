using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// guarda en formato xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        public void Guardar(string archivo,T datos)
        {
            XmlTextWriter xtw = null;
            xtw = new XmlTextWriter(archivo, Encoding.UTF8);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            ser.Serialize(xtw, datos);
            xtw.Close();
        }
        /// <summary>
        /// Lee deserializando de formato xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        public void Leer(string archivo, out T datos)
        {
            XmlTextReader xtr = new XmlTextReader(archivo);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            T aux = (T)ser.Deserialize(xtr);
            datos = aux;
            xtr.Close();
        }
    }
}
