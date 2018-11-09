using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Enumerado de Clases
        public enum EClases
        {
            Programacion, Laboratorio, SPD, Legislacion
        }
        #endregion

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;
        #endregion

        #region Properties
        /// <summary>
        /// Propeidad de lectura/escritura de la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }


        /// <summary>
        /// Propiedad de lectura/escritura de la lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }

            set
            {
                this.jornadas = value;
            }
        }


        /// <summary>
        /// Propiedad de lectura/escritura de la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Se accederá a una Jornada específica a través de un indexador.
        /// </summary>
        /// <param name="i">indice de la jornada</param>
        /// <returns>la jornada correspondiente al indice</returns>
        public Jornada this[int i]
        {
            get
            {
                if(i>=0 && i <= this.Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (i >= 0 && i <= this.Jornadas.Count)
                {
                    this.Jornadas[i]=value;
                }
            }
        }
        #endregion

        #region Constructor
        public Universidad()
        {

        }
        #endregion

        #region Metodos
        public static bool Guardar(Universidad uni)
        {

        }
        #endregion
    }
}
