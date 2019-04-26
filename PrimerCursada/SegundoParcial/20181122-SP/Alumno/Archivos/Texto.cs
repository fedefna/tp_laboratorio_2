using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Archivos
{
    public class Texto<T> : IArchivo<Queue <Patente>>
    {
        /// <summary>
        /// Guarda en archivo una cola de datos
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        public void Guardar(string archivo, Queue<Patente> datos)
        {
            StreamWriter sw = new StreamWriter(archivo);
            foreach(Patente p in datos)
            {
                sw.WriteLine(p);
            }
            sw.Close();
        }

        /// <summary>
        /// lee de archivo y deja en la cola datos lo leido
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        public void Leer(string archivo, out Queue<Patente> datos)
        {
            StreamReader sr = new StreamReader(archivo);
            string str = sr.ReadToEnd();
            Patente p;
            Queue<Patente> auxQueue = new Queue<Patente>();

            foreach(string s in str.Split('\n'))
            {
                string aux = s.Replace('\r', ' ');
                aux = s.Trim();
                p = PatenteStringExtension.ValidarPatente(aux);
                if (p != null)
                {
                    auxQueue.Enqueue(p);
                }
            }
            datos = auxQueue;
            sr.Close();
        }
    }
}
