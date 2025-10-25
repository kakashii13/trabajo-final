namespace UI
{
    partial class RegistrarFactura
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
            this.fecha_factura = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_numero_factura = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_observacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_prestador = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lista_prestadores = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_monto = new System.Windows.Forms.NumericUpDown();
            this.txt_numero_autorizacion = new System.Windows.Forms.NumericUpDown();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btnAdjuntarFactura = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txt_numero_factura)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_monto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_numero_autorizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // fecha_factura
            // 
            this.fecha_factura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_factura.Location = new System.Drawing.Point(15, 42);
            this.fecha_factura.Name = "fecha_factura";
            this.fecha_factura.Size = new System.Drawing.Size(91, 20);
            this.fecha_factura.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha recibida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Monto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Numero factura";
            // 
            // txt_numero_factura
            // 
            this.txt_numero_factura.Location = new System.Drawing.Point(255, 42);
            this.txt_numero_factura.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txt_numero_factura.Name = "txt_numero_factura";
            this.txt_numero_factura.Size = new System.Drawing.Size(120, 20);
            this.txt_numero_factura.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Observacion";
            // 
            // txt_observacion
            // 
            this.txt_observacion.Location = new System.Drawing.Point(166, 93);
            this.txt_observacion.Multiline = true;
            this.txt_observacion.Name = "txt_observacion";
            this.txt_observacion.Size = new System.Drawing.Size(209, 69);
            this.txt_observacion.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Numero autorizacion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Prestador";
            // 
            // txt_prestador
            // 
            this.txt_prestador.Location = new System.Drawing.Point(15, 142);
            this.txt_prestador.Name = "txt_prestador";
            this.txt_prestador.ReadOnly = true;
            this.txt_prestador.Size = new System.Drawing.Size(120, 20);
            this.txt_prestador.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lista_prestadores);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 260);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prestadores";
            // 
            // lista_prestadores
            // 
            this.lista_prestadores.FormattingEnabled = true;
            this.lista_prestadores.Location = new System.Drawing.Point(12, 28);
            this.lista_prestadores.Name = "lista_prestadores";
            this.lista_prestadores.Size = new System.Drawing.Size(137, 212);
            this.lista_prestadores.TabIndex = 0;
            this.lista_prestadores.SelectedValueChanged += new System.EventHandler(this.lista_prestadores_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtArchivo);
            this.groupBox2.Controls.Add(this.btnAdjuntarFactura);
            this.groupBox2.Controls.Add(this.txt_monto);
            this.groupBox2.Controls.Add(this.txt_numero_autorizacion);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_prestador);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_numero_factura);
            this.groupBox2.Controls.Add(this.txt_observacion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.fecha_factura);
            this.groupBox2.Location = new System.Drawing.Point(191, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 214);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos factura";
            // 
            // txt_monto
            // 
            this.txt_monto.DecimalPlaces = 2;
            this.txt_monto.Location = new System.Drawing.Point(135, 42);
            this.txt_monto.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txt_monto.Name = "txt_monto";
            this.txt_monto.Size = new System.Drawing.Size(95, 20);
            this.txt_monto.TabIndex = 14;
            // 
            // txt_numero_autorizacion
            // 
            this.txt_numero_autorizacion.Location = new System.Drawing.Point(15, 94);
            this.txt_numero_autorizacion.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.txt_numero_autorizacion.Name = "txt_numero_autorizacion";
            this.txt_numero_autorizacion.Size = new System.Drawing.Size(120, 20);
            this.txt_numero_autorizacion.TabIndex = 13;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Brown;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cancel.Location = new System.Drawing.Point(336, 246);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(120, 32);
            this.btn_cancel.TabIndex = 46;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_save.Location = new System.Drawing.Point(462, 246);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(120, 32);
            this.btn_save.TabIndex = 45;
            this.btn_save.Text = "Guardar cambios";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btnAdjuntarFactura
            // 
            this.btnAdjuntarFactura.Location = new System.Drawing.Point(15, 177);
            this.btnAdjuntarFactura.Name = "btnAdjuntarFactura";
            this.btnAdjuntarFactura.Size = new System.Drawing.Size(154, 27);
            this.btnAdjuntarFactura.TabIndex = 47;
            this.btnAdjuntarFactura.Text = "+ Adjuntar factura";
            this.btnAdjuntarFactura.UseVisualStyleBackColor = true;
            this.btnAdjuntarFactura.Click += new System.EventHandler(this.btnAdjuntarFactura_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.AutoSize = true;
            this.txtArchivo.Location = new System.Drawing.Point(175, 184);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(0, 13);
            this.txtArchivo.TabIndex = 48;
            // 
            // RegistrarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 292);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistrarFactura";
            this.Text = "RegistrarFactura";
            ((System.ComponentModel.ISupportInitialize)(this.txt_numero_factura)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_monto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_numero_autorizacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fecha_factura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txt_numero_factura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_observacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_prestador;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lista_prestadores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.NumericUpDown txt_numero_autorizacion;
        private System.Windows.Forms.NumericUpDown txt_monto;
        private System.Windows.Forms.Button btnAdjuntarFactura;
        private System.Windows.Forms.Label txtArchivo;
    }
}