using BE;
using BLL;
using Servicios;
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
    public partial class DetalleSolicitud : Form
    {
        BESolicitud solicitudSeleccionada;
        BLLPrestador bllPrestador;
        BLLSolicitud bllSolicitud;
        List<BEPrestador> prestadores;
        BEPrestador prestadorSeleccionado;
        BEPractica practicaSolicitada;
        BEAutorizacion autorizacion;

        public DetalleSolicitud(BESolicitud solicitudSeleccionada)
        {
            InitializeComponent();
            bllPrestador = new BLLPrestador();
            bllSolicitud = new BLLSolicitud();
            this.solicitudSeleccionada = solicitudSeleccionada;
            practicaSolicitada = solicitudSeleccionada.Practica;
            CargarDatos();
        }
        private void CargarDatos()
        {
            try { 
                txtCuil.Text = solicitudSeleccionada.Afiliado.Cuil;
                txtNombreApellido.Text = solicitudSeleccionada.Afiliado.NombreApellido;
                txtActivo.Text = solicitudSeleccionada.Afiliado.Activo ? "Si" : "No";

                var planActual = solicitudSeleccionada.Afiliado.PlanActual;
                txtPlan.Text = planActual?.ToString() ?? "Sin plan";
                
                txtTelefono.Text = solicitudSeleccionada.Afiliado.Telefono;

                fechaSolicitud.Text = solicitudSeleccionada.FechaSolicitud.ToString("dd/MM/yyyy");
                txtEstadoSolicitud.Text = solicitudSeleccionada.Estado;
                txtPracticaSolicitada.Text = solicitudSeleccionada.Practica.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_listar_Click(object sender, EventArgs e)
        {
            try {
                listaPrestadores.Items.Clear();

                prestadores = bllPrestador.ListarPrestadoresSegunPractica(practicaSolicitada);

                if(prestadores == null || prestadores.Count == 0)
                {
                    throw new Exception("No hay prestadores disponibles para la practica solicitada.");
                }

                foreach (BEPrestador prestador in prestadores)
                {
                    listaPrestadores.Items.Add(prestador);
                }
            }
            catch (Exception ex)
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
        private void btn_rechazar_Click(object sender, EventArgs e)
        {
            try {
                if (solicitudSeleccionada == null) { throw new Exception("No se ha seleccionado ninguna solicitud."); }

                DialogResult confirmar = MessageBox.Show(
                    "¿Está seguro que desea rechazar esta solicitud?",
                    "Confirmar rechazo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (confirmar != DialogResult.Yes)
                {
                    return;
                }

                ObservacionRechazo observacionRechazo = new ObservacionRechazo();


                if (observacionRechazo.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string observacion = observacionRechazo.Observacion;
                
                
                bllSolicitud.RechazarSolicitud(solicitudSeleccionada, observacion);


                MessageBox.Show("Solicitud rechazada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMotivoRechazo.Text = observacion;
                txtEstadoSolicitud.Text = "Rechazado";
                btnAutorizar.Enabled = false;
                btnRechazar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_asignar_Click(object sender, EventArgs e)
        {
            try {
                if(prestadorSeleccionado == null) { throw new Exception("No se ha seleccionado ningun prestador."); }

                autorizacion = new BEAutorizacion
                {
                    Prestador = prestadorSeleccionado
                };

                MessageBox.Show("Prestador asignado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAsignarPrestador.Enabled = false;
                btnAutorizar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_autorizar_Click_1(object sender, EventArgs e)
        {
            try {
                if(autorizacion == null || autorizacion.Prestador == null) { throw new Exception("No se ha asignado ningun prestador."); }

                autorizacion = bllSolicitud.AutorizarSolicitud(solicitudSeleccionada, autorizacion.Prestador);

                string rutaPDF = ServicioPDF.GenerarPDFAutorizacion(autorizacion);

                txtEstadoSolicitud.Text = "Aceptado";
                btnAutorizar.Enabled = false;
                btnRechazar.Enabled = false;
                txtNumeroAutorizacion.Text = autorizacion.NumeroAutorizacion.ToString();

                DialogResult resultado = MessageBox.Show(
                    $"Solicitud autorizada correctamente.\nNúmero de autorización: {autorizacion.NumeroAutorizacion}\n\n¿Desea abrir el PDF generado?",
                    "Éxito",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
        );

                if (resultado == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(rutaPDF);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
