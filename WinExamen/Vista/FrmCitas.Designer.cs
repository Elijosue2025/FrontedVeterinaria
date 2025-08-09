namespace WinExamen.Vista
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
       
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox3 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            ListarCita = new Button();
            ActualizarCita = new Button();
            guardarCita = new Button();
            groupBox1 = new GroupBox();
            label5 = new Label();
            estado_cita = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            observaciones_cita = new TextBox();
            motivo_cita = new TextBox();
            label1 = new Label();
            id_cita = new TextBox();
            label6 = new Label();
            fk_mascota = new TextBox();
            fecharegistro = new DateTimePicker();
            fechacita = new DateTimePicker();
            label7 = new Label();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Location = new Point(64, 343);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(753, 296);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "citas";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 29);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(689, 245);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ListarCita);
            groupBox2.Controls.Add(ActualizarCita);
            groupBox2.Controls.Add(guardarCita);
            groupBox2.Location = new Point(581, 24);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(179, 231);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            // 
            // ListarCita
            // 
            ListarCita.Location = new Point(48, 175);
            ListarCita.Margin = new Padding(3, 4, 3, 4);
            ListarCita.Name = "ListarCita";
            ListarCita.Size = new Size(86, 31);
            ListarCita.TabIndex = 10;
            ListarCita.Text = "Listar";
            ListarCita.UseVisualStyleBackColor = true;
            // 
            // ActualizarCita
            // 
            ActualizarCita.Location = new Point(48, 99);
            ActualizarCita.Margin = new Padding(3, 4, 3, 4);
            ActualizarCita.Name = "ActualizarCita";
            ActualizarCita.Size = new Size(86, 31);
            ActualizarCita.TabIndex = 9;
            ActualizarCita.Text = "Actualizar";
            ActualizarCita.UseVisualStyleBackColor = true;
            ActualizarCita.Click += button2_Click;
            // 
            // guardarCita
            // 
            guardarCita.Location = new Point(48, 28);
            guardarCita.Margin = new Padding(3, 4, 3, 4);
            guardarCita.Name = "guardarCita";
            guardarCita.Size = new Size(86, 31);
            guardarCita.TabIndex = 8;
            guardarCita.Text = "Guardar";
            guardarCita.UseVisualStyleBackColor = true;
            guardarCita.Click += guardarCita_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fechacita);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(fecharegistro);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(fk_mascota);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(estado_cita);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(observaciones_cita);
            groupBox1.Controls.Add(motivo_cita);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(id_cita);
            groupBox1.Location = new Point(12, 0);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(563, 294);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 257);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 9;
            label5.Text = "Estado Cita";
            // 
            // estado_cita
            // 
            estado_cita.Location = new Point(110, 247);
            estado_cita.Margin = new Padding(3, 4, 3, 4);
            estado_cita.Name = "estado_cita";
            estado_cita.Size = new Size(114, 27);
            estado_cita.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 195);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 7;
            label4.Text = "Observaciones";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 139);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 6;
            label3.Text = "Motivo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(235, 191);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 5;
            label2.Text = "Fecha registro";
            label2.Click += label2_Click;
            // 
            // observaciones_cita
            // 
            observaciones_cita.Location = new Point(110, 191);
            observaciones_cita.Margin = new Padding(3, 4, 3, 4);
            observaciones_cita.Name = "observaciones_cita";
            observaciones_cita.Size = new Size(114, 27);
            observaciones_cita.TabIndex = 4;
            // 
            // motivo_cita
            // 
            motivo_cita.Location = new Point(110, 135);
            motivo_cita.Margin = new Padding(3, 4, 3, 4);
            motivo_cita.Name = "motivo_cita";
            motivo_cita.Size = new Size(114, 27);
            motivo_cita.TabIndex = 3;
            motivo_cita.TextChanged += textBox3_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 82);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 1;
            label1.Text = "ID";
            // 
            // id_cita
            // 
            id_cita.Location = new Point(110, 72);
            id_cita.Margin = new Padding(3, 4, 3, 4);
            id_cita.Name = "id_cita";
            id_cita.Size = new Size(114, 27);
            id_cita.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(253, 142);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 11;
            label6.Text = "ID mascota";
            // 
            // fk_mascota
            // 
            fk_mascota.Location = new Point(343, 135);
            fk_mascota.Margin = new Padding(3, 4, 3, 4);
            fk_mascota.Name = "fk_mascota";
            fk_mascota.Size = new Size(114, 27);
            fk_mascota.TabIndex = 10;
            // 
            // fecharegistro
            // 
            fecharegistro.Location = new Point(313, 191);
            fecharegistro.Name = "fecharegistro";
            fecharegistro.Size = new Size(250, 27);
            fecharegistro.TabIndex = 12;
            fecharegistro.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // fechacita
            // 
            fechacita.Location = new Point(313, 252);
            fechacita.Name = "fechacita";
            fechacita.Size = new Size(250, 27);
            fechacita.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(235, 252);
            label7.Name = "label7";
            label7.Size = new Size(75, 20);
            label7.TabIndex = 13;
            label7.Text = "Fecha cita";
            // 
            // FrmCitas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 655);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCitas";
            Text = "FrmCitas";
            Load += FrmCitas_Load;
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private Button ListarCita;
        private Button ActualizarCita;
        private Button guardarCita;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox observaciones_cita;
        private TextBox motivo_cita;
        private Label label1;
        private TextBox id_cita;
        private Label label5;
        private TextBox estado_cita;
        private DateTimePicker fechacita;
        private Label label7;
        private DateTimePicker fecharegistro;
        private Label label6;
        private TextBox fk_mascota;
    }
}