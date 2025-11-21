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
        }
        public ABMRolesPermisos()
        {
            InitializeComponent();
            bllPermiso = new BLLPermiso();
            bllUsuario = new BLLUsuario();

            CompletarListados();
        }

        private void CompletarListados()
        {
            ListarPermisos();
            ListarRoles();
            ListarUsuarios();
        }
        private void ListarRoles()
        {
            try
            {
                listaRoles.Items.Clear();
                List<BERol> roles = bllPermiso.ListarRolesConPermisos();
                foreach (BERol rol in roles)
                {
                    listaRoles.Items.Add(rol);
                }
            }
            catch (Exception ex)
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
        private void ListarPermisos()
        {
            try
            {
                treePermisosSimples.Nodes.Clear();

                List<BEPermisoSimple> permisos = bllPermiso.ListarPermisos();

                CargarPermisosEnTreeView(treePermisosSimples, permisos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region permisos
        private void add_permiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPermisoSimple.Text))
                {
                    throw new Exception("El nombre del permiso no puede estar vacío.");
                }

                BEPermisoSimple nuevoPermiso = new BEPermisoSimple(txtPermisoSimple.Text);

                bllPermiso.CrearPermiso(nuevoPermiso, false);

                ListarPermisos();

                MessageBox.Show("Permiso creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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

                ListarPermisos();

                MessageBox.Show("Permiso borrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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

                ListarPermisos();

                MessageBox.Show("Permiso modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_clear_permiso_Click(object sender, EventArgs e)
        {
            btnCrearPermiso.Enabled = true;
            btnEliminarPermiso.Enabled = false;
            btnModificarPermiso.Enabled = false;
            txtPermisoSimple.Text = "";
        }
        private void tree_permisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                txtPermisoSeleccionado.Text = "";
                if (treePermisosSimples.SelectedNode == null) { return; }

                if (treePermisosSimples.SelectedNode.Tag == null)
                {
                    txtPermisoSimple.Text = "";
                    btnCrearPermiso.Enabled = true;
                    btnEliminarPermiso.Enabled = false;
                    btnModificarPermiso.Enabled = false;
                    return;
                }

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
        private void add_role_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtRol.Text == "")
                {
                    throw new Exception("El nombre del rol no puede estar vacío.");
                }
               
                BERol nuevoRol = new BERol(txtRol.Text.ToLower());

                bllPermiso.CrearPermiso(nuevoRol, true);

                CompletarListados();

                MessageBox.Show("Rol creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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

                CompletarListados();

                MessageBox.Show("Rol borrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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

                var permisosRol = rolSeleccionado.ObtenerPermisos().Cast<BEPermisoSimple>();

                CargarPermisosEnTreeView(treePermisosRoles, permisosRol);

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

                list_roles_SelectedValueChanged(null, null);

                MessageBox.Show("Permiso asignado al rol exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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

                    var permisosRol = rol.ObtenerPermisos().Cast<BEPermisoSimple>();

                    CargarPermisosEnTreeView(treeUsuarioRolesPermisos, permisosRol, rolNode);

                    rootNode.Nodes.Add(rolNode);
                }

                if (permisosSimples.Any())
                {
                    CargarPermisosEnTreeView(treeUsuarioRolesPermisos, permisosSimples, rootNode);
                }

                treeUsuarioRolesPermisos.Nodes.Add(rootNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
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
        private void CargarPermisosEnTreeView(TreeView treeView, IEnumerable<BEPermisoSimple> permisos, TreeNode nodoPadre = null)
        {
            treeView.Nodes.Clear();
            
            var permisosPorModulo = permisos
                .OfType<BEPermisoSimple>()
                .GroupBy(p =>
                {
                    var partes = p.Nombre.Split('.');
                    return partes.Length > 0 ? partes[0] : "Sin Categoría";
                });
            
            foreach (var grupoModulo in permisosPorModulo)
            {
                TreeNode moduloNode = new TreeNode(grupoModulo.Key);
                moduloNode.Tag = null;
                foreach (var permiso in grupoModulo)
                {
                    var permisoNombre = permiso.Nombre.Contains('.')
                        ? permiso.Nombre.Split('.')[1]
                        : permiso.Nombre;
                    TreeNode permisoNode = new TreeNode(permisoNombre);
                    permisoNode.Tag = permiso;
                    moduloNode.Nodes.Add(permisoNode);
                }

                if (nodoPadre != null)
                    nodoPadre.Nodes.Add(moduloNode);
                else
                    treeView.Nodes.Add(moduloNode);
            }
        }
    }
}
