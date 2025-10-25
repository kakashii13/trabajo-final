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
                dg_practicas.DataSource = bllPractica.ListarPracticas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeshabilitarAcciones()
        {
            add_practica.Enabled = false;
            mod_practica.Enabled = false;
        }

        private void HabilitarAcciones()
        {
            add_practica.Enabled = true;
            mod_practica.Enabled = true;
        }

        private void HabilitarInputs()
        {
            txt_precio.Enabled = true;
            txt_nombre.Enabled = true;
            txt_codigo.Enabled = true;
        }

        private void LimpiarInputs()
        {
            txt_nombre.Clear();
            txt_codigo.Value = 0;
            txt_precio.Value = 0;
            txt_precio.Enabled = false;
            txt_nombre.Enabled = false;
            txt_codigo.Enabled = false;
        }
        private void add_practica_Click_1(object sender, EventArgs e)
        {
            // comportamiento UI
            btn_cancel.Enabled = true;
            btn_save.Enabled = true;
            DeshabilitarAcciones();
            HabilitarInputs();
            modo = "Alta";
        }

        private void mod_practica_Click_1(object sender, EventArgs e)
        {
            try
            {
                modo = "Modificacion";
                // llenamos los campos con datos de la practica seleccionada
                if (dg_practicas.CurrentRow == null) { return; }

                practicaSeleccionada = dg_practicas.CurrentRow.DataBoundItem as BEPractica;

                if (practicaSeleccionada == null) { return; }
               
                txt_nombre.Text = practicaSeleccionada.Nombre;
                txt_codigo.Value = practicaSeleccionada.Codigo;
                txt_precio.Text = practicaSeleccionada.Precio.ToString();

                // comportamiento UI
                btn_cancel.Enabled = true;
                btn_save.Enabled = true;
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
            btn_save.Enabled = false;
            btn_cancel.Enabled = false;
            HabilitarAcciones();
            LimpiarInputs();
        }
        private void btn_save_Click_1(object sender, EventArgs e)
        {
            try
            {
                // validamos los campos
                if (string.IsNullOrWhiteSpace(txt_nombre.Text))
                {
                    throw new Exception("El nombre de la practica es obligatorio.");
                }
               
                if(!decimal.TryParse(txt_precio.Text, out decimal precio_txt) || precio_txt <= 0)
                {
                    throw new Exception("El precio de la practica es obligatorio y debe ser un número decimal mayor a 0.");
                }

                if (txt_codigo.Value <= 0)
                {
                    throw new Exception("El código de la practica es obligatorio y debe ser un número mayor a 0.");
                }

                var nombre = txt_nombre.Text.Trim();
                var precio = Convert.ToDecimal(txt_precio.Text);
                var codigo = Convert.ToInt32(txt_codigo.Value);


                if (modo == "Alta")
                {
                    BEPractica practica = new BEPractica(0, codigo, nombre, precio);
                    bllPractica.CrearPractica(practica);

                    MessageBox.Show("Practica creada exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (modo == "Modificacion")
                {
                    BEPractica practica = new BEPractica(practicaSeleccionada.Id, codigo, nombre, precio);

                    bllPractica.ModificarPractica(practica);

                    MessageBox.Show("Practica modificada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarInputs();
                btn_save.Enabled = false;
                btn_cancel.Enabled = false;
                HabilitarAcciones();
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
