using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

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
            //if(double.TryParse(strNumero, out double numero))
            //{
            //    this.numero = numero;
            //}
            setNumero = strNumero;
        }

        private double ValidarNumero(string strNumero)
        {
            double result = 0;

            if (double.TryParse(strNumero, out double numero))
            {
                result = numero;
            }

            return result;
        }

        public string setNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

            
        public static string BinarioDecimal(string binario)
        {
            string retorno="";
            double resultado=0;

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
            }
            retorno = resultado.ToString();

            return retorno;
        }

        public static string DecimalBinario(double numero)
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


        public static string DecimalBinario(string numero)
        {
            string binario;
            double num;

            double.TryParse(numero, out num);

            binario = DecimalBinario(num);

            return binario;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double num;

            num = n1.numero + n2.numero;

            return num;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double num;

            num = n1.numero - n2.numero;

            return num;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double num;

            num = n1.numero / n2.numero;

            return num;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double num;

            num = n1.numero * n2.numero;

            return num;
        }   

    }
}
