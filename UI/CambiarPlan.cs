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
    public partial class CambiarPlan : Form
    {
        BLLAfiliado bllAfiliado;
        BEAfiliado afiliadoSeleccionado;
        BEPlan planSugerido;
        BLLPlan bllPlan;
        BLLAporte bllAporte;
        public CambiarPlan(BEAfiliado afiliadoSeleccionado)
        {
            InitializeComponent();
            this.afiliadoSeleccionado = afiliadoSeleccionado;

            bllAfiliado = new BLLAfiliado();
            bllPlan = new BLLPlan();
            bllAporte = new BLLAporte();
           
            CargarDatosFormulario();
        }

        private void CargarDatosFormulario()
        {
            try
            {
                dgvAportes.DataSource = bllAporte.ObtenerAportesPorAfiliado(afiliadoSeleccionado);

                fechaVigencia.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);

                BEPlan planActual = afiliadoSeleccionado.ObtenerPlanActual().Plan;
                txtPlanActual.Text = planActual?.Nombre ?? "Sin plan";

                planSugerido = bllPlan.ObtenerPlanPorId(afiliadoSeleccionado.PlanSugeridoId ?? 0);
                txtNuevoPlan.Text = planSugerido?.Nombre ?? "No disponible";
               
                btnGuardar.Enabled = planSugerido != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try {
                if (planSugerido == null)
                {
                    throw new Exception("No hay un plan sugerido para asignar.");
                }

                bllAfiliado.CambiarPlan(afiliadoSeleccionado, planSugerido);
                
                MessageBox.Show("Cambio de plan realizado con éxito.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
