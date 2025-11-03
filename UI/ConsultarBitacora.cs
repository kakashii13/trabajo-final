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
    public partial class ConsultarBitacora : Form
    {
        BLLBitacora bllBitacora;
        List<BEBitacora> bitacoras;
        public ConsultarBitacora()
        {
            InitializeComponent();
            bllBitacora = new BLLBitacora();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try { 
                dgvBitacora.DataSource = null;
                bitacoras = bllBitacora.ListarTodo();
                dgvBitacora.DataSource = bitacoras;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_backups_Click(object sender, EventArgs e)
        {
            dgvBitacora.DataSource = bitacoras.Where(b => b.Operacion == "Backup").ToList();
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            dgvBitacora.DataSource = bitacoras.Where(b => b.Operacion == "Restore").ToList();
        }

        private void btn_todo_Click(object sender, EventArgs e)
        {
            dgvBitacora.DataSource = bitacoras;
        }
    }
}
