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
                dgvPlanes.DataSource = bllPlan.ListarPlanes();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeshabilitarAcciones()
        {
            btnCrear.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void HabilitarAcciones()
        {
            btnCrear.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void HabilitarInputs()
        {
            txtMonto.Enabled = true;
            txtNombre.Enabled = true;
        }

        private void LimpiarInputs()
        {
            txtNombre.Clear();
            txtMonto.Clear();
            txtMonto.Enabled = false;
            txtNombre.Enabled = false;
        }

        private void add_plan_Click(object sender, EventArgs e)
        {
            // comportamiento UI
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            DeshabilitarAcciones();
            HabilitarInputs();
            modo = "Alta";
        }

        private void mod_plan_Click(object sender, EventArgs e)
        {
            try
            {
                // llenamos los campos con datos del plan seleccionado
                if (dgvPlanes.CurrentRow == null) {
                    MessageBox.Show("Debe seleccionar un plan para modificar.",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                planSeleccionado = dgvPlanes.CurrentRow.DataBoundItem as BEPlan;

                if (planSeleccionado == null) {
                    MessageBox.Show("Error al obtener el plan seleccionado.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtNombre.Text = planSeleccionado.Nombre;
                txtMonto.Text = planSeleccionado.AporteTope.ToString();

                btnCancelar.Enabled = true;
                btnGuardar.Enabled = true;
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
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
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
               if(string.IsNullOrWhiteSpace(txtNombre.Text) ||
                   string.IsNullOrWhiteSpace(txtMonto.Text))
                {
                    throw new Exception("Todos los campos son obligatorios.");
                }

                if (!int.TryParse(txtMonto.Text, out int aporteTope))
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

                var nombre = txtNombre.Text.Trim();

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

                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
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
