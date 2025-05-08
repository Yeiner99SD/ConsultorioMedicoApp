using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConsultorioMedicoApp
{
    public partial class FrmCitas : Form
    {
        public FrmCitas()
        {
            InitializeComponent();
            CargarCitas();

        }

        private void FrmCitas_Load(object sender, EventArgs e)
        {

        }

        private void CargarCitas(DateTime? fecha = null)
        {
            string query = "SELECT c.id, p.nombre AS Paciente, m.nombre AS Medico, e.nombre AS Especialidad, c.fecha_cita, c.hora, c.motivo, c.estado " +
                           "FROM cita c " +
                           "JOIN paciente p ON c.id_paciente = p.id " +
                           "JOIN medico m ON c.id_medico = m.id " +
                           "JOIN especialidad e ON m.especialidad_id = e.id ";

            if (fecha != null)
            {
                query += "WHERE c.fecha_cita = @fecha";
            }

            using (MySqlConnection conn = Conexion.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                if (fecha != null)
                    cmd.Parameters.AddWithValue("@fecha", fecha.Value.Date);

                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                dgvCitas.DataSource = dt;
            }
           dgvCitas.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarCitas(dtpFiltroFecha.Value);
        }

        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            FrmAgendarCita agendar = new FrmAgendarCita();
            agendar.ShowDialog();
            CargarCitas(); // Recarga al cerrar
        }

        private void dgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
