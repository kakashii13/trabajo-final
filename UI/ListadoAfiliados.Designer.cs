namespace UI
{
    partial class ListadoAfiliados
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
            this.dg_afiliados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cambio = new System.Windows.Forms.Button();
            this.btn_inactivar = new System.Windows.Forms.Button();
            this.btn_activar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_afiliados)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_afiliados
            // 
            this.dg_afiliados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_afiliados.Location = new System.Drawing.Point(12, 35);
            this.dg_afiliados.Name = "dg_afiliados";
            this.dg_afiliados.ReadOnly = true;
            this.dg_afiliados.Size = new System.Drawing.Size(856, 150);
            this.dg_afiliados.TabIndex = 0;
            this.dg_afiliados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_afiliados_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listado afiliados";
            // 
            // btn_cambio
            // 
            this.btn_cambio.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_cambio.Enabled = false;
            this.btn_cambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cambio.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cambio.Location = new System.Drawing.Point(728, 214);
            this.btn_cambio.Name = "btn_cambio";
            this.btn_cambio.Size = new System.Drawing.Size(140, 34);
            this.btn_cambio.TabIndex = 5;
            this.btn_cambio.Text = "Cambiar plan";
            this.btn_cambio.UseVisualStyleBackColor = false;
            this.btn_cambio.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_inactivar
            // 
            this.btn_inactivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inactivar.ForeColor = System.Drawing.Color.Brown;
            this.btn_inactivar.Location = new System.Drawing.Point(595, 214);
            this.btn_inactivar.Name = "btn_inactivar";
            this.btn_inactivar.Size = new System.Drawing.Size(123, 34);
            this.btn_inactivar.TabIndex = 6;
            this.btn_inactivar.Text = "Inactivar";
            this.btn_inactivar.UseVisualStyleBackColor = true;
            this.btn_inactivar.Click += new System.EventHandler(this.btn_inactivar_Click);
            // 
            // btn_activar
            // 
            this.btn_activar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_activar.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_activar.Location = new System.Drawing.Point(466, 214);
            this.btn_activar.Name = "btn_activar";
            this.btn_activar.Size = new System.Drawing.Size(123, 34);
            this.btn_activar.TabIndex = 7;
            this.btn_activar.Text = "Activar";
            this.btn_activar.UseVisualStyleBackColor = true;
            this.btn_activar.Click += new System.EventHandler(this.btn_activar_Click);
            // 
            // ListadoAfiliados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 260);
            this.Controls.Add(this.btn_activar);
            this.Controls.Add(this.btn_inactivar);
            this.Controls.Add(this.btn_cambio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_afiliados);
            this.Name = "ListadoAfiliados";
            this.Text = "ListadoAfiliados";
            ((System.ComponentModel.ISupportInitialize)(this.dg_afiliados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_afiliados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cambio;
        private System.Windows.Forms.Button btn_inactivar;
        private System.Windows.Forms.Button btn_activar;
    }
}