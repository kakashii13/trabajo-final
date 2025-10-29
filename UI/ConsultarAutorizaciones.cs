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
    public partial class ConsultarAutorizaciones : Form
    {
        BLLAutorizacion bllAutorizaciones;
        BLLAfiliado bllAfiliado;
        List<BEAutorizacion> autorizaciones;
        BEAfiliado afiliadoSeleccionado;
        public ConsultarAutorizaciones()
        {
            InitializeComponent();
            bllAutorizaciones = new BLLAutorizacion();
            bllAfiliado = new BLLAfiliado();
            dgv_autorizaciones.DataBindingComplete += Dgv_autorizaciones_DataBindingComplete;

            CargarAfiliados();
            CargarAutorizaciones();

        }

        private void CargarAfiliados()
        {
            try {

                List<BEAfiliado> afiliados = bllAfiliado.ListarAfiliados();
                foreach(BEAfiliado afiliado in afiliados)
                {
                   lista_afiliados.Items.Add(afiliado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAutorizaciones()
        {
            try {
                autorizaciones = bllAutorizaciones.ListarAutorizaciones()
                                .OrderByDescending(a => a.FechaAutorizacion) 
                                .ToList();

                dgv_autorizaciones.AutoGenerateColumns = false;
                dgv_autorizaciones.Columns.Clear();

                dgv_autorizaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NumeroAutorizacion",
                    HeaderText = "Nº Autorización",
                    Name = "NumeroAutorizacion"
                });

                dgv_autorizaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaAutorizacion",
                    HeaderText = "Fecha",
                    Name = "FechaAutorizacion",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
                });

                DataGridViewTextBoxColumn colAfiliado = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Afiliado",
                    Name = "Afiliado"
                };
                dgv_autorizaciones.Columns.Add(colAfiliado);

                DataGridViewTextBoxColumn colPractica = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Práctica",
                    Name = "Practica"
                };
                dgv_autorizaciones.Columns.Add(colPractica);

                DataGridViewTextBoxColumn colPrestador = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Prestador",
                    Name = "Prestador"
                };
                dgv_autorizaciones.Columns.Add(colPrestador);

                DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Precio",
                    Name = "Precio",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                };
                dgv_autorizaciones.Columns.Add(colPrecio);

                dgv_autorizaciones.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "Facturada",
                    HeaderText = "Facturada",
                    Name = "Facturada"
                });

                dgv_autorizaciones.DataSource = autorizaciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_autorizaciones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgv_autorizaciones.Rows)
            {
                if (row.DataBoundItem is BEAutorizacion autorizacion)
                {
                    row.Cells["Afiliado"].Value = autorizacion.Afiliado.NombreApellido;
                    row.Cells["Practica"].Value = autorizacion.Practica.Nombre;
                    row.Cells["Precio"].Value = autorizacion.Practica.Precio;
                    row.Cells["Prestador"].Value = autorizacion.Prestador.RazonSocial;
                }
            }
        }

        private void lista_afiliados_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                if (lista_afiliados.SelectedItem == null) 
                {
                    afiliadoSeleccionado = null; 
                    dgv_autorizaciones.DataSource = autorizaciones; 
                    return;
                }

                afiliadoSeleccionado = (BEAfiliado)lista_afiliados.SelectedItem;
                dgv_autorizaciones.DataSource = autorizaciones.Where(a => a.Afiliado.Id == afiliadoSeleccionado.Id).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_listar_Click(object sender, EventArgs e)
        {
            lista_afiliados.SelectedIndex = -1;
            dgv_autorizaciones.DataSource = autorizaciones;
        }
    }
}
