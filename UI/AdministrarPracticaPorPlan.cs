using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class AdministrarPracticaPorPlan : Form
    {
        BLLPlan bllPlan;
        BLLPractica bllPractica;
        List<BEPractica> practicas;
        BEPlan planSeleccionado;
        BEPractica practicaSeleccionadoPorPlan;
        BEPractica practicaDisponibleSeleccionada;
        public AdministrarPracticaPorPlan()
        {
            InitializeComponent();
            bllPlan = new BLLPlan();
            bllPractica = new BLLPractica();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try {

               practicas = bllPractica.ListarPracticas();

               List<BEPlan> planes = bllPlan.ListarPlanesCompletos();

                foreach (var plan in planes)
                {
                    listaPlanes.Items.Add(plan);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_listar_Click(object sender, EventArgs e)
        {
            listaPracticas.Items.Clear();
            foreach (var practica in practicas)
            {
                listaPracticas.Items.Add(practica);
            }
        }

        private void lista_planes_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                listaPracticasPlan.Items.Clear();
                txtPlanSeleccionado.Clear();
                txtPracticaPlan.Clear();

                if (listaPlanes.SelectedItem == null) { 
                    planSeleccionado = null;
                    return;
                }

                planSeleccionado = (BEPlan)listaPlanes.SelectedItem;
                
                
                txtPlanSeleccionado.Text = planSeleccionado.ToString();

                
                foreach(BEPractica practica in planSeleccionado.Practicas)
                {
                    listaPracticasPlan.Items.Add(practica);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lista_practicas_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                if (listaPracticas.SelectedItem == null) {
                    practicaDisponibleSeleccionada = null; 
                    txtPracticaSeleccionada.Clear();
                    return;
                }

                practicaDisponibleSeleccionada = (BEPractica)listaPracticas.SelectedItem;

                txtPracticaSeleccionada.Text = practicaDisponibleSeleccionada.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_asignar_Click(object sender, EventArgs e)
        {
            try {
                 if(planSeleccionado == null || practicaDisponibleSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar un plan y una práctica.");
                }

                bllPlan.AsignarPractica(planSeleccionado, practicaDisponibleSeleccionada);

                listaPracticasPlan.Items.Add(practicaDisponibleSeleccionada);

                MessageBox.Show("Práctica asignada al plan correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPracticaSeleccionada.Clear();
                listaPracticas.ClearSelected();
                practicaDisponibleSeleccionada = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lista_practicas_plan_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                if(listaPracticasPlan.SelectedItem == null)
                {
                    practicaSeleccionadoPorPlan = null; 
                    txtPracticaPlan.Clear();
                    return;
                }
               
                practicaSeleccionadoPorPlan = (BEPractica)listaPracticasPlan.SelectedItem;
                txtPracticaPlan.Text = practicaSeleccionadoPorPlan.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(planSeleccionado == null || practicaSeleccionadoPorPlan == null)
                {
                    throw new Exception("Debe seleccionar un plan y una práctica.");
                }

                DialogResult resultado = MessageBox.Show(
                $"¿Está seguro que desea eliminar la práctica '{practicaSeleccionadoPorPlan.Nombre}' del plan '{planSeleccionado.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    return;
                }

                bllPlan.QuitarPractica(planSeleccionado, practicaSeleccionadoPorPlan);

                listaPracticasPlan.Items.Remove(practicaSeleccionadoPorPlan);

                MessageBox.Show("Práctica eliminada del plan correctamente.", "Exito", MessageBoxButtons.OK);
                
                txtPracticaPlan.Clear();
                listaPracticasPlan.ClearSelected();
                practicaSeleccionadoPorPlan = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
