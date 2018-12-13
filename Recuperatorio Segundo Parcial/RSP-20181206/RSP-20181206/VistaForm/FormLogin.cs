using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaForm
{
    public partial class FormLogin : Form
    {
        Usuario usuario;
        public FormLogin()
        {
            InitializeComponent();
            txtClave.UseSystemPasswordChar = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //ALUMNO
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            try
            {
                usuario = usuarioDAO.Leer(txtUsuario.Text,txtClave.Text);
                if (usuario is null)
                {
                    MessageBox.Show("Usuario o claves incorrectos", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar recuperar el usuario.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (usuario != null)
            {
                this.Hide();
                FormAgencia f2 = new FormAgencia();
                f2.ShowDialog();
            }

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {

            //ALUMNO
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuario = new Usuario(txtUsuario.Text, txtClave.Text);
            try
            {
                usuarioDAO.Guardar(usuario);
                MessageBox.Show("Usuario registrado.");
            }
            catch (ClaveInvalidaException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al registrar usuario.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //limpio los controles después del registro
            this.txtUsuario.Clear();
            this.txtClave.Clear();
            usuario = null;

        }
    }
}
