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
    public partial class Persona : Form
    {
        SqlConnection conn;
        public Persona(SqlConnection connDB)
        {
            this.conn = connDB;
            InitializeComponent();
            
        }

        private void Persona_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(conn.State.ToString());
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if(conn.State == ConnectionState.Open)
            {
                String sql = "select * from Person";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                dgvListado.DataSource = dt;
                dgvListado.Refresh();

            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if ( conn.State == ConnectionState.Open)
            {
                String FirstName = txtNombre.Text;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "BuscarPersonaNombre";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //crear parametros
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@FirstName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Value = FirstName;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                dgvListado.DataSource = dt;
                dgvListado.Refresh();
            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
        }
    }
}
