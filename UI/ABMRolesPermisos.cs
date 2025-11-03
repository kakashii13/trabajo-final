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
    public partial class ABMRolesPermisos : Form
    {
        BLLPermiso bllPermiso;
        BLLUsuario bllUsuario;
        BEUsuario usuarioSeleccionado;

        private void ABMRolesPermisos_Load(object sender, EventArgs e)
        {
            CompletarListados();
        }
        public ABMRolesPermisos()
        {
            InitializeComponent();
            bllPermiso = new BLLPermiso();
            bllUsuario = new BLLUsuario();
        }

        // cargar permisos y roles
        private void CompletarListados()
        {
            try {
                CargarPermisosDisponibles();

                listaRoles.Items.Clear();
                List<BERol> roles = bllPermiso.ListarRolesConPermisos();
                foreach (BERol rol in roles)
                {
                    listaRoles.Items.Add(rol);
                }

                ListarUsuarios();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarUsuarios()
        {
            try
            {
                listaUsuarios.Items.Clear();
                List<BEUsuario> usuarios = bllUsuario.ListarUsuarios();
                foreach (BEUsuario usuario in usuarios)
                {
                    listaUsuarios.Items.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // resetear campos y botones
        private void Resetear()
        {
            txtPermisoSimple.Text = "";
            txtRol.Text = "";
            btnCrearPermiso.Enabled = true;
            btnEliminarPermiso.Enabled = false;
            btnModificarPermiso.Enabled = false;
            btnCrearRol.Enabled = true;
            btnEliminarRol.Enabled = false;
            btnModificarRol.Enabled = false;
        }

        #region permisos
        // agregar permiso
        private void add_permiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPermisoSimple.Text)) // ✅ Usar IsNullOrWhiteSpace
                {
                    throw new Exception("El nombre del permiso no puede estar vacío.");
                }

                BEPermisoSimple nuevoPermiso = new BEPermisoSimple(txtPermisoSimple.Text);

                // persistimos el permiso
                bllPermiso.CrearPermiso(nuevoPermiso, false);

                // actualizamos la lista
                CargarPermisosDisponibles();

                MessageBox.Show("Permiso creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // eliminar permiso
        private void del_permiso_Click(object sender, EventArgs e)
        {
            try {
                if (treePermisosSimples.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un permiso.");
                }

                if (treePermisosSimples.SelectedNode.Tag == null)
                {
                    throw new Exception("Debe seleccionar un permiso específico, no un módulo.");
                }

                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)treePermisosSimples.SelectedNode.Tag;

                bllPermiso.BorrarPermiso(permisoSeleccionado);

                // actualizamos el tree
                CargarPermisosDisponibles();

                MessageBox.Show("Permiso borrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // modificar permiso
        private void mod_permiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (treePermisosSimples.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un permiso.");
                }

                if (treePermisosSimples.SelectedNode.Tag == null)
                {
                    throw new Exception("Debe seleccionar un permiso específico, no un módulo.");
                }

                if (txtPermisoSimple.Text == "")
                {
                    throw new Exception("El nombre del permiso no puede estar vacío.");
                }

                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)treePermisosSimples.SelectedNode.Tag;
                string nombre = txtPermisoSimple.Text;
                permisoSeleccionado.Nombre = nombre;

                bllPermiso.ModificarPermiso(permisoSeleccionado);

                CargarPermisosDisponibles();

                MessageBox.Show("Permiso modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // limpiar campos de permiso
        private void btn_clear_permiso_Click(object sender, EventArgs e)
        {
            btnCrearPermiso.Enabled = true;
            btnEliminarPermiso.Enabled = false;
            btnModificarPermiso.Enabled = false;
            txtPermisoSimple.Text = "";
        }

        // seleccionar permiso
        private void tree_permisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                txtPermisoSeleccionado.Text = "";
                if (treePermisosSimples.SelectedNode == null) { return; }

                // si es un modulo, deshabilitamos edicion/borrado
                if (treePermisosSimples.SelectedNode.Tag == null)
                {
                    txtPermisoSimple.Text = "";
                    btnCrearPermiso.Enabled = true;
                    btnEliminarPermiso.Enabled = false;
                    btnModificarPermiso.Enabled = false;
                    return;
                }

                // si es un nodo de permiso, habilitamos edicion/borrado
                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)treePermisosSimples.SelectedNode.Tag;
                txtPermisoSeleccionado.Text = permisoSeleccionado.Nombre;
                txtPermisoSimple.Text = permisoSeleccionado.Nombre;

                btnCrearPermiso.Enabled = false;
                btnEliminarPermiso.Enabled = true;
                btnModificarPermiso.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region roles
        // agregar rol
        private void add_role_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtRol.Text == "")
                {
                    throw new Exception("El nombre del rol no puede estar vacío.");
                }
               
                // crear rol
                BERol nuevoRol = new BERol(txtRol.Text.ToLower());

                bllPermiso.CrearPermiso(nuevoRol, true);

                // actualizar la lista
                CompletarListados();

                MessageBox.Show("Rol creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // eliminar rol
        private void del_rol_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaRoles.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un rol.");
                }

                BERol rolSeleccionado = (BERol)listaRoles.SelectedItem;

                bllPermiso.BorrarPermiso(rolSeleccionado);

                // actualizamos la lista
                CompletarListados();

                MessageBox.Show("Rol borrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // modificar rol
        private void btn_mod_rol_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaRoles.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un rol.");    
                }
                if (txtRol.Text == "")
                {
                    throw new Exception("El nombre del rol no puede estar vacío.");
                }

                BERol rolSeleccionado = (BERol)listaRoles.SelectedItem;
                string nombre = txtRol.Text.ToLower();
                rolSeleccionado.Nombre = nombre;

                bllPermiso.ModificarPermiso(rolSeleccionado);

                CompletarListados();

                MessageBox.Show("Rol modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // seleccionar rol
        private void list_roles_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                treePermisosRoles.Nodes.Clear();

                if (listaRoles.SelectedItem == null)
                {
                    txtRol.Text = "";
                    btnCrearRol.Enabled = true;
                    btnEliminarRol.Enabled = false;
                    btnModificarRol.Enabled = false;
                    return;
                }
                BERol rolSeleccionado = (BERol)listaRoles.SelectedItem;

                // agrupamos los permisos del rol por modulo
                var permisosPorModulo = rolSeleccionado.ObtenerPermisos()
                    .Cast<BEPermisoSimple>()
                    .GroupBy(p => {
                        var partes = p.Nombre.Split('.');
                        return partes.Length > 0 ? partes[0] : "Sin Categoría";
                    });

                // creamos un nodo por cada módulo
                foreach (var grupoModulo in permisosPorModulo)
                {
                    TreeNode moduloNode = new TreeNode(grupoModulo.Key);
                    moduloNode.Tag = null; // el nodo de modulo no representa un permiso

                    // agregamos cada permiso del módulo
                    foreach (var permiso in grupoModulo)
                    {
                        // quitamos la parte del modulo del nombre para mostrarlo mas limpio
                        var permisoNombre = permiso.Nombre.Contains('.')
                            ? permiso.Nombre.Substring(permiso.Nombre.IndexOf('.') + 1)
                            : permiso.Nombre;

                        TreeNode permisoNode = new TreeNode(permisoNombre);
                        permisoNode.Tag = permiso; 

                        moduloNode.Nodes.Add(permisoNode);
                    }

                    treePermisosRoles.Nodes.Add(moduloNode);
                }

                txtRol.Text = rolSeleccionado.Nombre;
                btnCrearRol.Enabled = false;
                btnEliminarRol.Enabled = true;
                btnModificarRol.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // limpiar campos de rol
        private void btn_clear_rol_Click(object sender, EventArgs e)
        {
            btnCrearRol.Enabled = true;
            btnEliminarRol.Enabled = false;
            btnModificarRol.Enabled = false;
            txtRol.Text = "";
            listaRoles.ClearSelected();
        }

        #endregion

        #region asignacion permisos a roles
        // asignar permiso a rol
        private void attach_permiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaRoles.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un rol.");
                }

                if (treePermisosSimples.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un permiso.");
                }

                if (treePermisosSimples.SelectedNode.Tag == null)
                {
                    throw new Exception("Debe seleccionar un permiso específico, no un módulo.");
                }

                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)treePermisosSimples.SelectedNode.Tag;
                BERol rolSeleccionado = (BERol)listaRoles.SelectedItem;

                bllPermiso.AsignarPermiso(rolSeleccionado, permisoSeleccionado);

                // actualizamos la lista
                list_roles_SelectedValueChanged(null, null);

                MessageBox.Show("Permiso asignado al rol exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // remover permiso de rol
        private void remove_permiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (treePermisosRoles.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un permiso del rol.");
                }

                if(treePermisosRoles.SelectedNode.Tag == null)
                {
                    throw new Exception("Debe seleccionar un permiso específico, no un módulo.");
                }

                if (listaRoles.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un rol.");
                }

                BERol rolSeleccionado = (BERol)listaRoles.SelectedItem;
                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)treePermisosRoles.SelectedNode.Tag;

                bllPermiso.RemoverPermiso(rolSeleccionado, permisoSeleccionado);

                // actualizamos la lista
                list_roles_SelectedValueChanged(null, null);

                MessageBox.Show("Permiso removido del rol exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        // actualizar listas
        private void btn_update_Click(object sender, EventArgs e)
        {
              CompletarListados();
        }

        #region usuarios
        private void list_usuarios_SelectedValueChanged(object sender, EventArgs e)
        {
            try { 
                checkEncriptacion.Checked = false;
                usuarioSeleccionado = (BEUsuario)listaUsuarios.SelectedItem;

                if (usuarioSeleccionado == null)
                {
                    checkEncriptacion.Enabled = false;
                    return;
                }
                txtUsuario.Text = usuarioSeleccionado.NombreUsuario;
                txtUsuarioPassword.Text = usuarioSeleccionado.Password;
                txtUsuarioId.Text = usuarioSeleccionado.Id.ToString();
                checkEncriptacion.Enabled = true;

                CargarRolesPermisosUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPermisosDisponibles()
        {
            try
            {
                treePermisosSimples.Nodes.Clear();

                // Obtenemos todos los permisos simples
                List<BEPermisoSimple> permisos = bllPermiso.ListarPermisos();

                // Agrupamos permisos por módulo (parte antes del primer punto)
                var permisosPorModulo = permisos.GroupBy(p => {
                    var partes = p.Nombre.Split('.');
                    return partes.Length > 0 ? partes[0] : "Sin Categoría";
                });

                // Creamos un nodo por cada módulo
                foreach (var grupoModulo in permisosPorModulo)
                {
                    TreeNode moduloNode = new TreeNode(grupoModulo.Key);
                    moduloNode.Tag = null; // El nodo de módulo no representa un permiso

                    // Agregamos cada permiso del módulo
                    foreach (var permiso in grupoModulo)
                    {
                        // Quitamos la parte del módulo del nombre para mostrarlo más limpio
                        var permisoNombre = permiso.Nombre.Contains('.')
                            ? permiso.Nombre.Substring(permiso.Nombre.IndexOf('.') + 1)
                            : permiso.Nombre;

                        TreeNode permisoNode = new TreeNode(permisoNombre);
                        permisoNode.Tag = permiso;

                        moduloNode.Nodes.Add(permisoNode);
                    }

                    treePermisosSimples.Nodes.Add(moduloNode);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRolesPermisosUsuario()
        {
            try
            {
                treeUsuarioRolesPermisos.Nodes.Clear();
                TreeNode rootNode = new TreeNode(usuarioSeleccionado.NombreUsuario);
                rootNode.Tag = usuarioSeleccionado;

                var roles = usuarioSeleccionado.Permisos.OfType<BERol>()
                    .ToList();
                var permisosSimples = usuarioSeleccionado.Permisos.OfType<BEPermisoSimple>()
                    .ToList();

                foreach (BERol rol in roles)
                {
                    TreeNode rolNode = new TreeNode(rol.Nombre);
                    rolNode.Tag = rol;

                    // extraccion del nombre debido a la nomenclatura del permiso
                    // eg. "facturacion.CrearFactura"
                    // "Facturacion" seria el menu
                    // "CrearFactura" seria el permiso dentro del menu
                    var permisosPorMenu = rol.ObtenerPermisos()
                        .Cast<BEPermisoSimple>()
                        .GroupBy(p => {
                            var partes = p.Nombre.Split('.');
                            return partes.Length > 0 ? partes[0] : "Sin Categoría";
                        });

                    foreach (var grupoMenu in permisosPorMenu)
                    {
                        TreeNode menuNode = new TreeNode(grupoMenu.Key);
                        menuNode.Tag = null; 

                        foreach (var p in grupoMenu)
                        {
                            var permisoNombre = p.Nombre.Contains('.')
                                ? p.Nombre.Substring(p.Nombre.IndexOf('.') + 1)
                                : p.Nombre;
                            TreeNode permisoNode = new TreeNode(permisoNombre);
                            permisoNode.Tag = p;
                            menuNode.Nodes.Add(permisoNode);
                        }
                        rolNode.Nodes.Add(menuNode);
                    }
                    rootNode.Nodes.Add(rolNode);
                }

                // en caso de que el usuario tenga permisos simples asignados directamente
                if (permisosSimples.Any())
                {
                    var permisosSimplesAgrupados = permisosSimples.GroupBy(p => {
                        var partes = p.Nombre.Split('.');
                        return partes.Length > 0 ? partes[0] : "Sin Categoría";
                    });

                    foreach (var grupoModulo in permisosSimplesAgrupados)
                    {
                        TreeNode moduloNode = new TreeNode(grupoModulo.Key);
                        moduloNode.Tag = null;

                        foreach (var permiso in grupoModulo)
                        {
                            var permisoNombre = permiso.Nombre.Contains('.')
                                ? permiso.Nombre.Substring(permiso.Nombre.IndexOf('.') + 1)
                                : permiso.Nombre;
                            TreeNode permisoNode = new TreeNode(permisoNombre);
                            permisoNode.Tag = permiso;
                            moduloNode.Nodes.Add(permisoNode);
                        }
                        rootNode.Nodes.Add(moduloNode);
                    }
                }

                treeUsuarioRolesPermisos.Nodes.Add(rootNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        // mostrar password desencriptado
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try {
                if(usuarioSeleccionado == null)
                {
                    checkEncriptacion.Checked = false;
                    throw new Exception("Debe seleccionar un usuario.");
                }

                if (checkEncriptacion.Checked) 
                {
                    txtUsuarioPassword.Text = ServicioSeguridad.Desencriptar(usuarioSeleccionado.Password);
                }
                else 
                {
                    txtUsuarioPassword.Text = usuarioSeleccionado.Password;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_asignar_rol_Click(object sender, EventArgs e)
        {
            try {
                if(usuarioSeleccionado == null || listaRoles.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un usuario y un rol.");
                }

                BERol rolSeleccionado = (BERol)listaRoles.SelectedItem;
                bllUsuario.AsignarRol(usuarioSeleccionado, rolSeleccionado);

                MessageBox.Show("Rol asignado al usuario exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRolesPermisosUsuario();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_remove_rol_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioSeleccionado == null || treeUsuarioRolesPermisos.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un usuario y un nodo del árbol.");
                }

                if (!(treeUsuarioRolesPermisos.SelectedNode.Tag is BERol))
                {
                    throw new Exception("Debe seleccionar un rol del árbol.");
                }

                BERol rolSeleccionado = (BERol)treeUsuarioRolesPermisos.SelectedNode.Tag;

                if (rolSeleccionado == null)
                {
                    throw new Exception("El rol seleccionado no existe.");
                }
                bllUsuario.QuitarRol(usuarioSeleccionado, rolSeleccionado);

                MessageBox.Show("Rol removido del usuario exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRolesPermisosUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_quitar_permiso_user_Click(object sender, EventArgs e)
        {
            try {
                if(usuarioSeleccionado == null || treeUsuarioRolesPermisos.SelectedNode == null || !(treeUsuarioRolesPermisos.SelectedNode.Tag is BEPermisoSimple))
                {
                    throw new Exception("Debe seleccionar un usuario y un permiso del válido.");
                }
                BEPermiso permisoSeleccionado = (BEPermiso)treeUsuarioRolesPermisos.SelectedNode.Tag;

                bllUsuario.QuitarPermiso(usuarioSeleccionado, permisoSeleccionado);

                MessageBox.Show("Permiso removido del usuario exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRolesPermisosUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_asignar_permiso_user_Click(object sender, EventArgs e)
        {
            try {
                if(usuarioSeleccionado == null || treePermisosSimples.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un usuario y un permiso.");
                }
                if (treePermisosSimples.SelectedNode.Tag == null)
                {
                    throw new Exception("Debe seleccionar un permiso específico, no un módulo.");
                }
                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)treePermisosSimples.SelectedNode.Tag;
                bllUsuario.AsignarPermiso(usuarioSeleccionado, permisoSeleccionado);
                MessageBox.Show("Permiso asignado al usuario exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRolesPermisosUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tree_permisos_roles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try{
                txtPermisoRolSeleccionado.Text = "";
                if (treePermisosRoles.SelectedNode == null) { return; }
                txtPermisoRolSeleccionado.Text = treePermisosRoles.SelectedNode.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tree_user_permisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                txtPermisoUsuarioSeleccionado.Text = "";
                txtRolUsuarioSeleccionado.Text = "";

                if (treeUsuarioRolesPermisos.SelectedNode == null ||
                    treeUsuarioRolesPermisos.SelectedNode.Tag == null) 
                {
                    return;
                }

                if (treeUsuarioRolesPermisos.SelectedNode.Tag is BERol)
                {
                    BERol rol = (BERol)treeUsuarioRolesPermisos.SelectedNode.Tag;
                    txtRolUsuarioSeleccionado.Text = rol.Nombre;
                }
                else if (treeUsuarioRolesPermisos.SelectedNode.Tag is BEPermisoSimple)
                {
                    BEPermisoSimple permiso = (BEPermisoSimple)treeUsuarioRolesPermisos.SelectedNode.Tag;
                    txtPermisoUsuarioSeleccionado.Text = permiso.Nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
