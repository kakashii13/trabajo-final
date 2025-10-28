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
                dgv_facturas.DataSource = null;

                facturas = bllFactura.ListarFacturas();

                dgv_facturas.DataSource = facturas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_pendientes_Click(object sender, EventArgs e)
        {
            try {
                dgv_facturas.DataSource = null;
                var facturasFiltradas = facturas.Where(f => f.Estado == "Pendiente").ToList();
                dgv_facturas.DataSource = facturasFiltradas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void btn_aceptadas_Click(object sender, EventArgs e)
        {
            try {
                dgv_facturas.DataSource = null;
                var facturasFiltradas = facturas.Where(f => f.Estado == "Aceptada").ToList();
                dgv_facturas.DataSource = facturasFiltradas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_rechazadas_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_facturas.DataSource = null;
                var facturasFiltradas = facturas.Where(f => f.Estado == "Rechazada").ToList();
                dgv_facturas.DataSource = facturasFiltradas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPagas_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_facturas.DataSource = null;
                var facturasFiltradas = facturas.Where(f => f.Estado == "Pagada").ToList();
                dgv_facturas.DataSource = facturasFiltradas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_validar_importe_Click(object sender, EventArgs e)
        {
            try { 
                if(facturaSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                if (facturaSeleccionada.Estado != "Pendiente")
                {
                    throw new Exception("Solo se pueden validar facturas en estado Pendiente.");
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

                if(facturaSeleccionada.Estado != "Pendiente")
                {
                    throw new Exception("Solo se pueden validar facturas en estado Pendiente.");
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

                if (facturaSeleccionada.Estado != "Pendiente")
                {
                    throw new Exception("Solo se pueden rechazar facturas en estado Pendiente.");
                }

                bllFactura.RechazarFactura(facturaSeleccionada);
                
                MessageBox.Show("Factura rechazada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                CargarDatos();

                facturaSeleccionada = null;
                btn_rechazar.Enabled = false;
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

                if (facturaSeleccionada.Estado != "Pendiente")
                {
                    throw new Exception("Solo se pueden aceptar facturas en estado Pendiente.");
                }

                facturaSeleccionada.Estado = "Aceptada";
                bllFactura.ActualizarFactura(facturaSeleccionada);
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
                if (dgv_facturas.CurrentRow == null) { return; }

                facturaSeleccionada = dgv_facturas.CurrentRow.DataBoundItem as BEFactura;

                if(facturaSeleccionada.ImporteValidado && facturaSeleccionada.AutorizacionValidada && facturaSeleccionada.Estado == "Pendiente")
                {
                    btn_aceptar.Enabled = true;
                }
                else
                {
                    btn_aceptar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
