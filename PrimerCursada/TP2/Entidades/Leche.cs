using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        /// <summary>
        /// Enumerado con los distintos tipos de leche posibles.
        /// </summary>
        public enum ETipo { Entera, Descremada }
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param> Marca del producto
        /// <param name="patente"></param>Codigo de barras
        /// <param name="color"></param> Color del empaque
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            tipo = ETipo.Entera;
        }

        /// <summary>
        /// Por defecto, TIPO será ENTERA. Segunto constructor
        /// </summary>
        /// <param name="marca"></param> Marca del producto
        /// <param name="patente"></param>Codigo de barras
        /// <param name="color"></param> Color del empaque
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo):this(marca,patente,color)
        {
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Devuelve todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
