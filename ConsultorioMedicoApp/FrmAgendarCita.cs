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
    public partial class FrmAgendarCita : Form
    {
        private int? citaId = null;

        public FrmAgendarCita(int idCita)
        {
            InitializeComponent();
            CargarPacientes();
            this.citaId = idCita;
            CargarMedicos();
            CargarHoras();
            CargarDatosCita();

        }
        public FrmAgendarCita()
        {
            InitializeComponent();
            CargarPacientes();
            CargarMedicos();
        }
        private void CargarDatosCita()
        {
            using (MySqlConnection conn = Conexion.ObtenerConexion())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM cita WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", citaId);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cbPaciente.SelectedValue = reader["id_paciente"];
                    cbMedico.SelectedValue = reader["id_medico"];
                    dtpFechaCita.Value = Convert.ToDateTime(reader["fecha_cita"]);
                    cbHora.Text = reader["hora"].ToString();
                    txtMotivo.Text = reader["motivo"].ToString();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmAgendarCita_Load(object sender, EventArgs e)
        {

        }

        private void CargarPacientes()
        {
            using (MySqlConnection conn = Conexion.ObtenerConexion())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT id, nombre FROM paciente", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbPaciente.DataSource = dt;
                cbPaciente.DisplayMember = "nombre";
                cbPaciente.ValueMember = "id";
            }
        }

        private void CargarMedicos()
        {
            using (MySqlConnection conn = Conexion.ObtenerConexion())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT id, nombre FROM medico", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbMedico.DataSource = dt;
                cbMedico.DisplayMember = "nombre";
                cbMedico.ValueMember = "id";
            }
        }

        private void CargarHoras()
        {
            // Horas predeterminadas (puedes modificar este rango)
            cbHora.Items.AddRange(new string[]
            {
                "08:00", "09:00", "10:00", "11:00",
                "13:00", "14:00", "15:00", "16:00"
            });
        }

        private void cbHora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbPaciente.SelectedValue == null || cbMedico.SelectedValue == null ||
                string.IsNullOrEmpty(cbHora.Text) || string.IsNullOrEmpty(txtMotivo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = Conexion.ObtenerConexion())
            {
                MySqlCommand cmd;

                if (citaId == null)
                {
                    // Insertar nueva cita
                    cmd = new MySqlCommand("INSERT INTO cita (id_paciente, id_medico, fecha_cita, hora, motivo, estado) VALUES (@id_paciente, @id_medico, @fecha, @hora, @motivo, 'pendiente')", conn);
                }
                else
                {
                    // Actualizar cita existente
                    cmd = new MySqlCommand("UPDATE cita SET id_paciente=@id_paciente, id_medico=@id_medico, fecha_cita=@fecha, hora=@hora, motivo=@motivo WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", citaId);
                }

                cmd.Parameters.AddWithValue("@id_paciente", cbPaciente.SelectedValue);
                cmd.Parameters.AddWithValue("@id_medico", cbMedico.SelectedValue);
                cmd.Parameters.AddWithValue("@fecha", dtpFechaCita.Value.Date);
                cmd.Parameters.AddWithValue("@hora", cbHora.Text);
                cmd.Parameters.AddWithValue("@motivo", txtMotivo.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(citaId == null ? "Cita registrada correctamente." : "Cita actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
