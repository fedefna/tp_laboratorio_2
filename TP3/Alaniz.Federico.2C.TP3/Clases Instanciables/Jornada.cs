using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Properties
        public Universidad.EClases Clase { get => clase; set => clase = value; }
        public List<Alumno> Alumnos { get => alumnos; set => alumnos = value; }
        public Profesor Instructor { get => instructor; set => instructor = value; }
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor privado que inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor publico que setea clase, instructor y llama al privado
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        /// <summary>
        /// Guardar de clase guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada de la cual se sacan los datos</param>
        /// <returns>true or false</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            bool retorno = true;
            if (!(texto.Guardar("Jornada.txt", jornada.ToString())))
            {
                retorno = false;
                throw new ArchivoTxtException("No se puede guardar el archivo TXT.");
            }
            return retorno;
        }
        /// <summary>
        ///  Leer de clase retornará los datos de la Jornada como texto.
        /// </summary>
        /// <returns>retornará los datos de la Jornada como texto.</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string retorno = "No se pudo leer el archivo.";
            if (!(texto.Leer("Jornada.txt", out retorno)))
            {
                throw new ArchivoTxtException("Error al leer el archivo TXT.");
            }
            return retorno;
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>True or false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.Alumnos.Contains(a);
        }
        /// <summary>
        /// Una Jornada será distinta a un Alumno si el mismo no participa de la clase
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true or false</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j==a);
        }
        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j">jornada a agregar alumnos</param>
        /// <param name="a">alumnoa agregar en la jornada</param>
        /// <returns>devuelve la jornada actualizada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j.Alumnos.Contains(a)))
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// ToString mostrará todos los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Clase: {0}/nInstructor: {1}/nLista de Alumnos:",this.Clase,this.Instructor.ToString());
            foreach(Alumno a in this.Alumnos)
            {
                sb.AppendFormat("/n{0}",a);
            }
            return sb.ToString();
        }
        #endregion
    }
}
