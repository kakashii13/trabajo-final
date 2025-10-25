namespace UI
{
    partial class RegistrarPago
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
            this.lista_facturas = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_numero_recibo = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_importe = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.fecha_pago = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_factura = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_numero_recibo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_importe)).BeginInit();
            this.SuspendLayout();
            // 
            // lista_facturas
            // 
            this.lista_facturas.FormattingEnabled = true;
            this.lista_facturas.Location = new System.Drawing.Point(16, 19);
            this.lista_facturas.Name = "lista_facturas";
            this.lista_facturas.Size = new System.Drawing.Size(160, 199);
            this.lista_facturas.TabIndex = 0;
            this.lista_facturas.SelectedValueChanged += new System.EventHandler(this.lista_facturas_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lista_facturas);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 232);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturas aceptadas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_numero_recibo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_importe);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.fecha_pago);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_factura);
            this.groupBox2.Location = new System.Drawing.Point(227, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 131);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registrar pago";
            // 
            // txt_numero_recibo
            // 
            this.txt_numero_recibo.Location = new System.Drawing.Point(130, 83);
            this.txt_numero_recibo.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.txt_numero_recibo.Name = "txt_numero_recibo";
            this.txt_numero_recibo.Size = new System.Drawing.Size(95, 20);
            this.txt_numero_recibo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Numero recibo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Importe pagado";
            // 
            // txt_importe
            // 
            this.txt_importe.DecimalPlaces = 2;
            this.txt_importe.Location = new System.Drawing.Point(9, 83);
            this.txt_importe.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.txt_importe.Name = "txt_importe";
            this.txt_importe.Size = new System.Drawing.Size(95, 20);
            this.txt_importe.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha de pago";
            // 
            // fecha_pago
            // 
            this.fecha_pago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_pago.Location = new System.Drawing.Point(126, 35);
            this.fecha_pago.Name = "fecha_pago";
            this.fecha_pago.Size = new System.Drawing.Size(99, 20);
            this.fecha_pago.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Factura";
            // 
            // txt_factura
            // 
            this.txt_factura.Location = new System.Drawing.Point(6, 35);
            this.txt_factura.Name = "txt_factura";
            this.txt_factura.ReadOnly = true;
            this.txt_factura.Size = new System.Drawing.Size(98, 20);
            this.txt_factura.TabIndex = 0;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Brown;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cancel.Location = new System.Drawing.Point(355, 167);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(120, 32);
            this.btn_cancel.TabIndex = 49;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_save.Location = new System.Drawing.Point(355, 212);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(120, 32);
            this.btn_save.TabIndex = 48;
            this.btn_save.Text = "Guardar";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // RegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 261);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistrarPago";
            this.Text = "RegistrarPago";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_numero_recibo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_importe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lista_facturas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txt_importe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fecha_pago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_factura;
        private System.Windows.Forms.NumericUpDown txt_numero_recibo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
    }
}