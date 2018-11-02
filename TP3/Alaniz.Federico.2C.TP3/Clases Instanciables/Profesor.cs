using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    sealed class Profesor:Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// constructor 
        /// </summary>
        public Profesor()
        {

        }
        /// <summary>
        /// constructor privado
        /// </summary>
        private Profesor()
        {

        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre,string apellido,string dni,ENacionalidad nacionalidad)
        {

        }
        #endregion


    }
}
