namespace WinExamen.Vista
{
    partial class FrmMascota
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
            pk_mascota = new TextBox();
            label1 = new Label();
            nombreMascota = new TextBox();
            especieMascota = new TextBox();
            razaMascota = new TextBox();
            label2 = new Label();
            Especie = new Label();
            label4 = new Label();
            agregarMascota = new Button();
            actualizasMascota = new Button();
            listarMascotas = new Button();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            label9 = new Label();
            label11 = new Label();
            textBox9 = new TextBox();
            textBox11 = new TextBox();
            label12 = new Label();
            textBox12 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            generoMascota = new TextBox();
            colorMascota = new TextBox();
            pesoMascota = new TextBox();
            label8 = new Label();
            fechaNacimiento = new TextBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // pk_mascota
            // 
            pk_mascota.Location = new Point(110, 19);
            pk_mascota.Margin = new Padding(3, 4, 3, 4);
            pk_mascota.Name = "pk_mascota";
            pk_mascota.Size = new Size(114, 27);
            pk_mascota.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 29);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 1;
            label1.Text = "ID";
            // 
            // nombreMascota
            // 
            nombreMascota.Location = new Point(110, 79);
            nombreMascota.Margin = new Padding(3, 4, 3, 4);
            nombreMascota.Name = "nombreMascota";
            nombreMascota.Size = new Size(114, 27);
            nombreMascota.TabIndex = 2;
            // 
            // especieMascota
            // 
            especieMascota.Location = new Point(110, 135);
            especieMascota.Margin = new Padding(3, 4, 3, 4);
            especieMascota.Name = "especieMascota";
            especieMascota.Size = new Size(114, 27);
            especieMascota.TabIndex = 3;
            // 
            // razaMascota
            // 
            razaMascota.Location = new Point(110, 191);
            razaMascota.Margin = new Padding(3, 4, 3, 4);
            razaMascota.Name = "razaMascota";
            razaMascota.Size = new Size(114, 27);
            razaMascota.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 83);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 5;
            label2.Text = "nombre";
            // 
            // Especie
            // 
            Especie.AutoSize = true;
            Especie.Location = new Point(35, 139);
            Especie.Name = "Especie";
            Especie.Size = new Size(59, 20);
            Especie.TabIndex = 6;
            Especie.Text = "Especie";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 201);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 7;
            label4.Text = "Raza";
            // 
            // agregarMascota
            // 
            agregarMascota.Location = new Point(48, 28);
            agregarMascota.Margin = new Padding(3, 4, 3, 4);
            agregarMascota.Name = "agregarMascota";
            agregarMascota.Size = new Size(86, 31);
            agregarMascota.TabIndex = 8;
            agregarMascota.Text = "Agregar";
            agregarMascota.UseVisualStyleBackColor = true;
            agregarMascota.Click += agregarMascota_Click;
            // 
            // actualizasMascota
            // 
            actualizasMascota.Location = new Point(48, 99);
            actualizasMascota.Margin = new Padding(3, 4, 3, 4);
            actualizasMascota.Name = "actualizasMascota";
            actualizasMascota.Size = new Size(86, 31);
            actualizasMascota.TabIndex = 9;
            actualizasMascota.Text = "Actualizar";
            actualizasMascota.UseVisualStyleBackColor = true;
            actualizasMascota.Click += actualizasMascota_Click;
            // 
            // listarMascotas
            // 
            listarMascotas.Location = new Point(48, 175);
            listarMascotas.Margin = new Padding(3, 4, 3, 4);
            listarMascotas.Name = "listarMascotas";
            listarMascotas.Size = new Size(86, 31);
            listarMascotas.TabIndex = 10;
            listarMascotas.Text = "Listar";
            listarMascotas.UseVisualStyleBackColor = true;
            listarMascotas.Click += listarMascotas_Click;
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
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(textBox9);
            groupBox1.Controls.Add(textBox11);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(textBox12);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(generoMascota);
            groupBox1.Controls.Add(colorMascota);
            groupBox1.Controls.Add(pesoMascota);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(fechaNacimiento);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(Especie);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(razaMascota);
            groupBox1.Controls.Add(especieMascota);
            groupBox1.Controls.Add(nombreMascota);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(pk_mascota);
            groupBox1.Location = new Point(12, 13);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(737, 256);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(506, 147);
            label9.Name = "label9";
            label9.Size = new Size(54, 20);
            label9.TabIndex = 23;
            label9.Text = "Estado";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(489, 93);
            label11.Name = "label11";
            label11.Size = new Size(102, 20);
            label11.TabIndex = 21;
            label11.Text = "FechaRegistro";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(597, 147);
            textBox9.Margin = new Padding(3, 4, 3, 4);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(114, 27);
            textBox9.TabIndex = 20;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(597, 93);
            textBox11.Margin = new Padding(3, 4, 3, 4);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(114, 27);
            textBox11.TabIndex = 18;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(519, 24);
            label12.Name = "label12";
            label12.Size = new Size(72, 20);
            label12.TabIndex = 17;
            label12.Text = "ID Dueño";
            label12.Click += label12_Click;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(597, 21);
            textBox12.Margin = new Padding(3, 4, 3, 4);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(114, 27);
            textBox12.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(257, 209);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 15;
            label5.Text = "Genero";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(257, 147);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 14;
            label6.Text = "Color";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(257, 91);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 13;
            label7.Text = "Peso";
            // 
            // generoMascota
            // 
            generoMascota.Location = new Point(332, 199);
            generoMascota.Margin = new Padding(3, 4, 3, 4);
            generoMascota.Name = "generoMascota";
            generoMascota.Size = new Size(114, 27);
            generoMascota.TabIndex = 12;
            // 
            // colorMascota
            // 
            colorMascota.Location = new Point(332, 143);
            colorMascota.Margin = new Padding(3, 4, 3, 4);
            colorMascota.Name = "colorMascota";
            colorMascota.Size = new Size(114, 27);
            colorMascota.TabIndex = 11;
            // 
            // pesoMascota
            // 
            pesoMascota.Location = new Point(332, 87);
            pesoMascota.Margin = new Padding(3, 4, 3, 4);
            pesoMascota.Name = "pesoMascota";
            pesoMascota.Size = new Size(114, 27);
            pesoMascota.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(257, 37);
            label8.Name = "label8";
            label8.Size = new Size(128, 20);
            label8.TabIndex = 9;
            label8.Text = "Fecha Nacimiento";
            // 
            // fechaNacimiento
            // 
            fechaNacimiento.Location = new Point(391, 34);
            fechaNacimiento.Margin = new Padding(3, 4, 3, 4);
            fechaNacimiento.Name = "fechaNacimiento";
            fechaNacimiento.Size = new Size(114, 27);
            fechaNacimiento.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listarMascotas);
            groupBox2.Controls.Add(actualizasMascota);
            groupBox2.Controls.Add(agregarMascota);
            groupBox2.Location = new Point(755, 35);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(179, 231);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Location = new Point(91, 305);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(753, 296);
            groupBox3.TabIndex = 14;
            groupBox3.TabStop = false;
            groupBox3.Text = "Pacientes";
            // 
            // FrmMascota
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 639);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmMascota";
            Text = "FrmPacientes";
            Load += FrmPacientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox pk_mascota;
        private Label label1;
        private TextBox nombreMascota;
        private TextBox especieMascota;
        private TextBox razaMascota;
        private Label label2;
        private Label Especie;
        private Label label4;
        private Button agregarMascota;
        private Button actualizasMascota;
        private Button listarMascotas;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label9;
        private Label label11;
        private TextBox textBox9;
        private TextBox textBox11;
        private Label label12;
        private TextBox textBox12;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox generoMascota;
        private TextBox colorMascota;
        private TextBox pesoMascota;
        private Label label8;
        private TextBox fechaNacimiento;
    }
}