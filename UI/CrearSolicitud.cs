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
    public partial class CrearSolicitud : Form
    {
        BLLSolicitud bllSolicitud;
        BLLAfiliado bllAfiliado;
        BLLPractica bllPractica;
        BEAfiliado afiliadoSeleccionado;
        public CrearSolicitud()
        {
            InitializeComponent();
            bllSolicitud = new BLLSolicitud();
            bllAfiliado = new BLLAfiliado();
            bllPractica = new BLLPractica();
            CargarData();
        }

        private void CargarData()
        {
            try {
                List<BEAfiliado> afiliados = bllAfiliado.ListarAfiliados();
                foreach (BEAfiliado afiliado in afiliados)
                {
                    lista_afiliados.Items.Add(afiliado);
                }
                combo_practicas.DataSource = bllPractica.ListarPracticas(); 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarFormulario()
        {
            afiliadoSeleccionado = null;
            txt_cuil.Clear();
            lista_afiliados.ClearSelected(); 
            combo_practicas.SelectedIndex = -1; 
            date_solicitud.Value = DateTime.Now;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try {
                if(afiliadoSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un afiliado.",
               "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (combo_practicas.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una práctica.",
                 "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (date_solicitud.Value > DateTime.Now)
                {
                    MessageBox.Show("La fecha de solicitud no puede ser futura.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaSolicitud = date_solicitud.Value;
                BEPractica practicaSeleccionada = (BEPractica)combo_practicas.SelectedItem;

                BESolicitud solicitud = new BESolicitud(0, fechaSolicitud, null, null, afiliadoSeleccionado, practicaSeleccionada);

                bllSolicitud.CrearSolicitud(solicitud);

                MessageBox.Show("Solicitud creada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lista_afiliados_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                if (lista_afiliados.SelectedItem == null)
                {
                    afiliadoSeleccionado = null; 
                    txt_cuil.Clear();            
                    return;
                }
                afiliadoSeleccionado = (BEAfiliado)lista_afiliados.SelectedItem;
                txt_cuil.Text = afiliadoSeleccionado.Cuil;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
