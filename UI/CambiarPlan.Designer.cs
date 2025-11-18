namespace UI
{
    partial class CambiarPlan
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAportes = new System.Windows.Forms.DataGridView();
            this.txtNuevoPlan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlanActual = new System.Windows.Forms.TextBox();
            this.fechaVigencia = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAportes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAportes);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aportes";
            // 
            // dgvAportes
            // 
            this.dgvAportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAportes.Location = new System.Drawing.Point(6, 19);
            this.dgvAportes.Name = "dgvAportes";
            this.dgvAportes.ReadOnly = true;
            this.dgvAportes.Size = new System.Drawing.Size(424, 150);
            this.dgvAportes.TabIndex = 0;
            // 
            // txtNuevoPlan
            // 
            this.txtNuevoPlan.BackColor = System.Drawing.Color.OliveDrab;
            this.txtNuevoPlan.ForeColor = System.Drawing.SystemColors.Window;
            this.txtNuevoPlan.Location = new System.Drawing.Point(6, 37);
            this.txtNuevoPlan.Name = "txtNuevoPlan";
            this.txtNuevoPlan.ReadOnly = true;
            this.txtNuevoPlan.Size = new System.Drawing.Size(108, 20);
            this.txtNuevoPlan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Plan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Id plan";
            // 
            // txtPlanActual
            // 
            this.txtPlanActual.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtPlanActual.Location = new System.Drawing.Point(5, 37);
            this.txtPlanActual.Name = "txtPlanActual";
            this.txtPlanActual.ReadOnly = true;
            this.txtPlanActual.Size = new System.Drawing.Size(108, 20);
            this.txtPlanActual.TabIndex = 3;
            // 
            // fechaVigencia
            // 
            this.fechaVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaVigencia.Location = new System.Drawing.Point(133, 37);
            this.fechaVigencia.Name = "fechaVigencia";
            this.fechaVigencia.Size = new System.Drawing.Size(114, 20);
            this.fechaVigencia.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha vigencia";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.fechaVigencia);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNuevoPlan);
            this.groupBox2.Location = new System.Drawing.Point(141, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 63);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuevo plan";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Brown;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Location = new System.Drawing.Point(322, 332);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 32);
            this.btnCancelar.TabIndex = 44;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.Location = new System.Drawing.Point(322, 377);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 32);
            this.btnGuardar.TabIndex = 43;
            this.btnGuardar.Text = "Guardar cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPlanActual);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(119, 63);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Plan actual";
            // 
            // CambiarPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 424);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "CambiarPlan";
            this.Text = "CambioPlan";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAportes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAportes;
        private System.Windows.Forms.TextBox txtNuevoPlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlanActual;
        private System.Windows.Forms.DateTimePicker fechaVigencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}