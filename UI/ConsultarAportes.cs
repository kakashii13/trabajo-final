using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ConsultarAportes : Form
    {
        BLLAporte bllAporte;
        BLLAfiliado bllAfiliado;
        List<BEAporte> aportes;
        List<BEAfiliado> afiliados;

        public ConsultarAportes()
        {
            InitializeComponent();
            bllAporte = new BLLAporte();
            bllAfiliado = new BLLAfiliado();

            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                aportes = bllAporte.ListarAportes()
                .OrderByDescending(a => a.FechaRecibido)
                .ToList();
                dgvAportes.DataSource = aportes;

                afiliados = bllAfiliado.ListarAfiliados();
                foreach(var afiliado in afiliados)
                {
                    listaAfiliados.Items.Add(afiliado);
                }

                listaAfiliados.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizarListado_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void list_afiliados_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (listaAfiliados.SelectedItem == null) { return; }

                BEAfiliado afiliadoSeleccionado = (BEAfiliado)listaAfiliados.SelectedItem;

                var aportesFiltrados = aportes.Where(a => a.AfiliadoId == afiliadoSeleccionado.Id).ToList();

                dgvAportes.DataSource = aportesFiltrados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            listaAfiliados.SelectedIndex = -1;

            dgvAportes.DataSource = aportes;
        }
    }
}
