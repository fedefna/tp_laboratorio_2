using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

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
                if (i >= 0 && i <= this.Jornadas.Count)
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
                    this.Jornadas[i] = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus
        /// Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> aux = new Xml<Universidad>();

            if (aux.Guardar("Universidad.xml", uni) == false)
            { //Si no se pudo guardar lanza la excepción.
                throw new ArchivosException("No se pudo guardar la universidad.");
            }

            return retorno;
        }
        /// <summary>
        /// Desserializa los datos de una universidad para mostrarlos
        /// </summary>
        /// <returns>La universidad con todos los datos del xml</returns>
        public static Universidad Leer()
        {
            Universidad retorno;
            Xml <Universidad> aux = new Xml<Universidad>();

            if (!(aux.Leer("Universidad.xml",out retorno)))
            {
                throw new ArchivosException("No se pudo leer el archivo xml.");
            }

            return retorno;
        }
        /// <summary>
        /// MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante
        /// ToString
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Jornada j in uni.Jornadas)
            {
                sb.AppendFormat("JORNADA:");
                sb.AppendFormat(j.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Los datos del Universidad se harán públicos mediante
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        ///  Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.Alumnos.Contains(a);
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.Instructores.Contains(i);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach(Profesor p in g.Instructores)
            {
                if(p == clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// El distinto retornará el primer Profesor que no
        /// pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Instructores)
            {
                if (p != clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
        /// clase, un Profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la
        /// toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g , EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);
            foreach(Alumno a in g.Alumnos)
            {
                if (a==clase)
                {
                    jornada.Alumnos.Add(a);
                }
            }
            g.Jornadas.Add(jornada);

            return g;
        }
        /// <summary>
        /// Inscribe a un alumno a la universidad (Siempre que no esté ya inscripto).
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoExistenteException();
            }
            return u;
        }
        /// <summary>
        /// Inscribe a un profesor a la universidad (Siempre que no esté ya inscripto).
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            else
            {
                throw new ProfesorExistenteException();
            }
            return u;
        }
        #endregion
    }
}
