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
    public partial class Backup : Form
    {
        BLLBackup bllBackup;
        BLLBitacora bllBitacora;
        BEUsuario usuarioLogueado;
        public Backup(BEUsuario usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
            bllBackup = new BLLBackup();
            bllBitacora = new BLLBitacora();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try { 
                dgv_backups.DataSource = null;
                dgv_backups.DataSource = bllBitacora.ListarBackups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_backup_Click(object sender, EventArgs e)
        {
            try {

                DialogResult resultado = MessageBox.Show(
                   "¿Está seguro que desea crear un backup?\n\nEsto guardará el estado actual del sistema.",
                   "Confirmar backup",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    return;
                }

                btn_backup.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                bllBackup.CrearBackup(usuarioLogueado);
                MessageBox.Show("Backup realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_backup.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
    }
}
