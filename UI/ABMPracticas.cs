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
    public partial class ABMPracticas : Form
    {
        BLLPractica bllPractica;
        BEPractica practicaSeleccionada;
        string modo = null;
        public ABMPracticas()
        {
            InitializeComponent();
            bllPractica = new BLLPractica();
            CargarGrid();
        }

        private void CargarGrid()
        {
            try
            {
                dgvPracticas.DataSource = bllPractica.ListarPracticas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeshabilitarAcciones()
        {
            btnCrear.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void HabilitarAcciones()
        {
            btnCrear.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void HabilitarInputs()
        {
            txtPrecio.Enabled = true;
            txtNombre.Enabled = true;
            txtCodigo.Enabled = true;
        }

        private void LimpiarInputs()
        {
            txtNombre.Clear();
            txtCodigo.Value = 0;
            txtPrecio.Value = 0;
            txtPrecio.Enabled = false;
            txtNombre.Enabled = false;
            txtCodigo.Enabled = false;
        }
        private void add_practica_Click_1(object sender, EventArgs e)
        {
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            DeshabilitarAcciones();
            HabilitarInputs();
            modo = "Alta";
        }

        private void mod_practica_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvPracticas.CurrentRow == null) {
                    MessageBox.Show("Debe seleccionar una práctica para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                

                practicaSeleccionada = dgvPracticas.CurrentRow.DataBoundItem as BEPractica;

                if (practicaSeleccionada == null) {
                    MessageBox.Show("Error al obtener la práctica seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                modo = "Modificacion";
               
                txtNombre.Text = practicaSeleccionada.Nombre;
                txtCodigo.Value = practicaSeleccionada.Codigo;
                txtPrecio.Text = practicaSeleccionada.Precio.ToString();

                btnCancelar.Enabled = true;
                btnGuardar.Enabled = true;
                DeshabilitarAcciones();
                HabilitarInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            practicaSeleccionada = null; 
            modo = null;
            HabilitarAcciones();
            LimpiarInputs();
        }
        private void btn_save_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    throw new Exception("El nombre de la practica es obligatorio.");
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
                {
                    throw new Exception("El precio debe ser un número decimal mayor a 0.");
                }

                if (txtCodigo.Value <= 0)
                {
                    throw new Exception("El código de la practica es obligatorio y debe ser un número mayor a 0.");
                }

                var nombre = txtNombre.Text.Trim();
                var codigo = (int)txtCodigo.Value;

                if (modo == "Alta")
                {
                    BEPractica practica = new BEPractica(0, codigo, nombre, precio);
                    bllPractica.CrearPractica(practica);

                    MessageBox.Show("Practica creada exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (modo == "Modificacion")
                {
                    if (practicaSeleccionada == null)
                    {
                        throw new Exception("No hay una práctica seleccionada para modificar.");
                    }

                    BEPractica practica = new BEPractica(practicaSeleccionada.Id, codigo, nombre, precio);

                    bllPractica.ModificarPractica(practica);

                    MessageBox.Show("Practica modificada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarInputs();
                HabilitarAcciones();
                
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                practicaSeleccionada = null; 
                modo = null;

                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
