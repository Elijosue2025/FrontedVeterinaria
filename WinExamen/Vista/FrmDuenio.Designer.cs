namespace WinExamen.Vista
{
    partial class FrmDuenio
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
            listarDuenio = new Button();
            Actualizar = new Button();
            agregardueño = new Button();
            groupBox1 = new GroupBox();
            fecha = new TextBox();
            label7 = new Label();
            checkBox1 = new CheckBox();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            direccion = new TextBox();
            email = new TextBox();
            label4 = new Label();
            label3 = new Label();
            Nombre = new Label();
            textBox4 = new TextBox();
            apellido = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            pk_duenio = new TextBox();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Location = new Point(81, 297);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(753, 296);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Facturas";
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
            groupBox2.Controls.Add(listarDuenio);
            groupBox2.Controls.Add(Actualizar);
            groupBox2.Controls.Add(agregardueño);
            groupBox2.Location = new Point(581, 24);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(179, 231);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            // 
            // listarDuenio
            // 
            listarDuenio.Location = new Point(48, 175);
            listarDuenio.Margin = new Padding(3, 4, 3, 4);
            listarDuenio.Name = "listarDuenio";
            listarDuenio.Size = new Size(86, 31);
            listarDuenio.TabIndex = 10;
            listarDuenio.Text = "Listar";
            listarDuenio.UseVisualStyleBackColor = true;
            listarDuenio.Click += listarDuenio_Click;
            // 
            // Actualizar
            // 
            Actualizar.Location = new Point(48, 99);
            Actualizar.Margin = new Padding(3, 4, 3, 4);
            Actualizar.Name = "Actualizar";
            Actualizar.Size = new Size(86, 31);
            Actualizar.TabIndex = 9;
            Actualizar.Text = "Actualizar";
            Actualizar.UseVisualStyleBackColor = true;
            Actualizar.Click += Actualizar_Click;
            // 
            // agregardueño
            // 
            agregardueño.Location = new Point(48, 28);
            agregardueño.Margin = new Padding(3, 4, 3, 4);
            agregardueño.Name = "agregardueño";
            agregardueño.Size = new Size(86, 31);
            agregardueño.TabIndex = 8;
            agregardueño.Text = "Agregar";
            agregardueño.UseVisualStyleBackColor = true;
            agregardueño.Click += agregardueño_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fecha);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(direccion);
            groupBox1.Controls.Add(email);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Nombre);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(apellido);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(pk_duenio);
            groupBox1.Location = new Point(12, 13);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(563, 256);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            // 
            // fecha
            // 
            fecha.Location = new Point(370, 29);
            fecha.Margin = new Padding(3, 4, 3, 4);
            fecha.Name = "fecha";
            fecha.Size = new Size(114, 27);
            fecha.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(262, 29);
            label7.Name = "label7";
            label7.Size = new Size(102, 20);
            label7.TabIndex = 15;
            label7.Text = "Fecha registro";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(329, 201);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(131, 24);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Activo/Inactivo";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(254, 204);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 13;
            label2.Text = "Estado";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(254, 142);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 12;
            label5.Text = "Direccion";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(254, 86);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 11;
            label6.Text = "Email";
            // 
            // direccion
            // 
            direccion.Location = new Point(329, 138);
            direccion.Margin = new Padding(3, 4, 3, 4);
            direccion.Name = "direccion";
            direccion.Size = new Size(114, 27);
            direccion.TabIndex = 9;
            // 
            // email
            // 
            email.Location = new Point(329, 82);
            email.Margin = new Padding(3, 4, 3, 4);
            email.Name = "email";
            email.Size = new Size(114, 27);
            email.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 201);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 7;
            label4.Text = "Telefono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 139);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 6;
            label3.Text = "Apellido";
            // 
            // Nombre
            // 
            Nombre.AutoSize = true;
            Nombre.Location = new Point(35, 83);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(64, 20);
            Nombre.TabIndex = 5;
            Nombre.Text = "Nombre";
            Nombre.Click += label2_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(110, 191);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(114, 27);
            textBox4.TabIndex = 4;
            // 
            // apellido
            // 
            apellido.Location = new Point(110, 135);
            apellido.Margin = new Padding(3, 4, 3, 4);
            apellido.Name = "apellido";
            apellido.Size = new Size(114, 27);
            apellido.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(110, 79);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(114, 27);
            textBox2.TabIndex = 2;
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
            // pk_duenio
            // 
            pk_duenio.Location = new Point(110, 19);
            pk_duenio.Margin = new Padding(3, 4, 3, 4);
            pk_duenio.Name = "pk_duenio";
            pk_duenio.Size = new Size(114, 27);
            pk_duenio.TabIndex = 0;
            // 
            // FrmDuenio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmDuenio";
            Text = "FrmFacturas";
            Load += FrmDuenio_Load;
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
        private Button listarDuenio;
        private Button Actualizar;
        private Button agregardueño;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label Nombre;
        private TextBox textBox4;
        private TextBox apellido;
        private TextBox textBox2;
        private Label label1;
        private TextBox pk_duenio;
        private TextBox fecha;
        private Label label7;
        private CheckBox checkBox1;
        private Label label2;
        private Label label5;
        private Label label6;
        private TextBox direccion;
        private TextBox email;
    }
}