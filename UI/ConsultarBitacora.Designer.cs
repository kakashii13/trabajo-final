namespace UI
{
    partial class ConsultarBitacora
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
            this.dgv_bitacora = new System.Windows.Forms.DataGridView();
            this.btn_restore = new System.Windows.Forms.Button();
            this.btn_todo = new System.Windows.Forms.Button();
            this.btn_backups = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_bitacora);
            this.groupBox1.Location = new System.Drawing.Point(22, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 260);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bitacora";
            // 
            // dgv_bitacora
            // 
            this.dgv_bitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bitacora.Location = new System.Drawing.Point(6, 19);
            this.dgv_bitacora.Name = "dgv_bitacora";
            this.dgv_bitacora.Size = new System.Drawing.Size(799, 235);
            this.dgv_bitacora.TabIndex = 0;
            // 
            // btn_restore
            // 
            this.btn_restore.Location = new System.Drawing.Point(603, 283);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(112, 33);
            this.btn_restore.TabIndex = 1;
            this.btn_restore.Text = "Restores";
            this.btn_restore.UseVisualStyleBackColor = true;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // btn_todo
            // 
            this.btn_todo.Location = new System.Drawing.Point(721, 283);
            this.btn_todo.Name = "btn_todo";
            this.btn_todo.Size = new System.Drawing.Size(112, 33);
            this.btn_todo.TabIndex = 2;
            this.btn_todo.Text = "Listar todo";
            this.btn_todo.UseVisualStyleBackColor = true;
            this.btn_todo.Click += new System.EventHandler(this.btn_todo_Click);
            // 
            // btn_backups
            // 
            this.btn_backups.Location = new System.Drawing.Point(485, 283);
            this.btn_backups.Name = "btn_backups";
            this.btn_backups.Size = new System.Drawing.Size(112, 33);
            this.btn_backups.TabIndex = 3;
            this.btn_backups.Text = "Backups";
            this.btn_backups.UseVisualStyleBackColor = true;
            this.btn_backups.Click += new System.EventHandler(this.btn_backups_Click);
            // 
            // Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 328);
            this.Controls.Add(this.btn_backups);
            this.Controls.Add(this.btn_todo);
            this.Controls.Add(this.btn_restore);
            this.Controls.Add(this.groupBox1);
            this.Name = "Bitacora";
            this.Text = "Bitacora";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bitacora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_bitacora;
        private System.Windows.Forms.Button btn_restore;
        private System.Windows.Forms.Button btn_todo;
        private System.Windows.Forms.Button btn_backups;
    }
}