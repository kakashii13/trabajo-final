namespace UI
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicio = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarClave = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.admin = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesPermisos = new System.Windows.Forms.ToolStripMenuItem();
            this.padron = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarAfiliado = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoAfiliados = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarAporte = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAportes = new System.Windows.Forms.ToolStripMenuItem();
            this.autorizaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.crearSolicitud = new System.Windows.Forms.ToolStripMenuItem();
            this.resolverSolicitud = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAutorizaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarFacturas = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarPago = new System.Windows.Forms.ToolStripMenuItem();
            this.prestadores = new System.Windows.Forms.ToolStripMenuItem();
            this.abmPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.abmPracticas = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarPrestador = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarPracticaPorPlan = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarPrestadorPorPractica = new System.Windows.Forms.ToolStripMenuItem();
            this.baseDatos = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacora = new System.Windows.Forms.ToolStripMenuItem();
            this.backup = new System.Windows.Forms.ToolStripMenuItem();
            this.restore = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicio,
            this.admin,
            this.padron,
            this.autorizaciones,
            this.facturacion,
            this.prestadores,
            this.baseDatos,
            this.dashboard});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicio
            // 
            this.inicio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarClave,
            this.cerrarSesion});
            this.inicio.Name = "inicio";
            this.inicio.Size = new System.Drawing.Size(48, 20);
            this.inicio.Text = "Inicio";
            // 
            // cambiarClave
            // 
            this.cambiarClave.Name = "cambiarClave";
            this.cambiarClave.Size = new System.Drawing.Size(149, 22);
            this.cambiarClave.Text = "Cambiar clave";
            this.cambiarClave.Click += new System.EventHandler(this.cambiarClaveToolStripMenuItem_Click);
            // 
            // cerrarSesion
            // 
            this.cerrarSesion.Name = "cerrarSesion";
            this.cerrarSesion.Size = new System.Drawing.Size(149, 22);
            this.cerrarSesion.Text = "Cerrar sesion";
            this.cerrarSesion.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // admin
            // 
            this.admin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarios,
            this.rolesPermisos});
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(55, 20);
            this.admin.Text = "Admin";
            // 
            // usuarios
            // 
            this.usuarios.Name = "usuarios";
            this.usuarios.Size = new System.Drawing.Size(162, 22);
            this.usuarios.Text = "Usuarios";
            this.usuarios.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // rolesPermisos
            // 
            this.rolesPermisos.Name = "rolesPermisos";
            this.rolesPermisos.Size = new System.Drawing.Size(162, 22);
            this.rolesPermisos.Text = "Roles y permisos";
            this.rolesPermisos.Click += new System.EventHandler(this.rolesYPermisosToolStripMenuItem_Click);
            // 
            // padron
            // 
            this.padron.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarAfiliado,
            this.listadoAfiliados,
            this.registrarAporte,
            this.consultarAportes});
            this.padron.Name = "padron";
            this.padron.Size = new System.Drawing.Size(57, 20);
            this.padron.Text = "Padron";
            // 
            // registrarAfiliado
            // 
            this.registrarAfiliado.Name = "registrarAfiliado";
            this.registrarAfiliado.Size = new System.Drawing.Size(167, 22);
            this.registrarAfiliado.Text = "Registrar afiliado";
            this.registrarAfiliado.Click += new System.EventHandler(this.registrarAfiliadoToolStripMenuItem_Click);
            // 
            // listadoAfiliados
            // 
            this.listadoAfiliados.Name = "listadoAfiliados";
            this.listadoAfiliados.Size = new System.Drawing.Size(167, 22);
            this.listadoAfiliados.Text = "Listado afiliados";
            this.listadoAfiliados.Click += new System.EventHandler(this.listadoAfiliados_Click);
            // 
            // registrarAporte
            // 
            this.registrarAporte.Name = "registrarAporte";
            this.registrarAporte.Size = new System.Drawing.Size(167, 22);
            this.registrarAporte.Text = "Registrar aporte";
            this.registrarAporte.Click += new System.EventHandler(this.registrarAporteToolStripMenuItem_Click);
            // 
            // consultarAportes
            // 
            this.consultarAportes.Name = "consultarAportes";
            this.consultarAportes.Size = new System.Drawing.Size(167, 22);
            this.consultarAportes.Text = "Consultar aportes";
            this.consultarAportes.Click += new System.EventHandler(this.consultarAportes_Click);
            // 
            // autorizaciones
            // 
            this.autorizaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearSolicitud,
            this.resolverSolicitud,
            this.consultarAutorizaciones});
            this.autorizaciones.Name = "autorizaciones";
            this.autorizaciones.Size = new System.Drawing.Size(97, 20);
            this.autorizaciones.Text = "Autorizaciones";
            // 
            // crearSolicitud
            // 
            this.crearSolicitud.Name = "crearSolicitud";
            this.crearSolicitud.Size = new System.Drawing.Size(204, 22);
            this.crearSolicitud.Text = "Crear solicitud";
            this.crearSolicitud.Click += new System.EventHandler(this.crearSolicitud_Click);
            // 
            // resolverSolicitud
            // 
            this.resolverSolicitud.Name = "resolverSolicitud";
            this.resolverSolicitud.Size = new System.Drawing.Size(204, 22);
            this.resolverSolicitud.Text = "Resolver solicitud";
            this.resolverSolicitud.Click += new System.EventHandler(this.resolverSolicitud_Click);
            // 
            // consultarAutorizaciones
            // 
            this.consultarAutorizaciones.Name = "consultarAutorizaciones";
            this.consultarAutorizaciones.Size = new System.Drawing.Size(204, 22);
            this.consultarAutorizaciones.Text = "Consultar autorizaciones";
            this.consultarAutorizaciones.Click += new System.EventHandler(this.listarAutorizaciones_Click);
            // 
            // facturacion
            // 
            this.facturacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarFactura,
            this.consultarFacturas,
            this.registrarPago});
            this.facturacion.Name = "facturacion";
            this.facturacion.Size = new System.Drawing.Size(81, 20);
            this.facturacion.Text = "Facturacion";
            // 
            // registrarFactura
            // 
            this.registrarFactura.Name = "registrarFactura";
            this.registrarFactura.Size = new System.Drawing.Size(170, 22);
            this.registrarFactura.Text = "Registrar factura";
            this.registrarFactura.Click += new System.EventHandler(this.registrarFactura_Click);
            // 
            // consultarFacturas
            // 
            this.consultarFacturas.Name = "consultarFacturas";
            this.consultarFacturas.Size = new System.Drawing.Size(170, 22);
            this.consultarFacturas.Text = "Consultar facturas";
            this.consultarFacturas.Click += new System.EventHandler(this.consultarFacturas_Click);
            // 
            // registrarPago
            // 
            this.registrarPago.Name = "registrarPago";
            this.registrarPago.Size = new System.Drawing.Size(170, 22);
            this.registrarPago.Text = "Registrar pago";
            this.registrarPago.Click += new System.EventHandler(this.registrarPago_Click);
            // 
            // prestadores
            // 
            this.prestadores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abmPlanes,
            this.abmPracticas,
            this.registrarPrestador,
            this.administrarPracticaPorPlan,
            this.administrarPrestadorPorPractica});
            this.prestadores.Name = "prestadores";
            this.prestadores.Size = new System.Drawing.Size(139, 20);
            this.prestadores.Text = "Prestadores y practicas";
            // 
            // abmPlanes
            // 
            this.abmPlanes.Name = "abmPlanes";
            this.abmPlanes.Size = new System.Drawing.Size(255, 22);
            this.abmPlanes.Text = "ABM planes";
            this.abmPlanes.Click += new System.EventHandler(this.abmPlanes_Click);
            // 
            // abmPracticas
            // 
            this.abmPracticas.Name = "abmPracticas";
            this.abmPracticas.Size = new System.Drawing.Size(255, 22);
            this.abmPracticas.Text = "ABM practicas";
            this.abmPracticas.Click += new System.EventHandler(this.abmPracticas_Click);
            // 
            // registrarPrestador
            // 
            this.registrarPrestador.Name = "registrarPrestador";
            this.registrarPrestador.Size = new System.Drawing.Size(255, 22);
            this.registrarPrestador.Text = "Registrar prestador";
            this.registrarPrestador.Click += new System.EventHandler(this.registrarPrestador_Click);
            // 
            // administrarPracticaPorPlan
            // 
            this.administrarPracticaPorPlan.Name = "administrarPracticaPorPlan";
            this.administrarPracticaPorPlan.Size = new System.Drawing.Size(255, 22);
            this.administrarPracticaPorPlan.Text = "Administrar practica por plan";
            this.administrarPracticaPorPlan.Click += new System.EventHandler(this.administrarPracticaPorPlan_Click);
            // 
            // administrarPrestadorPorPractica
            // 
            this.administrarPrestadorPorPractica.Name = "administrarPrestadorPorPractica";
            this.administrarPrestadorPorPractica.Size = new System.Drawing.Size(255, 22);
            this.administrarPrestadorPorPractica.Text = "Administrar prestador por practica";
            this.administrarPrestadorPorPractica.Click += new System.EventHandler(this.administrarPrestadorPorPractica_Click);
            // 
            // baseDatos
            // 
            this.baseDatos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitacora,
            this.backup,
            this.restore});
            this.baseDatos.Name = "baseDatos";
            this.baseDatos.Size = new System.Drawing.Size(91, 20);
            this.baseDatos.Text = "Base de datos";
            // 
            // bitacora
            // 
            this.bitacora.Name = "bitacora";
            this.bitacora.Size = new System.Drawing.Size(117, 22);
            this.bitacora.Text = "Bitacora";
            this.bitacora.Click += new System.EventHandler(this.bitacora_Click);
            // 
            // backup
            // 
            this.backup.Name = "backup";
            this.backup.Size = new System.Drawing.Size(117, 22);
            this.backup.Text = "Backup";
            this.backup.Click += new System.EventHandler(this.backup_Click);
            // 
            // restore
            // 
            this.restore.Name = "restore";
            this.restore.Size = new System.Drawing.Size(117, 22);
            this.restore.Text = "Restore";
            this.restore.Click += new System.EventHandler(this.restore_Click);
            // 
            // dashboard
            // 
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(76, 20);
            this.dashboard.Text = "Dashboard";
            this.dashboard.Click += new System.EventHandler(this.dashboard_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 711);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem admin;
        private System.Windows.Forms.ToolStripMenuItem usuarios;
        private System.Windows.Forms.ToolStripMenuItem rolesPermisos;
        private System.Windows.Forms.ToolStripMenuItem padron;
        private System.Windows.Forms.ToolStripMenuItem autorizaciones;
        private System.Windows.Forms.ToolStripMenuItem facturacion;
        private System.Windows.Forms.ToolStripMenuItem inicio;
        private System.Windows.Forms.ToolStripMenuItem cambiarClave;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem prestadores;
        private System.Windows.Forms.ToolStripMenuItem registrarAfiliado;
        private System.Windows.Forms.ToolStripMenuItem listadoAfiliados;
        private System.Windows.Forms.ToolStripMenuItem registrarAporte;
        private System.Windows.Forms.ToolStripMenuItem consultarAportes;
        private System.Windows.Forms.ToolStripMenuItem crearSolicitud;
        private System.Windows.Forms.ToolStripMenuItem resolverSolicitud;
        private System.Windows.Forms.ToolStripMenuItem registrarFactura;
        private System.Windows.Forms.ToolStripMenuItem consultarFacturas;
        private System.Windows.Forms.ToolStripMenuItem registrarPago;
        private System.Windows.Forms.ToolStripMenuItem registrarPrestador;
        private System.Windows.Forms.ToolStripMenuItem administrarPracticaPorPlan;
        private System.Windows.Forms.ToolStripMenuItem administrarPrestadorPorPractica;
        private System.Windows.Forms.ToolStripMenuItem baseDatos;
        private System.Windows.Forms.ToolStripMenuItem bitacora;
        private System.Windows.Forms.ToolStripMenuItem backup;
        private System.Windows.Forms.ToolStripMenuItem restore;
        private System.Windows.Forms.ToolStripMenuItem dashboard;
        private System.Windows.Forms.ToolStripMenuItem abmPlanes;
        private System.Windows.Forms.ToolStripMenuItem abmPracticas;
        private System.Windows.Forms.ToolStripMenuItem consultarAutorizaciones;
    }
}

