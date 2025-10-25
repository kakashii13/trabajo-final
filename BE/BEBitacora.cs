using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBitacora : BEEntidad
    {
        public DateTime FechaHora { get; set; }
        public string Operacion { get; set; }
        public BEUsuario Usuario { get; set; }
        public string Detalle { get; set; }

        public BEBitacora() { }
        public BEBitacora(DateTime fechaHora, BEUsuario usuario, string operacion, string detalle)
        {
            FechaHora = fechaHora;
            Usuario = usuario;
            Operacion = operacion;
            Detalle = detalle;
        }

        public override string ToString()
        {
            return $"{FechaHora} - {Usuario.NombreUsuario} - {Operacion} - {Detalle}";
        }
    }
}
