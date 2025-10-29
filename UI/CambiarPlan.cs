﻿using System;
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
                // aportes del afiliado
                list_aportes.DataSource = bllAporte.ObtenerAportesPorAfiliado(afiliadoSeleccionado);

                // fecha sugerida
                date_time.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);

                // plan actual
                BEPlan planActual = afiliadoSeleccionado.ObtenerPlanActual().Plan;
                txt_plan.Text = planActual?.Nombre ?? "Sin plan";

                // plan sugerido
                planSugerido = bllPlan.ObtenerPlanPorId(afiliadoSeleccionado.PlanSugeridoId ?? 0);
                txt_nuevo_plan.Text = planSugerido?.Nombre ?? "No disponible";
               
                btn_save.Enabled = planSugerido != null;
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

                // cerramos el formulario con resultado OK
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
