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
    public partial class CambiarClave : Form
    {
        BEUsuario usuarioLogueado;
        BLLUsuario bllUsuario = new BLLUsuario();
        public CambiarClave(BEUsuario usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try { 
                string claveActual = txt_current_pass.Text;
                string nuevaClave = txt_new_pass.Text;
                string confirmarClave = txt_confirm_pass.Text;

                if(string.IsNullOrEmpty(claveActual) || string.IsNullOrEmpty(nuevaClave) || string.IsNullOrEmpty(confirmarClave))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(nuevaClave != confirmarClave)
                {
                    MessageBox.Show("La nueva clave y la confirmación no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ServicioSeguridad.Encriptar(claveActual) != usuarioLogueado.Password)
                {
                    MessageBox.Show("La clave actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bllUsuario.CambiarPassword(usuarioLogueado, nuevaClave);

                MessageBox.Show("Clave cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                txt_current_pass.Clear();
                txt_new_pass.Clear();
                txt_confirm_pass.Clear();
            }
            catch (Exception ex) { MessageBox.Show("Error al cambiar la clave: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
