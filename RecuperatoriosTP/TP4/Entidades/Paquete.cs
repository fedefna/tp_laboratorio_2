using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        #region EnumEstados
        /// <summary>
        /// enumerado de estados
        /// </summary>
        public enum EEstado {Ingresado,EnViaje,Entregado}
        #endregion

        #region Atributos
        string direccionEntrega;
        EEstado estado;
        string trackingID;
        #endregion

        #region Properties
        /// <summary>
        /// propertie para acceder a DireccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        /// <summary>
        /// propertie para acceder a ESTADO
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        /// <summary>
        /// propertie para acceder a trakingID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Constructor
        public Paquete(string direccionDeEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionDeEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }
        #endregion

        #region Delegado
        public delegate void DelegadoEstado(object o, EventArgs e);
        public event DelegadoEstado InformarEstado;
        #endregion

        #region Metodos

        /// <summary>
        /// Coloca una demora, realiza los cambios de estado y los informa hasta que el estado sea Entregado.
        /// Luego de que Estado=Entregado se guarda el cambio de estado en la base.
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformarEstado.Invoke(this, new EventArgs());
            }
            try
            {
                //Guardo en la base
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }
        /// <summary>
        /// Comparo 2 paquetes para ver si son iguales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param> 
        /// <returns>retorna verdadero o falso si los trakingID son iguales o no</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool resultado = (p1.TrackingID == p2.TrackingID);
            return resultado;
        }
        /// <summary>
        /// Compara por distinto a 2 paquetes
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>vof segun su trakingID</returns>
        public static bool operator != (Paquete p1, Paquete p2)
        {
            return !(p1==p2);
        }
        /// <summary>
        /// Devuelve los datos de un paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion
    }
}
