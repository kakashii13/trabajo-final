using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public static class ServicioDirectorio
    {
        private static readonly string RutaBase = AppDomain.CurrentDomain.BaseDirectory;
        public static string RutaDB => Path.Combine(RutaBase, "db");
        public static string RutaBackups => Path.Combine(RutaBase, "backups");
        public static string RutaPDFs => Path.Combine(RutaBase, "pdfs");
        public static string RutaSystem => Path.Combine(RutaBase, "system");
        public static void InicializarEstructura()
        {
            Directory.CreateDirectory(RutaDB);
            Directory.CreateDirectory(RutaBackups);
            Directory.CreateDirectory(RutaPDFs);
            Directory.CreateDirectory(RutaSystem);
        }
    }
}
