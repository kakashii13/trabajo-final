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
                    lista_planes.Items.Add(plan);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_listar_Click(object sender, EventArgs e)
        {
            lista_practicas.Items.Clear();
            foreach (var practica in practicas)
            {
                lista_practicas.Items.Add(practica);
            }
        }

        private void lista_planes_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                lista_practicas_plan.Items.Clear();
                txt_plan.Clear();
                txt_practica_plan.Clear();

                if (lista_planes.SelectedIndex == -1) { return; }

                planSeleccionado = (BEPlan)lista_planes.SelectedItem;
                
                // completamos el campo de plan seleccionado
                txt_plan.Text = planSeleccionado.ToString();

                // listamos las practicas del plan seleccionado
                foreach(BEPractica practica in planSeleccionado.Practicas)
                {
                    lista_practicas_plan.Items.Add(practica);
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
                if (lista_practicas.SelectedIndex == -1) { return; }

                practicaDisponibleSeleccionada = (BEPractica)lista_practicas.SelectedItem;

                txt_practica.Text = practicaDisponibleSeleccionada.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_asignar_Click(object sender, EventArgs e)
        {
            try {
                 if(planSeleccionado == null && practicaDisponibleSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar un plan y una práctica.");
                }

                bllPlan.AsignarPractica(planSeleccionado, practicaDisponibleSeleccionada);

                // actualizamos la lista de practicas del plan
                lista_practicas_plan.Items.Add(practicaDisponibleSeleccionada);
                planSeleccionado.Practicas.Add(practicaDisponibleSeleccionada);

                MessageBox.Show("Práctica asignada al plan correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_practica.Clear();
                lista_practicas.ClearSelected();
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
                if(lista_practicas_plan.SelectedIndex == -1) { return; }
               
                practicaSeleccionadoPorPlan = (BEPractica)lista_practicas_plan.SelectedItem;
                txt_practica_plan.Text = practicaSeleccionadoPorPlan.ToString();
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
                if(planSeleccionado == null && practicaSeleccionadoPorPlan == null)
                {
                    throw new Exception("Debe seleccionar un plan y una práctica.");
                }
                bllPlan.QuitarPractica(planSeleccionado, practicaSeleccionadoPorPlan);
                
                // actualizamos la lista de practicas del plan
                lista_practicas_plan.Items.Remove(practicaSeleccionadoPorPlan);
                planSeleccionado.Practicas.Remove(practicaSeleccionadoPorPlan);

                MessageBox.Show("Práctica eliminada del plan correctamente.", "Exito", MessageBoxButtons.OK);
                
                txt_practica_plan.Clear();
                lista_practicas_plan.ClearSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
