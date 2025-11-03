namespace UI
{
    partial class ConsultarAutorizaciones
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
            this.dgvAutorizaciones = new System.Windows.Forms.DataGridView();
            this.listaAfiliados = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnListarTodas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAutorizaciones
            // 
            this.dgvAutorizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutorizaciones.Location = new System.Drawing.Point(6, 27);
            this.dgvAutorizaciones.Name = "dgvAutorizaciones";
            this.dgvAutorizaciones.ReadOnly = true;
            this.dgvAutorizaciones.Size = new System.Drawing.Size(652, 278);
            this.dgvAutorizaciones.TabIndex = 0;
            // 
            // listaAfiliados
            // 
            this.listaAfiliados.FormattingEnabled = true;
            this.listaAfiliados.Location = new System.Drawing.Point(6, 27);
            this.listaAfiliados.Name = "listaAfiliados";
            this.listaAfiliados.Size = new System.Drawing.Size(185, 199);
            this.listaAfiliados.TabIndex = 1;
            this.listaAfiliados.SelectedValueChanged += new System.EventHandler(this.lista_afiliados_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaAfiliados);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 232);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Afiliados";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAutorizaciones);
            this.groupBox2.Location = new System.Drawing.Point(228, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(667, 311);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Autorizaciones";
            // 
            // btnListarTodas
            // 
            this.btnListarTodas.Location = new System.Drawing.Point(752, 328);
            this.btnListarTodas.Name = "btnListarTodas";
            this.btnListarTodas.Size = new System.Drawing.Size(143, 32);
            this.btnListarTodas.TabIndex = 4;
            this.btnListarTodas.Text = "Listar todas";
            this.btnListarTodas.UseVisualStyleBackColor = true;
            this.btnListarTodas.Click += new System.EventHandler(this.btn_listar_Click);
            // 
            // ConsultarAutorizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 372);
            this.Controls.Add(this.btnListarTodas);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsultarAutorizaciones";
            this.Text = "ListarAutorizaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAutorizaciones;
        private System.Windows.Forms.ListBox listaAfiliados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnListarTodas;
    }
}