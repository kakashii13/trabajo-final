namespace UI
{
    partial class Restore
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
            this.lista_backups = new System.Windows.Forms.ListBox();
            this.btn_restore = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btnActualizarListado = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lista_backups);
            this.groupBox1.Location = new System.Drawing.Point(19, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 294);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backups disponibles";
            // 
            // lista_backups
            // 
            this.lista_backups.FormattingEnabled = true;
            this.lista_backups.Location = new System.Drawing.Point(6, 19);
            this.lista_backups.Name = "lista_backups";
            this.lista_backups.Size = new System.Drawing.Size(307, 264);
            this.lista_backups.TabIndex = 0;
            // 
            // btn_restore
            // 
            this.btn_restore.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_restore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_restore.Location = new System.Drawing.Point(19, 417);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(323, 41);
            this.btn_restore.TabIndex = 1;
            this.btn_restore.Text = "Realizar restore";
            this.btn_restore.UseVisualStyleBackColor = false;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.Brown;
            this.btn_cancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_cancelar.Location = new System.Drawing.Point(19, 370);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(323, 41);
            this.btn_cancelar.TabIndex = 2;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btnActualizarListado
            // 
            this.btnActualizarListado.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnActualizarListado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnActualizarListado.Location = new System.Drawing.Point(19, 323);
            this.btnActualizarListado.Name = "btnActualizarListado";
            this.btnActualizarListado.Size = new System.Drawing.Size(323, 41);
            this.btnActualizarListado.TabIndex = 3;
            this.btnActualizarListado.Text = "Actualizar listado";
            this.btnActualizarListado.UseVisualStyleBackColor = false;
            this.btnActualizarListado.Click += new System.EventHandler(this.btnActualizarListado_Click);
            // 
            // Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 469);
            this.Controls.Add(this.btnActualizarListado);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_restore);
            this.Controls.Add(this.groupBox1);
            this.Name = "Restore";
            this.Text = "Restore";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lista_backups;
        private System.Windows.Forms.Button btn_restore;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btnActualizarListado;
    }
}