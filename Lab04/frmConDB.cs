using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab04
{
    public partial class frmConDB : Form
    {

        public SqlConnection conn;
        public frmConDB()
        {
            InitializeComponent();
        }

        private void frmConDB_Load(object sender, EventArgs e)
        {
            btnDesconectar.Enabled = false;
            btnEstado.Enabled = false;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            //Declaramos variables para conexión a bd
            String servidor = txtServidor.Text;
            String bd = txtBaseDatos.Text;
            String user = txtUsuario.Text;
            String pwd = txtPassword.Text;

            String str = "Server=" + servidor + ";DataBase=" + bd + ";";

            if (chkAutenticacion.Checked)
                str += "Integrated Security=true";
            else
                str += "User Id=" + user + ";Password = " + pwd + ";";

            //abrir una conexión en con el servidor
            try
            {
                conn = new SqlConnection(str);
                conn.Open();
                MessageBox.Show("Conectado Satisfactoriamente");
                btnDesconectar.Enabled = true;
                btnEstado.Enabled = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR al conectar al servidor: \n" + ex.ToString());
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Estado del servidor: " + conn.State +
                        "\nVersión del servidor : " + conn.ServerVersion +
                        "\nBase de datos: " + conn.Database);
                }
                else
                    MessageBox.Show("Estado del servidor: " + conn.State);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Imposible determinar el estado del servidor: \n" + ex.ToString());
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if ( conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    MessageBox.Show("Conexión cerrada Satisfactoriamente");
                    btnDesconectar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("La conexión ya esta cerrada");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cerrar la conexión: \n" +
                    ex.ToString());
            }
        }

        private void chkAutenticacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutenticacion.Checked)
            {
                txtUsuario.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona(conn);
            persona.Show();
        }

        private void txtServidor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
