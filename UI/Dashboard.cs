﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class Dashboard : Form
    {
        BLLAfiliado bllAfiliado;
        BLLFactura bllFactura;
        BLLSolicitud bllSolicitud;
        BLLAutorizacion bllAutorizacion;
        List<BESolicitud> solicitudes;
        List<BEFactura> facturas;
        List<BEAutorizacion> autorizaciones;

        public Dashboard()
        {
            InitializeComponent();
            bllAfiliado = new BLLAfiliado();
            bllFactura = new BLLFactura();
            bllSolicitud = new BLLSolicitud();
            bllAutorizacion = new BLLAutorizacion();

            CargarDashboard();
        }

        public void CargarDashboard()
        {
            try
            {
                // afiliados
                List<BEAfiliado> afiliados = bllAfiliado.ListarAfiliados();
                lbl_afiliados.Text = afiliados.Count.ToString();
                var activos = afiliados.Where(a => a.Activo).Count();
                var inactivos = afiliados.Where(a => !a.Activo).Count();
                lbl_afiliados_activos.Text = activos.ToString();
                lbl_afiliados_inactivos.Text = inactivos.ToString();
                
                ConfigurarChartAfiliados(activos, inactivos);

                // solicitudes
                solicitudes = bllSolicitud.ListarSolicitudes();
                // facturas
                facturas = bllFactura.ListarFacturas();
                // autorizaciones
                autorizaciones = bllAutorizacion.ListarAutorizaciones();

                ActualizarLabels(solicitudes, facturas, autorizaciones);

                // practicas mas solicitadas
                ActualizarPracticasChart(solicitudes);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar el dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarPracticasChart(List<BESolicitud> solicitudes)
        {
            var practicasMasSolicitadas = solicitudes
                   .GroupBy(s => s.Practica.Nombre)
                   .Select(g => new { Practica = g.Key, Cantidad = g.Count() })
                   .OrderByDescending(g => g.Cantidad)
                   .Take(5)
                   .ToList();

            chart_practicas_solicitadas.Series.Clear();
            
            var series = chart_practicas_solicitadas.Series.Add("Prácticas");

            foreach (var practica in practicasMasSolicitadas)
            {
                series.Points.AddXY(practica.Practica, practica.Cantidad);
            }
        }

        private void ActualizarLabels(List<BESolicitud> solicitudes, List<BEFactura> facturas, List<BEAutorizacion> autorizaciones)
        {
            // actualizar labels de solicitudes
            lbl_solicitudes_pendientes.Text = solicitudes.Where(s => s.Estado == "Pendiente").Count().ToString();
            lbl_solicitudes_aceptadas.Text = solicitudes.Where(s => s.Estado == "Aceptado").Count().ToString();
            lbl_solicitudes_rechazadas.Text = solicitudes.Where(s => s.Estado == "Rechazado").Count().ToString();
            lbl_solicitudes_aceptadas_monto.Text = solicitudes
                .Where(s => s.Estado == "Aceptado")
                .Sum(s => s.Practica.Precio)
                .ToString("C");
            lbl_solicitudes_pendientes_monto.Text = solicitudes
                .Where(s => s.Estado == "Pendiente")
                .Sum(s => s.Practica.Precio)
                .ToString("C");
            lbl_solicitudes_rechazadas_monto.Text = solicitudes
                .Where(s => s.Estado == "Rechazado")
                .Sum(s => s.Practica.Precio)
                .ToString("C");


            // actualizar labels de facturas
            lbl_facturas_pendientes.Text = facturas.Where(f => f.Estado == "Pendiente").Count().ToString();
            lbl_facturas_aceptadas.Text = facturas.Where(f => f.Estado == "Aceptada").Count().ToString();
            lbl_facturas_rechazadas.Text = facturas.Where(f => f.Estado == "Rechazada").Count().ToString();
            lbl_facturas_pagas.Text = facturas.Where(f => f.Estado == "Pagada").Count().ToString();

            lbl_facturas_pendientes_monto.Text = facturas
                .Where(f => f.Estado == "Pendiente")
                .Sum(f => f.Monto)
                .ToString("C");
            lbl_facturas_aceptadas_monto.Text = facturas
                .Where(f => f.Estado == "Aceptada")
                .Sum(f => f.Monto)
                .ToString("C");
            lbl_facturas_rechazadas_monto.Text = facturas
                .Where(f => f.Estado == "Rechazada")
                .Sum(f => f.Monto)
                .ToString("C");
            lbl_facturas_pagas_monto.Text = facturas
                .Where(f => f.Estado == "Pagada")
                .Sum(f => f.Monto)
                .ToString("C");

            // actualizar label de autorizacion
            lblAutorizaciones.Text = autorizaciones.Count.ToString();
        }

        private void btn_mes_Click(object sender, EventArgs e)
        {
            try {
                var solicitudesFiltradas = solicitudes
                    .Where(s => s.FechaSolicitud.Month == DateTime.Now.Month && s.FechaSolicitud.Year == DateTime.Now.Year)
                    .ToList();
                
                var facturasFiltradas = facturas
                    .Where(f => f.FechaRecibida.Month == DateTime.Now.Month && f.FechaRecibida.Year == DateTime.Now.Year)
                    .ToList();

                var autorizacionesFiltradas = autorizaciones
                    .Where(a => a.FechaAutorizacion.Month == DateTime.Now.Month && a.FechaAutorizacion.Year == DateTime.Now.Year)
                    .ToList();

                ActualizarLabels(solicitudesFiltradas, facturasFiltradas, autorizacionesFiltradas);

                // practicas mas solicitadas
                ActualizarPracticasChart(solicitudesFiltradas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por mes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ultimos_dias_Click(object sender, EventArgs e)
        {
            try { 
                
                var solicitudesFiltradas = solicitudes
                    .Where(s => (DateTime.Now - s.FechaSolicitud).TotalDays <= 7)
                    .ToList();
                
                var facturasFiltradas = facturas.
                    Where(f => (DateTime.Now - f.FechaRecibida).TotalDays <= 7)
                    .ToList();

                var autorizacionesFiltradas = autorizaciones
                    .Where(a => (DateTime.Now - a.FechaAutorizacion).TotalDays <= 7)
                    .ToList();

                ActualizarLabels(solicitudesFiltradas, facturasFiltradas, autorizacionesFiltradas);
                // practicas mas solicitadas
                ActualizarPracticasChart(solicitudesFiltradas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por últimos días: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_hoy_Click(object sender, EventArgs e)
        {
            try 
            {
                var solicitudesFiltradas = solicitudes
                    .Where(s => s.FechaSolicitud.Date == DateTime.Now.Date)
                    .ToList();
                
                var facturasFiltradas = facturas
                    .Where(f => f.FechaRecibida.Date == DateTime.Now.Date)
                    .ToList();
                
                var autorizacionesFiltradas = autorizaciones
                    .Where(a => a.FechaAutorizacion.Date == DateTime.Now.Date)
                    .ToList();

                ActualizarLabels(solicitudesFiltradas, facturasFiltradas, autorizacionesFiltradas);
                // practicas mas solicitadas
                ActualizarPracticasChart(solicitudesFiltradas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por hoy: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ultimos_treinta_Click(object sender, EventArgs e)
        {
            try
            {
                var solicitudesFiltradas = solicitudes
                    .Where(s => (DateTime.Now - s.FechaSolicitud).TotalDays <= 30)
                    .ToList();
                
                var facturasFiltradas = facturas
                    .Where(f => (DateTime.Now - f.FechaRecibida).TotalDays <= 30)
                    .ToList();
                
                var autorizacionesFiltradas = autorizaciones
                    .Where(a => (DateTime.Now - a.FechaAutorizacion).TotalDays <= 30)
                    .ToList();

                ActualizarLabels(solicitudesFiltradas, facturasFiltradas, autorizacionesFiltradas);
                // practicas mas solicitadas
                ActualizarPracticasChart(solicitudesFiltradas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por últimos treinta días: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarChartAfiliados(int activos, int inactivos)
        {
            chartAfiliados.Series.Clear();

            // creamos la serie de tipo torta
            var series = chartAfiliados.Series.Add("Afiliados");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            // agregamos los puntos
            var puntoActivos = series.Points.Add(activos);
            puntoActivos.Label = $"Activos ({activos})";
            puntoActivos.LegendText = "Activos";
            puntoActivos.Color = Color.SeaGreen;

            var puntoInactivos = series.Points.Add(inactivos);
            puntoInactivos.Label = $"Inactivos ({inactivos})";
            puntoInactivos.LegendText = "Inactivos";
            puntoInactivos.Color = Color.Brown;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try { 
                DateTime fechaDesde = fecha_desde.Value.Date;
                DateTime fechaHasta = fecha_hasta.Value.Date;

                var solicitudesFiltradas = solicitudes
                    .Where(s => s.FechaSolicitud.Date >= fechaDesde && s.FechaSolicitud.Date <= fechaHasta)
                    .ToList();
                
                var facturasFiltradas = facturas
                    .Where(f => f.FechaRecibida.Date >= fechaDesde && f.FechaRecibida.Date <= fechaHasta)
                    .ToList();
               
                var autorizacionesFiltradas = autorizaciones
                    .Where(a => a.FechaAutorizacion.Date >= fechaDesde && a.FechaAutorizacion.Date <= fechaHasta)
                    .ToList();

                ActualizarLabels(solicitudesFiltradas, facturasFiltradas, autorizacionesFiltradas);
                // practicas mas solicitadas
                ActualizarPracticasChart(solicitudesFiltradas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar por fecha: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
