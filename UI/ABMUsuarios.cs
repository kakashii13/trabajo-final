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
            dgv_users.DataSource = usuarios;
            dgv_users.Columns["Password"].Visible = false;
            dgv_users.Columns["Eliminado"].Visible = false;
        }
        private void LimpiarInputs()
        {
            txt_nombre.Enabled = false;
            txt_apellido.Enabled = false;
            txt_user_nombre.Enabled = false;
            txt_password.Enabled = false;
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_user_nombre.Text = "";
            txt_password.Text = "";
        }
        private void HabilitarInputs()
        {
            txt_nombre.Enabled = true;
            txt_apellido.Enabled = true;
            txt_user_nombre.Enabled = true;
        }
        private void HabilitarAcciones()
        {
            add_user.Enabled = true;
            btnInactivar.Enabled = true;
            mod_user.Enabled = true;
        }
        private void DeshabilitarAcciones()
        {
            add_user.Enabled = false;
            btnInactivar.Enabled = false;
            mod_user.Enabled = false;
        }
        private void CargarDatosUsuario(BEUsuario usuario)
        {
            txt_nombre.Text = usuario.Nombre;
            txt_apellido.Text = usuario.Apellido;
            txt_user_nombre.Text = usuario.NombreUsuario;
        }
        // habilita el formulario para crear un usuario
        private void add_user_Click(object sender, EventArgs e)
        {
            // comportamiento UI
            btn_cancel.Enabled = true;
            btn_save.Enabled = true;
            
            // seteamos una password por default para nuevos usuarios
            txt_password.Text = "1234";
            txt_password.Enabled = true;

            DeshabilitarAcciones();
            HabilitarInputs();
            modo = "Alta";
        }
        // habilita el formulario para modificar un usuario
        private void mod_user_Click(object sender, EventArgs e)
        {
            try
            {
                modo = "Modificacion";
                // llenamos los campos con datos del usuario seleccionado
                if (dgv_users.CurrentRow == null) { return; }
                
                usuarioSeleccionado = dgv_users.CurrentRow.DataBoundItem as BEUsuario;

                if (usuarioSeleccionado == null) { return; }
                
                CargarDatosUsuario(usuarioSeleccionado);

                // comportamiento UI
                btn_cancel.Enabled = true;
                btn_save.Enabled = true;
                DeshabilitarAcciones();
                HabilitarInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // guardar cambios o nuevo usuario
        private void btn_save_Click(object sender, EventArgs e)
        {
            try {
                // validamos los campos
                if (!ValidarCamposUI()) { return; }
                    

                var nombre = txt_nombre.Text.Trim();
                var apellido = txt_apellido.Text.Trim();
                var nombreUsuario = txt_user_nombre.Text.Trim().ToLower();
                var password = txt_password.Text;

                if (modo == "Alta")
                {
                    BEUsuario usuario = new BEUsuario(nombre, apellido, password, nombreUsuario, 0, true, false);
                    bllUsuario.CrearUsuario(usuario);

                    MessageBox.Show("Usuario creado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (modo == "Modificacion")
                {
                    usuarioSeleccionado.ActualizarDatos(nombre, apellido,nombreUsuario);
                    bllUsuario.ModificarUsuario(usuarioSeleccionado);

                    MessageBox.Show("Usuario modificado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarInputs();
                btn_save.Enabled = false;
                btn_cancel.Enabled = false;
                HabilitarAcciones();
                modo = null;
                ListarUsuarios();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // cancela la operacion en curso
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = false;
            btn_cancel.Enabled = false;
            HabilitarAcciones();
            LimpiarInputs();
        }
        // actualiza el listado de usuarios
        private void btn_update_Click(object sender, EventArgs e)
        {
             ListarUsuarios();
        }
        private bool ValidarCamposUI()
        {
            if (string.IsNullOrWhiteSpace(txt_nombre.Text))
            {
                txt_nombre.Focus();
                MessageBox.Show("El nombre es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;  
            }

            if (string.IsNullOrWhiteSpace(txt_apellido.Text))
            {
                txt_apellido.Focus();
                MessageBox.Show("El apellido es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
            if (string.IsNullOrWhiteSpace(txt_user_nombre.Text))
            {
                txt_user_nombre.Focus();
                MessageBox.Show("El nombre de usuario es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(string.IsNullOrEmpty(txt_password.Text) && modo == "Alta")
            {
                txt_password.Focus();
                MessageBox.Show("La contraseña es requerida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                usuarioSeleccionado = dgv_users.CurrentRow.DataBoundItem as BEUsuario;

                if (usuarioSeleccionado == null) { return; }
                bllUsuario.DesactivarUsuario(usuarioSeleccionado);

                MessageBox.Show("Usuario desactivado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_activar_Click(object sender, EventArgs e)
        {
            try {
                usuarioSeleccionado = dgv_users.CurrentRow.DataBoundItem as BEUsuario;

                if (usuarioSeleccionado == null) { return; }
                bllUsuario.ActivarUsuario(usuarioSeleccionado);

                MessageBox.Show("Usuario activado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarInputs();
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
                usuarioSeleccionado = dgv_users.CurrentRow.DataBoundItem as BEUsuario;
                if (usuarioSeleccionado == null) { return; }

                bllUsuario.EliminarUsuario(usuarioSeleccionado);
                MessageBox.Show("Usuario eliminado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarInputs();
                ListarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetearPass_Click(object sender, EventArgs e)
        {
            try {
                usuarioSeleccionado = dgv_users.CurrentRow.DataBoundItem as BEUsuario;
                if (usuarioSeleccionado == null) { return; }

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
