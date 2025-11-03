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
            this.btnListarPracticas = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listaPracticas = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listaPracticasPrestador = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaPrestadores = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNuevaPractica = new System.Windows.Forms.TextBox();
            this.btnAsignarPracticaPrestador = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPracticaPrestador = new System.Windows.Forms.TextBox();
            this.btnEliminarPracticaPrestador = new System.Windows.Forms.Button();
            this.txtPrestadorSeleccionado = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListarPracticas
            // 
            this.btnListarPracticas.Location = new System.Drawing.Point(403, 220);
            this.btnListarPracticas.Name = "btnListarPracticas";
            this.btnListarPracticas.Size = new System.Drawing.Size(132, 41);
            this.btnListarPracticas.TabIndex = 47;
            this.btnListarPracticas.Text = "Listar practicas disponibles";
            this.btnListarPracticas.UseVisualStyleBackColor = true;
            this.btnListarPracticas.Click += new System.EventHandler(this.btn_listar_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listaPracticas);
            this.groupBox3.Location = new System.Drawing.Point(383, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(152, 200);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Practicas disponibles";
            // 
            // listaPracticas
            // 
            this.listaPracticas.FormattingEnabled = true;
            this.listaPracticas.Location = new System.Drawing.Point(6, 19);
            this.listaPracticas.Name = "listaPracticas";
            this.listaPracticas.Size = new System.Drawing.Size(140, 173);
            this.listaPracticas.TabIndex = 2;
            this.listaPracticas.SelectedValueChanged += new System.EventHandler(this.lista_practicas_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listaPracticasPrestador);
            this.groupBox2.Location = new System.Drawing.Point(197, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 200);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Practicas por prestador";
            // 
            // listaPracticasPrestador
            // 
            this.listaPracticasPrestador.FormattingEnabled = true;
            this.listaPracticasPrestador.Location = new System.Drawing.Point(6, 19);
            this.listaPracticasPrestador.Name = "listaPracticasPrestador";
            this.listaPracticasPrestador.Size = new System.Drawing.Size(154, 173);
            this.listaPracticasPrestador.TabIndex = 1;
            this.listaPracticasPrestador.SelectedValueChanged += new System.EventHandler(this.lista_practicas_prestador_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaPrestadores);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 200);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prestadores";
            // 
            // listaPrestadores
            // 
            this.listaPrestadores.FormattingEnabled = true;
            this.listaPrestadores.Location = new System.Drawing.Point(6, 19);
            this.listaPrestadores.Name = "listaPrestadores";
            this.listaPrestadores.Size = new System.Drawing.Size(152, 173);
            this.listaPrestadores.TabIndex = 0;
            this.listaPrestadores.SelectedValueChanged += new System.EventHandler(this.lista_prestadores_SelectedValueChanged);
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
            this.groupBox4.Controls.Add(this.txtNuevaPractica);
            this.groupBox4.Controls.Add(this.btnAsignarPracticaPrestador);
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
            // txtNuevaPractica
            // 
            this.txtNuevaPractica.Location = new System.Drawing.Point(10, 42);
            this.txtNuevaPractica.Name = "txtNuevaPractica";
            this.txtNuevaPractica.ReadOnly = true;
            this.txtNuevaPractica.Size = new System.Drawing.Size(147, 20);
            this.txtNuevaPractica.TabIndex = 40;
            // 
            // btnAsignarPracticaPrestador
            // 
            this.btnAsignarPracticaPrestador.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAsignarPracticaPrestador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarPracticaPrestador.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAsignarPracticaPrestador.Location = new System.Drawing.Point(11, 68);
            this.btnAsignarPracticaPrestador.Name = "btnAsignarPracticaPrestador";
            this.btnAsignarPracticaPrestador.Size = new System.Drawing.Size(148, 32);
            this.btnAsignarPracticaPrestador.TabIndex = 34;
            this.btnAsignarPracticaPrestador.Text = "Asignar practica";
            this.btnAsignarPracticaPrestador.UseVisualStyleBackColor = false;
            this.btnAsignarPracticaPrestador.Click += new System.EventHandler(this.btn_asignar_Click_1);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtPracticaPrestador);
            this.groupBox5.Controls.Add(this.btnEliminarPracticaPrestador);
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
            // txtPracticaPrestador
            // 
            this.txtPracticaPrestador.Location = new System.Drawing.Point(17, 41);
            this.txtPracticaPrestador.Name = "txtPracticaPrestador";
            this.txtPracticaPrestador.ReadOnly = true;
            this.txtPracticaPrestador.Size = new System.Drawing.Size(147, 20);
            this.txtPracticaPrestador.TabIndex = 42;
            // 
            // btnEliminarPracticaPrestador
            // 
            this.btnEliminarPracticaPrestador.BackColor = System.Drawing.Color.Brown;
            this.btnEliminarPracticaPrestador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPracticaPrestador.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminarPracticaPrestador.Location = new System.Drawing.Point(16, 67);
            this.btnEliminarPracticaPrestador.Name = "btnEliminarPracticaPrestador";
            this.btnEliminarPracticaPrestador.Size = new System.Drawing.Size(148, 32);
            this.btnEliminarPracticaPrestador.TabIndex = 33;
            this.btnEliminarPracticaPrestador.Text = "Eliminar practica";
            this.btnEliminarPracticaPrestador.UseVisualStyleBackColor = false;
            this.btnEliminarPracticaPrestador.Click += new System.EventHandler(this.btn_eliminar_Click_1);
            // 
            // txtPrestadorSeleccionado
            // 
            this.txtPrestadorSeleccionado.Location = new System.Drawing.Point(12, 253);
            this.txtPrestadorSeleccionado.Name = "txtPrestadorSeleccionado";
            this.txtPrestadorSeleccionado.ReadOnly = true;
            this.txtPrestadorSeleccionado.Size = new System.Drawing.Size(147, 20);
            this.txtPrestadorSeleccionado.TabIndex = 48;
            // 
            // AdministrarPrestadorPorPractica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 415);
            this.Controls.Add(this.btnListarPracticas);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txtPrestadorSeleccionado);
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

        private System.Windows.Forms.Button btnListarPracticas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listaPracticas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listaPracticasPrestador;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listaPrestadores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNuevaPractica;
        private System.Windows.Forms.Button btnAsignarPracticaPrestador;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPracticaPrestador;
        private System.Windows.Forms.Button btnEliminarPracticaPrestador;
        private System.Windows.Forms.TextBox txtPrestadorSeleccionado;
    }
}