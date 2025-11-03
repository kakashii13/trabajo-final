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
            this.fechaFactura = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrestador = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaPrestadores = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtArchivo = new System.Windows.Forms.Label();
            this.btnAdjuntarFactura = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.NumericUpDown();
            this.txtNumeroAutorizacion = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnRemoverPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroFactura)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroAutorizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaFactura
            // 
            this.fechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaFactura.Location = new System.Drawing.Point(15, 42);
            this.fechaFactura.Name = "fechaFactura";
            this.fechaFactura.Size = new System.Drawing.Size(91, 20);
            this.fechaFactura.TabIndex = 0;
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
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(255, 42);
            this.txtNumeroFactura.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroFactura.TabIndex = 6;
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
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(166, 93);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(209, 69);
            this.txtObservacion.TabIndex = 7;
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
            // txtPrestador
            // 
            this.txtPrestador.Location = new System.Drawing.Point(15, 142);
            this.txtPrestador.Name = "txtPrestador";
            this.txtPrestador.ReadOnly = true;
            this.txtPrestador.Size = new System.Drawing.Size(120, 20);
            this.txtPrestador.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaPrestadores);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 260);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prestadores";
            // 
            // listaPrestadores
            // 
            this.listaPrestadores.FormattingEnabled = true;
            this.listaPrestadores.Location = new System.Drawing.Point(12, 28);
            this.listaPrestadores.Name = "listaPrestadores";
            this.listaPrestadores.Size = new System.Drawing.Size(137, 212);
            this.listaPrestadores.TabIndex = 0;
            this.listaPrestadores.SelectedValueChanged += new System.EventHandler(this.lista_prestadores_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoverPdf);
            this.groupBox2.Controls.Add(this.txtArchivo);
            this.groupBox2.Controls.Add(this.btnAdjuntarFactura);
            this.groupBox2.Controls.Add(this.txtMonto);
            this.groupBox2.Controls.Add(this.txtNumeroAutorizacion);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtPrestador);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNumeroFactura);
            this.groupBox2.Controls.Add(this.txtObservacion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.fechaFactura);
            this.groupBox2.Location = new System.Drawing.Point(191, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 260);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos factura";
            // 
            // txtArchivo
            // 
            this.txtArchivo.AutoSize = true;
            this.txtArchivo.Location = new System.Drawing.Point(175, 184);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(0, 13);
            this.txtArchivo.TabIndex = 48;
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
            // txtMonto
            // 
            this.txtMonto.DecimalPlaces = 2;
            this.txtMonto.Location = new System.Drawing.Point(135, 42);
            this.txtMonto.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(95, 20);
            this.txtMonto.TabIndex = 14;
            // 
            // txtNumeroAutorizacion
            // 
            this.txtNumeroAutorizacion.Location = new System.Drawing.Point(15, 94);
            this.txtNumeroAutorizacion.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.txtNumeroAutorizacion.Name = "txtNumeroAutorizacion";
            this.txtNumeroAutorizacion.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroAutorizacion.TabIndex = 13;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Brown;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Location = new System.Drawing.Point(326, 284);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 32);
            this.btnCancelar.TabIndex = 46;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.Location = new System.Drawing.Point(462, 284);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 32);
            this.btnGuardar.TabIndex = 45;
            this.btnGuardar.Text = "Guardar cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btnRemoverPdf
            // 
            this.btnRemoverPdf.ForeColor = System.Drawing.Color.Firebrick;
            this.btnRemoverPdf.Location = new System.Drawing.Point(15, 213);
            this.btnRemoverPdf.Name = "btnRemoverPdf";
            this.btnRemoverPdf.Size = new System.Drawing.Size(154, 27);
            this.btnRemoverPdf.TabIndex = 49;
            this.btnRemoverPdf.Text = "Remover pdf";
            this.btnRemoverPdf.UseVisualStyleBackColor = true;
            this.btnRemoverPdf.Click += new System.EventHandler(this.btnRemoverPdf_Click);
            // 
            // RegistrarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 338);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistrarFactura";
            this.Text = "RegistrarFactura";
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroFactura)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroAutorizacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fechaFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtNumeroFactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrestador;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listaPrestadores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.NumericUpDown txtNumeroAutorizacion;
        private System.Windows.Forms.NumericUpDown txtMonto;
        private System.Windows.Forms.Button btnAdjuntarFactura;
        private System.Windows.Forms.Label txtArchivo;
        private System.Windows.Forms.Button btnRemoverPdf;
    }
}