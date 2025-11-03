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
    public partial class ResolverSolicitud : Form
    {
        BLLSolicitud bllSolicitud;
        List<BESolicitud> solicitudes;
        BESolicitud solicitudSeleccionada;
        public ResolverSolicitud()
        {
            InitializeComponent();
            bllSolicitud = new BLLSolicitud();
            dgvSolicitudes.DataBindingComplete += Dgv_solicitudes_DataBindingComplete;

            CargarSolicitudes();
        }

        private void CargarSolicitudes()
        {
            try
            {
                solicitudes = bllSolicitud.ListarSolicitudes()
                            .OrderByDescending(s => s.FechaSolicitud)
                            .ToList();

                dgvSolicitudes.AutoGenerateColumns = false;
                dgvSolicitudes.Columns.Clear();

                dgvSolicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Estado",
                    HeaderText = "Estado",
                    Name = "Estado"
                });


                dgvSolicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaSolicitud",
                    HeaderText = "Fecha",
                    Name = "FechaSolicitud",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
                });


                dgvSolicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Afiliado",
                    Name = "Afiliado"
                });

                dgvSolicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Práctica",
                    Name = "Practica"
                });

                dgvSolicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Precio",
                    Name = "Precio",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                });

                dgvSolicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MotivoRechazo",
                    HeaderText = "Motivo de rechazo",
                    Name = "MotivoRechazo"
                });

                dgvSolicitudes.DataSource = solicitudes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_solicitudes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvSolicitudes.Rows)
            {
                if (row.DataBoundItem is BESolicitud solicitud)
                {
                    row.Cells["Afiliado"].Value = solicitud.Afiliado?.NombreApellido ?? "N/A";
                    row.Cells["Practica"].Value = solicitud.Practica?.Nombre ?? "N/A";
                    row.Cells["Precio"].Value = solicitud.Practica?.Precio ?? 0;
                }
            }
        }

        private void FiltrarPorEstado(string estado)
        {
            if (string.IsNullOrEmpty(estado))
            {
                dgvSolicitudes.DataSource = solicitudes; 
            }
            else
            {
                dgvSolicitudes.DataSource = solicitudes
                    .Where(s => s.Estado == estado)
                    .ToList();
            }
        }

        private void btn_pendientes_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado("Pendiente");
        }

        private void btn_aceptadas_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado("Aceptado");
        }

        private void btn_rechazadas_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado("Rechazado");
        }

        private void btn_analizar_Click(object sender, EventArgs e)
        {
            try {
                if(solicitudSeleccionada == null)
                {
                    throw new Exception("No se ha seleccionado ninguna solicitud.");
                }

                DetalleSolicitud detalle = new DetalleSolicitud(solicitudSeleccionada);
                detalle.ShowDialog();
                CargarSolicitudes();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dg_solicitudes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                btnAnalizar.Enabled = false;
                solicitudSeleccionada = null;

                if (dgvSolicitudes.CurrentRow == null) { return; }

                solicitudSeleccionada = (BESolicitud)dgvSolicitudes.CurrentRow.DataBoundItem;

                if (solicitudSeleccionada == null) { return; }

                if (solicitudSeleccionada.Estado == "Pendiente")
                {
                    btnAnalizar.Enabled = true;
                }
            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
