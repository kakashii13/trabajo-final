namespace UI
{
    partial class ABMPracticas
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
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.mod_practica = new System.Windows.Forms.Button();
            this.add_practica = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dg_practicas = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.NumericUpDown();
            this.txt_precio = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_practicas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_codigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_precio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Precio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Nombre";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Enabled = false;
            this.txt_nombre.Location = new System.Drawing.Point(15, 218);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(100, 20);
            this.txt_nombre.TabIndex = 58;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Brown;
            this.btn_cancel.Enabled = false;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cancel.Location = new System.Drawing.Point(516, 162);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(120, 32);
            this.btn_cancel.TabIndex = 57;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click_1);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_save.Enabled = false;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_save.Location = new System.Drawing.Point(516, 207);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(120, 32);
            this.btn_save.TabIndex = 56;
            this.btn_save.Text = "Guardar cambios";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click_1);
            // 
            // mod_practica
            // 
            this.mod_practica.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mod_practica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mod_practica.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mod_practica.Location = new System.Drawing.Point(516, 62);
            this.mod_practica.Name = "mod_practica";
            this.mod_practica.Size = new System.Drawing.Size(120, 32);
            this.mod_practica.TabIndex = 54;
            this.mod_practica.Text = "Modificar";
            this.mod_practica.UseVisualStyleBackColor = false;
            this.mod_practica.Click += new System.EventHandler(this.mod_practica_Click_1);
            // 
            // add_practica
            // 
            this.add_practica.BackColor = System.Drawing.SystemColors.HighlightText;
            this.add_practica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_practica.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.add_practica.Location = new System.Drawing.Point(516, 14);
            this.add_practica.Name = "add_practica";
            this.add_practica.Size = new System.Drawing.Size(120, 32);
            this.add_practica.TabIndex = 53;
            this.add_practica.Text = "Crear";
            this.add_practica.UseVisualStyleBackColor = false;
            this.add_practica.Click += new System.EventHandler(this.add_practica_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dg_practicas);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 173);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Practicas";
            // 
            // dg_practicas
            // 
            this.dg_practicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_practicas.Location = new System.Drawing.Point(5, 17);
            this.dg_practicas.Name = "dg_practicas";
            this.dg_practicas.ReadOnly = true;
            this.dg_practicas.Size = new System.Drawing.Size(457, 139);
            this.dg_practicas.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Codigo";
            // 
            // txt_codigo
            // 
            this.txt_codigo.Enabled = false;
            this.txt_codigo.Location = new System.Drawing.Point(270, 219);
            this.txt_codigo.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(112, 20);
            this.txt_codigo.TabIndex = 64;
            // 
            // txt_precio
            // 
            this.txt_precio.DecimalPlaces = 2;
            this.txt_precio.Enabled = false;
            this.txt_precio.Location = new System.Drawing.Point(136, 219);
            this.txt_precio.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.Size = new System.Drawing.Size(112, 20);
            this.txt_precio.TabIndex = 65;
            // 
            // ABMPracticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 259);
            this.Controls.Add(this.txt_precio);
            this.Controls.Add(this.txt_codigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.mod_practica);
            this.Controls.Add(this.add_practica);
            this.Controls.Add(this.groupBox1);
            this.Name = "ABMPracticas";
            this.Text = "ABMPracticas";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_practicas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_codigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_precio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button mod_practica;
        private System.Windows.Forms.Button add_practica;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dg_practicas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txt_codigo;
        private System.Windows.Forms.NumericUpDown txt_precio;
    }
}