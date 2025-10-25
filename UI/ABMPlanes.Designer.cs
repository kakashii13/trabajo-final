namespace UI
{
    partial class ABMPlanes
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
            this.dg_planes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.mod_plan = new System.Windows.Forms.Button();
            this.add_plan = new System.Windows.Forms.Button();
            this.txt_tope = new System.Windows.Forms.Label();
            this.txt_monto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_planes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_planes
            // 
            this.dg_planes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_planes.Location = new System.Drawing.Point(13, 17);
            this.dg_planes.Name = "dg_planes";
            this.dg_planes.ReadOnly = true;
            this.dg_planes.Size = new System.Drawing.Size(351, 139);
            this.dg_planes.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dg_planes);
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 173);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Planes";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Brown;
            this.btn_cancel.Enabled = false;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cancel.Location = new System.Drawing.Point(418, 157);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(120, 32);
            this.btn_cancel.TabIndex = 47;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_save.Enabled = false;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_save.Location = new System.Drawing.Point(418, 202);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(120, 32);
            this.btn_save.TabIndex = 46;
            this.btn_save.Text = "Guardar cambios";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // mod_plan
            // 
            this.mod_plan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mod_plan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mod_plan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mod_plan.Location = new System.Drawing.Point(418, 57);
            this.mod_plan.Name = "mod_plan";
            this.mod_plan.Size = new System.Drawing.Size(120, 32);
            this.mod_plan.TabIndex = 44;
            this.mod_plan.Text = "Modificar";
            this.mod_plan.UseVisualStyleBackColor = false;
            this.mod_plan.Click += new System.EventHandler(this.mod_plan_Click);
            // 
            // add_plan
            // 
            this.add_plan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.add_plan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_plan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.add_plan.Location = new System.Drawing.Point(418, 9);
            this.add_plan.Name = "add_plan";
            this.add_plan.Size = new System.Drawing.Size(120, 32);
            this.add_plan.TabIndex = 43;
            this.add_plan.Text = "Crear";
            this.add_plan.UseVisualStyleBackColor = false;
            this.add_plan.Click += new System.EventHandler(this.add_plan_Click);
            // 
            // txt_tope
            // 
            this.txt_tope.AutoSize = true;
            this.txt_tope.Location = new System.Drawing.Point(130, 198);
            this.txt_tope.Name = "txt_tope";
            this.txt_tope.Size = new System.Drawing.Size(61, 13);
            this.txt_tope.TabIndex = 51;
            this.txt_tope.Text = "Monto tope";
            // 
            // txt_monto
            // 
            this.txt_monto.Enabled = false;
            this.txt_monto.Location = new System.Drawing.Point(130, 214);
            this.txt_monto.Name = "txt_monto";
            this.txt_monto.Size = new System.Drawing.Size(100, 20);
            this.txt_monto.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Nombre";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Enabled = false;
            this.txt_nombre.Location = new System.Drawing.Point(12, 214);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(100, 20);
            this.txt_nombre.TabIndex = 48;
            // 
            // ABMPlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 245);
            this.Controls.Add(this.txt_tope);
            this.Controls.Add(this.txt_monto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.mod_plan);
            this.Controls.Add(this.add_plan);
            this.Controls.Add(this.groupBox1);
            this.Name = "ABMPlanes";
            this.Text = "ABMPlanes";
            ((System.ComponentModel.ISupportInitialize)(this.dg_planes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_planes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button mod_plan;
        private System.Windows.Forms.Button add_plan;
        private System.Windows.Forms.Label txt_tope;
        private System.Windows.Forms.TextBox txt_monto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nombre;
    }
}