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
        BEUsuario usuarioLogueado;
        public Restore(BEUsuario usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
            bllBackup = new BLLBackup();
            CargarDatos();
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
        private void btnActualizarListado_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_restore_Click(object sender, EventArgs e)
        {
            try
            {
                if (lista_backups.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un backup para restaurar.");
                }

                string backupSeleccionado = lista_backups.SelectedItem.ToString();

                DialogResult resultado = MessageBox.Show(
                $"ADVERTENCIA\n\n" +
                $"Está a punto de restaurar el backup:\n'{backupSeleccionado}'\n\n" +
                $"Esta acción sobreescribirá todos los datos actuales del sistema.\n\n" +
                $"¿Está seguro que desea continuar?",
                "Confirmar restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

                if (resultado != DialogResult.Yes)
                {
                    return;
                }

                btn_restore.Enabled = false;
                btn_cancelar.Enabled = false;
                lista_backups.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                bllBackup.RestaurarBackup(usuarioLogueado, backupSeleccionado);
                MessageBox.Show("Backup restaurado con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_restore.Enabled = true;
                btn_cancelar.Enabled = true;
                lista_backups.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
    }
}
