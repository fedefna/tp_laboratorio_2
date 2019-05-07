using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.ResetText();
            lblResultado.ResetText();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private static double Operar(string num1, string num2, string Operador)
        {
            Numero uno = new Numero(num1);
            Numero dos = new Numero(num2);
            
            return Calculadora.Operar(uno, dos, Operador);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirBinario_Click(object sender, EventArgs e)
        {
            if(double.TryParse(lblResultado.Text,out double num))
            {
                Numero numero = new Numero(num);
                lblResultado.Text= numero.DecimalBinario(num);
            }
        }

        private void btnConvertirDecimal_Click(object sender, EventArgs e)
        {
            if (double.TryParse(lblResultado.Text, out double num))
            {
                Numero numero = new Numero(num);
                lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
            }
        }
    }
}
