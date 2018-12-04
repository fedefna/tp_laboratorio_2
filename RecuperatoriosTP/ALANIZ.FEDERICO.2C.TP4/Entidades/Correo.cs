using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;
        #endregion

        #region Properties
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de un correo
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region Metodos
        /// <summary>
        ///  retornar los datos de todos los paquetes de su lista
        /// </summary>
        /// <param name="elementos">lista de paquetes</param>
        /// <returns> retornar los datos de todos los paquetes de su lista</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            if (elementos is Correo)
            {
                foreach (Paquete p in ((Correo)elementos).Paquetes)
                {
                    sb.AppendFormat(p.ToString());
                }
            }
            
            return sb.ToString();
        }
        /// <summary>
        /// Finaliza todos los hilos abiertos en mockPaquetes
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                if (t.IsAlive)
                {
                    t.Abort();
                }
            }
        }
        /// <summary>
        /// De no estar repetido el paquete, agregar el paquete a la lista de paquetes
        /// </summary>
        /// <param name="c">correo</param>
        /// <param name="p">paquete</param>
        /// <returns>el correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            //Chekeo si ya esta el paquete
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                {
                    throw new TrackingIdRepetidaException("Este paquete ya se encuentra ingresado.");
                }
            }
            //Si no esta, lo agrego
            c.Paquetes.Add(p);
            //Creo un hilo para MockCicloDeVida y agrego ese hilo a mockPaquetes
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            //Ejecuto el hilo
            hilo.Start();
            return c;
        }
        #endregion
    }
}
