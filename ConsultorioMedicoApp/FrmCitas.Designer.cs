namespace ConsultorioMedicoApp
{
    partial class FrmCitas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvCitas = new DataGridView();
            dtpFiltroFecha = new DateTimePicker();
            btnFiltrar = new Button();
            btnNuevaCita = new Button();
            btnEditarCita = new Button();
            btnCancelarCita = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            SuspendLayout();
            // 
            // dgvCitas
            // 
            dgvCitas.BackgroundColor = SystemColors.Control;
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCitas.Location = new Point(34, 141);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.Size = new Size(893, 323);
            dgvCitas.TabIndex = 0;
            dgvCitas.CellContentClick += dgvCitas_CellContentClick;
            // 
            // dtpFiltroFecha
            // 
            dtpFiltroFecha.Location = new Point(34, 92);
            dtpFiltroFecha.Name = "dtpFiltroFecha";
            dtpFiltroFecha.Size = new Size(222, 23);
            dtpFiltroFecha.TabIndex = 1;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(262, 92);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(75, 23);
            btnFiltrar.TabIndex = 2;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnNuevaCita
            // 
            btnNuevaCita.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevaCita.Location = new Point(410, 76);
            btnNuevaCita.Name = "btnNuevaCita";
            btnNuevaCita.Size = new Size(122, 40);
            btnNuevaCita.TabIndex = 3;
            btnNuevaCita.Text = "Nueva Cita";
            btnNuevaCita.UseVisualStyleBackColor = true;
            btnNuevaCita.Click += btnNuevaCita_Click;
            // 
            // btnEditarCita
            // 
            btnEditarCita.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditarCita.ForeColor = Color.Green;
            btnEditarCita.Location = new Point(538, 76);
            btnEditarCita.Name = "btnEditarCita";
            btnEditarCita.Size = new Size(122, 40);
            btnEditarCita.TabIndex = 4;
            btnEditarCita.Text = "Editar Cita";
            btnEditarCita.UseVisualStyleBackColor = true;
            btnEditarCita.Click += btnEditarCita_Click;
            // 
            // btnCancelarCita
            // 
            btnCancelarCita.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarCita.ForeColor = Color.FromArgb(192, 0, 0);
            btnCancelarCita.Location = new Point(666, 75);
            btnCancelarCita.Name = "btnCancelarCita";
            btnCancelarCita.Size = new Size(122, 40);
            btnCancelarCita.TabIndex = 5;
            btnCancelarCita.Text = "Cancelar Cita";
            btnCancelarCita.UseVisualStyleBackColor = true;
            btnCancelarCita.Click += btnCancelarCita_Click;
            // 
            // FrmCitas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1208, 630);
            Controls.Add(btnCancelarCita);
            Controls.Add(btnEditarCita);
            Controls.Add(btnNuevaCita);
            Controls.Add(btnFiltrar);
            Controls.Add(dtpFiltroFecha);
            Controls.Add(dgvCitas);
            Name = "FrmCitas";
            Text = "FrmCitas";
            Load += FrmCitas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCitas;
        private DateTimePicker dtpFiltroFecha;
        private Button btnFiltrar;
        private Button btnNuevaCita;
        private Button btnEditarCita;
        private Button btnCancelarCita;
    }
}