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

                List<BEPrestador> prestadores = bllPrestador.ListarPrestadores();

                // aprovechamos el listado de practicas para hidratar las practicas de cada prestador
                foreach (var prestador in prestadores)
                {
                    prestador.Practicas = HidratarPracticasDePrestador(prestador);
                     lista_prestadores.Items.Add(prestador);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<BEPractica> HidratarPracticasDePrestador(BEPrestador prestador)
        {
            try
            {
                List<int> idsPracticas = bllPrestador.ListarPracticasDelPrestador(prestador);

                // buscamos en la lista que ya cargamos de practicas
                return practicas
                    .Where(p => idsPracticas.Contains(p.Id))
                    .ToList();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void lista_prestadores_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                lista_practicas_prestador.Items.Clear();
                txt_prestador.Clear();
                txt_practica_prestador.Clear();

                if (lista_prestadores.SelectedIndex == -1) { return; }

                prestadorSeleccionado = (BEPrestador)lista_prestadores.SelectedItem;

                // completamos el campo de prestador seleccionado
                txt_prestador.Text = prestadorSeleccionado.ToString();

                // listamos las practicas del prestador seleccionado
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
                if (lista_practicas_prestador.SelectedIndex == -1) { return; }

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
                if (prestadorSeleccionado == null && practicaSeleccionadoPorPrestador == null)
                {
                    throw new Exception("Debe seleccionar un prestador y una práctica.");
                }
                bllPrestador.QuitarPractica(prestadorSeleccionado, practicaSeleccionadoPorPrestador);

                // actualizamos la lista de practicas del prestador
                lista_practicas_prestador.Items.Remove(practicaSeleccionadoPorPrestador);
                prestadorSeleccionado.Practicas.Remove(practicaSeleccionadoPorPrestador);

                txt_practica_prestador.Clear();
                lista_practicas_prestador.ClearSelected();

                MessageBox.Show("Práctica eliminada del prestador correctamente.", "Exito", MessageBoxButtons.OK);
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
                if (prestadorSeleccionado == null && practicaDisponibleSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar un prestador y una práctica.");
                }

                bllPrestador.AsignarPractica(prestadorSeleccionado, practicaDisponibleSeleccionada);

                // actualizamos la lista de practicas del prestador
                lista_practicas_prestador.Items.Add(practicaDisponibleSeleccionada);
                prestadorSeleccionado.Practicas.Add(practicaDisponibleSeleccionada);

                txt_practica.Clear();
                lista_practicas.ClearSelected();
                practicaDisponibleSeleccionada = null;
                
                MessageBox.Show("Práctica asignada al prestador correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (lista_practicas.SelectedIndex == -1){ return; }

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
