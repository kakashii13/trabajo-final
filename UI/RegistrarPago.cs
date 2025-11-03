using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios;

namespace UI
{
    public partial class RegistrarPago : Form
    {
        BLLPago bllPago;
        BLLFactura bllFactura;
        public RegistrarPago()
        {
            InitializeComponent();
            
            bllPago = new BLLPago();
            bllFactura = new BLLFactura();

            CargarDatos();
            CargarFormasDePago();
        }

        private void CargarDatos()
        {
            try {
                listaFacturas.Items.Clear();
                List<BEFactura> facturas = bllFactura.ListarFacturas()
                .Where(f => f.Estado == "Aceptada")
                .OrderByDescending(f => f.FechaRecibida) 
                .ToList();

                foreach (BEFactura factura in facturas)
                {
                    listaFacturas.Items.Add(factura);
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

        private void lista_facturas_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                if (listaFacturas.SelectedItem == null)
                {
                    txtFactura.Clear();
                    txtImporte.Value = 0;
                    return;
                }

                BEFactura factura = (BEFactura)listaFacturas.SelectedItem; 
                txtFactura.Text = factura.Numero.ToString();
                txtImporte.Value = factura.Monto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFormasDePago()
        {
            selectFormaPago.Items.Add("Cheque");
            selectFormaPago.Items.Add("Transferencia Bancaria");
            selectFormaPago.SelectedIndex = 0; 
        }

        private void btnGenerarRecibo_Click(object sender, EventArgs e)
        {
            try { 
                if(listaFacturas.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                if (txtImporte.Value <= 0)
                {
                    throw new Exception("El importe debe ser mayor a cero.");
                }

                if (selectFormaPago.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar una forma de pago.");
                }

                decimal importe = txtImporte.Value;
                BEFactura factura = (BEFactura)listaFacturas.SelectedItem;


                if (importe != factura.Monto)
                {
                    DialogResult resultado = MessageBox.Show(
                        $"El importe ingresado ({importe:C2}) no coincide con el monto de la factura ({factura.Monto:C2}).\n\n¿Desea continuar de todos modos?",
                        "Advertencia",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (resultado != DialogResult.Yes)
                    {
                        return;
                    }
                }

                var fechaPago = this.fechaPago.Value;

                BEPago nuevoPago = new BEPago(0, fechaPago, importe, 0, factura.Id, selectFormaPago.SelectedItem.ToString());

                BEPago pago = bllPago.RegistrarPago(nuevoPago);

                factura.Pago = pago;

                string rutaPDF = ServicioPDF.GenerarPDFRecibo(factura);

                DialogResult resultadoPDF = MessageBox.Show(
                    $"Recibo generado correctamente.\nNúmero de recibo: {pago.NumeroRecibo}\n\n¿Desea abrir el PDF generado?",
                    "Éxito",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
        );

                if (resultadoPDF == DialogResult.Yes)
                {
                    // abrimos el pdf con el lector default
                    System.Diagnostics.Process.Start(rutaPDF);
                }

                txtFactura.Clear();
                txtImporte.Value = 0;
                listaFacturas.ClearSelected();
                selectFormaPago.SelectedIndex = 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
