using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;


namespace frmPresentacion
{
    public partial class frmPresentacion : Form
    { 
        public frmPresentacion()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("Data Source=P005298\\SQLEXPRESS;Initial Catalog=SeguimientoTemas;Integrated Security=True");

        #region Botones Control Formulario Padre
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDescargarTemas_Click(object sender, EventArgs e)
        {
            exportaraexcel(dtgViewNuevoTema);
            MessageBox.Show("Exportacion de datos realizada");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }
        #endregion

        #region Funciones Limpiar Campos
        public void limpiarCamposNuevoTema() 
        {
            txtBoxNombreProyectoNuevoTema.Text = "";
            cmbBoxUnidadNegocio.Text = "";
            cmboxTipoProyecto.Text = "";
            txtBoxBreveReseñaNuevoTema.Text = "";
            cmbBoxDesarrollador.Text = "";
            txtBoxIdNecesidad.Text = "";
            txtDevOps.Text = "";
            cmbBoxEstado.Text = "";
            txtNuevoTemaFechaInicio.Text = "";
            txtNuevoTemaFechaFin.Text = "";
            cmbAnalistaNuevoTema.Text = "";

        }

        public void limpiarCamposNuevaNovedad()
        {
          
            txtBoxNombreProyectoNuevaNovedad.Text = "";
            txtBoxBreveReseñaNuevaNovedad.Text = "";
            txtNuevaNovedadFechaInicio.Text = "";
            txtNuevaNovedadFechaFin.Text = "";

        }
        #endregion

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        #region Mostrar datos DtgView
        public void llenarTablaTemas()
        {
            string consultaTemas = "select * from dbo.NuevoTema";
            SqlDataAdapter adaptadorNuevoTema = new SqlDataAdapter(consultaTemas, conexion);
            DataTable dtNuevoTema = new DataTable();
            adaptadorNuevoTema.Fill(dtNuevoTema);
            dtgViewNuevoTema.DataSource = dtNuevoTema;
        }

        public void llenarTablaNovedad() 
        {
            string consultaNovedades = "select * from dbo.NuevaNovedad";
            SqlDataAdapter adaptadorNovedades = new SqlDataAdapter(consultaNovedades, conexion);
            DataTable dtNovedades = new DataTable();
            adaptadorNovedades.Fill(dtNovedades);
            dtgViewNuevaNovedad.DataSource = dtNovedades;
        }
        #endregion

        private void frmPresentacion_Load(object sender, EventArgs e)
        {
            string consultaTemas = "select * from dbo.NuevoTema";
            SqlDataAdapter adaptadorNuevoTema = new SqlDataAdapter(consultaTemas, conexion);
            DataTable dtNuevoTema = new DataTable();
            adaptadorNuevoTema.Fill(dtNuevoTema);
            dtgViewNuevoTema.DataSource = dtNuevoTema;

            string consultaNovedades = "select * from dbo.NuevaNovedad";
            SqlDataAdapter adaptadorNovedades = new SqlDataAdapter(consultaNovedades,conexion);
            DataTable dtNovedades = new DataTable();
            adaptadorNovedades.Fill(dtNovedades);
            dtgViewNuevaNovedad.DataSource = dtNovedades;   
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            limpiarCamposNuevoTema();
        }

        private void btnRefrescarNovedades_Click(object sender, EventArgs e)
        {
            limpiarCamposNuevaNovedad();
        }

