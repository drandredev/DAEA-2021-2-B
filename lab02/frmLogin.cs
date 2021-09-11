using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab02
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String pass = txtPassword.Text;

            String[] usuarios = { "andre", "maul" };

            String[] passwords = { "123", "456" };

            for (int i = 0; i < usuarios.Length; i++)
            {
                if (usuarios[i] == usuario && passwords[i] == pass)
                {
                    PrincipalMDI2 principal = new PrincipalMDI2();
                    principal.Show();
                    this.Hide();
                }

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
