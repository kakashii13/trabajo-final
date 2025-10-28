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
                lista_facturas.Items.Clear();
                List<BEFactura> facturas = bllFactura.ListarFacturas().Where(f => f.Estado == "Aceptada").ToList();
                foreach(BEFactura factura in facturas)
                {
                    lista_facturas.Items.Add(factura);
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
                if(lista_facturas.SelectedItem == null) { return; }
                txt_factura.Text = ((BEFactura)lista_facturas.SelectedItem).Numero.ToString();
                txt_importe.Value = ((BEFactura)lista_facturas.SelectedItem).Monto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFormasDePago()
        {
            comboFormaPago.Items.Add("Cheque");
            comboFormaPago.Items.Add("Transferencia Bancaria");
            comboFormaPago.SelectedIndex = 0; 
        }

        private void btnGenerarRecibo_Click(object sender, EventArgs e)
        {
            try { 
                if(lista_facturas.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                if(string.IsNullOrWhiteSpace(txt_importe.Text))
                {
                    throw new Exception("Debe completar todos los campos.");
                }

                if(!decimal.TryParse(txt_importe.Text, out decimal importeFactura))
                {
                    throw new Exception("El importe debe ser un número válido.");
                }

                var importe = decimal.Parse(txt_importe.Text);
                
                var fechaPago = fecha_pago.Value;
                BEFactura factura = (BEFactura)lista_facturas.SelectedItem;

                BEPago nuevoPago = new BEPago(0, fechaPago, importe, 0, factura.Id, comboFormaPago.SelectedItem.ToString());

                BEPago pago = bllPago.RegistrarPago(nuevoPago);

                factura.Pago = pago;

                string rutaPDF = ServicioPDF.GenerarPDFRecibo(factura);

                DialogResult resultado = MessageBox.Show(
                    $"Recibo generado correctamente.\nNúmero de recibo: {nuevoPago.NumeroRecibo}\n\n¿Desea abrir el PDF generado?",
                    "Éxito",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
        );

                if (resultado == DialogResult.Yes)
                {
                    // abrimos el pdf con el lector default
                    System.Diagnostics.Process.Start(rutaPDF);
                }

                txt_factura.Clear();
                txt_importe.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
