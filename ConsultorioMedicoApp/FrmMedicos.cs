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
    public partial class FrmMedicos : Form
    {
        private int idMedicoSeleccionado = -1;

        public FrmMedicos()
        {
            InitializeComponent();
        }

        private void FrmMedicos_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarEspecialidades();
            CargarMedicos();
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!CamposCompletos())
            {
                MessageBox.Show("Por favor, complete todos los campos y seleccione una especialidad.");
                return;
            }

            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = "INSERT INTO Medico (nombre, especialidad_id, email, telefono, consultorio) " +
                               "VALUES (@nombre, @especialidad_id, @email, @telefono, @consultorio)";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@especialidad_id", ((KeyValuePair<int, string>)cmbEspecialidad.SelectedItem).Key);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@consultorio", txtConsultorio.Text.Trim());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Médico guardado correctamente.");
                CargarMedicos();
                LimpiarFormulario();
            }
        }
        private void CargarMedicos()
        {
            dgvMedicos.Rows.Clear();

            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = @"SELECT m.id, m.nombre, e.nombre AS especialidad, m.email, m.telefono, m.consultorio 
                                 FROM Medico m 
                                 INNER JOIN Especialidad e ON m.especialidad_id = e.id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvMedicos.Rows.Add(
                        reader["id"],
                        reader["nombre"],
                        reader["especialidad"],
                        reader["email"],
                        reader["telefono"],
                        reader["consultorio"]
                    );
                }
            }
        }

        private void CargarEspecialidades()
        {
            cmbEspecialidad.Items.Clear();
            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = "SELECT id, nombre FROM Especialidad";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbEspecialidad.Items.Add(new KeyValuePair<int, string>(
                        Convert.ToInt32(reader["id"]),
                        reader["nombre"].ToString()));
                }
            }

            cmbEspecialidad.DisplayMember = "Value";
            cmbEspecialidad.ValueMember = "Key";
        }

        private void ConfigurarDataGridView()
        {
            dgvMedicos.ColumnCount = 6;
            dgvMedicos.Columns[0].Name = "ID";
            dgvMedicos.Columns[1].Name = "Nombre";
            dgvMedicos.Columns[2].Name = "Especialidad";
            dgvMedicos.Columns[3].Name = "Email";
            dgvMedicos.Columns[4].Name = "Teléfono";
            dgvMedicos.Columns[5].Name = "Consultorio";
            dgvMedicos.ReadOnly = true;
            dgvMedicos.AllowUserToAddRows = false;
            dgvMedicos.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            cmbEspecialidad.SelectedIndex = -1;
            txtEmail.Clear();
            txtTelefono.Clear();
            txtConsultorio.Clear();
            idMedicoSeleccionado = -1;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private bool CamposCompletos()
        {
            return !string.IsNullOrWhiteSpace(txtNombre.Text)
                && cmbEspecialidad.SelectedItem != null
                && !string.IsNullOrWhiteSpace(txtEmail.Text)
                && !string.IsNullOrWhiteSpace(txtTelefono.Text)
                && !string.IsNullOrWhiteSpace(txtConsultorio.Text);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idMedicoSeleccionado == -1 || !CamposCompletos())
            {
                MessageBox.Show("Seleccione un médico y complete todos los campos.");
                return;
            }

            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = "UPDATE Medico SET nombre=@nombre, especialidad_id=@especialidad_id, email=@email, " +
                               "telefono=@telefono, consultorio=@consultorio WHERE id=@id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@especialidad_id", ((KeyValuePair<int, string>)cmbEspecialidad.SelectedItem).Key);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@consultorio", txtConsultorio.Text.Trim());
                cmd.Parameters.AddWithValue("@id", idMedicoSeleccionado);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Médico actualizado.");
                CargarMedicos();
                LimpiarFormulario();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idMedicoSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un médico primero.");
                return;
            }

            DialogResult confirm = MessageBox.Show("¿Está seguro de eliminar este médico?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                using (var conexion = Conexion.ObtenerConexion())
                {
                    string query = "DELETE FROM Medico WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idMedicoSeleccionado);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Médico eliminado.");
                CargarMedicos();
                LimpiarFormulario();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMedicos.Rows[e.RowIndex];

                idMedicoSeleccionado = Convert.ToInt32(row.Cells[0].Value);
                txtNombre.Text = row.Cells[1].Value.ToString();
                cmbEspecialidad.SelectedIndex = cmbEspecialidad.FindStringExact(row.Cells[2].Value.ToString());
                txtEmail.Text = row.Cells[3].Value.ToString();
                txtTelefono.Text = row.Cells[4].Value.ToString();
                txtConsultorio.Text = row.Cells[5].Value.ToString();

                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }
    }
}
