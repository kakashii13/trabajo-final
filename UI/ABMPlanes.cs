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
    public partial class ABMPlanes : Form
    {
        BLLPlan bllPlan;
        BEPlan planSeleccionado;
        string modo = null;
        public ABMPlanes()
        {
            InitializeComponent();
            bllPlan = new BLLPlan();

            CargarGrid();
        }

        private void CargarGrid()
        {
            try {
                dg_planes.DataSource = bllPlan.ListarPlanes();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeshabilitarAcciones()
        {
            add_plan.Enabled = false;
            mod_plan.Enabled = false;
        }

        private void HabilitarAcciones()
        {
            add_plan.Enabled = true;
            mod_plan.Enabled = true;
        }

        private void HabilitarInputs()
        {
            txt_monto.Enabled = true;
            txt_nombre.Enabled = true;
        }

        private void LimpiarInputs()
        {
            txt_nombre.Clear();
            txt_monto.Clear();
            txt_monto.Enabled = false;
            txt_nombre.Enabled = false;
        }

        private void add_plan_Click(object sender, EventArgs e)
        {
            // comportamiento UI
            btn_cancel.Enabled = true;
            btn_save.Enabled = true;
            DeshabilitarAcciones();
            HabilitarInputs();
            modo = "Alta";
        }

        private void mod_plan_Click(object sender, EventArgs e)
        {
            try
            {
                // llenamos los campos con datos del plan seleccionado
                if (dg_planes.CurrentRow == null) {
                    MessageBox.Show("Debe seleccionar un plan para modificar.",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                planSeleccionado = dg_planes.CurrentRow.DataBoundItem as BEPlan;

                if (planSeleccionado == null) {
                    MessageBox.Show("Error al obtener el plan seleccionado.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txt_nombre.Text = planSeleccionado.Nombre;
                txt_monto.Text = planSeleccionado.AporteTope.ToString();

                btn_cancel.Enabled = true;
                btn_save.Enabled = true;
                DeshabilitarAcciones();
                HabilitarInputs();
                modo = "Modificacion";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = false;
            btn_cancel.Enabled = false;
            HabilitarAcciones();
            LimpiarInputs();
            modo = null;
            planSeleccionado = null;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                // validamos los campos
               if(string.IsNullOrWhiteSpace(txt_nombre.Text) ||
                   string.IsNullOrWhiteSpace(txt_monto.Text))
                {
                    throw new Exception("Todos los campos son obligatorios.");
                }

                if (!int.TryParse(txt_monto.Text, out int aporteTope))
                {
                    throw new Exception("El monto debe ser un número entero válido.");
                }

                if (aporteTope <= 0)
                {
                    throw new Exception("El monto debe ser mayor a cero.");
                }

                if (aporteTope > 1000000)
                {
                    throw new Exception("El monto no puede superar $1.000.000.");
                }

                var nombre = txt_nombre.Text.Trim();

                if (modo == "Alta")
                {
                    BEPlan plan = new BEPlan(0, nombre, aporteTope);

                    bllPlan.CrearPlan(plan);

                    MessageBox.Show("Plan creado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (modo == "Modificacion")
                {
                    planSeleccionado.Nombre = nombre;
                    planSeleccionado.AporteTope = aporteTope;
                    bllPlan.ModificarPlan(planSeleccionado);

                    MessageBox.Show("Plan modificado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarInputs();
                HabilitarAcciones();

                btn_save.Enabled = false;
                btn_cancel.Enabled = false;
                planSeleccionado = null;
                modo = null;
                
                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
