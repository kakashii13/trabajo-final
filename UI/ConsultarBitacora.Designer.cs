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
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnListarTodo = new System.Windows.Forms.Button();
            this.btnBackups = new System.Windows.Forms.Button();
            this.btnActualizarListado = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvBitacora);
            this.groupBox1.Location = new System.Drawing.Point(22, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 260);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bitacora";
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Location = new System.Drawing.Point(6, 19);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.Size = new System.Drawing.Size(799, 235);
            this.dgvBitacora.TabIndex = 0;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(603, 283);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(112, 33);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "Restores";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // btnListarTodo
            // 
            this.btnListarTodo.Location = new System.Drawing.Point(721, 283);
            this.btnListarTodo.Name = "btnListarTodo";
            this.btnListarTodo.Size = new System.Drawing.Size(112, 33);
            this.btnListarTodo.TabIndex = 2;
            this.btnListarTodo.Text = "Listar todo";
            this.btnListarTodo.UseVisualStyleBackColor = true;
            this.btnListarTodo.Click += new System.EventHandler(this.btn_todo_Click);
            // 
            // btnBackups
            // 
            this.btnBackups.Location = new System.Drawing.Point(485, 283);
            this.btnBackups.Name = "btnBackups";
            this.btnBackups.Size = new System.Drawing.Size(112, 33);
            this.btnBackups.TabIndex = 3;
            this.btnBackups.Text = "Backups";
            this.btnBackups.UseVisualStyleBackColor = true;
            this.btnBackups.Click += new System.EventHandler(this.btn_backups_Click);
            // 
            // btnActualizarListado
            // 
            this.btnActualizarListado.Location = new System.Drawing.Point(367, 283);
            this.btnActualizarListado.Name = "btnActualizarListado";
            this.btnActualizarListado.Size = new System.Drawing.Size(112, 33);
            this.btnActualizarListado.TabIndex = 4;
            this.btnActualizarListado.Text = "Actualizar listado";
            this.btnActualizarListado.UseVisualStyleBackColor = true;
            this.btnActualizarListado.Click += new System.EventHandler(this.btnActualizarListado_Click);
            // 
            // ConsultarBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 328);
            this.Controls.Add(this.btnActualizarListado);
            this.Controls.Add(this.btnBackups);
            this.Controls.Add(this.btnListarTodo);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsultarBitacora";
            this.Text = "Bitacora";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnListarTodo;
        private System.Windows.Forms.Button btnBackups;
        private System.Windows.Forms.Button btnActualizarListado;
    }
}