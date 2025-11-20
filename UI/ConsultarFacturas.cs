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
    public partial class ConsultarFacturas : Form
    {
        BLLFactura bllFactura;
        List<BEFactura> facturas;
        BEFactura facturaSeleccionada;
        public ConsultarFacturas()
        {
            InitializeComponent();
            bllFactura = new BLLFactura();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                dgvFacturas.DataSource = null;

                facturas = bllFactura.ListarFacturas();

                dgvFacturas.DataSource = facturas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizarListado_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void FiltrarPorEstado(string estado)
        {
            try
            {
                dgvFacturas.DataSource = facturas
                    .Where(f => f.Estado == estado)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las facturas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_pendientes_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado("Pendiente");
        } 
        private void btn_aceptadas_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado("Aceptada");
        }
        private void btn_rechazadas_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado("Rechazada");
        }
        private void btnPagas_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado("Pagada");
        }
        private void btn_validar_importe_Click(object sender, EventArgs e)
        {
            try { 
                if(facturaSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                bllFactura.ValidarImporte(facturaSeleccionada);

                MessageBox.Show("Importe validado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                facturaSeleccionada = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }
        private void btn_validar_autorizacion_Click(object sender, EventArgs e)
        {
            try {
                if(facturaSeleccionada == null) { 
                    throw new Exception("Debe seleccionar una factura.");
                }

                bllFactura.ValidarAutorizacion(facturaSeleccionada);

                MessageBox.Show("Autorización validada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                facturaSeleccionada = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar la autorizacion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_rechazar_Click(object sender, EventArgs e)
        {
            try {
                if (facturaSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                DialogResult resultado = MessageBox.Show(
                $"¿Está seguro que desea rechazar la factura N° {facturaSeleccionada.Numero}?",
                "Confirmar rechazo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    return;
                }

                bllFactura.RechazarFactura(facturaSeleccionada);
                
                MessageBox.Show("Factura rechazada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                CargarDatos();

                facturaSeleccionada = null;
                btnRechazar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al rechazar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try { 
                if(facturaSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                bllFactura.AceptarFactura(facturaSeleccionada);

                MessageBox.Show("Factura aceptada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                CargarDatos();
                
                facturaSeleccionada = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aceptar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (dgvFacturas.CurrentRow == null) { return; }

                facturaSeleccionada = dgvFacturas.CurrentRow.DataBoundItem as BEFactura;

                if(facturaSeleccionada.ImporteValidado && facturaSeleccionada.AutorizacionValidada && facturaSeleccionada.Estado == "Pendiente")
                {
                    btnAceptar.Enabled = true;
                }
                else
                {
                    btnAceptar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
