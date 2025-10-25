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
            dg_solicitudes.DataBindingComplete += Dgv_solicitudes_DataBindingComplete;

            CargarSolicitudes();
        }

        private void CargarSolicitudes()
        {
            try
            {
                solicitudes = bllSolicitud.ListarSolicitudes();
                dg_solicitudes.AutoGenerateColumns = false;
                dg_solicitudes.Columns.Clear();

                dg_solicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Estado",
                    HeaderText = "Estado",
                    Name = "Estado"
                });


                dg_solicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaSolicitud",
                    HeaderText = "Fecha",
                    Name = "FechaSolicitud",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
                });


                dg_solicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Afiliado",
                    Name = "Afiliado"
                });

                dg_solicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Práctica",
                    Name = "Practica"
                });

                dg_solicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Precio",
                    Name = "Precio",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                });

                dg_solicitudes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MotivoRechazo",
                    HeaderText = "Motivo de rechazo",
                    Name = "MotivoRechazo"
                });

                dg_solicitudes.DataSource = solicitudes;
                dg_solicitudes.Refresh();

                foreach (DataGridViewRow row in dg_solicitudes.Rows)
                {
                    if (row.DataBoundItem is BESolicitud solicitud)
                    {
                        row.Cells["Afiliado"].Value = solicitud.Afiliado?.NombreApellido;
                        row.Cells["Practica"].Value = solicitud.Practica?.Nombre;
                        row.Cells["Precio"].Value = solicitud.Practica?.Precio;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_solicitudes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dg_solicitudes.Rows)
            {
                if (row.DataBoundItem is BESolicitud solicitud)
                {
                    row.Cells["Afiliado"].Value = solicitud.Afiliado.NombreApellido;
                    row.Cells["Practica"].Value = solicitud.Practica.Nombre;
                    row.Cells["Precio"].Value = solicitud.Practica.Precio;
                }
            }
        }

        private void btn_pendientes_Click(object sender, EventArgs e)
        {
            dg_solicitudes.DataSource = bllSolicitud.ListarSolicitudes().Where(s => s.Estado == "Pendiente").ToList();
        }

        private void btn_aceptadas_Click(object sender, EventArgs e)
        {
            dg_solicitudes.DataSource = bllSolicitud.ListarSolicitudes().Where(s => s.Estado == "Aceptado").ToList();
        }

        private void btn_rechazadas_Click(object sender, EventArgs e)
        {
            dg_solicitudes.DataSource = bllSolicitud.ListarSolicitudes().Where(s => s.Estado == "Rechazado").ToList();
        }

        private void btn_analizar_Click(object sender, EventArgs e)
        {
            try {
                if(solicitudSeleccionada == null)
                {
                    throw new Exception("No se ha seleccionado ninguna solicitud.");
                }

                SolicitudDetalle detalle = new SolicitudDetalle(solicitudSeleccionada);
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
                btn_analizar.Enabled = false;
                solicitudSeleccionada = null;

                if (dg_solicitudes.CurrentRow == null) { return; }
                solicitudSeleccionada = (BESolicitud)dg_solicitudes.CurrentRow.DataBoundItem;

                if(solicitudSeleccionada.Estado == "Pendiente")
                {
                    btn_analizar.Enabled = true;
                }
            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
