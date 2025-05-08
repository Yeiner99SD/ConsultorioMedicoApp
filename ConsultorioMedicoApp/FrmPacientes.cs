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
    public partial class FrmPacientes : Form
    {
        private int idPacienteSeleccionado = -1;

        public FrmPacientes()
        {
            InitializeComponent();
        }
        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarPacientes();
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
        private void CargarPacientes()
        {
            dgvPacientes.Rows.Clear();

            using (var conexion = Conexion.ObtenerConexion())
            {
                if (conexion == null) return;

                string query = "SELECT * FROM Paciente";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvPacientes.Rows.Add(
                        reader["id"],
                        reader["nombre"],
                        reader["apellido"],
                        reader["documento"],
                        reader["email"],
                        reader["telefono"],
                        Convert.ToDateTime(reader["fecha_nacimiento"]).ToString("yyyy-MM-dd")
                    );
                }
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvPacientes.ColumnCount = 7;
            dgvPacientes.Columns[0].Name = "ID";
            dgvPacientes.Columns[1].Name = "Nombre";
            dgvPacientes.Columns[2].Name = "Apellido";
            dgvPacientes.Columns[3].Name = "Documento";
            dgvPacientes.Columns[4].Name = "Email";
            dgvPacientes.Columns[5].Name = "Teléfono";
            dgvPacientes.Columns[6].Name = "Fecha Nacimiento";
            dgvPacientes.ReadOnly = true;
            dgvPacientes.AllowUserToAddRows = false;
            dgvPacientes.DefaultCellStyle.ForeColor = Color.Black;

        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            idPacienteSeleccionado = -1;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTelefono_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFechaNacimiento_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!CamposCompletos())
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            using (var conexion = Conexion.ObtenerConexion())
            {
                if (conexion == null)
                    return;

                string query = "INSERT INTO Paciente (nombre, apellido, documento, email, telefono, fecha_nacimiento) " +
                               "VALUES (@nombre, @apellido, @documento, @email, @telefono, @fechaNacimiento)";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                cmd.Parameters.AddWithValue("@documento", txtDocumento.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@fechaNacimiento", dtpFechaNacimiento.Value.Date);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Paciente guardado correctamente.");
                CargarPacientes();
                LimpiarFormulario();
            }
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPacientes.Rows[e.RowIndex];

                idPacienteSeleccionado = Convert.ToInt32(row.Cells[0].Value);
                txtNombre.Text = row.Cells[1].Value.ToString();
                txtApellido.Text = row.Cells[2].Value.ToString();
                txtDocumento.Text = row.Cells[3].Value.ToString();
                txtEmail.Text = row.Cells[4].Value.ToString();
                txtTelefono.Text = row.Cells[5].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(row.Cells[6].Value);

                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idPacienteSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un paciente primero.");
                return;
            }

            if (!CamposCompletos())
            {
                MessageBox.Show("Por favor, complete todos los campos antes de editar.");
                return;
            }

            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = "UPDATE Paciente SET nombre = @nombre, apellido = @apellido, documento = @documento, " +
                               "email = @email, telefono = @telefono, fecha_nacimiento = @fechaNacimiento " +
                               "WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                cmd.Parameters.AddWithValue("@documento", txtDocumento.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@fechaNacimiento", dtpFechaNacimiento.Value.Date);
                cmd.Parameters.AddWithValue("@id", idPacienteSeleccionado);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Paciente actualizado.");
                CargarPacientes();
                LimpiarFormulario();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idPacienteSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un paciente primero.");
                return;
            }

            var confirmacion = MessageBox.Show("¿Estás seguro de eliminar este paciente?", "Confirmar eliminación", MessageBoxButtons.YesNo);

            if (confirmacion == DialogResult.Yes)
            {
                using (var conexion = Conexion.ObtenerConexion())
                {
                    string query = "DELETE FROM Paciente WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idPacienteSeleccionado);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Paciente eliminado.");
                CargarPacientes();
                LimpiarFormulario();
            }
        }
        private bool CamposCompletos()
        {
            return !string.IsNullOrWhiteSpace(txtNombre.Text)
                && !string.IsNullOrWhiteSpace(txtApellido.Text)
                && !string.IsNullOrWhiteSpace(txtDocumento.Text)
                && !string.IsNullOrWhiteSpace(txtEmail.Text)
                && !string.IsNullOrWhiteSpace(txtTelefono.Text);
        }
    }
}
