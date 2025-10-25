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
using System.IO;
using Servicios;

namespace UI
{
    public partial class RegistrarFactura : Form
    {
        BLLPrestador bllPrestadores;
        BLLFactura bllFactura;
        BEPrestador prestadorSeleccionado;
        private string rutaPDFSeleccionado;
        public RegistrarFactura()
        {
            InitializeComponent();
            bllPrestadores = new BLLPrestador();
            bllFactura = new BLLFactura();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try { 
                List<BEPrestador> prestadores = bllPrestadores.ListarPrestadores();
                foreach(BEPrestador prestador in prestadores)
                {
                    lista_prestadores.Items.Add(prestador);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lista_prestadores_SelectedValueChanged(object sender, EventArgs e)
        {
            try { 
                if(lista_prestadores.SelectedItems == null) { return; }
                prestadorSeleccionado = (BEPrestador)lista_prestadores.SelectedItem;
                if(prestadorSeleccionado == null) { return; }
                txt_prestador.Text = prestadorSeleccionado.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try {
                if (!ValidarCamposUI())
                    return;

                int numero_autorizacion = int.Parse(txt_numero_autorizacion.Text.Trim());
                int numero_factura = int.Parse(txt_numero_factura.Text.Trim());
                decimal monto = decimal.Parse(txt_monto.Text.Trim());
                DateTime fecha = fecha_factura.Value.Date;
                string observacion = txt_observacion.Text.Trim();

                string rutaPDFGuardado = null;
                if (!string.IsNullOrEmpty(rutaPDFSeleccionado))
                {
                    rutaPDFGuardado = CopiarPDFFactura(numero_factura, rutaPDFSeleccionado);
                }

                BEAutorizacion autorizacion = new BEAutorizacion(numero_autorizacion);
                BEFactura factura = new BEFactura(0, fecha, monto, numero_factura, observacion, null, prestadorSeleccionado, autorizacion, rutaPDFGuardado);

                bllFactura.CrearFactura(factura);
             
                MessageBox.Show("Factura registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarInputs()
        {
            txt_monto.Value = 0;
            txt_numero_autorizacion.Value = 0;
            txt_numero_factura.Value = 0;
            txt_observacion.Clear();
            txt_prestador.Clear();
            lista_prestadores.ClearSelected();
            prestadorSeleccionado = null;
            rutaPDFSeleccionado = null;
            txtArchivo.Text = "";
        }
        private string CopiarPDFFactura(int numeroFactura, string rutaArchivoOriginal)
        {
            try
            {
                // creamos la carpeta si no existe
                string carpetaPDFs = Path.Combine(ServicioDirectorio.RutaPDFs, "Facturas");

                if (!Directory.Exists(carpetaPDFs))
                    Directory.CreateDirectory(carpetaPDFs);

                // nombre unico para el archivo
                string extension = Path.GetExtension(rutaArchivoOriginal);
                string nombreArchivo = $"Factura_{numeroFactura}_{DateTime.Now:yyyyMMdd_HHmmss}{extension}";
                string rutaDestino = Path.Combine(carpetaPDFs, nombreArchivo);

                // copiamos el archivo
                File.Copy(rutaArchivoOriginal, rutaDestino, true);

                return rutaDestino;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al copiar el archivo PDF: {ex.Message}");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCamposUI()
        {
            if (prestadorSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un prestador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txt_numero_autorizacion.Text.Trim(), out int numero_autorizacion) || numero_autorizacion <= 0)
            {
                MessageBox.Show("El número de autorización es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txt_numero_factura.Text.Trim(), out int numero_factura) || numero_factura <= 0)
            {
                MessageBox.Show("El número de factura es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!decimal.TryParse(txt_monto.Text.Trim(), out decimal monto) || monto <= 0)
            {
                MessageBox.Show("El monto debe ser un número decimal positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (fecha_factura.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de la factura no puede ser futura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(rutaPDFSeleccionado == null)
            {
                MessageBox.Show("Debe adjuntar el archivo PDF de la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAdjuntarFactura_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar PDF de la factura";
                openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    rutaPDFSeleccionado = openFileDialog.FileName;

                    txtArchivo.Text = Path.GetFileName(rutaPDFSeleccionado);

                    MessageBox.Show($"Archivo seleccionado: {Path.GetFileName(rutaPDFSeleccionado)}",
                        "Archivo cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
