using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    #region Enumerado de Nacionalidades
    public enum ENacionalidad
    {
        Argentino,Extranjero
    }
    #endregion

    abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Properties
        /// <summary>
        /// Devuelve y setea el apellido (validacion en el set)
        /// </summary>
        public string Apellido { get => apellido; set => apellido = ValidarNombreApellido(value); }
        
        /// <summary>
        /// Devuelve y setea el dni (validacion en el set)
        /// </summary>
        public int Dni { get => dni; set => dni = ValidarDni(this.nacionalidad,value); }

        /// <summary>
        /// Devuelve y setea la nacionalidad (sin validaciones)
        /// </summary>
        public ENacionalidad Nacionalidad { get => nacionalidad; set => nacionalidad = value; }

        /// <summary>
        /// Devuelve y setea el nombre (validacion en el set)
        /// </summary>
        public string Nombre { get => nombre; set => nombre = ValidarNombreApellido(value); }

        /// <summary>
        /// 
        /// </summary>
        public string StringToDni
        {
            set => dni = ValidarDni(this.nacionalidad, value);
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor publico sin dni
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">apellido  de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// constructor publico
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.Dni = dni;
        }


        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendFormat("\nNACIONALIDAD: {0}", this.Nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// Valida que el dni sea correcto:
        /// para argentino: entre 1 y 89999999
        /// para extranjero: entre 90000000 y 99999999.
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">dni de la persona</param>
        /// <returns>Devuelve el nro de dni si es valido, sino devuelve NacionalidadInvalidaException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;

            return retorno;
        }

        /// <summary>
        /// Convierte un dni de string a int y lo manda al metodo anterior
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Dni de la persona</param>
        /// <returns>El dni o si dni tiene formato erroneo DniInvalidoException o si dni no valida rangos la NacionalidadInvalidaException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;

            return retorno;
        }

        /// <summary>
        /// Valida que sean cadenas con caracteres válidos para nombres
        /// </summary>
        /// <param name="dato">Nombre de la persona</param>
        /// <returns>Devuelve el nombre o una cadena vacia</returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";

            return retorno;
        }
        #endregion
    }

}
