namespace UI
{
    partial class ConsultarAportes
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
            this.dg_aportes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.list_afiliados = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_aportes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_aportes
            // 
            this.dg_aportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_aportes.Location = new System.Drawing.Point(6, 19);
            this.dg_aportes.Name = "dg_aportes";
            this.dg_aportes.Size = new System.Drawing.Size(487, 144);
            this.dg_aportes.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.list_afiliados);
            this.groupBox1.Location = new System.Drawing.Point(13, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 216);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Afiliados";
            // 
            // list_afiliados
            // 
            this.list_afiliados.FormattingEnabled = true;
            this.list_afiliados.Location = new System.Drawing.Point(6, 19);
            this.list_afiliados.Name = "list_afiliados";
            this.list_afiliados.Size = new System.Drawing.Size(181, 186);
            this.list_afiliados.TabIndex = 0;
            this.list_afiliados.SelectedValueChanged += new System.EventHandler(this.list_afiliados_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_aportes);
            this.groupBox2.Location = new System.Drawing.Point(225, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 169);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aportes";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(600, 200);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(124, 33);
            this.btn_clear.TabIndex = 1;
            this.btn_clear.Text = "Mostrar todos";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // ConsultarAportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 245);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ConsultarAportes";
            this.Text = "ConsultarAportes";
            ((System.ComponentModel.ISupportInitialize)(this.dg_aportes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_aportes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox list_afiliados;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_clear;
    }
}