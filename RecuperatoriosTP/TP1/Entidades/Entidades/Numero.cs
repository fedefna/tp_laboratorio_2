using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributes
        private double numero;
        #endregion

        #region Properties
        public string setNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Constructors
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            setNumero = strNumero;
        }
        #endregion

        #region Methods
        /// <summary>
        /// si se puede parsear strNumero a souble lo guardo en num y lo asigno a result
        /// </summary>
        /// <param name="strNumero">Recibo el string a parsear</param>
        /// <returns>El numero parseado o 0 si no se pudo parsear.</returns>
        private static double ValidarNumero(string strNumero)
        {
            double result = 0;

            if (double.TryParse(strNumero, out double num))
            {
                result = num;
            }
            //Siempre devuelvo result
            return result;
        }
        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>un string con el numero binario en formato decimal caso contratio:"Valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {
            string result = "Valor invalido";
            double resultado = 0;
            int aux = 0;

            char[] array = binario.ToCharArray();
            // Invertido xq los valores van incrementandose de derecha a izquierda: 16-8-4-2-1
            Array.Reverse(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    // potencia de 2, según la posición
                    resultado += (int)Math.Pow(2, i);
                }
                else
                {
                    if (array[i] != '0')
                    {
                        aux = 1;
                        break;
                    }
                }
            }
            if (aux == 0)
            {
                result = resultado.ToString();
            }
            return result;
        }
        /// <summary>
        /// Convierte un decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>devuelve el binario en formato string caso contrario:"Valor invalido".</returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";

            while (numero != 0 && numero != 1)
            {
                if (numero % 2 == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }

                numero = Math.Truncate(numero / 2);
            }

            binario = numero + binario;

            return binario;
        }
        /// <summary>
        /// cmabia el decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Devuelve el binario del numero ingresado o "Numero invalido" en caso contrario.</returns>
        public string DecimalBinario(string numero)
        {
            string result = "Numero invalido!";

            if (double.TryParse(numero, out double num))
            {
                result = DecimalBinario(num);
            }
            return result;
        }
        #endregion

        #region Operators
        public static double operator +(Numero n1, Numero n2)
        {
            double num;

            num = n1.numero + n2.numero;

            return num;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double result;

            result = n1.numero - n2.numero;

            return result;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double result;

            if (n2.numero == 0)
            {
                result = double.MinValue;
            }
            else
            {
                result = n1.numero / n2.numero;
            }

            return result;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double result;

            result = n1.numero * n2.numero;

            return result;
        }
        #endregion

    }
}
