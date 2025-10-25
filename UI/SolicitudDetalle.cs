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
    public partial class SolicitudDetalle : Form
    {
        BESolicitud solicitudSeleccionada;
        BLLPrestador bllPrestador;
        BLLSolicitud bllSolicitud;
        List<BEPrestador> prestadores;
        BEPrestador prestadorSeleccionado;
        BEPractica practicaSolicitada;
        BEAutorizacion autorizacion;
        BLLAutorizacion bllAutorizacion;
        public SolicitudDetalle(BESolicitud solicitudSeleccionada)
        {
            InitializeComponent();
            bllPrestador = new BLLPrestador();
            bllSolicitud = new BLLSolicitud();
            bllAutorizacion = new BLLAutorizacion();
            this.solicitudSeleccionada = solicitudSeleccionada;
            practicaSolicitada = solicitudSeleccionada.Practica;
            CargarDatos();
        }

        private void CargarDatos()
        {
            try { 
                // afiliado
                txt_cuil.Text = solicitudSeleccionada.Afiliado.Cuil;
                txt_nombre_apellido.Text = solicitudSeleccionada.Afiliado.NombreApellido;
                txt_activo.Text = solicitudSeleccionada.Afiliado.Activo ? "Si" : "No";
                txt_nro_afiliado.Text = solicitudSeleccionada.Afiliado.NroAfiliado.ToString();
                txt_plan.Text = solicitudSeleccionada.Afiliado.ObtenerPlanActual().ToString();
                txt_telefono.Text = solicitudSeleccionada.Afiliado.Telefono;

                // solicitud
                fecha_solicitud.Text = solicitudSeleccionada.FechaSolicitud.ToString("dd/MM/yyyy");
                txt_solicitud_estado.Text = solicitudSeleccionada.Estado;
                txt_practica.Text = solicitudSeleccionada.Practica.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_listar_Click(object sender, EventArgs e)
        {
            try {
                // limpiamos el listado
                lista_prestadores.Items.Clear();

                // listamos los prestadores disponibles para la practica
                prestadores = bllPrestador.ListarPrestadoresSegunPractica(practicaSolicitada);

                if(prestadores == null || prestadores.Count == 0)
                {
                    throw new Exception("No hay prestadores disponibles para la practica solicitada.");
                }

                foreach (BEPrestador prestador in prestadores)
                {
                    lista_prestadores.Items.Add(prestador);
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
                if(lista_prestadores.SelectedIndex < 0) { return; }
                prestadorSeleccionado = (BEPrestador)lista_prestadores.SelectedItem;
                txt_prestador.Text = prestadorSeleccionado.ToString();
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
                ObservacionRechazo observacionRechazo = new ObservacionRechazo();

                if (observacionRechazo.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string observacion = observacionRechazo.Observacion;
                solicitudSeleccionada.Estado = "Rechazado";
                solicitudSeleccionada.MotivoRechazo = observacion;
                
                bllSolicitud.ModificarSolicitud(solicitudSeleccionada);


                MessageBox.Show("Solicitud rechazada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_rechazo.Text = observacion;
                txt_solicitud_estado.Text = solicitudSeleccionada.Estado;

                btn_autorizar.Enabled = false;
                btn_rechazar.Enabled = false;
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

                autorizacion = new BEAutorizacion();
                autorizacion.Prestador = prestadorSeleccionado;

                MessageBox.Show("Prestador asignado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_asignar.Enabled = false;
                btn_autorizar.Enabled = true;
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

                // asignamos afiliado y practica
                autorizacion.Afiliado = solicitudSeleccionada.Afiliado;
                autorizacion.Practica = solicitudSeleccionada.Practica;
                autorizacion.FechaAutorizacion = DateTime.Now;
                autorizacion.Facturada = false;

                autorizacion = bllAutorizacion.CrearAutorizacion(autorizacion);

                // actualizamos estado de la solicitud
                solicitudSeleccionada.Estado = "Aceptado";
                bllSolicitud.ModificarSolicitud(solicitudSeleccionada);

                // generamos el pdf de la autorizacion
                string rutaPDF = ServicioPDF.GenerarPDFAutorizacion(autorizacion);

                // actualizamos la vista
                txt_solicitud_estado.Text = solicitudSeleccionada.Estado;
                btn_autorizar.Enabled = false;
                btn_rechazar.Enabled = false;
                txt_nro_autorizacion.Text = autorizacion.NumeroAutorizacion.ToString();

                DialogResult resultado = MessageBox.Show(
                    $"Solicitud autorizada correctamente.\nNúmero de autorización: {autorizacion.NumeroAutorizacion}\n\n¿Desea abrir el PDF generado?",
                    "Éxito",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
        );

                if (resultado == DialogResult.Yes)
                {
                    // abrimos el pdf con el lector default
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
