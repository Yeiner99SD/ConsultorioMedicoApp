using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConsultorioMedicoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection con = Conexion.ObtenerConexion();
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Conexion exitosa");
                con.Close();
            }
        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_registrart_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear(); // Limpia lo anterior

            FrmPacientes frm = new FrmPacientes();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(frm);
            frm.Show();
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void buttonstatic_medicos_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();

            FrmMedicos frm = new FrmMedicos();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(frm);
            frm.Show();
        }

        private void buttonstatic_citas_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();

            FrmCitas frm = new FrmCitas();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(frm);
            frm.Show();
        }
    }
}
