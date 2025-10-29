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
                     lista_prestadores.Items.Add(prestador);
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
                lista_practicas_prestador.Items.Clear();
                txt_prestador.Clear();
                txt_practica_prestador.Clear();

                if (lista_prestadores.SelectedItem == null) {
                    prestadorSeleccionado = null;
                    return;
                }

                prestadorSeleccionado = (BEPrestador)lista_prestadores.SelectedItem;

                txt_prestador.Text = prestadorSeleccionado.ToString();

                foreach (BEPractica practica in prestadorSeleccionado.Practicas)
                {
                    lista_practicas_prestador.Items.Add(practica);
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
                if (lista_practicas_prestador.SelectedItem == null) {
                    practicaSeleccionadoPorPrestador = null; 
                    return;
                }

                practicaSeleccionadoPorPrestador = (BEPractica)lista_practicas_prestador.SelectedItem;
                txt_practica_prestador.Text = practicaSeleccionadoPorPrestador.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_listar_Click_1(object sender, EventArgs e)
        {
            lista_practicas.Items.Clear();
            foreach (var practica in practicas)
            {
                lista_practicas.Items.Add(practica);
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

                // actualizamos la lista de practicas del prestador
                lista_practicas_prestador.Items.Remove(practicaSeleccionadoPorPrestador);

                txt_practica_prestador.Clear();
                lista_practicas_prestador.ClearSelected();

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

                lista_practicas_prestador.Items.Add(practicaDisponibleSeleccionada);

                MessageBox.Show("Práctica asignada al prestador correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_practica.Clear();
                lista_practicas.ClearSelected();
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
                if (lista_practicas.SelectedItem == null)
                {
                    practicaDisponibleSeleccionada = null; 
                    txt_practica.Clear();
                    return;
                }

                practicaDisponibleSeleccionada = (BEPractica)lista_practicas.SelectedItem;

                txt_practica.Text = practicaDisponibleSeleccionada.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
