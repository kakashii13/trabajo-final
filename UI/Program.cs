using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infraestructura;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // inicializar el sistema
            Inicializacion.InicializarSistema();

            // instancia del formulario login
            Login loginForm = new Login();

            Application.Run(loginForm);

        }
    }
}
