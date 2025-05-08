namespace ConsultorioMedicoApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Encabezado = new Label();
            encabezado_agendar = new Label();
            label2 = new Label();
            registrar = new Label();
            button_registrart = new Button();
            panelContenido = new Panel();
            label1 = new Label();
            buttonstatic_medicos = new Button();
            buttonstatic_citas = new Button();
            SuspendLayout();
            // 
            // Encabezado
            // 
            Encabezado.AutoSize = true;
            Encabezado.Font = new Font("Segoe UI", 18F);
            Encabezado.ForeColor = Color.AliceBlue;
            Encabezado.Location = new Point(477, 9);
            Encabezado.Name = "Encabezado";
            Encabezado.Size = new Size(610, 32);
            Encabezado.TabIndex = 0;
            Encabezado.Text = "Bienvenido a la clinica JIMFORD de la ciudad de bogotá";
            Encabezado.TextAlign = ContentAlignment.TopCenter;
            Encabezado.Click += label1_Click_1;
            // 
            // encabezado_agendar
            // 
            encabezado_agendar.AutoSize = true;
            encabezado_agendar.Font = new Font("Segoe UI", 12F);
            encabezado_agendar.Location = new Point(1090, 65);
            encabezado_agendar.Name = "encabezado_agendar";
            encabezado_agendar.Size = new Size(154, 21);
            encabezado_agendar.TabIndex = 1;
            encabezado_agendar.Text = "¿Desea ver sus citas?";
            encabezado_agendar.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(629, 184);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 2;
            // 
            // registrar
            // 
            registrar.AutoSize = true;
            registrar.Font = new Font("Segoe UI", 12F);
            registrar.Location = new Point(215, 65);
            registrar.Name = "registrar";
            registrar.Size = new Size(319, 21);
            registrar.TabIndex = 3;
            registrar.Text = "¿ Quieres ver a los pacientes y modificarlos ?";
            // 
            // button_registrart
            // 
            button_registrart.Font = new Font("Segoe UI", 11F);
            button_registrart.ForeColor = SystemColors.ActiveCaptionText;
            button_registrart.Location = new Point(305, 89);
            button_registrart.Name = "button_registrart";
            button_registrart.Size = new Size(125, 31);
            button_registrart.TabIndex = 4;
            button_registrart.Text = "Pacientes";
            button_registrart.UseVisualStyleBackColor = true;
            button_registrart.Click += button_registrart_Click;
            // 
            // panelContenido
            // 
            panelContenido.BorderStyle = BorderStyle.FixedSingle;
            panelContenido.Location = new Point(32, 143);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(1428, 485);
            panelContenido.TabIndex = 5;
            panelContenido.Paint += panelContenido_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(591, 65);
            label1.Name = "label1";
            label1.Size = new Size(312, 21);
            label1.TabIndex = 6;
            label1.Text = "¿ Quieres ver a los medicos y modificarlos ?";
            label1.Click += label1_Click_2;
            // 
            // buttonstatic_medicos
            // 
            buttonstatic_medicos.ForeColor = SystemColors.ActiveCaptionText;
            buttonstatic_medicos.Location = new Point(726, 89);
            buttonstatic_medicos.Name = "buttonstatic_medicos";
            buttonstatic_medicos.Size = new Size(95, 31);
            buttonstatic_medicos.TabIndex = 7;
            buttonstatic_medicos.Text = "Medicos";
            buttonstatic_medicos.UseVisualStyleBackColor = true;
            buttonstatic_medicos.Click += buttonstatic_medicos_Click;
            // 
            // buttonstatic_citas
            // 
            buttonstatic_citas.ForeColor = SystemColors.ActiveCaptionText;
            buttonstatic_citas.Location = new Point(1127, 89);
            buttonstatic_citas.Name = "buttonstatic_citas";
            buttonstatic_citas.Size = new Size(80, 32);
            buttonstatic_citas.TabIndex = 8;
            buttonstatic_citas.Text = "Citas";
            buttonstatic_citas.UseVisualStyleBackColor = true;
            buttonstatic_citas.Click += buttonstatic_citas_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(1504, 649);
            Controls.Add(buttonstatic_citas);
            Controls.Add(buttonstatic_medicos);
            Controls.Add(label1);
            Controls.Add(panelContenido);
            Controls.Add(button_registrart);
            Controls.Add(registrar);
            Controls.Add(label2);
            Controls.Add(encabezado_agendar);
            Controls.Add(Encabezado);
            ForeColor = SystemColors.ButtonHighlight;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Encabezado;
        private Label encabezado_agendar;
        private Label label2;
        private Label registrar;
        private Button button_registrart;
        private Panel panelContenido;
        private Label label1;
        private Button buttonstatic_medicos;
        private Button buttonstatic_citas;
    }
}
