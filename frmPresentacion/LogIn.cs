using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace frmPresentacion
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("Data Source=P005298\\SQLEXPRESS;Initial Catalog=SeguimientoTemas;Integrated Security=True");

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "select * from dbo.usuarios where ID_Usuario='"+ txtIdUsuario .Text+ "' and Pass='"+ txtPassUsuario .Text+ "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.HasRows == true)
            {
                MessageBox.Show("Bienvenido!");
                frmPresentacion log = new frmPresentacion();
                this.Hide();
                log.Show();
                
            }
            else 
            {
                MessageBox.Show("Usuario o contraseña incorrectas");
            }
            conexion.Close();
        }

        private void btnRegistrarLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string consulta = "insert into dbo.Usuarios values('"+ txtIdUsuario .Text + "','"+ txtPassUsuario .Text+ "')";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Nuevo usuario agregado");               
                conexion.Close();           
            }
            catch (Exception)
            {
                MessageBox.Show("Debe ingresar datos para guardar");
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
