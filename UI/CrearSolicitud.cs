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
        BEAfiliado afiliadoSeleccionado;
        BEPlan planAfiliado;
        public CrearSolicitud()
        {
            InitializeComponent();
            bllSolicitud = new BLLSolicitud();
            bllAfiliado = new BLLAfiliado();
            CargarData();
        }

        private void CargarData()
        {
            try {
                List<BEAfiliado> afiliados = bllAfiliado.ListarAfiliados();
                foreach (BEAfiliado afiliado in afiliados)
                {
                    listaAfiliados.Items.Add(afiliado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarFormulario()
        {
            afiliadoSeleccionado = null;
            txtCuil.Clear();
            listaAfiliados.ClearSelected(); 
            selectPracticas.SelectedIndex = -1; 
            fechaSolicitud.Value = DateTime.Now;
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
                if (selectPracticas.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una práctica.",
                 "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.fechaSolicitud.Value > DateTime.Now)
                {
                    MessageBox.Show("La fecha de solicitud no puede ser futura.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fecha = fechaSolicitud.Value.Date;
                BEPractica practicaSeleccionada = (BEPractica)selectPracticas.SelectedItem;

                BESolicitud solicitud = new BESolicitud(0, fecha, null, null, afiliadoSeleccionado, practicaSeleccionada);

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
                if (listaAfiliados.SelectedItem == null)
                {
                    afiliadoSeleccionado = null; 
                    txtCuil.Clear();            
                    return;
                }
                afiliadoSeleccionado = (BEAfiliado)listaAfiliados.SelectedItem;
                txtCuil.Text = afiliadoSeleccionado.Cuil;


                selectPracticas.DataSource = null;

                planAfiliado = bllAfiliado.ObtenerPlanActualAfiliado(afiliadoSeleccionado);
                txtPlan.Text = planAfiliado.Nombre;
                selectPracticas.DataSource = planAfiliado.Practicas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
