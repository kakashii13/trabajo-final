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
            dgvAutorizaciones.DataBindingComplete += Dgv_autorizaciones_DataBindingComplete;

            CargarAfiliados();
            CargarAutorizaciones();

        }

        private void CargarAfiliados()
        {
            try {

                List<BEAfiliado> afiliados = bllAfiliado.ListarAfiliados();
                foreach(BEAfiliado afiliado in afiliados)
                {
                   listaAfiliados.Items.Add(afiliado);
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

                dgvAutorizaciones.AutoGenerateColumns = false;
                dgvAutorizaciones.Columns.Clear();

                dgvAutorizaciones.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NumeroAutorizacion",
                    HeaderText = "Nº Autorización",
                    Name = "NumeroAutorizacion"
                });

                dgvAutorizaciones.Columns.Add(new DataGridViewTextBoxColumn
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
                dgvAutorizaciones.Columns.Add(colAfiliado);

                DataGridViewTextBoxColumn colPractica = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Práctica",
                    Name = "Practica"
                };
                dgvAutorizaciones.Columns.Add(colPractica);

                DataGridViewTextBoxColumn colPrestador = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Prestador",
                    Name = "Prestador"
                };
                dgvAutorizaciones.Columns.Add(colPrestador);

                DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Precio",
                    Name = "Precio",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                };
                dgvAutorizaciones.Columns.Add(colPrecio);

                dgvAutorizaciones.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "Facturada",
                    HeaderText = "Facturada",
                    Name = "Facturada"
                });

                dgvAutorizaciones.DataSource = autorizaciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_autorizaciones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvAutorizaciones.Rows)
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
                if (listaAfiliados.SelectedItem == null) 
                {
                    afiliadoSeleccionado = null; 
                    dgvAutorizaciones.DataSource = autorizaciones; 
                    return;
                }

                afiliadoSeleccionado = (BEAfiliado)listaAfiliados.SelectedItem;
                dgvAutorizaciones.DataSource = autorizaciones.Where(a => a.Afiliado.Id == afiliadoSeleccionado.Id).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_listar_Click(object sender, EventArgs e)
        {
            listaAfiliados.SelectedIndex = -1;
            dgvAutorizaciones.DataSource = autorizaciones;
        }
    }
}
