using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BLL;
using BE;

namespace UI
{
    public partial class Restore : Form
    {
        BLLBackup bllBackup;
        BLLBitacora bllBitacora;
        BEUsuario usuarioLogueado;
        public Restore(BEUsuario usuarioLogueado)
        {
            InitializeComponent();
            bllBackup = new BLLBackup();
            bllBitacora = new BLLBitacora();
            CargarDatos();
            this.usuarioLogueado = usuarioLogueado;
        }

        private void CargarDatos()
        {
            try {
                lista_backups.Items.Clear();
                List<DirectoryInfo> backups = bllBackup.ListarBackupsDisponibles();

                foreach(DirectoryInfo backup in backups)
                {
                    lista_backups.Items.Add(backup.Name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            try { 
                if(lista_backups.SelectedItem == null)
                {
                   throw new Exception("Debe seleccionar un backup para restaurar.");
                }

                bllBackup.RestaurarBackup(usuarioLogueado, lista_backups.SelectedItem.ToString());
                MessageBox.Show("Backup restaurado con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
