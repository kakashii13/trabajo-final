namespace UI
{
    partial class ConsultarFacturas
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
            this.dgv_facturas = new System.Windows.Forms.DataGridView();
            this.btn_aceptadas = new System.Windows.Forms.Button();
            this.btn_rechazadas = new System.Windows.Forms.Button();
            this.btn_pendientes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_validar_importe = new System.Windows.Forms.Button();
            this.btn_validar_autorizacion = new System.Windows.Forms.Button();
            this.btn_rechazar = new System.Windows.Forms.Button();
            this.btn_aceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facturas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_facturas
            // 
            this.dgv_facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_facturas.Location = new System.Drawing.Point(12, 55);
            this.dgv_facturas.Name = "dgv_facturas";
            this.dgv_facturas.ReadOnly = true;
            this.dgv_facturas.Size = new System.Drawing.Size(649, 166);
            this.dgv_facturas.TabIndex = 0;
            this.dgv_facturas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_facturas_CellClick);
            // 
            // btn_aceptadas
            // 
            this.btn_aceptadas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_aceptadas.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_aceptadas.Location = new System.Drawing.Point(204, 9);
            this.btn_aceptadas.Name = "btn_aceptadas";
            this.btn_aceptadas.Size = new System.Drawing.Size(75, 37);
            this.btn_aceptadas.TabIndex = 12;
            this.btn_aceptadas.Text = "Aceptadas";
            this.btn_aceptadas.UseVisualStyleBackColor = false;
            this.btn_aceptadas.Click += new System.EventHandler(this.btn_aceptadas_Click);
            // 
            // btn_rechazadas
            // 
            this.btn_rechazadas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_rechazadas.ForeColor = System.Drawing.Color.Brown;
            this.btn_rechazadas.Location = new System.Drawing.Point(285, 9);
            this.btn_rechazadas.Name = "btn_rechazadas";
            this.btn_rechazadas.Size = new System.Drawing.Size(75, 37);
            this.btn_rechazadas.TabIndex = 11;
            this.btn_rechazadas.Text = "Rechazadas";
            this.btn_rechazadas.UseVisualStyleBackColor = false;
            this.btn_rechazadas.Click += new System.EventHandler(this.btn_rechazadas_Click);
            // 
            // btn_pendientes
            // 
            this.btn_pendientes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pendientes.ForeColor = System.Drawing.Color.Chocolate;
            this.btn_pendientes.Location = new System.Drawing.Point(123, 9);
            this.btn_pendientes.Name = "btn_pendientes";
            this.btn_pendientes.Size = new System.Drawing.Size(75, 37);
            this.btn_pendientes.TabIndex = 10;
            this.btn_pendientes.Text = "Pendientes";
            this.btn_pendientes.UseVisualStyleBackColor = false;
            this.btn_pendientes.Click += new System.EventHandler(this.btn_pendientes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Facturas";
            // 
            // btn_validar_importe
            // 
            this.btn_validar_importe.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_validar_importe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_validar_importe.Location = new System.Drawing.Point(12, 228);
            this.btn_validar_importe.Name = "btn_validar_importe";
            this.btn_validar_importe.Size = new System.Drawing.Size(143, 37);
            this.btn_validar_importe.TabIndex = 13;
            this.btn_validar_importe.Text = "Validar importe";
            this.btn_validar_importe.UseVisualStyleBackColor = false;
            this.btn_validar_importe.Click += new System.EventHandler(this.btn_validar_importe_Click);
            // 
            // btn_validar_autorizacion
            // 
            this.btn_validar_autorizacion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_validar_autorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_validar_autorizacion.Location = new System.Drawing.Point(181, 228);
            this.btn_validar_autorizacion.Name = "btn_validar_autorizacion";
            this.btn_validar_autorizacion.Size = new System.Drawing.Size(143, 37);
            this.btn_validar_autorizacion.TabIndex = 14;
            this.btn_validar_autorizacion.Text = "Validar autorizacion";
            this.btn_validar_autorizacion.UseVisualStyleBackColor = false;
            this.btn_validar_autorizacion.Click += new System.EventHandler(this.btn_validar_autorizacion_Click);
            // 
            // btn_rechazar
            // 
            this.btn_rechazar.BackColor = System.Drawing.Color.Brown;
            this.btn_rechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rechazar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_rechazar.Location = new System.Drawing.Point(351, 228);
            this.btn_rechazar.Name = "btn_rechazar";
            this.btn_rechazar.Size = new System.Drawing.Size(143, 37);
            this.btn_rechazar.TabIndex = 15;
            this.btn_rechazar.Text = "Rechazar factura";
            this.btn_rechazar.UseVisualStyleBackColor = false;
            this.btn_rechazar.Click += new System.EventHandler(this.btn_rechazar_Click);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_aceptar.Enabled = false;
            this.btn_aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_aceptar.Location = new System.Drawing.Point(518, 228);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(143, 37);
            this.btn_aceptar.TabIndex = 16;
            this.btn_aceptar.Text = "Aceptar factura";
            this.btn_aceptar.UseVisualStyleBackColor = false;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // ConsultarFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 277);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.btn_rechazar);
            this.Controls.Add(this.btn_validar_autorizacion);
            this.Controls.Add(this.btn_validar_importe);
            this.Controls.Add(this.btn_aceptadas);
            this.Controls.Add(this.btn_rechazadas);
            this.Controls.Add(this.btn_pendientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_facturas);
            this.Name = "ConsultarFacturas";
            this.Text = "ConsultarFacturas";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_facturas;
        private System.Windows.Forms.Button btn_aceptadas;
        private System.Windows.Forms.Button btn_rechazadas;
        private System.Windows.Forms.Button btn_pendientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_validar_importe;
        private System.Windows.Forms.Button btn_validar_autorizacion;
        private System.Windows.Forms.Button btn_rechazar;
        private System.Windows.Forms.Button btn_aceptar;
    }
}