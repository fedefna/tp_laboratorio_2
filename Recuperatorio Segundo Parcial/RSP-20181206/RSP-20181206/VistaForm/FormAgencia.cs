using System;
using System.Windows.Forms;
using Entidades;
using Archivos;

namespace VistaForm
{
    public partial class FormAgencia : Form
    {
        private Agencia agencia;

        public FormAgencia()
        {
            InitializeComponent();
            agencia = new Agencia("Agencia UTN");
            string[] items = new string[] { "Micro", "Avión" };
            this.cmbTipoPasaje.DataSource = items;
            this.cmbTipoPasaje.SelectedIndex = 0;
            this.nudEscalas.Enabled = false;


            this.txtNombre.Text = "Nombre";
            this.txtApellido.Text = "Apellido";
            this.txtDni.Text = "33444555";
            this.txtOrigen.Text = "Buenos Aires";
            this.txtDestino.Text = "Cordoba";
            cmbTipoServicio.DataSource = Enum.GetValues(typeof(Servicio));
        }

        private void btnEmitirPasaje_Click(object sender, System.EventArgs e)
        {
            Pasajero pasajero = new Pasajero(txtNombre.Text, txtApellido.Text, txtDni.Text);
            Pasaje pasaje = null;

            if (cmbTipoPasaje.Text == "Avion")
            {
                pasaje = new PasajeAvion(txtOrigen.Text, txtDestino.Text, pasajero, float.Parse(txtPrecio.Text), dtpFechaPartida.Value, int.Parse(nudEscalas.ToString()));
            }
            else
                if(cmbTipoPasaje.Text == "Micro")
                {
                    Servicio servicio = Servicio.Comun;
                    if (cmbTipoServicio.Text == "Ejecutivo")
                    {
                        servicio = Servicio.Ejecutivo;
                    }
                    else
                    {
                        if(cmbTipoServicio.Text == "SemiCama")
                        {
                            servicio = Servicio.SemiCama;
                        }
                    }
                try
                {
                    pasaje = new PasajeMicro(txtOrigen.Text, txtDestino.Text, pasajero, float.Parse(txtPrecio.Text), dtpFechaPartida.Value, servicio);
                }
                catch (Exception)
                {
                    MessageBox.Show("Complete todos los datos");
                }
                }
            agencia+=pasaje;
        }

        private void btnMostrar_Click(object sender, System.EventArgs e)
        {
            if(!(agencia.PasajesVendidos is null))
            {
                rtbMostrar.Text = (string)agencia;
            }
            else
            {
                MessageBox.Show("Agencia vacia");
            }
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            Xml<Agencia> xml = new Xml<Agencia>();
            try
            {
                xml.Guardar("Agencia.xml", agencia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbTipoPasaje_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.cmbTipoPasaje.SelectedIndex == 0)
            {
                this.nudEscalas.Enabled = false;
                this.nudEscalas.Value = 0;
                this.cmbTipoServicio.Enabled = true;
            }
            else
            {
                this.nudEscalas.Enabled = true;
                this.cmbTipoServicio.Enabled = false;
            }
        }

        private void FormAgencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormAgencia_Load(object sender, EventArgs e)
        {
            agencia.Informar += MostrarMensaje;
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
    }
}
