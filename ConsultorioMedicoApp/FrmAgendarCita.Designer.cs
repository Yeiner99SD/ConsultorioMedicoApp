namespace ConsultorioMedicoApp
{
    partial class FrmAgendarCita
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
            cbPaciente = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cbMedico = new ComboBox();
            dtpFechaCita = new DateTimePicker();
            label3 = new Label();
            cbHora = new ComboBox();
            label4 = new Label();
            txtMotivo = new TextBox();
            label5 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // cbPaciente
            // 
            cbPaciente.FormattingEnabled = true;
            cbPaciente.Location = new Point(205, 103);
            cbPaciente.Name = "cbPaciente";
            cbPaciente.Size = new Size(200, 23);
            cbPaciente.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(126, 106);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 1;
            label1.Text = "Paciente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 154);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 2;
            label2.Text = "Medico encargado";
            // 
            // cbMedico
            // 
            cbMedico.FormattingEnabled = true;
            cbMedico.Location = new Point(205, 154);
            cbMedico.Name = "cbMedico";
            cbMedico.Size = new Size(200, 23);
            cbMedico.TabIndex = 3;
            // 
            // dtpFechaCita
            // 
            dtpFechaCita.Location = new Point(205, 201);
            dtpFechaCita.Name = "dtpFechaCita";
            dtpFechaCita.Size = new Size(200, 23);
            dtpFechaCita.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 209);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 5;
            label3.Text = "Fecha de la cita";
            // 
            // cbHora
            // 
            cbHora.FormattingEnabled = true;
            cbHora.Location = new Point(205, 250);
            cbHora.Name = "cbHora";
            cbHora.Size = new Size(200, 23);
            cbHora.TabIndex = 6;
            cbHora.SelectedIndexChanged += cbHora_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(145, 253);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 7;
            label4.Text = "Hora";
            label4.Click += label4_Click;
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(205, 299);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(200, 23);
            txtMotivo.TabIndex = 8;
            txtMotivo.TextChanged += txtMotivo_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(145, 302);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 9;
            label5.Text = "Motivo";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(247, 346);
            button1.Name = "button1";
            button1.Size = new Size(127, 41);
            button1.TabIndex = 10;
            button1.Text = "Agendar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmAgendarCita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1274, 631);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(txtMotivo);
            Controls.Add(label4);
            Controls.Add(cbHora);
            Controls.Add(label3);
            Controls.Add(dtpFechaCita);
            Controls.Add(cbMedico);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbPaciente);
            Name = "FrmAgendarCita";
            Text = "FrmAgendarCita";
            Load += FrmAgendarCita_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbPaciente;
        private Label label1;
        private Label label2;
        private ComboBox cbMedico;
        private DateTimePicker dtpFechaCita;
        private Label label3;
        private ComboBox cbHora;
        private Label label4;
        private TextBox txtMotivo;
        private Label label5;
        private Button button1;
    }
}