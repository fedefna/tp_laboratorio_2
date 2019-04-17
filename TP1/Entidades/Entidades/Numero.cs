using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        //Atributos
        private double numero;

        //Properties
        public string setNumero
        {
            set 
            {
                this.numero = ValidarNumero(value);
            }
        }

        //Constructores
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

        //Metodos
        /// <summary>
        /// si se puede parsear strNumero a souble lo guardo en num y lo asigno a result
        /// </summary>
        /// <param name="strNumero">Recibo el string a parsear</param>
        /// <returns>El numero parseado o 0 si no se pudo parsear.</returns>
        private static double ValidarNumero(string strNumero)
        {
            double result = 0;
            
            if (double.TryParse(strNumero,out double num))
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
                    if(array[i] != '0')
                    {
                        aux = 1;
                        break;
                    }
                }
            }
            if (aux==0){
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
            string binario = "Valor invalido.";
            string aux = "";

            while (numero != 0 && numero != 1)
            {
                if (numero % 2 == 0)
                {
                    aux = "0" + aux;
                }
                else
                {
                    aux = "1" + aux;
                }

                numero = Math.Truncate(numero / 2);
            }

            aux = numero + binario;
            return binario;
        }

        public string DecimalBinario(string numero)
        {

        }

    }
}
