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
            FrmAgendarCita frm = new FrmAgendarCita();
            frm.ShowDialog();
            CargarCitas();
        }

        private void dgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditarCita_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cita para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCita = Convert.ToInt32(dgvCitas.SelectedRows[0].Cells["id"].Value);

            FrmAgendarCita frm = new FrmAgendarCita(idCita);
            frm.ShowDialog();
            CargarCitas(); // refresca la lista
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cita para cancelar.");
                return;
            }

            int id = Convert.ToInt32(dgvCitas.SelectedRows[0].Cells["id"].Value);

            DialogResult r = MessageBox.Show("¿Está seguro de cancelar esta cita?", "Confirmar", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE cita SET estado = 'cancelada' WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                CargarCitas();
            }
        }
    }
}
