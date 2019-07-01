using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        /// Guarda el string recibido por parametro en un txt, si ya existe lo agrega sino lo crea.
        /// </summary>
        /// <param name="texto">string a agregar</param>
        /// <param name="path">path del archivo</param>
        /// <returns>treu si guarda</returns>
        public static bool Guardar(this string texto, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + path, true))
                {
                    sw.WriteLine(texto);
                    return true;
                }
            }
            catch (Exception)
            {
                throw new Exception ("Error al guardar en TXT.");
            }
        }

    }
}
