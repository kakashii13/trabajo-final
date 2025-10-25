namespace UI
{
    partial class ABMRolesPermisos
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
            this.btn_asignar_permiso_rol = new System.Windows.Forms.Button();
            this.btn_quitar_permiso_rol = new System.Windows.Forms.Button();
            this.btn_del_rol = new System.Windows.Forms.Button();
            this.btn_mod_rol = new System.Windows.Forms.Button();
            this.btn_crear_role = new System.Windows.Forms.Button();
            this.list_roles = new System.Windows.Forms.ListBox();
            this.btn_del_permiso = new System.Windows.Forms.Button();
            this.btn_mod_permiso = new System.Windows.Forms.Button();
            this.btn_crear_permiso = new System.Windows.Forms.Button();
            this.txt_permiso = new System.Windows.Forms.TextBox();
            this.txt_role = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_limpiar_permiso = new System.Windows.Forms.Button();
            this.btn_limpiar_rol = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.list_usuarios = new System.Windows.Forms.ListBox();
            this.tree_user_permisos = new System.Windows.Forms.TreeView();
            this.btn_asignar_rol = new System.Windows.Forms.Button();
            this.btn_quitar_rol = new System.Windows.Forms.Button();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.check_encriptacion = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tree_permisos = new System.Windows.Forms.TreeView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tree_permisos_roles = new System.Windows.Forms.TreeView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_quitar_permiso_user = new System.Windows.Forms.Button();
            this.btn_asignar_permiso_user = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_permiso_usuario_seleccionado = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_rol_usuario_seleccionado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_permiso_rol_seleccionado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_permiso_seleccionado = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_asignar_permiso_rol
            // 
            this.btn_asignar_permiso_rol.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_asignar_permiso_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_asignar_permiso_rol.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_asignar_permiso_rol.Location = new System.Drawing.Point(6, 387);
            this.btn_asignar_permiso_rol.Name = "btn_asignar_permiso_rol";
            this.btn_asignar_permiso_rol.Size = new System.Drawing.Size(230, 32);
            this.btn_asignar_permiso_rol.TabIndex = 32;
            this.btn_asignar_permiso_rol.Text = "Asignar permiso al rol";
            this.btn_asignar_permiso_rol.UseVisualStyleBackColor = false;
            this.btn_asignar_permiso_rol.Click += new System.EventHandler(this.attach_permiso_Click);
            // 
            // btn_quitar_permiso_rol
            // 
            this.btn_quitar_permiso_rol.BackColor = System.Drawing.Color.Brown;
            this.btn_quitar_permiso_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quitar_permiso_rol.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_quitar_permiso_rol.Location = new System.Drawing.Point(6, 349);
            this.btn_quitar_permiso_rol.Name = "btn_quitar_permiso_rol";
            this.btn_quitar_permiso_rol.Size = new System.Drawing.Size(230, 32);
            this.btn_quitar_permiso_rol.TabIndex = 31;
            this.btn_quitar_permiso_rol.Text = "Quitar permiso al rol";
            this.btn_quitar_permiso_rol.UseVisualStyleBackColor = false;
            this.btn_quitar_permiso_rol.Click += new System.EventHandler(this.remove_permiso_Click);
            // 
            // btn_del_rol
            // 
            this.btn_del_rol.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_del_rol.Enabled = false;
            this.btn_del_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del_rol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_del_rol.Location = new System.Drawing.Point(6, 355);
            this.btn_del_rol.Name = "btn_del_rol";
            this.btn_del_rol.Size = new System.Drawing.Size(141, 32);
            this.btn_del_rol.TabIndex = 29;
            this.btn_del_rol.Text = "Eliminar";
            this.btn_del_rol.UseVisualStyleBackColor = false;
            this.btn_del_rol.Click += new System.EventHandler(this.del_rol_Click);
            // 
            // btn_mod_rol
            // 
            this.btn_mod_rol.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_mod_rol.Enabled = false;
            this.btn_mod_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mod_rol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_mod_rol.Location = new System.Drawing.Point(6, 317);
            this.btn_mod_rol.Name = "btn_mod_rol";
            this.btn_mod_rol.Size = new System.Drawing.Size(141, 32);
            this.btn_mod_rol.TabIndex = 28;
            this.btn_mod_rol.Text = "Modificar";
            this.btn_mod_rol.UseVisualStyleBackColor = false;
            this.btn_mod_rol.Click += new System.EventHandler(this.btn_mod_rol_Click);
            // 
            // btn_crear_role
            // 
            this.btn_crear_role.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_crear_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_crear_role.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_crear_role.Location = new System.Drawing.Point(6, 279);
            this.btn_crear_role.Name = "btn_crear_role";
            this.btn_crear_role.Size = new System.Drawing.Size(141, 32);
            this.btn_crear_role.TabIndex = 27;
            this.btn_crear_role.Text = "Crear";
            this.btn_crear_role.UseVisualStyleBackColor = false;
            this.btn_crear_role.Click += new System.EventHandler(this.add_role_Click);
            // 
            // list_roles
            // 
            this.list_roles.FormattingEnabled = true;
            this.list_roles.Location = new System.Drawing.Point(6, 19);
            this.list_roles.Name = "list_roles";
            this.list_roles.Size = new System.Drawing.Size(141, 199);
            this.list_roles.TabIndex = 26;
            this.list_roles.SelectedValueChanged += new System.EventHandler(this.list_roles_SelectedValueChanged);
            // 
            // btn_del_permiso
            // 
            this.btn_del_permiso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_del_permiso.Enabled = false;
            this.btn_del_permiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del_permiso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_del_permiso.Location = new System.Drawing.Point(6, 352);
            this.btn_del_permiso.Name = "btn_del_permiso";
            this.btn_del_permiso.Size = new System.Drawing.Size(223, 32);
            this.btn_del_permiso.TabIndex = 24;
            this.btn_del_permiso.Text = "Eliminar";
            this.btn_del_permiso.UseVisualStyleBackColor = false;
            this.btn_del_permiso.Click += new System.EventHandler(this.del_permiso_Click);
            // 
            // btn_mod_permiso
            // 
            this.btn_mod_permiso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_mod_permiso.Enabled = false;
            this.btn_mod_permiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mod_permiso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_mod_permiso.Location = new System.Drawing.Point(6, 314);
            this.btn_mod_permiso.Name = "btn_mod_permiso";
            this.btn_mod_permiso.Size = new System.Drawing.Size(223, 32);
            this.btn_mod_permiso.TabIndex = 23;
            this.btn_mod_permiso.Text = "Modificar";
            this.btn_mod_permiso.UseVisualStyleBackColor = false;
            this.btn_mod_permiso.Click += new System.EventHandler(this.mod_permiso_Click);
            // 
            // btn_crear_permiso
            // 
            this.btn_crear_permiso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_crear_permiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_crear_permiso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_crear_permiso.Location = new System.Drawing.Point(6, 276);
            this.btn_crear_permiso.Name = "btn_crear_permiso";
            this.btn_crear_permiso.Size = new System.Drawing.Size(223, 32);
            this.btn_crear_permiso.TabIndex = 22;
            this.btn_crear_permiso.Text = "Crear";
            this.btn_crear_permiso.UseVisualStyleBackColor = false;
            this.btn_crear_permiso.Click += new System.EventHandler(this.add_permiso_Click);
            // 
            // txt_permiso
            // 
            this.txt_permiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_permiso.Location = new System.Drawing.Point(6, 250);
            this.txt_permiso.Name = "txt_permiso";
            this.txt_permiso.Size = new System.Drawing.Size(223, 22);
            this.txt_permiso.TabIndex = 37;
            // 
            // txt_role
            // 
            this.txt_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_role.Location = new System.Drawing.Point(6, 253);
            this.txt_role.Name = "txt_role";
            this.txt_role.Size = new System.Drawing.Size(141, 22);
            this.txt_role.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(91, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Permiso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "Rol";
            // 
            // btn_limpiar_permiso
            // 
            this.btn_limpiar_permiso.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_limpiar_permiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_limpiar_permiso.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_limpiar_permiso.Location = new System.Drawing.Point(6, 390);
            this.btn_limpiar_permiso.Name = "btn_limpiar_permiso";
            this.btn_limpiar_permiso.Size = new System.Drawing.Size(223, 32);
            this.btn_limpiar_permiso.TabIndex = 41;
            this.btn_limpiar_permiso.Text = "Limpiar";
            this.btn_limpiar_permiso.UseVisualStyleBackColor = false;
            this.btn_limpiar_permiso.Click += new System.EventHandler(this.btn_clear_permiso_Click);
            // 
            // btn_limpiar_rol
            // 
            this.btn_limpiar_rol.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_limpiar_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_limpiar_rol.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_limpiar_rol.Location = new System.Drawing.Point(6, 393);
            this.btn_limpiar_rol.Name = "btn_limpiar_rol";
            this.btn_limpiar_rol.Size = new System.Drawing.Size(141, 32);
            this.btn_limpiar_rol.TabIndex = 42;
            this.btn_limpiar_rol.Text = "Limpiar";
            this.btn_limpiar_rol.UseVisualStyleBackColor = false;
            this.btn_limpiar_rol.Click += new System.EventHandler(this.btn_clear_rol_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_update.Location = new System.Drawing.Point(809, 98);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(193, 32);
            this.btn_update.TabIndex = 43;
            this.btn_update.Text = "Actualizar listados";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // list_usuarios
            // 
            this.list_usuarios.FormattingEnabled = true;
            this.list_usuarios.Location = new System.Drawing.Point(7, 19);
            this.list_usuarios.Name = "list_usuarios";
            this.list_usuarios.Size = new System.Drawing.Size(120, 199);
            this.list_usuarios.TabIndex = 45;
            this.list_usuarios.SelectedValueChanged += new System.EventHandler(this.list_usuarios_SelectedValueChanged);
            // 
            // tree_user_permisos
            // 
            this.tree_user_permisos.Location = new System.Drawing.Point(6, 19);
            this.tree_user_permisos.Name = "tree_user_permisos";
            this.tree_user_permisos.Size = new System.Drawing.Size(179, 324);
            this.tree_user_permisos.TabIndex = 46;
            this.tree_user_permisos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_user_permisos_AfterSelect);
            // 
            // btn_asignar_rol
            // 
            this.btn_asignar_rol.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_asignar_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_asignar_rol.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_asignar_rol.Location = new System.Drawing.Point(7, 275);
            this.btn_asignar_rol.Name = "btn_asignar_rol";
            this.btn_asignar_rol.Size = new System.Drawing.Size(120, 32);
            this.btn_asignar_rol.TabIndex = 48;
            this.btn_asignar_rol.Text = "Asignar rol";
            this.btn_asignar_rol.UseVisualStyleBackColor = false;
            this.btn_asignar_rol.Click += new System.EventHandler(this.btn_asignar_rol_Click);
            // 
            // btn_quitar_rol
            // 
            this.btn_quitar_rol.BackColor = System.Drawing.Color.Brown;
            this.btn_quitar_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quitar_rol.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_quitar_rol.Location = new System.Drawing.Point(7, 237);
            this.btn_quitar_rol.Name = "btn_quitar_rol";
            this.btn_quitar_rol.Size = new System.Drawing.Size(120, 32);
            this.btn_quitar_rol.TabIndex = 49;
            this.btn_quitar_rol.Text = "Quitar rol";
            this.btn_quitar_rol.UseVisualStyleBackColor = false;
            this.btn_quitar_rol.Click += new System.EventHandler(this.btn_remove_rol_Click);
            // 
            // txt_usuario
            // 
            this.txt_usuario.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_usuario.Location = new System.Drawing.Point(6, 36);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.ReadOnly = true;
            this.txt_usuario.Size = new System.Drawing.Size(100, 20);
            this.txt_usuario.TabIndex = 50;
            this.txt_usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Nombre usuario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Password";
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_password.Location = new System.Drawing.Point(6, 80);
            this.txt_password.Name = "txt_password";
            this.txt_password.ReadOnly = true;
            this.txt_password.Size = new System.Drawing.Size(202, 20);
            this.txt_password.TabIndex = 52;
            this.txt_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "ID";
            // 
            // txt_id
            // 
            this.txt_id.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_id.Location = new System.Drawing.Point(128, 36);
            this.txt_id.Name = "txt_id";
            this.txt_id.ReadOnly = true;
            this.txt_id.Size = new System.Drawing.Size(100, 20);
            this.txt_id.TabIndex = 54;
            this.txt_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // check_encriptacion
            // 
            this.check_encriptacion.AutoSize = true;
            this.check_encriptacion.Enabled = false;
            this.check_encriptacion.Location = new System.Drawing.Point(226, 83);
            this.check_encriptacion.Name = "check_encriptacion";
            this.check_encriptacion.Size = new System.Drawing.Size(137, 17);
            this.check_encriptacion.TabIndex = 56;
            this.check_encriptacion.Text = "Encriptar / desencriptar";
            this.check_encriptacion.UseVisualStyleBackColor = true;
            this.check_encriptacion.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.check_encriptacion);
            this.groupBox1.Controls.Add(this.txt_usuario);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_id);
            this.groupBox1.Controls.Add(this.txt_password);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 119);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario seleccionado";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_quitar_rol);
            this.groupBox2.Controls.Add(this.btn_asignar_rol);
            this.groupBox2.Controls.Add(this.list_usuarios);
            this.groupBox2.Location = new System.Drawing.Point(12, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 311);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuarios";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.list_roles);
            this.groupBox3.Controls.Add(this.btn_crear_role);
            this.groupBox3.Controls.Add(this.btn_mod_rol);
            this.groupBox3.Controls.Add(this.btn_del_rol);
            this.groupBox3.Controls.Add(this.btn_limpiar_rol);
            this.groupBox3.Controls.Add(this.txt_role);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(359, 180);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(153, 436);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Roles";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tree_permisos);
            this.groupBox4.Controls.Add(this.btn_limpiar_permiso);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txt_permiso);
            this.groupBox4.Controls.Add(this.btn_del_permiso);
            this.groupBox4.Controls.Add(this.btn_mod_permiso);
            this.groupBox4.Controls.Add(this.btn_crear_permiso);
            this.groupBox4.Location = new System.Drawing.Point(766, 182);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 434);
            this.groupBox4.TabIndex = 60;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Permisos";
            // 
            // tree_permisos
            // 
            this.tree_permisos.Location = new System.Drawing.Point(6, 19);
            this.tree_permisos.Name = "tree_permisos";
            this.tree_permisos.Size = new System.Drawing.Size(223, 210);
            this.tree_permisos.TabIndex = 63;
            this.tree_permisos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_permisos_AfterSelect);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tree_permisos_roles);
            this.groupBox5.Controls.Add(this.btn_quitar_permiso_rol);
            this.groupBox5.Controls.Add(this.btn_asignar_permiso_rol);
            this.groupBox5.Location = new System.Drawing.Point(518, 180);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(242, 436);
            this.groupBox5.TabIndex = 61;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Permisos por rol";
            // 
            // tree_permisos_roles
            // 
            this.tree_permisos_roles.Location = new System.Drawing.Point(6, 19);
            this.tree_permisos_roles.Name = "tree_permisos_roles";
            this.tree_permisos_roles.Size = new System.Drawing.Size(230, 324);
            this.tree_permisos_roles.TabIndex = 63;
            this.tree_permisos_roles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_permisos_roles_AfterSelect);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_quitar_permiso_user);
            this.groupBox6.Controls.Add(this.btn_asignar_permiso_user);
            this.groupBox6.Controls.Add(this.tree_user_permisos);
            this.groupBox6.Location = new System.Drawing.Point(161, 182);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(192, 434);
            this.groupBox6.TabIndex = 62;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Roles y permisos del usuario";
            // 
            // btn_quitar_permiso_user
            // 
            this.btn_quitar_permiso_user.BackColor = System.Drawing.Color.Brown;
            this.btn_quitar_permiso_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quitar_permiso_user.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_quitar_permiso_user.Location = new System.Drawing.Point(6, 349);
            this.btn_quitar_permiso_user.Name = "btn_quitar_permiso_user";
            this.btn_quitar_permiso_user.Size = new System.Drawing.Size(180, 32);
            this.btn_quitar_permiso_user.TabIndex = 64;
            this.btn_quitar_permiso_user.Text = "Quitar permiso al usuario";
            this.btn_quitar_permiso_user.UseVisualStyleBackColor = false;
            this.btn_quitar_permiso_user.Click += new System.EventHandler(this.btn_quitar_permiso_user_Click);
            // 
            // btn_asignar_permiso_user
            // 
            this.btn_asignar_permiso_user.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_asignar_permiso_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_asignar_permiso_user.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_asignar_permiso_user.Location = new System.Drawing.Point(6, 387);
            this.btn_asignar_permiso_user.Name = "btn_asignar_permiso_user";
            this.btn_asignar_permiso_user.Size = new System.Drawing.Size(180, 32);
            this.btn_asignar_permiso_user.TabIndex = 64;
            this.btn_asignar_permiso_user.Text = "Asignar permiso al usuario";
            this.btn_asignar_permiso_user.UseVisualStyleBackColor = false;
            this.btn_asignar_permiso_user.Click += new System.EventHandler(this.btn_asignar_permiso_user_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.txt_permiso_usuario_seleccionado);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.txt_rol_usuario_seleccionado);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.txt_permiso_rol_seleccionado);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.txt_permiso_seleccionado);
            this.groupBox7.Location = new System.Drawing.Point(414, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.groupBox7.Size = new System.Drawing.Size(389, 118);
            this.groupBox7.TabIndex = 63;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Datos seleccionados";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(212, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "Permiso de usuario seleccionado";
            // 
            // txt_permiso_usuario_seleccionado
            // 
            this.txt_permiso_usuario_seleccionado.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_permiso_usuario_seleccionado.Location = new System.Drawing.Point(213, 80);
            this.txt_permiso_usuario_seleccionado.Name = "txt_permiso_usuario_seleccionado";
            this.txt_permiso_usuario_seleccionado.ReadOnly = true;
            this.txt_permiso_usuario_seleccionado.Size = new System.Drawing.Size(153, 20);
            this.txt_permiso_usuario_seleccionado.TabIndex = 65;
            this.txt_permiso_usuario_seleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "Rol de usuario seleccionado";
            // 
            // txt_rol_usuario_seleccionado
            // 
            this.txt_rol_usuario_seleccionado.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_rol_usuario_seleccionado.Location = new System.Drawing.Point(8, 80);
            this.txt_rol_usuario_seleccionado.Name = "txt_rol_usuario_seleccionado";
            this.txt_rol_usuario_seleccionado.ReadOnly = true;
            this.txt_rol_usuario_seleccionado.Size = new System.Drawing.Size(190, 20);
            this.txt_rol_usuario_seleccionado.TabIndex = 63;
            this.txt_rol_usuario_seleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(212, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Permiso de rol seleccionado";
            // 
            // txt_permiso_rol_seleccionado
            // 
            this.txt_permiso_rol_seleccionado.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_permiso_rol_seleccionado.Location = new System.Drawing.Point(213, 36);
            this.txt_permiso_rol_seleccionado.Name = "txt_permiso_rol_seleccionado";
            this.txt_permiso_rol_seleccionado.ReadOnly = true;
            this.txt_permiso_rol_seleccionado.Size = new System.Drawing.Size(153, 20);
            this.txt_permiso_rol_seleccionado.TabIndex = 61;
            this.txt_permiso_rol_seleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Permiso seleccionado";
            // 
            // txt_permiso_seleccionado
            // 
            this.txt_permiso_seleccionado.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txt_permiso_seleccionado.Location = new System.Drawing.Point(9, 36);
            this.txt_permiso_seleccionado.Name = "txt_permiso_seleccionado";
            this.txt_permiso_seleccionado.ReadOnly = true;
            this.txt_permiso_seleccionado.Size = new System.Drawing.Size(189, 20);
            this.txt_permiso_seleccionado.TabIndex = 59;
            this.txt_permiso_seleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ABMRolesPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 626);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Name = "ABMRolesPermisos";
            this.Text = " ";
            this.Load += new System.EventHandler(this.ABMRolesPermisos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_asignar_permiso_rol;
        private System.Windows.Forms.Button btn_quitar_permiso_rol;
        private System.Windows.Forms.Button btn_del_rol;
        private System.Windows.Forms.Button btn_mod_rol;
        private System.Windows.Forms.Button btn_crear_role;
        private System.Windows.Forms.ListBox list_roles;
        private System.Windows.Forms.Button btn_del_permiso;
        private System.Windows.Forms.Button btn_mod_permiso;
        private System.Windows.Forms.Button btn_crear_permiso;
        private System.Windows.Forms.TextBox txt_permiso;
        private System.Windows.Forms.TextBox txt_role;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_limpiar_permiso;
        private System.Windows.Forms.Button btn_limpiar_rol;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.ListBox list_usuarios;
        private System.Windows.Forms.TreeView tree_user_permisos;
        private System.Windows.Forms.Button btn_asignar_rol;
        private System.Windows.Forms.Button btn_quitar_rol;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.CheckBox check_encriptacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TreeView tree_permisos;
        private System.Windows.Forms.TreeView tree_permisos_roles;
        private System.Windows.Forms.Button btn_quitar_permiso_user;
        private System.Windows.Forms.Button btn_asignar_permiso_user;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_permiso_seleccionado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_permiso_usuario_seleccionado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_rol_usuario_seleccionado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_permiso_rol_seleccionado;
    }
}