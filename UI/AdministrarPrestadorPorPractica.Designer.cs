namespace UI
{
    partial class AdministrarPrestadorPorPractica
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
            this.btn_listar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lista_practicas = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lista_practicas_prestador = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lista_prestadores = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_practica = new System.Windows.Forms.TextBox();
            this.btn_asignar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_practica_prestador = new System.Windows.Forms.TextBox();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.txt_prestador = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_listar
            // 
            this.btn_listar.Location = new System.Drawing.Point(336, 220);
            this.btn_listar.Name = "btn_listar";
            this.btn_listar.Size = new System.Drawing.Size(132, 41);
            this.btn_listar.TabIndex = 47;
            this.btn_listar.Text = "Listar practicas disponibles";
            this.btn_listar.UseVisualStyleBackColor = true;
            this.btn_listar.Click += new System.EventHandler(this.btn_listar_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lista_practicas);
            this.groupBox3.Location = new System.Drawing.Point(336, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(132, 200);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Practicas disponibles";
            // 
            // lista_practicas
            // 
            this.lista_practicas.FormattingEnabled = true;
            this.lista_practicas.Location = new System.Drawing.Point(6, 19);
            this.lista_practicas.Name = "lista_practicas";
            this.lista_practicas.Size = new System.Drawing.Size(120, 173);
            this.lista_practicas.TabIndex = 2;
            this.lista_practicas.SelectedValueChanged += new System.EventHandler(this.lista_practicas_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lista_practicas_prestador);
            this.groupBox2.Location = new System.Drawing.Point(169, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 200);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Practicas por prestador";
            // 
            // lista_practicas_prestador
            // 
            this.lista_practicas_prestador.FormattingEnabled = true;
            this.lista_practicas_prestador.Location = new System.Drawing.Point(6, 19);
            this.lista_practicas_prestador.Name = "lista_practicas_prestador";
            this.lista_practicas_prestador.Size = new System.Drawing.Size(124, 173);
            this.lista_practicas_prestador.TabIndex = 1;
            this.lista_practicas_prestador.SelectedValueChanged += new System.EventHandler(this.lista_practicas_prestador_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lista_prestadores);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 200);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prestadores";
            // 
            // lista_prestadores
            // 
            this.lista_prestadores.FormattingEnabled = true;
            this.lista_prestadores.Location = new System.Drawing.Point(6, 19);
            this.lista_prestadores.Name = "lista_prestadores";
            this.lista_prestadores.Size = new System.Drawing.Size(120, 173);
            this.lista_prestadores.TabIndex = 0;
            this.lista_prestadores.SelectedValueChanged += new System.EventHandler(this.lista_prestadores_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "Prestador seleccionado";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txt_practica);
            this.groupBox4.Controls.Add(this.btn_asignar);
            this.groupBox4.Location = new System.Drawing.Point(219, 291);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(181, 110);
            this.groupBox4.TabIndex = 50;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Administrar nueva practica";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Practica seleccionada";
            // 
            // txt_practica
            // 
            this.txt_practica.Location = new System.Drawing.Point(10, 42);
            this.txt_practica.Name = "txt_practica";
            this.txt_practica.ReadOnly = true;
            this.txt_practica.Size = new System.Drawing.Size(147, 20);
            this.txt_practica.TabIndex = 40;
            // 
            // btn_asignar
            // 
            this.btn_asignar.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_asignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_asignar.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_asignar.Location = new System.Drawing.Point(11, 68);
            this.btn_asignar.Name = "btn_asignar";
            this.btn_asignar.Size = new System.Drawing.Size(148, 32);
            this.btn_asignar.TabIndex = 34;
            this.btn_asignar.Text = "Asignar practica";
            this.btn_asignar.UseVisualStyleBackColor = false;
            this.btn_asignar.Click += new System.EventHandler(this.btn_asignar_Click_1);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txt_practica_prestador);
            this.groupBox5.Controls.Add(this.btn_eliminar);
            this.groupBox5.Location = new System.Drawing.Point(12, 291);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(185, 110);
            this.groupBox5.TabIndex = 51;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Administrar practica del prestador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Practica seleccionada";
            // 
            // txt_practica_prestador
            // 
            this.txt_practica_prestador.Location = new System.Drawing.Point(17, 41);
            this.txt_practica_prestador.Name = "txt_practica_prestador";
            this.txt_practica_prestador.ReadOnly = true;
            this.txt_practica_prestador.Size = new System.Drawing.Size(147, 20);
            this.txt_practica_prestador.TabIndex = 42;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.Brown;
            this.btn_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_eliminar.Location = new System.Drawing.Point(16, 67);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(148, 32);
            this.btn_eliminar.TabIndex = 33;
            this.btn_eliminar.Text = "Eliminar practica";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click_1);
            // 
            // txt_prestador
            // 
            this.txt_prestador.Location = new System.Drawing.Point(12, 253);
            this.txt_prestador.Name = "txt_prestador";
            this.txt_prestador.ReadOnly = true;
            this.txt_prestador.Size = new System.Drawing.Size(147, 20);
            this.txt_prestador.TabIndex = 48;
            // 
            // AdministrarPrestadorPorPractica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 415);
            this.Controls.Add(this.btn_listar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txt_prestador);
            this.Name = "AdministrarPrestadorPorPractica";
            this.Text = "AdministrarPrestadorPorPractica";
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_listar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lista_practicas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lista_practicas_prestador;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lista_prestadores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_practica;
        private System.Windows.Forms.Button btn_asignar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_practica_prestador;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.TextBox txt_prestador;
    }
}