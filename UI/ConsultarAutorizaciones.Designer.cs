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
            this.dgv_autorizaciones = new System.Windows.Forms.DataGridView();
            this.lista_afiliados = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_listar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_autorizaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_autorizaciones
            // 
            this.dgv_autorizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_autorizaciones.Location = new System.Drawing.Point(6, 27);
            this.dgv_autorizaciones.Name = "dgv_autorizaciones";
            this.dgv_autorizaciones.ReadOnly = true;
            this.dgv_autorizaciones.Size = new System.Drawing.Size(652, 278);
            this.dgv_autorizaciones.TabIndex = 0;
            // 
            // lista_afiliados
            // 
            this.lista_afiliados.FormattingEnabled = true;
            this.lista_afiliados.Location = new System.Drawing.Point(6, 27);
            this.lista_afiliados.Name = "lista_afiliados";
            this.lista_afiliados.Size = new System.Drawing.Size(185, 199);
            this.lista_afiliados.TabIndex = 1;
            this.lista_afiliados.SelectedValueChanged += new System.EventHandler(this.lista_afiliados_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lista_afiliados);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 232);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Afiliados";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_autorizaciones);
            this.groupBox2.Location = new System.Drawing.Point(228, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(667, 311);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Autorizaciones";
            // 
            // btn_listar
            // 
            this.btn_listar.Location = new System.Drawing.Point(752, 328);
            this.btn_listar.Name = "btn_listar";
            this.btn_listar.Size = new System.Drawing.Size(143, 32);
            this.btn_listar.TabIndex = 4;
            this.btn_listar.Text = "Listar todas";
            this.btn_listar.UseVisualStyleBackColor = true;
            this.btn_listar.Click += new System.EventHandler(this.btn_listar_Click);
            // 
            // ListarAutorizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 372);
            this.Controls.Add(this.btn_listar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListarAutorizaciones";
            this.Text = "ListarAutorizaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_autorizaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_autorizaciones;
        private System.Windows.Forms.ListBox lista_afiliados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_listar;
    }
}