namespace UI
{
    partial class ABMAfiliados
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
            this.dgvAfiliados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCambiarPlan = new System.Windows.Forms.Button();
            this.btnInactivar = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfiliados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAfiliados
            // 
            this.dgvAfiliados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAfiliados.Location = new System.Drawing.Point(12, 62);
            this.dgvAfiliados.Name = "dgvAfiliados";
            this.dgvAfiliados.ReadOnly = true;
            this.dgvAfiliados.Size = new System.Drawing.Size(856, 229);
            this.dgvAfiliados.TabIndex = 0;
            this.dgvAfiliados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_afiliados_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listado afiliados";
            // 
            // btnCambiarPlan
            // 
            this.btnCambiarPlan.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCambiarPlan.Enabled = false;
            this.btnCambiarPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarPlan.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCambiarPlan.Location = new System.Drawing.Point(728, 297);
            this.btnCambiarPlan.Name = "btnCambiarPlan";
            this.btnCambiarPlan.Size = new System.Drawing.Size(140, 34);
            this.btnCambiarPlan.TabIndex = 5;
            this.btnCambiarPlan.Text = "Cambiar plan";
            this.btnCambiarPlan.UseVisualStyleBackColor = false;
            this.btnCambiarPlan.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInactivar
            // 
            this.btnInactivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInactivar.ForeColor = System.Drawing.Color.Brown;
            this.btnInactivar.Location = new System.Drawing.Point(595, 297);
            this.btnInactivar.Name = "btnInactivar";
            this.btnInactivar.Size = new System.Drawing.Size(123, 34);
            this.btnInactivar.TabIndex = 6;
            this.btnInactivar.Text = "Inactivar";
            this.btnInactivar.UseVisualStyleBackColor = true;
            this.btnInactivar.Click += new System.EventHandler(this.btn_inactivar_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivar.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnActivar.Location = new System.Drawing.Point(466, 297);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(123, 34);
            this.btnActivar.TabIndex = 7;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Click += new System.EventHandler(this.btn_activar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnActualizar.Location = new System.Drawing.Point(141, 19);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(123, 34);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar listado";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // ABMAfiliados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 343);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnInactivar);
            this.Controls.Add(this.btnCambiarPlan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAfiliados);
            this.Name = "ABMAfiliados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ListadoAfiliados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfiliados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAfiliados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCambiarPlan;
        private System.Windows.Forms.Button btnInactivar;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnActualizar;
    }
}