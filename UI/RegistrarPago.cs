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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try { 
                if(lista_facturas.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                if(string.IsNullOrWhiteSpace(txt_importe.Text) || string.IsNullOrWhiteSpace(txt_numero_recibo.Text))
                {
                    throw new Exception("Debe completar todos los campos.");
                }

                if(!decimal.TryParse(txt_importe.Text, out decimal importeFactura))
                {
                    throw new Exception("El importe debe ser un número válido.");
                }

                var importe = decimal.Parse(txt_importe.Text);
                var numeroRecibo = int.Parse(txt_numero_recibo.Text);
                var fechaPago = fecha_pago.Value;
                BEFactura factura = (BEFactura)lista_facturas.SelectedItem;

                bllPago.RegistrarPago(importe, numeroRecibo, fechaPago, factura);
                MessageBox.Show("Pago registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                txt_factura.Clear();
                txt_importe.Value = 0;
                txt_numero_recibo.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
