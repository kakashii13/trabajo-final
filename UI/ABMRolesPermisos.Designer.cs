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
            this.btnAsignarPermisoRol = new System.Windows.Forms.Button();
            this.btnQuitarPermisoRol = new System.Windows.Forms.Button();
            this.btnEliminarRol = new System.Windows.Forms.Button();
            this.btnModificarRol = new System.Windows.Forms.Button();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.listaRoles = new System.Windows.Forms.ListBox();
            this.btnEliminarPermiso = new System.Windows.Forms.Button();
            this.btnModificarPermiso = new System.Windows.Forms.Button();
            this.btnCrearPermiso = new System.Windows.Forms.Button();
            this.txtPermisoSimple = new System.Windows.Forms.TextBox();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLimpiarPermiso = new System.Windows.Forms.Button();
            this.btnLimpiarRol = new System.Windows.Forms.Button();
            this.btnActualizarListados = new System.Windows.Forms.Button();
            this.listaUsuarios = new System.Windows.Forms.ListBox();
            this.treeUsuarioRolesPermisos = new System.Windows.Forms.TreeView();
            this.btnAsignarRol = new System.Windows.Forms.Button();
            this.btnQuitarRol = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsuarioPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsuarioId = new System.Windows.Forms.TextBox();
            this.checkEncriptacion = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.treePermisosSimples = new System.Windows.Forms.TreeView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.treePermisosRoles = new System.Windows.Forms.TreeView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnQuitarPermisoUsuario = new System.Windows.Forms.Button();
            this.btnAsignarPermisoUsuario = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPermisoUsuarioSeleccionado = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRolUsuarioSeleccionado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPermisoRolSeleccionado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPermisoSeleccionado = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAsignarPermisoRol
            // 
            this.btnAsignarPermisoRol.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAsignarPermisoRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarPermisoRol.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAsignarPermisoRol.Location = new System.Drawing.Point(6, 387);
            this.btnAsignarPermisoRol.Name = "btnAsignarPermisoRol";
            this.btnAsignarPermisoRol.Size = new System.Drawing.Size(230, 32);
            this.btnAsignarPermisoRol.TabIndex = 32;
            this.btnAsignarPermisoRol.Text = "Asignar permiso al rol";
            this.btnAsignarPermisoRol.UseVisualStyleBackColor = false;
            this.btnAsignarPermisoRol.Click += new System.EventHandler(this.attach_permiso_Click);
            // 
            // btnQuitarPermisoRol
            // 
            this.btnQuitarPermisoRol.BackColor = System.Drawing.Color.Brown;
            this.btnQuitarPermisoRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarPermisoRol.ForeColor = System.Drawing.SystemColors.Control;
            this.btnQuitarPermisoRol.Location = new System.Drawing.Point(6, 349);
            this.btnQuitarPermisoRol.Name = "btnQuitarPermisoRol";
            this.btnQuitarPermisoRol.Size = new System.Drawing.Size(230, 32);
            this.btnQuitarPermisoRol.TabIndex = 31;
            this.btnQuitarPermisoRol.Text = "Quitar permiso al rol";
            this.btnQuitarPermisoRol.UseVisualStyleBackColor = false;
            this.btnQuitarPermisoRol.Click += new System.EventHandler(this.remove_permiso_Click);
            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnEliminarRol.Enabled = false;
            this.btnEliminarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarRol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEliminarRol.Location = new System.Drawing.Point(6, 355);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(141, 32);
            this.btnEliminarRol.TabIndex = 29;
            this.btnEliminarRol.Text = "Eliminar";
            this.btnEliminarRol.UseVisualStyleBackColor = false;
            this.btnEliminarRol.Click += new System.EventHandler(this.del_rol_Click);
            // 
            // btnModificarRol
            // 
            this.btnModificarRol.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnModificarRol.Enabled = false;
            this.btnModificarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarRol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnModificarRol.Location = new System.Drawing.Point(6, 317);
            this.btnModificarRol.Name = "btnModificarRol";
            this.btnModificarRol.Size = new System.Drawing.Size(141, 32);
            this.btnModificarRol.TabIndex = 28;
            this.btnModificarRol.Text = "Modificar";
            this.btnModificarRol.UseVisualStyleBackColor = false;
            this.btnModificarRol.Click += new System.EventHandler(this.btn_mod_rol_Click);
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnCrearRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearRol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCrearRol.Location = new System.Drawing.Point(6, 279);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(141, 32);
            this.btnCrearRol.TabIndex = 27;
            this.btnCrearRol.Text = "Crear";
            this.btnCrearRol.UseVisualStyleBackColor = false;
            this.btnCrearRol.Click += new System.EventHandler(this.add_role_Click);
            // 
            // listaRoles
            // 
            this.listaRoles.FormattingEnabled = true;
            this.listaRoles.Location = new System.Drawing.Point(6, 19);
            this.listaRoles.Name = "listaRoles";
            this.listaRoles.Size = new System.Drawing.Size(141, 199);
            this.listaRoles.TabIndex = 26;
            this.listaRoles.SelectedValueChanged += new System.EventHandler(this.list_roles_SelectedValueChanged);
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnEliminarPermiso.Enabled = false;
            this.btnEliminarPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPermiso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEliminarPermiso.Location = new System.Drawing.Point(6, 352);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(223, 32);
            this.btnEliminarPermiso.TabIndex = 24;
            this.btnEliminarPermiso.Text = "Eliminar";
            this.btnEliminarPermiso.UseVisualStyleBackColor = false;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.del_permiso_Click);
            // 
            // btnModificarPermiso
            // 
            this.btnModificarPermiso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnModificarPermiso.Enabled = false;
            this.btnModificarPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarPermiso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnModificarPermiso.Location = new System.Drawing.Point(6, 314);
            this.btnModificarPermiso.Name = "btnModificarPermiso";
            this.btnModificarPermiso.Size = new System.Drawing.Size(223, 32);
            this.btnModificarPermiso.TabIndex = 23;
            this.btnModificarPermiso.Text = "Modificar";
            this.btnModificarPermiso.UseVisualStyleBackColor = false;
            this.btnModificarPermiso.Click += new System.EventHandler(this.mod_permiso_Click);
            // 
            // btnCrearPermiso
            // 
            this.btnCrearPermiso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnCrearPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearPermiso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCrearPermiso.Location = new System.Drawing.Point(6, 276);
            this.btnCrearPermiso.Name = "btnCrearPermiso";
            this.btnCrearPermiso.Size = new System.Drawing.Size(223, 32);
            this.btnCrearPermiso.TabIndex = 22;
            this.btnCrearPermiso.Text = "Crear";
            this.btnCrearPermiso.UseVisualStyleBackColor = false;
            this.btnCrearPermiso.Click += new System.EventHandler(this.add_permiso_Click);
            // 
            // txtPermisoSimple
            // 
            this.txtPermisoSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPermisoSimple.Location = new System.Drawing.Point(6, 250);
            this.txtPermisoSimple.Name = "txtPermisoSimple";
            this.txtPermisoSimple.Size = new System.Drawing.Size(223, 22);
            this.txtPermisoSimple.TabIndex = 37;
            // 
            // txtRol
            // 
            this.txtRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRol.Location = new System.Drawing.Point(6, 253);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(141, 22);
            this.txtRol.TabIndex = 38;
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
            // btnLimpiarPermiso
            // 
            this.btnLimpiarPermiso.BackColor = System.Drawing.Color.SeaGreen;
            this.btnLimpiarPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarPermiso.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiarPermiso.Location = new System.Drawing.Point(6, 390);
            this.btnLimpiarPermiso.Name = "btnLimpiarPermiso";
            this.btnLimpiarPermiso.Size = new System.Drawing.Size(223, 32);
            this.btnLimpiarPermiso.TabIndex = 41;
            this.btnLimpiarPermiso.Text = "Limpiar";
            this.btnLimpiarPermiso.UseVisualStyleBackColor = false;
            this.btnLimpiarPermiso.Click += new System.EventHandler(this.btn_clear_permiso_Click);
            // 
            // btnLimpiarRol
            // 
            this.btnLimpiarRol.BackColor = System.Drawing.Color.SeaGreen;
            this.btnLimpiarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarRol.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiarRol.Location = new System.Drawing.Point(6, 393);
            this.btnLimpiarRol.Name = "btnLimpiarRol";
            this.btnLimpiarRol.Size = new System.Drawing.Size(141, 32);
            this.btnLimpiarRol.TabIndex = 42;
            this.btnLimpiarRol.Text = "Limpiar";
            this.btnLimpiarRol.UseVisualStyleBackColor = false;
            this.btnLimpiarRol.Click += new System.EventHandler(this.btn_clear_rol_Click);
            // 
            // btnActualizarListados
            // 
            this.btnActualizarListados.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnActualizarListados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarListados.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnActualizarListados.Location = new System.Drawing.Point(809, 98);
            this.btnActualizarListados.Name = "btnActualizarListados";
            this.btnActualizarListados.Size = new System.Drawing.Size(193, 32);
            this.btnActualizarListados.TabIndex = 43;
            this.btnActualizarListados.Text = "Actualizar listados";
            this.btnActualizarListados.UseVisualStyleBackColor = false;
            this.btnActualizarListados.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // listaUsuarios
            // 
            this.listaUsuarios.FormattingEnabled = true;
            this.listaUsuarios.Location = new System.Drawing.Point(7, 19);
            this.listaUsuarios.Name = "listaUsuarios";
            this.listaUsuarios.Size = new System.Drawing.Size(120, 199);
            this.listaUsuarios.TabIndex = 45;
            this.listaUsuarios.SelectedValueChanged += new System.EventHandler(this.list_usuarios_SelectedValueChanged);
            // 
            // treeUsuarioRolesPermisos
            // 
            this.treeUsuarioRolesPermisos.Location = new System.Drawing.Point(6, 19);
            this.treeUsuarioRolesPermisos.Name = "treeUsuarioRolesPermisos";
            this.treeUsuarioRolesPermisos.Size = new System.Drawing.Size(179, 324);
            this.treeUsuarioRolesPermisos.TabIndex = 46;
            this.treeUsuarioRolesPermisos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_user_permisos_AfterSelect);
            // 
            // btnAsignarRol
            // 
            this.btnAsignarRol.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAsignarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarRol.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAsignarRol.Location = new System.Drawing.Point(7, 275);
            this.btnAsignarRol.Name = "btnAsignarRol";
            this.btnAsignarRol.Size = new System.Drawing.Size(120, 32);
            this.btnAsignarRol.TabIndex = 48;
            this.btnAsignarRol.Text = "Asignar rol";
            this.btnAsignarRol.UseVisualStyleBackColor = false;
            this.btnAsignarRol.Click += new System.EventHandler(this.btn_asignar_rol_Click);
            // 
            // btnQuitarRol
            // 
            this.btnQuitarRol.BackColor = System.Drawing.Color.Brown;
            this.btnQuitarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarRol.ForeColor = System.Drawing.SystemColors.Control;
            this.btnQuitarRol.Location = new System.Drawing.Point(7, 237);
            this.btnQuitarRol.Name = "btnQuitarRol";
            this.btnQuitarRol.Size = new System.Drawing.Size(120, 32);
            this.btnQuitarRol.TabIndex = 49;
            this.btnQuitarRol.Text = "Quitar rol";
            this.btnQuitarRol.UseVisualStyleBackColor = false;
            this.btnQuitarRol.Click += new System.EventHandler(this.btn_remove_rol_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuario.Location = new System.Drawing.Point(6, 36);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 50;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // txtUsuarioPassword
            // 
            this.txtUsuarioPassword.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuarioPassword.Location = new System.Drawing.Point(6, 80);
            this.txtUsuarioPassword.Name = "txtUsuarioPassword";
            this.txtUsuarioPassword.ReadOnly = true;
            this.txtUsuarioPassword.Size = new System.Drawing.Size(202, 20);
            this.txtUsuarioPassword.TabIndex = 52;
            this.txtUsuarioPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // txtUsuarioId
            // 
            this.txtUsuarioId.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUsuarioId.Location = new System.Drawing.Point(128, 36);
            this.txtUsuarioId.Name = "txtUsuarioId";
            this.txtUsuarioId.ReadOnly = true;
            this.txtUsuarioId.Size = new System.Drawing.Size(100, 20);
            this.txtUsuarioId.TabIndex = 54;
            this.txtUsuarioId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkEncriptacion
            // 
            this.checkEncriptacion.AutoSize = true;
            this.checkEncriptacion.Enabled = false;
            this.checkEncriptacion.Location = new System.Drawing.Point(226, 83);
            this.checkEncriptacion.Name = "checkEncriptacion";
            this.checkEncriptacion.Size = new System.Drawing.Size(137, 17);
            this.checkEncriptacion.TabIndex = 56;
            this.checkEncriptacion.Text = "Encriptar / desencriptar";
            this.checkEncriptacion.UseVisualStyleBackColor = true;
            this.checkEncriptacion.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkEncriptacion);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtUsuarioId);
            this.groupBox1.Controls.Add(this.txtUsuarioPassword);
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
            this.groupBox2.Controls.Add(this.btnQuitarRol);
            this.groupBox2.Controls.Add(this.btnAsignarRol);
            this.groupBox2.Controls.Add(this.listaUsuarios);
            this.groupBox2.Location = new System.Drawing.Point(12, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 311);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuarios";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listaRoles);
            this.groupBox3.Controls.Add(this.btnCrearRol);
            this.groupBox3.Controls.Add(this.btnModificarRol);
            this.groupBox3.Controls.Add(this.btnEliminarRol);
            this.groupBox3.Controls.Add(this.btnLimpiarRol);
            this.groupBox3.Controls.Add(this.txtRol);
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
            this.groupBox4.Controls.Add(this.treePermisosSimples);
            this.groupBox4.Controls.Add(this.btnLimpiarPermiso);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtPermisoSimple);
            this.groupBox4.Controls.Add(this.btnEliminarPermiso);
            this.groupBox4.Controls.Add(this.btnModificarPermiso);
            this.groupBox4.Controls.Add(this.btnCrearPermiso);
            this.groupBox4.Location = new System.Drawing.Point(766, 182);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 434);
            this.groupBox4.TabIndex = 60;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Permisos";
            // 
            // treePermisosSimples
            // 
            this.treePermisosSimples.Location = new System.Drawing.Point(6, 19);
            this.treePermisosSimples.Name = "treePermisosSimples";
            this.treePermisosSimples.Size = new System.Drawing.Size(223, 210);
            this.treePermisosSimples.TabIndex = 63;
            this.treePermisosSimples.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_permisos_AfterSelect);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.treePermisosRoles);
            this.groupBox5.Controls.Add(this.btnQuitarPermisoRol);
            this.groupBox5.Controls.Add(this.btnAsignarPermisoRol);
            this.groupBox5.Location = new System.Drawing.Point(518, 180);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(242, 436);
            this.groupBox5.TabIndex = 61;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Permisos por rol";
            // 
            // treePermisosRoles
            // 
            this.treePermisosRoles.Location = new System.Drawing.Point(6, 19);
            this.treePermisosRoles.Name = "treePermisosRoles";
            this.treePermisosRoles.Size = new System.Drawing.Size(230, 324);
            this.treePermisosRoles.TabIndex = 63;
            this.treePermisosRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_permisos_roles_AfterSelect);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnQuitarPermisoUsuario);
            this.groupBox6.Controls.Add(this.btnAsignarPermisoUsuario);
            this.groupBox6.Controls.Add(this.treeUsuarioRolesPermisos);
            this.groupBox6.Location = new System.Drawing.Point(161, 182);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(192, 434);
            this.groupBox6.TabIndex = 62;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Roles y permisos del usuario";
            // 
            // btnQuitarPermisoUsuario
            // 
            this.btnQuitarPermisoUsuario.BackColor = System.Drawing.Color.Brown;
            this.btnQuitarPermisoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarPermisoUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.btnQuitarPermisoUsuario.Location = new System.Drawing.Point(6, 349);
            this.btnQuitarPermisoUsuario.Name = "btnQuitarPermisoUsuario";
            this.btnQuitarPermisoUsuario.Size = new System.Drawing.Size(180, 32);
            this.btnQuitarPermisoUsuario.TabIndex = 64;
            this.btnQuitarPermisoUsuario.Text = "Quitar permiso al usuario";
            this.btnQuitarPermisoUsuario.UseVisualStyleBackColor = false;
            this.btnQuitarPermisoUsuario.Click += new System.EventHandler(this.btn_quitar_permiso_user_Click);
            // 
            // btnAsignarPermisoUsuario
            // 
            this.btnAsignarPermisoUsuario.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAsignarPermisoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarPermisoUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAsignarPermisoUsuario.Location = new System.Drawing.Point(6, 387);
            this.btnAsignarPermisoUsuario.Name = "btnAsignarPermisoUsuario";
            this.btnAsignarPermisoUsuario.Size = new System.Drawing.Size(180, 32);
            this.btnAsignarPermisoUsuario.TabIndex = 64;
            this.btnAsignarPermisoUsuario.Text = "Asignar permiso al usuario";
            this.btnAsignarPermisoUsuario.UseVisualStyleBackColor = false;
            this.btnAsignarPermisoUsuario.Click += new System.EventHandler(this.btn_asignar_permiso_user_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.txtPermisoUsuarioSeleccionado);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.txtRolUsuarioSeleccionado);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.txtPermisoRolSeleccionado);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.txtPermisoSeleccionado);
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
            // txtPermisoUsuarioSeleccionado
            // 
            this.txtPermisoUsuarioSeleccionado.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtPermisoUsuarioSeleccionado.Location = new System.Drawing.Point(213, 80);
            this.txtPermisoUsuarioSeleccionado.Name = "txtPermisoUsuarioSeleccionado";
            this.txtPermisoUsuarioSeleccionado.ReadOnly = true;
            this.txtPermisoUsuarioSeleccionado.Size = new System.Drawing.Size(153, 20);
            this.txtPermisoUsuarioSeleccionado.TabIndex = 65;
            this.txtPermisoUsuarioSeleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // txtRolUsuarioSeleccionado
            // 
            this.txtRolUsuarioSeleccionado.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtRolUsuarioSeleccionado.Location = new System.Drawing.Point(8, 80);
            this.txtRolUsuarioSeleccionado.Name = "txtRolUsuarioSeleccionado";
            this.txtRolUsuarioSeleccionado.ReadOnly = true;
            this.txtRolUsuarioSeleccionado.Size = new System.Drawing.Size(190, 20);
            this.txtRolUsuarioSeleccionado.TabIndex = 63;
            this.txtRolUsuarioSeleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // txtPermisoRolSeleccionado
            // 
            this.txtPermisoRolSeleccionado.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtPermisoRolSeleccionado.Location = new System.Drawing.Point(213, 36);
            this.txtPermisoRolSeleccionado.Name = "txtPermisoRolSeleccionado";
            this.txtPermisoRolSeleccionado.ReadOnly = true;
            this.txtPermisoRolSeleccionado.Size = new System.Drawing.Size(153, 20);
            this.txtPermisoRolSeleccionado.TabIndex = 61;
            this.txtPermisoRolSeleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // txtPermisoSeleccionado
            // 
            this.txtPermisoSeleccionado.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtPermisoSeleccionado.Location = new System.Drawing.Point(9, 36);
            this.txtPermisoSeleccionado.Name = "txtPermisoSeleccionado";
            this.txtPermisoSeleccionado.ReadOnly = true;
            this.txtPermisoSeleccionado.Size = new System.Drawing.Size(189, 20);
            this.txtPermisoSeleccionado.TabIndex = 59;
            this.txtPermisoSeleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ABMRolesPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 626);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnActualizarListados);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Name = "ABMRolesPermisos";
            this.Text = " ";
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
        private System.Windows.Forms.Button btnAsignarPermisoRol;
        private System.Windows.Forms.Button btnQuitarPermisoRol;
        private System.Windows.Forms.Button btnEliminarRol;
        private System.Windows.Forms.Button btnModificarRol;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.ListBox listaRoles;
        private System.Windows.Forms.Button btnEliminarPermiso;
        private System.Windows.Forms.Button btnModificarPermiso;
        private System.Windows.Forms.Button btnCrearPermiso;
        private System.Windows.Forms.TextBox txtPermisoSimple;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLimpiarPermiso;
        private System.Windows.Forms.Button btnLimpiarRol;
        private System.Windows.Forms.Button btnActualizarListados;
        private System.Windows.Forms.ListBox listaUsuarios;
        private System.Windows.Forms.TreeView treeUsuarioRolesPermisos;
        private System.Windows.Forms.Button btnAsignarRol;
        private System.Windows.Forms.Button btnQuitarRol;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsuarioPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUsuarioId;
        private System.Windows.Forms.CheckBox checkEncriptacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TreeView treePermisosSimples;
        private System.Windows.Forms.TreeView treePermisosRoles;
        private System.Windows.Forms.Button btnQuitarPermisoUsuario;
        private System.Windows.Forms.Button btnAsignarPermisoUsuario;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPermisoSeleccionado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPermisoUsuarioSeleccionado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRolUsuarioSeleccionado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPermisoRolSeleccionado;
    }
}