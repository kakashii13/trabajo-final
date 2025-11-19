using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioSeguridad
    {
        public static string Encriptar(string texto)
        {
            try {
                byte[] encriptado = Encoding.Unicode.GetBytes(texto);
                string resultado = Convert.ToBase64String(encriptado);
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al encriptar: " + ex.Message);
            }
        }
        public static string Desencriptar(string textoEncriptado)
        {
            try
            {
                byte[] desencriptado = Convert.FromBase64String(textoEncriptado);
                string resultado = Encoding.Unicode.GetString(desencriptado);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desencriptar: " + ex.Message);
            }
        }
    }
}
