using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region Enum
        /// <summary>
        /// Enumerado de nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion

        #region Atributes

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }

        #endregion


        #region Properties

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.Nacionalidad,value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Convierte un DNI pasado como string a int. Valida que esté correctamente escrito y lo setea. 
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        ///valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y
        ///89999999 y Extranjero entre 90000000 y 99999999. Caso contrario, se lanzará la excepción
        ///NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1 || dato > 99999999) //Si está fuera de los rangos permitidos para cualquier nacionalidad.
            {
                throw new DniInvalidoException("DNI en rango inválido.");
            }
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato > 89999999) //Fuera del rango para Argentinos.
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato <= 89999999) //Fuera del rango para extranjeros.
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    }
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Este metodo trata de parsear el dni recibido en string.
        /// Si no se puede DniInvalidoException, si se puede se envia el dni en int al metodo anterior.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniInt;

            if (Regex.IsMatch(dato, @"^[0-9]+[0-9\.]*$")) //Contiene al menos 1 numero y luego, numeros o puntos. 
            {
                dato = dato.Replace(".", ""); //Quito los puntos. 
                Int32.TryParse(dato, out dniInt); //Parseo a Int. 
            }
            else //Si el DNI ingresado no tiene un formato válido... DNIInvalidoException. 
            {
                throw new DniInvalidoException("DNI ingresado tiene un formato inválido.");
            }

            return ValidarDni(nacionalidad, dniInt); //Lo envía al otro método para que valide el rango.
        }
        /// <summary>
        /// Valida que el apellido/nombre sea sólo letras, con opción de poner un espacio seguido de un segundo apellido/nombre. 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Apellido/nombre validado o cadena vacía.</returns>
        private static string ValidarNombreApellido(string dato)
        {
            string result = "";
            if (Regex.IsMatch(dato, @"^([a-zA-Záéíóú]+)(\s[a-zA-Záéíóú]+)*$"))
            {
                result = dato;
            }
            return result;
        }
        #endregion

        /// <summary>
        /// Sobrescritura de ToString(). 
        /// </summary>
        /// <returns>Nombre completo y nacionalidad de la persona.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendFormat("\nNACIONALIDAD: {0}", this.Nacionalidad);
            return sb.ToString();
        }
    }
}
