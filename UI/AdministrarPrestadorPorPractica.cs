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
    public partial class AdministrarPrestadorPorPractica : Form
    {
        BLLPrestador bllPrestador;
        BLLPractica bllPractica;
        List<BEPractica> practicas;
        BEPrestador prestadorSeleccionado;
        BEPractica practicaSeleccionadoPorPrestador;
        BEPractica practicaDisponibleSeleccionada;
        public AdministrarPrestadorPorPractica()
        {
            InitializeComponent();
            bllPractica = new BLLPractica();
            bllPrestador = new BLLPrestador();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                practicas = bllPractica.ListarPracticas();

                List<BEPrestador> prestadores = bllPrestador.ListarPrestadoresCompletos();

                foreach (var prestador in prestadores)
                {
                     listaPrestadores.Items.Add(prestador);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lista_prestadores_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                listaPracticasPrestador.Items.Clear();
                txtPrestadorSeleccionado.Clear();
                txtPracticaPrestador.Clear();

                if (listaPrestadores.SelectedItem == null) {
                    prestadorSeleccionado = null;
                    return;
                }

                prestadorSeleccionado = (BEPrestador)listaPrestadores.SelectedItem;

                txtPrestadorSeleccionado.Text = prestadorSeleccionado.ToString();

                foreach (BEPractica practica in prestadorSeleccionado.Practicas)
                {
                    listaPracticasPrestador.Items.Add(practica);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lista_practicas_prestador_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (listaPracticasPrestador.SelectedItem == null) {
                    practicaSeleccionadoPorPrestador = null; 
                    return;
                }

                practicaSeleccionadoPorPrestador = (BEPractica)listaPracticasPrestador.SelectedItem;
                txtPracticaPrestador.Text = practicaSeleccionadoPorPrestador.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_listar_Click_1(object sender, EventArgs e)
        {
            listaPracticas.Items.Clear();
            foreach (var practica in practicas)
            {
                listaPracticas.Items.Add(practica);
            }
        }
        private void btn_eliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (prestadorSeleccionado == null || practicaSeleccionadoPorPrestador == null)
                {
                    throw new Exception("Debe seleccionar un prestador y una práctica.");
                }

                DialogResult resultado = MessageBox.Show(
                $"¿Está seguro que desea eliminar '{practicaSeleccionadoPorPrestador.Nombre}' del prestador '{prestadorSeleccionado.RazonSocial}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                {
                    return;
                }

                bllPrestador.QuitarPractica(prestadorSeleccionado, practicaSeleccionadoPorPrestador);

                listaPracticasPrestador.Items.Remove(practicaSeleccionadoPorPrestador);

                txtPracticaPrestador.Clear();
                listaPracticasPrestador.ClearSelected();

                MessageBox.Show("Práctica eliminada del prestador correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_asignar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (prestadorSeleccionado == null || practicaDisponibleSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar un prestador y una práctica.");
                }

                bllPrestador.AsignarPractica(prestadorSeleccionado, practicaDisponibleSeleccionada);

                listaPracticasPrestador.Items.Add(practicaDisponibleSeleccionada);

                MessageBox.Show("Práctica asignada al prestador correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNuevaPractica.Clear();
                listaPracticas.ClearSelected();
                practicaDisponibleSeleccionada = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lista_practicas_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (listaPracticas.SelectedItem == null)
                {
                    practicaDisponibleSeleccionada = null; 
                    txtNuevaPractica.Clear();
                    return;
                }

                practicaDisponibleSeleccionada = (BEPractica)listaPracticas.SelectedItem;

                txtNuevaPractica.Text = practicaDisponibleSeleccionada.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
