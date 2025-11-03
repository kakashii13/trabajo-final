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
    public partial class RegistrarAfiliado : Form
    {
        BLLPlan bllPlan;
        BLLAfiliado bllAfiliado;
        
        public RegistrarAfiliado()
        {
            InitializeComponent();
            bllPlan = new BLLPlan();
            bllAfiliado = new BLLAfiliado();
            CargarPlanes();
        }

        private void CargarPlanes()
        {
            try
            {
                selectPlan.DataSource = bllPlan.ListarPlanes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try {
                var nombre = txtNombre.Text;
                var cuil = txtCuil.Text;
                var telefono = txtTelefono.Text;
                var plan = (BEPlan)selectPlan.SelectedItem;

                if(string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(cuil) || string.IsNullOrWhiteSpace(telefono) || plan == null)
                {
                    throw new Exception("Todos los campos son obligatorios.");
                }

                BEAfiliado afiliado = new BEAfiliado(0, nombre, cuil, true, telefono);

                bllAfiliado.CrearAfiliado(afiliado, plan);

                MessageBox.Show("Afiliado registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCuil.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();
                selectPlan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
