using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios;

namespace UI
{
    public partial class Menu : Form
    {
        BEUsuario usuarioLogueado;
        BLLUsuario bllUsuario;
        List<BEPermiso> permisosUsuario;
        public Menu(BEUsuario usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;

            bllUsuario = new BLLUsuario();

            ConfigurarMenu();
        }
        private void ConfigurarMenu()
        {
            try
            {
                permisosUsuario = bllUsuario.ListarPermisosDeUsuario(usuarioLogueado);

                AplanarPermisos(permisosUsuario);

                OcultarTodosLosItemsDelMenu(menuStrip1.Items);
                MostrarItemsSegunPermisos(menuStrip1.Items, permisosUsuario);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AplanarPermisos(List<BEPermiso> permisos)
        {
            var permisosACopiar = permisos.ToList();

            foreach (BEPermiso permiso in permisosACopiar)
            {
                if (permiso is BEPermisoSimple permisoSimple)
                {
                    if (!permisosUsuario.Any(p => p.Id == permisoSimple.Id))
                    {
                        permisosUsuario.Add(permisoSimple);
                    }
                }
                else if (permiso is BEPermiso rol)
                {
                    AplanarPermisos(rol.ObtenerPermisos());
                }
            }
        }
        private void OcultarTodosLosItemsDelMenu(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item.Name == "inicio")
                {
                    continue;
                }

                if (item is ToolStripMenuItem subMenuItem)
                {
                    subMenuItem.Visible = false;

                    if (subMenuItem.DropDownItems.Count > 0)
                    {
                        OcultarTodosLosItemsDelMenu(subMenuItem.DropDownItems);
                    }
                }
            }
        }
        private void MostrarItemsSegunPermisos(ToolStripItemCollection items, List<BEPermiso> permisosUsuario)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    if (menuItem.DropDownItems.Count > 0)
                    {
                        MostrarSubItemsSegunPermisos(menuItem, permisosUsuario);
                    }

