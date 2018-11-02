using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario:Persona
    {
        #region Atributos
        private int legajo;
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="legajo">Legajo de la persona</param>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Universitario(int legajo, string nombre,string apellido, string dni,ENacionalidad nacionalidad) 
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Se muestran todos los datos de la persona mas el de univ
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}\nLEGAJO NÚMERO: {1}", base.ToString(), this.legajo);
            return sb.ToString();
        }
        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobrecarga de equals: Dos Universitario serán iguales si y sólo si son del mismo Tipo
        /// y su Legajo o DNI son iguales
        /// </summary>
        /// <param name="obj">un objeto univ</param>
        /// <returns>true o false</returns>
        public override bool Equals(object obj)
        {
            if (!ReferenceEquals(obj, null) && obj is Universitario)
            {
                Universitario objeto = (Universitario)obj;
                if (objeto.legajo == this.legajo || objeto.Dni == this.Dni)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga de == usando la sobrecarga del equals
        /// </summary>
        /// <param name="uni1">objeto tipo univ</param>
        /// <param name="uni2">objeto tipo univ</param>
        /// <returns></returns>
        public static bool operator ==(Universitario uni1, Universitario uni2)
        {
            return uni1.Equals(uni2);
        }
        /// <summary>
        /// Sobrecarga de !=
        /// </summary>
        /// <param name="uni1">obj univ</param>
        /// <param name="uni2">obj univ</param>
        /// <returns>true o false</returns>
        public static bool operator !=(Universitario uni1, Universitario uni2)
        {
            return !(uni1 == uni2);
        }
        #endregion
    }
}
