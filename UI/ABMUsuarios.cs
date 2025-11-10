using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UI
{
    public partial class ABMUsuarios : Form
    {
        string modo = null;
        BLLUsuario bllUsuario = new BLLUsuario();
        BEUsuario usuarioSeleccionado = null;

        public ABMUsuarios()
        {
            InitializeComponent();
            LimpiarInputs();
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            List<BEUsuario> usuarios = bllUsuario.ListarUsuarios();
            dgvUsuarios.DataSource = usuarios;
            dgvUsuarios.Columns["Password"].Visible = false;
            dgvUsuarios.Columns["Eliminado"].Visible = false;
        }
        private void LimpiarInputs()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtPassword.Enabled = false;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNombreUsuario.Text = "";
            txtPassword.Text = "";
        }
        private void HabilitarInputs()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtNombreUsuario.Enabled = true;
        }
        private void HabilitarAcciones()
        {
            btnCrear.Enabled = true;
            btnInactivar.Enabled = true;
            btnModificar.Enabled = true;
        }
        private void DeshabilitarAcciones()
        {
            btnCrear.Enabled = false;
            btnInactivar.Enabled = false;
            btnModificar.Enabled = false;
        }
        private void CargarDatosUsuario(BEUsuario usuario)
        {
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtNombreUsuario.Text = usuario.NombreUsuario;
        }
        private void add_user_Click(object sender, EventArgs e)
        {
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            
            txtPassword.Text = "1234";
            txtPassword.Enabled = true;

            DeshabilitarAcciones();
            HabilitarInputs();
            modo = "Alta";
        }
        private void mod_user_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario para modificar.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                usuarioSeleccionado = dgvUsuarios.CurrentRow.DataBoundItem as BEUsuario;

                if (usuarioSeleccionado == null)
                {
                    MessageBox.Show("Error al obtener el usuario seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                modo = "Modificacion";
                
                CargarDatosUsuario(usuarioSeleccionado);

                btnCancelar.Enabled = true;
                btnGuardar.Enabled = true;

                DeshabilitarAcciones();
                HabilitarInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try {
                if (!ValidarCamposUI()) { return; }
                    

                var nombre = txtNombre.Text.Trim();
                var apellido = txtApellido.Text.Trim();
                var nombreUsuario = txtNombreUsuario.Text.Trim().ToLower();
                var password = txtPassword.Text;

                if (modo == "Alta")
                {
                    BEUsuario usuario = new BEUsuario(nombre, apellido, password, nombreUsuario, 0, true, false);
                    bllUsuario.CrearUsuario(usuario);

                    MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (modo == "Modificacion")
                {
                    if (usuarioSeleccionado == null) 
                    {
                        throw new Exception("No hay un usuario seleccionado para modificar.");
                    }

                    usuarioSeleccionado.ActualizarDatos(nombre, apellido,nombreUsuario);
                    bllUsuario.ModificarUsuario(usuarioSeleccionado);

                    MessageBox.Show("Usuario modificado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                usuarioSeleccionado = null; 
                modo = null;
                
                LimpiarInputs();
                HabilitarAcciones();
                ListarUsuarios();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            HabilitarAcciones();
            LimpiarInputs();
            usuarioSeleccionado = null;
            modo = null;
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
             ListarUsuarios();
        }
        private bool ValidarCamposUI()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Focus();
                MessageBox.Show("El nombre es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;  
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.Focus();
                MessageBox.Show("El apellido es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                txtNombreUsuario.Focus();
                MessageBox.Show("El nombre de usuario es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) && modo == "Alta")
            {
                txtPassword.Focus();
                MessageBox.Show("La contraseña es requerida.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                usuarioSeleccionado = dgvUsuarios.CurrentRow.DataBoundItem as BEUsuario;

                if (usuarioSeleccionado == null)
                {
                    MessageBox.Show("Error al obtener el usuario seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bllUsuario.DesactivarUsuario(usuarioSeleccionado);

                MessageBox.Show("Usuario desactivado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListarUsuarios();
                LimpiarInputs();
                usuarioSeleccionado = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_activar_Click(object sender, EventArgs e)
        {
            try {
                if (dgvUsuarios.CurrentRow == null) 
                {
                    MessageBox.Show("Debe seleccionar un usuario.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                usuarioSeleccionado = dgvUsuarios.CurrentRow.DataBoundItem as BEUsuario;

                if (usuarioSeleccionado == null)
                {
                    MessageBox.Show("Error al obtener el usuario seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                bllUsuario.ActivarUsuario(usuarioSeleccionado);

                MessageBox.Show("Usuario activado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListarUsuarios();
                LimpiarInputs();
                usuarioSeleccionado = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.CurrentRow == null) 
                {
                    MessageBox.Show("Debe seleccionar un usuario.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                usuarioSeleccionado = dgvUsuarios.CurrentRow.DataBoundItem as BEUsuario;

                if (usuarioSeleccionado == null)
                {
                    MessageBox.Show("Error al obtener el usuario seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult resultado = MessageBox.Show(
                $"¿Está seguro que desea eliminar al usuario '{usuarioSeleccionado.NombreUsuario}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                {
                    return;
                }

                bllUsuario.EliminarUsuario(usuarioSeleccionado);
                MessageBox.Show("Usuario eliminado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListarUsuarios(); 
                LimpiarInputs();
                usuarioSeleccionado = null; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetearPass_Click(object sender, EventArgs e)
        {
            try {
                if (dgvUsuarios.CurrentRow == null) 
                {
                    MessageBox.Show("Debe seleccionar un usuario.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                usuarioSeleccionado = dgvUsuarios.CurrentRow.DataBoundItem as BEUsuario;
               
                if (usuarioSeleccionado == null)
                {
                    MessageBox.Show("Error al obtener el usuario seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bllUsuario.ResetearPassword(usuarioSeleccionado);
                MessageBox.Show("Contraseña reseteada exitosamente. La nueva contraseña es '1234'.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarInputs();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
