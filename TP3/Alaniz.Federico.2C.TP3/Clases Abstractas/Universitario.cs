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

        #endregion
    }
}
