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
            this.dg_solicitudes = new System.Windows.Forms.DataGridView();
            this.btn_analizar = new System.Windows.Forms.Button();
            this.btn_pendientes = new System.Windows.Forms.Button();
            this.btn_rechazadas = new System.Windows.Forms.Button();
            this.btn_aceptadas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_solicitudes)).BeginInit();
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
            // dg_solicitudes
            // 
            this.dg_solicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_solicitudes.Location = new System.Drawing.Point(12, 52);
            this.dg_solicitudes.Name = "dg_solicitudes";
            this.dg_solicitudes.ReadOnly = true;
            this.dg_solicitudes.Size = new System.Drawing.Size(786, 229);
            this.dg_solicitudes.TabIndex = 1;
            this.dg_solicitudes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_solicitudes_CellContentClick);
            // 
            // btn_analizar
            // 
            this.btn_analizar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_analizar.Enabled = false;
            this.btn_analizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_analizar.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_analizar.Location = new System.Drawing.Point(656, 296);
            this.btn_analizar.Name = "btn_analizar";
            this.btn_analizar.Size = new System.Drawing.Size(142, 34);
            this.btn_analizar.TabIndex = 5;
            this.btn_analizar.Text = "Analizar solicitud";
            this.btn_analizar.UseVisualStyleBackColor = false;
            this.btn_analizar.Click += new System.EventHandler(this.btn_analizar_Click);
            // 
            // btn_pendientes
            // 
            this.btn_pendientes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pendientes.ForeColor = System.Drawing.Color.Chocolate;
            this.btn_pendientes.Location = new System.Drawing.Point(123, 9);
            this.btn_pendientes.Name = "btn_pendientes";
            this.btn_pendientes.Size = new System.Drawing.Size(75, 37);
            this.btn_pendientes.TabIndex = 6;
            this.btn_pendientes.Text = "Pendientes";
            this.btn_pendientes.UseVisualStyleBackColor = false;
            this.btn_pendientes.Click += new System.EventHandler(this.btn_pendientes_Click);
            // 
            // btn_rechazadas
            // 
            this.btn_rechazadas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_rechazadas.ForeColor = System.Drawing.Color.Brown;
            this.btn_rechazadas.Location = new System.Drawing.Point(285, 9);
            this.btn_rechazadas.Name = "btn_rechazadas";
            this.btn_rechazadas.Size = new System.Drawing.Size(75, 37);
            this.btn_rechazadas.TabIndex = 7;
            this.btn_rechazadas.Text = "Rechazadas";
            this.btn_rechazadas.UseVisualStyleBackColor = false;
            this.btn_rechazadas.Click += new System.EventHandler(this.btn_rechazadas_Click);
            // 
            // btn_aceptadas
            // 
            this.btn_aceptadas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_aceptadas.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_aceptadas.Location = new System.Drawing.Point(204, 9);
            this.btn_aceptadas.Name = "btn_aceptadas";
            this.btn_aceptadas.Size = new System.Drawing.Size(75, 37);
            this.btn_aceptadas.TabIndex = 8;
            this.btn_aceptadas.Text = "Aceptadas";
            this.btn_aceptadas.UseVisualStyleBackColor = false;
            this.btn_aceptadas.Click += new System.EventHandler(this.btn_aceptadas_Click);
            // 
            // ResolverSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 342);
            this.Controls.Add(this.btn_aceptadas);
            this.Controls.Add(this.btn_rechazadas);
            this.Controls.Add(this.btn_pendientes);
            this.Controls.Add(this.btn_analizar);
            this.Controls.Add(this.dg_solicitudes);
            this.Controls.Add(this.label1);
            this.Name = "ResolverSolicitud";
            this.Text = "ResolverSolicitud";
            ((System.ComponentModel.ISupportInitialize)(this.dg_solicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dg_solicitudes;
        private System.Windows.Forms.Button btn_analizar;
        private System.Windows.Forms.Button btn_pendientes;
        private System.Windows.Forms.Button btn_rechazadas;
        private System.Windows.Forms.Button btn_aceptadas;
    }
}