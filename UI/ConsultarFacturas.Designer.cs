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
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.btnAceptadas = new System.Windows.Forms.Button();
            this.btnRechazadas = new System.Windows.Forms.Button();
            this.btnPendientes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnValidarImporte = new System.Windows.Forms.Button();
            this.btnValidarAutorizacion = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnPagas = new System.Windows.Forms.Button();
            this.btnActualizarListado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Location = new System.Drawing.Point(12, 55);
            this.dgvFacturas.MultiSelect = false;
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.Size = new System.Drawing.Size(735, 254);
            this.dgvFacturas.TabIndex = 0;
            this.dgvFacturas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_facturas_CellClick);
            // 
            // btnAceptadas
            // 
            this.btnAceptadas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAceptadas.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAceptadas.Location = new System.Drawing.Point(510, 9);
            this.btnAceptadas.Name = "btnAceptadas";
            this.btnAceptadas.Size = new System.Drawing.Size(75, 37);
            this.btnAceptadas.TabIndex = 12;
            this.btnAceptadas.Text = "Aceptadas";
            this.btnAceptadas.UseVisualStyleBackColor = false;
            this.btnAceptadas.Click += new System.EventHandler(this.btn_aceptadas_Click);
            // 
            // btnRechazadas
            // 
            this.btnRechazadas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRechazadas.ForeColor = System.Drawing.Color.Brown;
            this.btnRechazadas.Location = new System.Drawing.Point(672, 9);
            this.btnRechazadas.Name = "btnRechazadas";
            this.btnRechazadas.Size = new System.Drawing.Size(75, 37);
            this.btnRechazadas.TabIndex = 11;
            this.btnRechazadas.Text = "Rechazadas";
            this.btnRechazadas.UseVisualStyleBackColor = false;
            this.btnRechazadas.Click += new System.EventHandler(this.btn_rechazadas_Click);
            // 
            // btnPendientes
            // 
            this.btnPendientes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPendientes.ForeColor = System.Drawing.Color.Chocolate;
            this.btnPendientes.Location = new System.Drawing.Point(429, 9);
            this.btnPendientes.Name = "btnPendientes";
            this.btnPendientes.Size = new System.Drawing.Size(75, 37);
            this.btnPendientes.TabIndex = 10;
            this.btnPendientes.Text = "Pendientes";
            this.btnPendientes.UseVisualStyleBackColor = false;
            this.btnPendientes.Click += new System.EventHandler(this.btn_pendientes_Click);
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
            // btnValidarImporte
            // 
            this.btnValidarImporte.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnValidarImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarImporte.Location = new System.Drawing.Point(98, 326);
            this.btnValidarImporte.Name = "btnValidarImporte";
            this.btnValidarImporte.Size = new System.Drawing.Size(143, 37);
            this.btnValidarImporte.TabIndex = 13;
            this.btnValidarImporte.Text = "Validar importe";
            this.btnValidarImporte.UseVisualStyleBackColor = false;
            this.btnValidarImporte.Click += new System.EventHandler(this.btn_validar_importe_Click);
            // 
            // btnValidarAutorizacion
            // 
            this.btnValidarAutorizacion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnValidarAutorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarAutorizacion.Location = new System.Drawing.Point(267, 326);
            this.btnValidarAutorizacion.Name = "btnValidarAutorizacion";
            this.btnValidarAutorizacion.Size = new System.Drawing.Size(143, 37);
            this.btnValidarAutorizacion.TabIndex = 14;
            this.btnValidarAutorizacion.Text = "Validar autorizacion";
            this.btnValidarAutorizacion.UseVisualStyleBackColor = false;
            this.btnValidarAutorizacion.Click += new System.EventHandler(this.btn_validar_autorizacion_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackColor = System.Drawing.Color.Brown;
            this.btnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechazar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRechazar.Location = new System.Drawing.Point(437, 326);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(143, 37);
            this.btnRechazar.TabIndex = 15;
            this.btnRechazar.Text = "Rechazar factura";
            this.btnRechazar.UseVisualStyleBackColor = false;
            this.btnRechazar.Click += new System.EventHandler(this.btn_rechazar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAceptar.Location = new System.Drawing.Point(604, 326);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(143, 37);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "Aceptar factura";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btnPagas
            // 
            this.btnPagas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPagas.ForeColor = System.Drawing.Color.YellowGreen;
            this.btnPagas.Location = new System.Drawing.Point(591, 9);
            this.btnPagas.Name = "btnPagas";
            this.btnPagas.Size = new System.Drawing.Size(75, 37);
            this.btnPagas.TabIndex = 17;
            this.btnPagas.Text = "Pagas";
            this.btnPagas.UseVisualStyleBackColor = false;
            this.btnPagas.Click += new System.EventHandler(this.btnPagas_Click);
            // 
            // btnActualizarListado
            // 
            this.btnActualizarListado.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnActualizarListado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnActualizarListado.Location = new System.Drawing.Point(98, 9);
            this.btnActualizarListado.Name = "btnActualizarListado";
            this.btnActualizarListado.Size = new System.Drawing.Size(96, 37);
            this.btnActualizarListado.TabIndex = 18;
            this.btnActualizarListado.Text = "Actualizar listado";
            this.btnActualizarListado.UseVisualStyleBackColor = false;
            this.btnActualizarListado.Click += new System.EventHandler(this.btnActualizarListado_Click);
            // 
            // ConsultarFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 375);
            this.Controls.Add(this.btnActualizarListado);
            this.Controls.Add(this.btnPagas);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnValidarAutorizacion);
            this.Controls.Add(this.btnValidarImporte);
            this.Controls.Add(this.btnAceptadas);
            this.Controls.Add(this.btnRechazadas);
            this.Controls.Add(this.btnPendientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFacturas);
            this.Name = "ConsultarFacturas";
            this.Text = "ConsultarFacturas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Button btnAceptadas;
        private System.Windows.Forms.Button btnRechazadas;
        private System.Windows.Forms.Button btnPendientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnValidarImporte;
        private System.Windows.Forms.Button btnValidarAutorizacion;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnPagas;
        private System.Windows.Forms.Button btnActualizarListado;
    }
}