﻿using BE;
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
    public partial class ConsultarAportes : Form
    {
        BLLAporte bllAporte;
        BLLAfiliado bllAfiliado;
        List<BEAporte> aportes;
        List<BEAfiliado> afiliados;

        public ConsultarAportes()
        {
            InitializeComponent();
            bllAporte = new BLLAporte();
            bllAfiliado = new BLLAfiliado();

            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                // cargamos los aportes
                aportes = bllAporte.ListarAportes()
                .OrderByDescending(a => a.FechaRecibido)
                .ToList();
                dg_aportes.DataSource = aportes;

                afiliados = bllAfiliado.ListarAfiliados();
                foreach(var afiliado in afiliados)
                {
                    list_afiliados.Items.Add(afiliado);
                }

                list_afiliados.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void list_afiliados_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (list_afiliados.SelectedItem == null) { return; }

                BEAfiliado afiliadoSeleccionado = (BEAfiliado)list_afiliados.SelectedItem;

                // filtramos los aportes del afiliado seleccionado
                var aportesFiltrados = aportes.Where(a => a.AfiliadoId == afiliadoSeleccionado.Id).ToList();

                dg_aportes.DataSource = aportesFiltrados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            list_afiliados.SelectedIndex = -1;

            // mostramos todos los aportes
            dg_aportes.DataSource = aportes;
        }
    }
}
