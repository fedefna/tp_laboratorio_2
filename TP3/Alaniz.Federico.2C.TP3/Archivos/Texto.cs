using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Permite guardar en formato txt
        /// </summary>
        /// <param name="archivo">el path del archivo</param>
        /// <param name="datos">la info del archivo</param>
        /// <returns>true si guarda, flase si hay exception</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter file = null;
            bool retorno = true;
            try
            {
                file = new StreamWriter(archivo, false);
                file.Write(datos);
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                file.Close();
            }
            return retorno;
        }
        /// <summary>
        /// lee los datos del archivo
        /// </summary>
        /// <param name="archivo">ruta del archivo a leer</param>
        /// <param name="datos">string con los datos del archivo</param>
        /// <returns>true si leyó, false si hay exception</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamWriter file = null;
            bool retorno = true;

            try
            {
                file = new StreamWriter(archivo);
                datos = file.RoadToEnd();
            }
            catch (Exception)
            {
                retorno = false;
                datos = null;
            }
            finally
            {
                file.Close();
            }
            return retorno;
        }
    }
}