                    if (TienePermiso(menuItem.Name, permisosUsuario))
                    {
                        menuItem.Visible = true;
                    }
                }
            }
        }
        private void MostrarSubItemsSegunPermisos(ToolStripMenuItem menuItem, List<BEPermiso> permisosUsuario)
        {
            bool algunSubItemVisible = false;

            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    if (subMenuItem.DropDownItems.Count > 0)
                    {
                        MostrarSubItemsSegunPermisos(subMenuItem, permisosUsuario);
                    }

                    if (TienePermiso(subMenuItem.Name, permisosUsuario))
                    {
                        subMenuItem.Visible = true;
                        algunSubItemVisible = true;
                    }
                }
            }

            if (algunSubItemVisible)
            {
                menuItem.Visible = true;
            }
        }
        private bool TienePermiso(string nombreItem, List<BEPermiso> permisosUsuario)
        {
            return permisosUsuario.Any(permiso =>
            {
                string nombrePermiso = permiso.Nombre.Contains(".")
                    ? permiso.Nombre.Split('.')[1]
                    : permiso.Nombre;

                return nombrePermiso.Equals(nombreItem, StringComparison.OrdinalIgnoreCase);
            });
        }
        private void rolesYPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMRolesPermisos ABM = new ABMRolesPermisos();
            ABM.MdiParent = this;
            ABM.WindowState = FormWindowState.Maximized;
            ABM.Show();
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ABMUsuarios ABM = new ABMUsuarios();
            ABM.MdiParent = this;
            ABM.WindowState = FormWindowState.Maximized;
            ABM.Show();
        }
        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarClave cambiarClave = new CambiarClave(usuarioLogueado);
            cambiarClave.MdiParent = this;
            cambiarClave.WindowState = FormWindowState.Maximized;
            cambiarClave.Show();
        }
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }
        private void registrarAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarAfiliado registrarAfiliado = new RegistrarAfiliado();
            registrarAfiliado.MdiParent = this;
            registrarAfiliado.WindowState = FormWindowState.Maximized;
            registrarAfiliado.Show();
        }
        private void registrarAporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarAporte registrarAporte = new RegistrarAporte();
            registrarAporte.MdiParent = this;
            registrarAporte.WindowState = FormWindowState.Maximized;
            registrarAporte.Show();
        }
        private void listadoAfiliados_Click(object sender, EventArgs e)
        {
            ABMAfiliados listadoAfiliados = new ABMAfiliados();
            listadoAfiliados.MdiParent = this;
            listadoAfiliados.WindowState = FormWindowState.Maximized;
            listadoAfiliados.Show();
        }
        private void consultarAportes_Click(object sender, EventArgs e)
        {
            ConsultarAportes consultarAportes = new ConsultarAportes();
            consultarAportes.MdiParent = this;
            consultarAportes.WindowState = FormWindowState.Maximized;
            consultarAportes.Show();
        }
        private void registrarPrestador_Click(object sender, EventArgs e)
        {
            RegistrarPrestador registrarPrestador = new RegistrarPrestador();
            registrarPrestador.MdiParent = this;
            registrarPrestador.WindowState = FormWindowState.Maximized;
            registrarPrestador.Show();
        }
        private void administrarPracticaPorPlan_Click(object sender, EventArgs e)
        {
            AdministrarPracticaPorPlan administrarPracticaPorPlan = new AdministrarPracticaPorPlan();
            administrarPracticaPorPlan.MdiParent = this;
            administrarPracticaPorPlan.WindowState = FormWindowState.Maximized;
            administrarPracticaPorPlan.Show();
        }
        private void abmPlanes_Click(object sender, EventArgs e)
        {
            ABMPlanes abmPlanes = new ABMPlanes();
            abmPlanes.MdiParent = this;
            abmPlanes.WindowState = FormWindowState.Maximized;
            abmPlanes.Show();
        }
        private void abmPracticas_Click(object sender, EventArgs e)
        {
            ABMPracticas abmPracticas = new ABMPracticas();
            abmPracticas.MdiParent = this;
            abmPracticas.WindowState = FormWindowState.Maximized;
            abmPracticas.Show();
        }
        private void administrarPrestadorPorPractica_Click(object sender, EventArgs e)
        {
            AdministrarPrestadorPorPractica administrarPrestadorPorPractica = new AdministrarPrestadorPorPractica();
            administrarPrestadorPorPractica.MdiParent = this;
            administrarPrestadorPorPractica.WindowState = FormWindowState.Maximized;
            administrarPrestadorPorPractica.Show();
        }
        private void crearSolicitud_Click(object sender, EventArgs e)
        {
            CrearSolicitud crearSolicitud = new CrearSolicitud();
            crearSolicitud.MdiParent = this;
            crearSolicitud.WindowState = FormWindowState.Maximized;
            crearSolicitud.Show();
        }
        private void resolverSolicitud_Click(object sender, EventArgs e)
        {
            ResolverSolicitud resolverSolicitud = new ResolverSolicitud();
            resolverSolicitud.MdiParent = this;
            resolverSolicitud.WindowState = FormWindowState.Maximized;
            resolverSolicitud.Show();
        }
        private void listarAutorizaciones_Click(object sender, EventArgs e)
        {
            ConsultarAutorizaciones listarAutorizaciones = new ConsultarAutorizaciones();
            listarAutorizaciones.MdiParent = this;
            listarAutorizaciones.WindowState = FormWindowState.Maximized;
            listarAutorizaciones.Show();
        }
        private void registrarFactura_Click(object sender, EventArgs e)
        {
            RegistrarFactura registrarFactura = new RegistrarFactura();
            registrarFactura.MdiParent = this;
            registrarFactura.WindowState = FormWindowState.Maximized;
            registrarFactura.Show();
        }
        private void consultarFacturas_Click(object sender, EventArgs e)
        {
            ConsultarFacturas consultarFacturas = new ConsultarFacturas();
            consultarFacturas.MdiParent = this;
            consultarFacturas.WindowState = FormWindowState.Maximized;
            consultarFacturas.Show();
        }
        private void registrarPago_Click(object sender, EventArgs e)
        {
            RegistrarPago registrarPago = new RegistrarPago();
            registrarPago.MdiParent = this;
            registrarPago.WindowState = FormWindowState.Maximized;
            registrarPago.Show();
        }
        private void backup_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup(usuarioLogueado);
            backup.MdiParent = this;
            backup.WindowState = FormWindowState.Maximized;
            backup.Show();
        }
        private void restore_Click(object sender, EventArgs e)
        {
            Restore restore = new Restore(usuarioLogueado);
            restore.MdiParent = this;
            restore.WindowState = FormWindowState.Maximized;
            restore.Show();
        }
        private void bitacora_Click(object sender, EventArgs e)
        {
            ConsultarBitacora bitacora = new ConsultarBitacora();
            bitacora.MdiParent = this;
            bitacora.WindowState = FormWindowState.Maximized;
            bitacora.Show();
        }
        private void dashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.MdiParent = this;
            dashboard.WindowState = FormWindowState.Maximized;
            dashboard.Show();
        }
    }
}
