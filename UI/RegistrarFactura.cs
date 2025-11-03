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
                List<BEPrestador> prestadores = bllPrestadores.ListarPrestadores()
                    .OrderBy(p => p.RazonSocial) 
                    .ToList();

                foreach (BEPrestador prestador in prestadores)
                {
                    listaPrestadores.Items.Add(prestador);
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
                if (listaPrestadores.SelectedItem == null) 
                {
                    prestadorSeleccionado = null;
                    txtPrestador.Clear();
                    return;
                }

                prestadorSeleccionado = (BEPrestador)listaPrestadores.SelectedItem;
                txtPrestador.Text = prestadorSeleccionado.ToString();
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

                int numero_autorizacion = (int)txtNumeroAutorizacion.Value;
                int numero_factura = (int)txtNumeroFactura.Value;
                decimal monto = txtMonto.Value;
                DateTime fecha = fechaFactura.Value.Date;
                string observacion = txtObservacion.Text.Trim();

                string rutaPDFGuardado = null;
               
                rutaPDFGuardado = CopiarPDFFactura(numero_factura, rutaPDFSeleccionado);

                BEAutorizacion autorizacion = new BEAutorizacion(numero_autorizacion);
                BEFactura factura = new BEFactura(0, fecha, monto, numero_factura, observacion, null, prestadorSeleccionado, autorizacion, rutaPDFGuardado, false, false);

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
            txtMonto.Value = 0;
            txtNumeroAutorizacion.Value = 0;
            txtNumeroFactura.Value = 0;
            txtObservacion.Clear();
            txtPrestador.Clear();
            listaPrestadores.ClearSelected();
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
            if (txtNumeroAutorizacion.Value <= 0)
            {
                MessageBox.Show("El número de autorización debe ser mayor a cero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeroAutorizacion.Focus();
                return false;
            }

            if (txtNumeroFactura.Value <= 0)
            {
                MessageBox.Show("El número de factura debe ser mayor a cero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeroFactura.Focus();
                return false;
            }

            if (txtMonto.Value <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMonto.Focus();
                return false;
            }

            if (fechaFactura.Value.Date > DateTime.Now.Date)
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

        private void btnRemoverPdf_Click(object sender, EventArgs e)
        {
           if(rutaPDFSeleccionado != null)
            {
                rutaPDFSeleccionado = null;
                txtArchivo.Text = "";
                MessageBox.Show("Archivo removido.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("No hay ningún archivo seleccionado.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
