using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Methods
        /// <summary>
        /// Valida que el operador sea uno de los cases, sino devuelve el operador +
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            string result = "";

            switch (operador)
            {
                case "*":
                    result = "*";
                    break;
                case "-":
                    result = "-";
                    break;
                case "/":
                    result = "/";
                    break;
                default:
                    result = "+";
                    break;
            }

            return result;

        }
        /// <summary>
        /// Operar utiliza los operators de la clase Numero y el metodo validarOperador
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double result;

            switch (ValidarOperador(operador))
            {
                case "*":
                    result = num1 * num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                default:
                    result = num1 + num2;
                    break;
            }

            return result;
        }
        #endregion
    }
}
