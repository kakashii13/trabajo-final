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

                list_roles.Items.Clear();
                List<BERol> roles = bllPermiso.ListarRolesConPermisos();
                foreach (BERol rol in roles)
                {
                    list_roles.Items.Add(rol);
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
                list_usuarios.Items.Clear();
                List<BEUsuario> usuarios = bllUsuario.ListarUsuarios();
                foreach (BEUsuario usuario in usuarios)
                {
                    list_usuarios.Items.Add(usuario);
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
            txt_permiso.Text = "";
            txt_role.Text = "";
            btn_crear_permiso.Enabled = true;
            btn_del_permiso.Enabled = false;
            btn_mod_permiso.Enabled = false;
            btn_crear_role.Enabled = true;
            btn_del_rol.Enabled = false;
            btn_mod_rol.Enabled = false;
        }

        #region permisos
        // agregar permiso
        private void add_permiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_permiso.Text)) // ✅ Usar IsNullOrWhiteSpace
                {
                    throw new Exception("El nombre del permiso no puede estar vacío.");
                }

                BEPermisoSimple nuevoPermiso = new BEPermisoSimple(txt_permiso.Text);

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
                if (tree_permisos.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un permiso.");
                }

                if (tree_permisos.SelectedNode.Tag == null)
                {
                    throw new Exception("Debe seleccionar un permiso específico, no un módulo.");
                }

                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)tree_permisos.SelectedNode.Tag;

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
                if (tree_permisos.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un permiso.");
                }

                if (tree_permisos.SelectedNode.Tag == null)
                {
                    throw new Exception("Debe seleccionar un permiso específico, no un módulo.");
                }

                if (txt_permiso.Text == "")
                {
                    throw new Exception("El nombre del permiso no puede estar vacío.");
                }

                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)tree_permisos.SelectedNode.Tag;
                string nombre = txt_permiso.Text;
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
            btn_crear_permiso.Enabled = true;
            btn_del_permiso.Enabled = false;
            btn_mod_permiso.Enabled = false;
            txt_permiso.Text = "";
        }

        // seleccionar permiso
        private void tree_permisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                txt_permiso_seleccionado.Text = "";
                if (tree_permisos.SelectedNode == null) { return; }

                // si es un modulo, deshabilitamos edicion/borrado
                if (tree_permisos.SelectedNode.Tag == null)
                {
                    txt_permiso.Text = "";
                    btn_crear_permiso.Enabled = true;
                    btn_del_permiso.Enabled = false;
                    btn_mod_permiso.Enabled = false;
                    return;
                }

                // si es un nodo de permiso, habilitamos edicion/borrado
                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)tree_permisos.SelectedNode.Tag;
                txt_permiso_seleccionado.Text = permisoSeleccionado.Nombre;
                txt_permiso.Text = permisoSeleccionado.Nombre;

                btn_crear_permiso.Enabled = false;
                btn_del_permiso.Enabled = true;
                btn_mod_permiso.Enabled = true;
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
                if(txt_role.Text == "")
                {
                    throw new Exception("El nombre del rol no puede estar vacío.");
                }
               
                // crear rol
                BERol nuevoRol = new BERol(txt_role.Text.ToLower());

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
                if (list_roles.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un rol.");
                }

                BERol rolSeleccionado = (BERol)list_roles.SelectedItem;

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
                if (list_roles.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un rol.");    
                }
                if (txt_role.Text == "")
                {
                    throw new Exception("El nombre del rol no puede estar vacío.");
                }

                BERol rolSeleccionado = (BERol)list_roles.SelectedItem;
                string nombre = txt_role.Text.ToLower();
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
                tree_permisos_roles.Nodes.Clear();

                if (list_roles.SelectedItem == null)
                {
                    txt_role.Text = "";
                    btn_crear_role.Enabled = true;
                    btn_del_rol.Enabled = false;
                    btn_mod_rol.Enabled = false;
                    return;
                }
                BERol rolSeleccionado = (BERol)list_roles.SelectedItem;

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

                    tree_permisos_roles.Nodes.Add(moduloNode);
                }

                txt_role.Text = rolSeleccionado.Nombre;
                btn_crear_role.Enabled = false;
                btn_del_rol.Enabled = true;
                btn_mod_rol.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // limpiar campos de rol
        private void btn_clear_rol_Click(object sender, EventArgs e)
        {
            btn_crear_role.Enabled = true;
            btn_del_rol.Enabled = false;
            btn_mod_rol.Enabled = false;
            txt_role.Text = "";
            list_roles.ClearSelected();
        }

        #endregion

        #region asignacion permisos a roles
        // asignar permiso a rol
        private void attach_permiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (list_roles.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un rol.");
                }

                if (tree_permisos.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un permiso.");
                }

                if (tree_permisos.SelectedNode.Tag == null)
                {
                    throw new Exception("Debe seleccionar un permiso específico, no un módulo.");
                }

                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)tree_permisos.SelectedNode.Tag;
                BERol rolSeleccionado = (BERol)list_roles.SelectedItem;

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
                if (tree_permisos_roles.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un permiso del rol.");
                }

                if(tree_permisos_roles.SelectedNode.Tag == null)
                {
                    throw new Exception("Debe seleccionar un permiso específico, no un módulo.");
                }

                if (list_roles.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un rol.");
                }

                BERol rolSeleccionado = (BERol)list_roles.SelectedItem;
                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)tree_permisos_roles.SelectedNode.Tag;

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
                check_encriptacion.Checked = false;
                usuarioSeleccionado = (BEUsuario)list_usuarios.SelectedItem;

                if (usuarioSeleccionado == null)
                {
                    check_encriptacion.Enabled = false;
                    return;
                }
                txt_usuario.Text = usuarioSeleccionado.NombreUsuario;
                txt_password.Text = usuarioSeleccionado.Password;
                txt_id.Text = usuarioSeleccionado.Id.ToString();
                check_encriptacion.Enabled = true;

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
                tree_permisos.Nodes.Clear();

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

                    tree_permisos.Nodes.Add(moduloNode);
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
                tree_user_permisos.Nodes.Clear();
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

                tree_user_permisos.Nodes.Add(rootNode);
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
                    check_encriptacion.Checked = false;
                    throw new Exception("Debe seleccionar un usuario.");
                }

                if (check_encriptacion.Checked) 
                {
                    txt_password.Text = ServicioSeguridad.Desencriptar(usuarioSeleccionado.Password);
                }
                else 
                {
                    txt_password.Text = usuarioSeleccionado.Password;
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
                if(usuarioSeleccionado == null || list_roles.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un usuario y un rol.");
                }

                BERol rolSeleccionado = (BERol)list_roles.SelectedItem;
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
                if (usuarioSeleccionado == null || tree_user_permisos.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un usuario y un nodo del árbol.");
                }

                if (!(tree_user_permisos.SelectedNode.Tag is BERol))
                {
                    throw new Exception("Debe seleccionar un rol del árbol.");
                }

                BERol rolSeleccionado = (BERol)tree_user_permisos.SelectedNode.Tag;

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
                if(usuarioSeleccionado == null || tree_user_permisos.SelectedNode == null || !(tree_user_permisos.SelectedNode.Tag is BEPermisoSimple))
                {
                    throw new Exception("Debe seleccionar un usuario y un permiso del válido.");
                }
                BEPermiso permisoSeleccionado = (BEPermiso)tree_user_permisos.SelectedNode.Tag;

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
                if(usuarioSeleccionado == null || tree_permisos.SelectedNode == null)
                {
                    throw new Exception("Debe seleccionar un usuario y un permiso.");
                }
                if (tree_permisos.SelectedNode.Tag == null)
                {
                    throw new Exception("Debe seleccionar un permiso específico, no un módulo.");
                }
                BEPermisoSimple permisoSeleccionado = (BEPermisoSimple)tree_permisos.SelectedNode.Tag;
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
                txt_permiso_rol_seleccionado.Text = "";
                if (tree_permisos_roles.SelectedNode == null) { return; }
                txt_permiso_rol_seleccionado.Text = tree_permisos_roles.SelectedNode.Text;
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
                txt_permiso_usuario_seleccionado.Text = "";
                txt_rol_usuario_seleccionado.Text = "";

                if (tree_user_permisos.SelectedNode == null ||
                    tree_user_permisos.SelectedNode.Tag == null) 
                {
                    return;
                }

                if (tree_user_permisos.SelectedNode.Tag is BERol)
                {
                    BERol rol = (BERol)tree_user_permisos.SelectedNode.Tag;
                    txt_rol_usuario_seleccionado.Text = rol.Nombre;
                }
                else if (tree_user_permisos.SelectedNode.Tag is BEPermisoSimple)
                {
                    BEPermisoSimple permiso = (BEPermisoSimple)tree_user_permisos.SelectedNode.Tag;
                    txt_permiso_usuario_seleccionado.Text = permiso.Nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
