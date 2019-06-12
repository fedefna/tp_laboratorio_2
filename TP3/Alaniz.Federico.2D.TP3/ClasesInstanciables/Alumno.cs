using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Alumno:Universitario
    {
        #region Enum
        /// <summary>
        /// Enumerado de estados de cuentas
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        #endregion

        #region Atributes

        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor default
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
        {

        }

        #endregion

        #region Methods

        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion
    }
}
