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
    public partial class RegistrarAporte : Form
    {
        BLLAporte bllAporte;
        BLLAfiliado bllAfiliado;
        public RegistrarAporte()
        {
            InitializeComponent();
            bllAporte = new BLLAporte();
            bllAfiliado = new BLLAfiliado();

            CargarDatos();

            // formateo el dateTimePicker para que solo muestre mes y año
            fechaPeriodo.Format = DateTimePickerFormat.Custom;
            fechaPeriodo.CustomFormat = "MM/yyyy";  
            fechaPeriodo.ShowUpDown = true;
        }

        private void CargarDatos()
        {
            try
            {
                // cargar listado de afiliados
                List<BEAfiliado> afiliados = bllAfiliado.ListarAfiliados();
                foreach (BEAfiliado af in afiliados)
                {
                    listaAfiliados.Items.Add(af);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try { 
                var cuil = txtCuil.Text;
                var periodo = fechaPeriodo.Value;
                var monto = Convert.ToDecimal(txtMonto.Text);

                if(string.IsNullOrEmpty(cuil) || monto <= 0)
                {
                    throw new Exception("Por favor, complete todos los campos correctamente.");
                }

                BEAfiliado afiliado = bllAfiliado.ObtenerAfiliadoPorCuil(cuil);
                BEAporte aporte = new BEAporte(0, monto, DateTime.Now, periodo, afiliado.Id);

                bllAporte.CrearAporte(aporte);

                MessageBox.Show("Aporte registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // limpiamos los campos
                txtCuil.Clear();
                txtMonto.Clear();
                fechaPeriodo.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void list_afiliados_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                if(listaAfiliados.SelectedItem == null) { return; }

                var cuilSeleccionado = (BEAfiliado)listaAfiliados.SelectedItem;
                txtCuil.Text = cuilSeleccionado.Cuil;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
