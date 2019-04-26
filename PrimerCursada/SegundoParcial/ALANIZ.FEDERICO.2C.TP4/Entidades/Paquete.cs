using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            while (this.Estado!=Paquete.EEstado.Entregado)
            {
                System.Threading.Thread.Sleep(4000);
                this.Estado = this.Estado + 1;
                InformarEstado.Invoke(new object { }, EventArgs.Empty);
            }
            //Guardar los datos en la base
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// mostrar
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} para {1}", this.TrackingID, this.DireccionEntrega);
            return sb.ToString();
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
            return string.Format("{0} ({1})", this.MostrarDatos(this), this.Estado.ToString());
        }
        #endregion
    }
}
