namespace UI
{
    partial class ResolverSolicitud
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.btnPendientes = new System.Windows.Forms.Button();
            this.btnRechazadas = new System.Windows.Forms.Button();
            this.btnAceptadas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solicitudes";
            // 
            // dgvSolicitudes
            // 
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudes.Location = new System.Drawing.Point(12, 52);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.ReadOnly = true;
            this.dgvSolicitudes.Size = new System.Drawing.Size(786, 229);
            this.dgvSolicitudes.TabIndex = 1;
            this.dgvSolicitudes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_solicitudes_CellContentClick);
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAnalizar.Enabled = false;
            this.btnAnalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalizar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAnalizar.Location = new System.Drawing.Point(656, 296);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(142, 34);
            this.btnAnalizar.TabIndex = 5;
            this.btnAnalizar.Text = "Analizar solicitud";
            this.btnAnalizar.UseVisualStyleBackColor = false;
            this.btnAnalizar.Click += new System.EventHandler(this.btn_analizar_Click);
            // 
            // btnPendientes
            // 
            this.btnPendientes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPendientes.ForeColor = System.Drawing.Color.Chocolate;
            this.btnPendientes.Location = new System.Drawing.Point(123, 9);
            this.btnPendientes.Name = "btnPendientes";
            this.btnPendientes.Size = new System.Drawing.Size(75, 37);
            this.btnPendientes.TabIndex = 6;
            this.btnPendientes.Text = "Pendientes";
            this.btnPendientes.UseVisualStyleBackColor = false;
            this.btnPendientes.Click += new System.EventHandler(this.btn_pendientes_Click);
            // 
            // btnRechazadas
            // 
            this.btnRechazadas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRechazadas.ForeColor = System.Drawing.Color.Brown;
            this.btnRechazadas.Location = new System.Drawing.Point(285, 9);
            this.btnRechazadas.Name = "btnRechazadas";
            this.btnRechazadas.Size = new System.Drawing.Size(75, 37);
            this.btnRechazadas.TabIndex = 7;
            this.btnRechazadas.Text = "Rechazadas";
            this.btnRechazadas.UseVisualStyleBackColor = false;
            this.btnRechazadas.Click += new System.EventHandler(this.btn_rechazadas_Click);
            // 
            // btnAceptadas
            // 
            this.btnAceptadas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAceptadas.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAceptadas.Location = new System.Drawing.Point(204, 9);
            this.btnAceptadas.Name = "btnAceptadas";
            this.btnAceptadas.Size = new System.Drawing.Size(75, 37);
            this.btnAceptadas.TabIndex = 8;
            this.btnAceptadas.Text = "Aceptadas";
            this.btnAceptadas.UseVisualStyleBackColor = false;
            this.btnAceptadas.Click += new System.EventHandler(this.btn_aceptadas_Click);
            // 
            // ResolverSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 342);
            this.Controls.Add(this.btnAceptadas);
            this.Controls.Add(this.btnRechazadas);
            this.Controls.Add(this.btnPendientes);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.dgvSolicitudes);
            this.Controls.Add(this.label1);
            this.Name = "ResolverSolicitud";
            this.Text = "ResolverSolicitud";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Button btnPendientes;
        private System.Windows.Forms.Button btnRechazadas;
        private System.Windows.Forms.Button btnAceptadas;
    }
}