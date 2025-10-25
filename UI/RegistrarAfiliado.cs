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
                List<BEPlan> planes = bllPlan.ListarPlanes();
                select_plan.DataSource = planes;
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
                var nombre = txt_nombre.Text;
                var cuil = txt_cuil.Text;
                var telefono = txt_tel.Text;
                var plan = (BEPlan)select_plan.SelectedItem;

                if(string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(cuil) || string.IsNullOrWhiteSpace(telefono) || plan == null)
                {
                    throw new Exception("Todos los campos son obligatorios.");
                }

                int nroAfiliado = GenerarNroAfiliado();

                BEAfiliado afiliado = new BEAfiliado(0, nombre, cuil, true, nroAfiliado, telefono);

                bllAfiliado.CrearAfiliado(afiliado, plan);

                MessageBox.Show("Afiliado registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_cuil.Clear();
                txt_nombre.Clear();
                txt_tel.Clear();
                select_plan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GenerarNroAfiliado()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999);
        }
    }
}
