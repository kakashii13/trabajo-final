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
    public partial class RegistrarPrestador : Form
    {
        BLLPrestador bllPrestador;
        public RegistrarPrestador()
        {
            InitializeComponent();
            bllPrestador = new BLLPrestador();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try {
                string cuit = txtCuit.Text;
                string razonSocial = txtRazonSocial.Text;

                if(string.IsNullOrWhiteSpace(cuit) || string.IsNullOrWhiteSpace(razonSocial))
                {
                    throw new Exception("Cuit y Razon Social son obligatorios");
                }

                BEPrestador prestador = new BEPrestador(0, cuit, razonSocial);

                bllPrestador.CrearPrestador(prestador);

                MessageBox.Show("Prestador creado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCuit.Clear();
                txtRazonSocial.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
