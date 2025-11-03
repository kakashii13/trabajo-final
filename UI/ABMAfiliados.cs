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

            btnCambiarPlan.Enabled = false;
            btnActivar.Enabled = false;
            btnInactivar.Enabled = false;

            ConfigurarDataGrid();
            CargarAfiliados();
        }

        private void ConfigurarDataGrid()
        {
            // ocultamos columnas no deseadas
            dgvAfiliados.AutoGenerateColumns = false;

            // configuramos columnas visibles
            dgvAfiliados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cuil",
                HeaderText = "Cuil"
            });
            dgvAfiliados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreApellido",
                HeaderText = "Nombre y apellido"
            });
            dgvAfiliados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NroAfiliado",
                HeaderText = "Numero de afiliado"
            });
            dgvAfiliados.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Activo",
                HeaderText = "Activo"
            });
            dgvAfiliados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Telefono"
            });
            dgvAfiliados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UltimoAporteMonto",
                HeaderText = "Último Aporte",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            dgvAfiliados.Columns.Add(new DataGridViewCheckBoxColumn
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
                dgvAfiliados.DataSource = afiliados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (dgvAfiliados.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un afiliado.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BEAfiliado afiliadoSeleccionado = dgvAfiliados.CurrentRow.DataBoundItem as BEAfiliado;

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
                if (dgvAfiliados.CurrentRow == null)
                {
                    btnCambiarPlan.Enabled = false;
                    btnActivar.Enabled = false;    
                    btnInactivar.Enabled = false;  
                    return;
                }

                BEAfiliado afiliadoSeleccionado = dgvAfiliados.CurrentRow.DataBoundItem as BEAfiliado;

                if (afiliadoSeleccionado == null)
                {
                    btnCambiarPlan.Enabled = false;
                    btnActivar.Enabled = false;
                    btnInactivar.Enabled = false;
                    return;
                }

                btnCambiarPlan.Enabled = afiliadoSeleccionado.CorrespondeCambioPlan;
                btnActivar.Enabled = !afiliadoSeleccionado.Activo;  
                btnInactivar.Enabled = afiliadoSeleccionado.Activo;  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_activar_Click(object sender, EventArgs e)
        {
            try {
                if (dgvAfiliados.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un afiliado.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BEAfiliado afiliadoSeleccionado = dgvAfiliados.CurrentRow.DataBoundItem as BEAfiliado;

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
                if (dgvAfiliados.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un afiliado.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BEAfiliado afiliadoSeleccionado = dgvAfiliados.CurrentRow.DataBoundItem as BEAfiliado;

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
