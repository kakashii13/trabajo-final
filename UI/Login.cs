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

namespace UI
{
    public partial class Login : Form
    {
        BLLUsuario bllUsuario = new BLLUsuario();
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login(object sender, EventArgs e)
        {
            try
            {
                var usuarioTxt = txtUsuario.Text;
                var passwordTxt = txtPassword.Text;

                if (string.IsNullOrWhiteSpace(usuarioTxt) || string.IsNullOrWhiteSpace(passwordTxt))
                {
                    throw new Exception("Debe ingresar usuario y contraseña.");
                }

                // validar que el usuario exista y que la contrasena sea correcta
                BEUsuario usuario = new BEUsuario(usuarioTxt, passwordTxt);

                BEUsuario usuarioLogueado = bllUsuario.ValidarLogin(usuario);

                if(usuarioLogueado == null)
                {
                    throw new Exception("Usuario o contraseña incorrecta.");
                }

                this.Hide();
                Menu menu = new Menu(usuarioLogueado);
                menu.FormClosed += (s, args) => this.Close();
                menu.Show();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
