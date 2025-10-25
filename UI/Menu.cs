﻿using System;
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
            permisosUsuario = bllUsuario.ListarPermisosDeUsuario(usuarioLogueado);
            AplanarPermisos(permisosUsuario);
            ConfigurarMenusSegunPermisos();
        }

        // metodo recursivo para obtener los permisos del rol y guardarlos como permisos simples del usuario
        private void AplanarPermisos(List<BEPermiso> permisos)
        {
            var permisosACopiar = permisos.ToList();

            foreach (BEPermiso permiso in permisosACopiar)
            {
                if (permiso is BEPermisoSimple permisoSimple)
                {
                    // Si es un permiso simple, agregarlo directamente
                    if (!permisosUsuario.Any(p => p.Id == permisoSimple.Id))
                    {
                        permisosUsuario.Add(permisoSimple);
                    }
                }
                else if (permiso is BEPermiso rol)
                {
                    // si un permiso es compuesto (rol), llamamos recursivamente al metodo
                    AplanarPermisos(rol.ObtenerPermisos());
                }
            }
        }

        private void ConfigurarMenusSegunPermisos()
        {
            // ocultamos todos los items primero
            OcultarTodosLosItemsDelMenu(menuStrip1.Items);

            // mostramos solo los items que el usuario tiene permiso
            MostrarItemsSegunPermisos(menuStrip1.Items, permisosUsuario);
        }

        private void MostrarItemsSegunPermisos(ToolStripItemCollection items, List<BEPermiso> permisosUsuario)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    // metodo recursivo para verificar subitems
                    if (menuItem.DropDownItems.Count > 0)
                    {
                        MostrarSubItemsSegunPermisos(menuItem, permisosUsuario);
                    }

                    // verificamos si el item tiene permisos
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
                    // metodo recursivo para verificar subitems
                    if (subMenuItem.DropDownItems.Count > 0)
                    {
                        MostrarSubItemsSegunPermisos(subMenuItem, permisosUsuario);
                    }

                    // verificamos si el subitem tiene permisos
                    if (TienePermiso(subMenuItem.Name, permisosUsuario))
                    {
                        subMenuItem.Visible = true;
                        algunSubItemVisible = true;
                    }
                }
            }

            // si algun subitem es visible, el item tambien debe ser visible
            if (algunSubItemVisible)
            {
                menuItem.Visible = true;
            }
        }

        private void OcultarTodosLosItemsDelMenu(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem subMenuItem)
                {
                    subMenuItem.Visible = false;

                    // si el elemento tiene subitems, llamamos recursivamente
                    if (subMenuItem.DropDownItems.Count > 0)
                    {
                        OcultarTodosLosItemsDelSubMenu(subMenuItem.DropDownItems);
                    }
                }
            }
        }

        private void OcultarTodosLosItemsDelSubMenu(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem subMenuItem)
                {
                    subMenuItem.Visible = false;

                    // si el elemento tiene subitems, llamamos recursivamente
                    if (subMenuItem.DropDownItems.Count > 0)
                    {
                        OcultarTodosLosItemsDelSubMenu(subMenuItem.DropDownItems);
                    }
                }
            }
        }

        private bool TienePermiso(string nombreItem, List<BEPermiso> permisosUsuario)
        {
            // verificamos si algun permiso en la lista de permisos del usuario coincide 
            // con el nombre del item
            return permisosUsuario.Any(permiso =>
            {
                // el permiso esta nomenclado como menu.permiso, por lo que extraemos el valor luego del "."
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
            ABM.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ABMUsuarios ABM = new ABMUsuarios();
            ABM.MdiParent = this;
            ABM.Show();
        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarClave cambiarClave = new CambiarClave(usuarioLogueado);
            cambiarClave.MdiParent = this;
            cambiarClave.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        #region padron
        private void registrarAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarAfiliado registrarAfiliado = new RegistrarAfiliado();
            registrarAfiliado.MdiParent = this;
            registrarAfiliado.Show();
        }

        private void registrarAporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarAporte registrarAporte = new RegistrarAporte();
            registrarAporte.MdiParent = this;
            registrarAporte.Show();
        }
       

        private void listadoAfiliados_Click(object sender, EventArgs e)
        {
            ListadoAfiliados listadoAfiliados = new ListadoAfiliados();
            listadoAfiliados.MdiParent = this;
            listadoAfiliados.Show();
        }

        private void consultarAportes_Click(object sender, EventArgs e)
        {
            ConsultarAportes consultarAportes = new ConsultarAportes();
            consultarAportes.MdiParent = this;
            consultarAportes.Show();
        }
        #endregion

        private void registrarPrestador_Click(object sender, EventArgs e)
        {
            RegistrarPrestador registrarPrestador = new RegistrarPrestador();
            registrarPrestador.MdiParent = this;
            registrarPrestador.Show();
        }

        private void administrarPracticaPorPlan_Click(object sender, EventArgs e)
        {
            AdministrarPracticaPorPlan administrarPracticaPorPlan = new AdministrarPracticaPorPlan();
            administrarPracticaPorPlan.MdiParent = this;
            administrarPracticaPorPlan.Show();
        }

        private void abmPlanes_Click(object sender, EventArgs e)
        {
            ABMPlanes abmPlanes = new ABMPlanes();
            abmPlanes.MdiParent = this;
            abmPlanes.Show();
        }

        private void abmPracticas_Click(object sender, EventArgs e)
        {
            ABMPracticas abmPracticas = new ABMPracticas();
            abmPracticas.MdiParent = this;
            abmPracticas.Show();
        }

        private void administrarPrestadorPorPractica_Click(object sender, EventArgs e)
        {
            AdministrarPrestadorPorPractica administrarPrestadorPorPractica = new AdministrarPrestadorPorPractica();
            administrarPrestadorPorPractica.MdiParent = this;
            administrarPrestadorPorPractica.Show();
        }

        private void crearSolicitud_Click(object sender, EventArgs e)
        {
            CrearSolicitud crearSolicitud = new CrearSolicitud();
            crearSolicitud.MdiParent = this;
            crearSolicitud.Show();
        }

        private void resolverSolicitud_Click(object sender, EventArgs e)
        {
            ResolverSolicitud resolverSolicitud = new ResolverSolicitud();
            resolverSolicitud.MdiParent = this;
            resolverSolicitud.Show();
        }

        private void listarAutorizaciones_Click(object sender, EventArgs e)
        {
            ListarAutorizaciones listarAutorizaciones = new ListarAutorizaciones();
            listarAutorizaciones.MdiParent = this;
            listarAutorizaciones.Show();
        }

        private void registrarFactura_Click(object sender, EventArgs e)
        {
            RegistrarFactura registrarFactura = new RegistrarFactura();
            registrarFactura.MdiParent = this;
            registrarFactura.Show();
        }

        private void consultarFacturas_Click(object sender, EventArgs e)
        {
            ConsultarFacturas consultarFacturas = new ConsultarFacturas();
            consultarFacturas.MdiParent = this;
            consultarFacturas.Show();
        }

        private void registrarPago_Click(object sender, EventArgs e)
        {
            RegistrarPago registrarPago = new RegistrarPago();
            registrarPago.MdiParent = this;
            registrarPago.Show();
        }

        private void backup_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup(usuarioLogueado);
            backup.MdiParent = this;
            backup.Show();
        }

        private void restore_Click(object sender, EventArgs e)
        {
            Restore restore = new Restore(usuarioLogueado);
            restore.MdiParent = this;
            restore.Show();
        }

        private void bitacora_Click(object sender, EventArgs e)
        {
            Bitacora bitacora = new Bitacora();
            bitacora.MdiParent = this;
            bitacora.Show();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.MdiParent = this;
            dashboard.Show();
        }
    }
}
