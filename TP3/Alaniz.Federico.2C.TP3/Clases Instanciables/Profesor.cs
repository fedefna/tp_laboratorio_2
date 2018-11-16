using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor:Universitario
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
        static Profesor()
        {
            random = new Random();
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
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia= new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Un profesor es igual a una clase si da la clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if (c == clase)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Un profesor es distinto de una clase si no la da
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }
        /// <summary>
        ///  se asignarán dos clases al azar al Profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }
        /// <summary>
        ///  retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nCLASES DEL DIA: ");
            foreach (Universidad.EClases c in this.clasesDelDia)
            {
                sb.AppendFormat("\n{0}", c);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}.", base.MostrarDatos(), this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Hace publicos los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

    }
}
