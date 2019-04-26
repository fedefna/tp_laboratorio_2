using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Permite serializar datos a un xml
        /// </summary>
        /// <param name="archivo">path del archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>verdadero si lo logra, falso si hay exception</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextWriter writer = null;
            bool retorno = true;

            try
            {
                writer = new XmlTextWriter(archivo, null);
                ser.Serialize(writer, datos);
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                writer.Close();
            }
            return retorno;
        }
        /// <summary>
        /// desserializa los datos de un xml
        /// </summary>
        /// <param name="archivo">path del archivo</param>
        /// <param name="datos">string donde van los datos de salida</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlReader reader = null;
            bool retorno = true;
            try
            {
                reader = new XmlTextReader(archivo);
                datos = (T)ser.Deserialize(reader);
            }
            catch (Exception)
            {
                retorno = false;
                datos = default(T);
            }
            finally
            {
                reader.Close();
            }
            return retorno;
        }
    }
}