        private void btnGuardarNuevoTema_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string consulta = "insert into dbo.NuevoTema values('" + txtBoxNombreProyectoNuevoTema.Text.ToUpper() + "','" + cmbBoxUnidadNegocio.Text.ToUpper() + "','" + cmboxTipoProyecto.Text.ToUpper() + "','" + txtBoxBreveReseñaNuevoTema.Text.ToUpper() + "','" + cmbBoxDesarrollador.Text.ToUpper() + "','" + txtBoxIdNecesidad.Text.ToUpper() + "','" + txtDevOps.Text.ToUpper() + "','" + cmbBoxEstado.Text.ToUpper() + "', '" + txtNuevoTemaFechaInicio.Text + "','" + txtNuevoTemaFechaFin.Text + "','"+ cmbAnalistaNuevoTema .Text.ToUpper()+ "')";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Nuevo tema agregado");
                llenarTablaTemas();
                conexion.Close();
                limpiarCamposNuevoTema();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe ingresar datos para guardar");
            }
        }

        private void btnGuardarNovedad_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string consulta = "insert into dbo.NuevaNovedad values('" + txtBoxNombreProyectoNuevaNovedad.Text.ToUpper() + "','" + txtBoxBreveReseñaNuevaNovedad.Text.ToUpper() + "','" + txtNuevaNovedadFechaInicio.Text + "','" + txtNuevaNovedadFechaInicio.Text + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Nueva novedad agregada");
                llenarTablaNovedad();
                conexion.Close();
                limpiarCamposNuevaNovedad();
            }
            catch (Exception)
            {

                MessageBox.Show("Debe ingresar datos para guardar");
            }
        }

        private void dtgViewNuevoTema_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtgViewNuevoTema_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void txtBoxNombreProyectoNuevaNovedad_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxNombreProyectoNuevaNovedad.Text!="") 
            {
                dtgViewNuevaNovedad.CurrentCell = null;
                foreach (DataGridViewRow r in dtgViewNuevaNovedad.Rows) 
                {
                    r.Visible = false;
                }

                foreach (DataGridViewRow r in dtgViewNuevaNovedad.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().ToUpper()).IndexOf(txtBoxNombreProyectoNuevaNovedad.Text.ToUpper()) == 0) ;
                        {
                            r.Visible = true;
                            break;
                        }
                    }

                }
      
            }
            else
            {
                conexion.Close();
            }
        }

        private void dtgViewNuevoTema_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            //txtBoxNombreProyectoNuevoTema.Text = dtgViewNuevoTema.CurrentRow.Cells[1].Value.ToString();
            //cmbBoxUnidadNegocio.Text = dtgViewNuevoTema.CurrentRow.Cells[2].Value.ToString();
            //cmboxTipoProyecto.Text = dtgViewNuevoTema.CurrentRow.Cells[3].Value.ToString();
            //txtBoxBreveReseñaNuevoTema.Text = dtgViewNuevoTema.CurrentRow.Cells[4].Value.ToString();
            //cmbBoxDesarrollador.Text = dtgViewNuevoTema.CurrentRow.Cells[5].Value.ToString();
            //txtBoxIdNecesidad.Text = dtgViewNuevoTema.CurrentRow.Cells[6].Value.ToString();
            //txtDevOps.Text = dtgViewNuevoTema.CurrentRow.Cells[7].Value.ToString();
            //cmbBoxEstado.Text = dtgViewNuevoTema.CurrentRow.Cells[8].Value.ToString();
        }

        public void exportaraexcel(DataGridView tabla)
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int IndiceColumna = 0;

            foreach (DataGridViewColumn col in tabla.Columns)
            {

                IndiceColumna++;

                excel.Cells[1, IndiceColumna] = col.Name;

            }

            int IndeceFila = 0;

            foreach (DataGridViewRow row in tabla.Rows)
            {

                IndeceFila++;

                IndiceColumna = 0;

                foreach (DataGridViewColumn col in tabla.Columns)
                {

                    IndiceColumna++;

                    excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;

                }

            }

            excel.Visible = true;


        }

        private void btnDescargarNovedad_Click(object sender, EventArgs e)
        {
            exportaraexcel(dtgViewNuevaNovedad);
            MessageBox.Show("Exportacion de datos realizada");
        }

        private void dtgViewNuevaNovedad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtNuevaNovedadFechaInicio.Text = dtgViewNuevaNovedad.CurrentRow.Cells[4].Value.ToString();
            //txtNuevaNovedadFechaFin.Text = dtgViewNuevaNovedad.CurrentRow.Cells[3].Value.ToString();
            //txtBoxBreveReseñaNuevaNovedad.Text = dtgViewNuevaNovedad.CurrentRow.Cells[1].Value.ToString();
            //txtBoxNombreProyectoNuevaNovedad.Text = dtgViewNuevaNovedad.CurrentRow.Cells[2].Value.ToString();

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form form = new Ayuda();
            form.Show();
        }
    }
}
