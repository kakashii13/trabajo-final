using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class ABMAfiliados : Form
    {
        BLLAfiliado bllAfiliado;
        public ABMAfiliados()
        {
            InitializeComponent();
            bllAfiliado = new BLLAfiliado();

            btn_cambio.Enabled = false;
            btn_activar.Enabled = false;
            btn_inactivar.Enabled = false;

            ConfigurarDataGrid();
            CargarAfiliados();
        }

        private void ConfigurarDataGrid()
        {
            // ocultamos columnas no deseadas
            dg_afiliados.AutoGenerateColumns = false;

            // configuramos columnas visibles
            dg_afiliados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cuil",
                HeaderText = "Cuil"
            });
            dg_afiliados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreApellido",
                HeaderText = "Nombre y apellido"
            });
            dg_afiliados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NroAfiliado",
                HeaderText = "Numero de afiliado"
            });
            dg_afiliados.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Activo",
                HeaderText = "Activo"
            });
            dg_afiliados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Telefono"
            });
            dg_afiliados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UltimoAporteMonto",
                HeaderText = "Último Aporte",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            dg_afiliados.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "CorrespondeCambioPlan",
                HeaderText = "Cambio Plan"
            });
        }

        private void CargarAfiliados()
        {
            try
            {
                List<BEAfiliado> afiliados = bllAfiliado.ListarAfiliadosConDatosCambioPlan();
                dg_afiliados.DataSource = afiliados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (dg_afiliados.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un afiliado.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BEAfiliado afiliadoSeleccionado = dg_afiliados.CurrentRow.DataBoundItem as BEAfiliado;

                if (afiliadoSeleccionado == null)
                {
                    MessageBox.Show("Error al obtener el afiliado seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!afiliadoSeleccionado.CorrespondeCambioPlan)
                {
                    MessageBox.Show("El afiliado no requiere cambio de plan.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                CambiarPlan cambioPlan = new CambiarPlan(afiliadoSeleccionado);

                if (cambioPlan.ShowDialog() == DialogResult.OK)
                {
                    CargarAfiliados(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dg_afiliados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dg_afiliados.CurrentRow == null)
                {
                    btn_cambio.Enabled = false;
                    btn_activar.Enabled = false;    
                    btn_inactivar.Enabled = false;  
                    return;
                }

                BEAfiliado afiliadoSeleccionado = dg_afiliados.CurrentRow.DataBoundItem as BEAfiliado;

                if (afiliadoSeleccionado == null)
                {
                    btn_cambio.Enabled = false;
                    btn_activar.Enabled = false;
                    btn_inactivar.Enabled = false;
                    return;
                }

                btn_cambio.Enabled = afiliadoSeleccionado.CorrespondeCambioPlan;
                btn_activar.Enabled = !afiliadoSeleccionado.Activo;  
                btn_inactivar.Enabled = afiliadoSeleccionado.Activo;  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_activar_Click(object sender, EventArgs e)
        {
            try {
                if (dg_afiliados.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un afiliado.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BEAfiliado afiliadoSeleccionado = dg_afiliados.CurrentRow.DataBoundItem as BEAfiliado;

                if (afiliadoSeleccionado == null)
                {
                    MessageBox.Show("Error al obtener el afiliado seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bllAfiliado.ActivarAfiliado(afiliadoSeleccionado);
                
                MessageBox.Show("Afiliado activado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                CargarAfiliados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_inactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_afiliados.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un afiliado.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BEAfiliado afiliadoSeleccionado = dg_afiliados.CurrentRow.DataBoundItem as BEAfiliado;

                if (afiliadoSeleccionado == null)
                {
                    MessageBox.Show("Error al obtener el afiliado seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult resultado = MessageBox.Show(
                   $"¿Está seguro que desea inactivar a {afiliadoSeleccionado.NombreApellido}?",
                   "Confirmar inactivación",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    return;
                }

                bllAfiliado.InactivarAfiliado(afiliadoSeleccionado);
                
                MessageBox.Show("Afiliado inactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                CargarAfiliados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
