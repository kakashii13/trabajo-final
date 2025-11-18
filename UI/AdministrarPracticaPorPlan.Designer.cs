namespace UI
{
    partial class AdministrarPracticaPorPlan
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
            this.listaPlanes = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listaPracticasPlan = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listaPracticas = new System.Windows.Forms.ListBox();
            this.btnEliminarPracticaPlan = new System.Windows.Forms.Button();
            this.btnAsignarPracticaPlan = new System.Windows.Forms.Button();
            this.btnListarPracticas = new System.Windows.Forms.Button();
            this.txtPlanSeleccionado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPracticaSeleccionada = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPracticaPlan = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaPlanes);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Planes";
            // 
            // listaPlanes
            // 
            this.listaPlanes.FormattingEnabled = true;
            this.listaPlanes.Location = new System.Drawing.Point(6, 19);
            this.listaPlanes.Name = "listaPlanes";
            this.listaPlanes.Size = new System.Drawing.Size(155, 173);
            this.listaPlanes.TabIndex = 0;
            this.listaPlanes.SelectedValueChanged += new System.EventHandler(this.lista_planes_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listaPracticasPlan);
            this.groupBox2.Location = new System.Drawing.Point(196, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Practicas por plan";
            // 
            // listaPracticasPlan
            // 
            this.listaPracticasPlan.FormattingEnabled = true;
            this.listaPracticasPlan.Location = new System.Drawing.Point(6, 19);
            this.listaPracticasPlan.Name = "listaPracticasPlan";
            this.listaPracticasPlan.Size = new System.Drawing.Size(163, 173);
            this.listaPracticasPlan.TabIndex = 1;
            this.listaPracticasPlan.SelectedValueChanged += new System.EventHandler(this.lista_practicas_plan_SelectedValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listaPracticas);
            this.groupBox3.Location = new System.Drawing.Point(383, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 200);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Practicas disponibles";
            // 
            // listaPracticas
            // 
            this.listaPracticas.FormattingEnabled = true;
            this.listaPracticas.Location = new System.Drawing.Point(6, 19);
            this.listaPracticas.Name = "listaPracticas";
            this.listaPracticas.Size = new System.Drawing.Size(157, 173);
            this.listaPracticas.TabIndex = 2;
            this.listaPracticas.SelectedValueChanged += new System.EventHandler(this.lista_practicas_SelectedValueChanged);
            // 
            // btnEliminarPracticaPlan
            // 
            this.btnEliminarPracticaPlan.BackColor = System.Drawing.Color.Brown;
            this.btnEliminarPracticaPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPracticaPlan.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminarPracticaPlan.Location = new System.Drawing.Point(16, 67);
            this.btnEliminarPracticaPlan.Name = "btnEliminarPracticaPlan";
            this.btnEliminarPracticaPlan.Size = new System.Drawing.Size(148, 32);
            this.btnEliminarPracticaPlan.TabIndex = 33;
            this.btnEliminarPracticaPlan.Text = "Eliminar practica";
            this.btnEliminarPracticaPlan.UseVisualStyleBackColor = false;
            this.btnEliminarPracticaPlan.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btnAsignarPracticaPlan
            // 
            this.btnAsignarPracticaPlan.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAsignarPracticaPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarPracticaPlan.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAsignarPracticaPlan.Location = new System.Drawing.Point(11, 68);
            this.btnAsignarPracticaPlan.Name = "btnAsignarPracticaPlan";
            this.btnAsignarPracticaPlan.Size = new System.Drawing.Size(148, 32);
            this.btnAsignarPracticaPlan.TabIndex = 34;
            this.btnAsignarPracticaPlan.Text = "Asignar practica";
            this.btnAsignarPracticaPlan.UseVisualStyleBackColor = false;
            this.btnAsignarPracticaPlan.Click += new System.EventHandler(this.btn_asignar_Click);
            // 
            // btnListarPracticas
            // 
            this.btnListarPracticas.Location = new System.Drawing.Point(383, 220);
            this.btnListarPracticas.Name = "btnListarPracticas";
            this.btnListarPracticas.Size = new System.Drawing.Size(169, 41);
            this.btnListarPracticas.TabIndex = 36;
            this.btnListarPracticas.Text = "Listar practicas disponibles";
            this.btnListarPracticas.UseVisualStyleBackColor = true;
            this.btnListarPracticas.Click += new System.EventHandler(this.btn_listar_Click);
            // 
            // txtPlanSeleccionado
            // 
            this.txtPlanSeleccionado.Location = new System.Drawing.Point(14, 315);
            this.txtPlanSeleccionado.Name = "txtPlanSeleccionado";
            this.txtPlanSeleccionado.ReadOnly = true;
            this.txtPlanSeleccionado.Size = new System.Drawing.Size(147, 20);
            this.txtPlanSeleccionado.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "Plan seleccionado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Practica seleccionada";
            // 
            // txtPracticaSeleccionada
            // 
            this.txtPracticaSeleccionada.Location = new System.Drawing.Point(10, 42);
            this.txtPracticaSeleccionada.Name = "txtPracticaSeleccionada";
            this.txtPracticaSeleccionada.ReadOnly = true;
            this.txtPracticaSeleccionada.Size = new System.Drawing.Size(147, 20);
            this.txtPracticaSeleccionada.TabIndex = 40;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtPracticaSeleccionada);
            this.groupBox4.Controls.Add(this.btnAsignarPracticaPlan);
            this.groupBox4.Location = new System.Drawing.Point(371, 294);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(181, 110);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Administrar nueva practica";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Practica seleccionada";
            // 
            // txtPracticaPlan
            // 
            this.txtPracticaPlan.Location = new System.Drawing.Point(17, 41);
            this.txtPracticaPlan.Name = "txtPracticaPlan";
            this.txtPracticaPlan.ReadOnly = true;
            this.txtPracticaPlan.Size = new System.Drawing.Size(147, 20);
            this.txtPracticaPlan.TabIndex = 42;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtPracticaPlan);
            this.groupBox5.Controls.Add(this.btnEliminarPracticaPlan);
            this.groupBox5.Location = new System.Drawing.Point(180, 294);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(185, 110);
            this.groupBox5.TabIndex = 43;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Administrar practica del plan";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(12, 218);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(169, 41);
            this.btnActualizar.TabIndex = 44;
            this.btnActualizar.Text = "Listar planes disponibles";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // AdministrarPracticaPorPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 416);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnListarPracticas);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txtPlanSeleccionado);
            this.Name = "AdministrarPracticaPorPlan";
            this.Text = "AdministrarPracticaPorPlan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEliminarPracticaPlan;
        private System.Windows.Forms.Button btnAsignarPracticaPlan;
        private System.Windows.Forms.ListBox listaPlanes;
        private System.Windows.Forms.ListBox listaPracticasPlan;
        private System.Windows.Forms.ListBox listaPracticas;
        private System.Windows.Forms.Button btnListarPracticas;
        private System.Windows.Forms.TextBox txtPlanSeleccionado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPracticaSeleccionada;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPracticaPlan;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnActualizar;
    }
}