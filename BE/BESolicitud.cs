using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BESolicitud : BEEntidad
    {
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; }
        public BEAfiliado Afiliado { get; set; }
        public BEPractica Practica { get; set; }
        public string MotivoRechazo { get; set; }

        public BESolicitud()
        {
            Afiliado = new BEAfiliado();
            Practica = new BEPractica();
        }
        public BESolicitud(int id, DateTime fechaSolicitud, string estado, string motivoRechazo, BEAfiliado afiliado, BEPractica practica)
        {
            Id = id;
            FechaSolicitud = fechaSolicitud;
            Estado = estado;
            MotivoRechazo = motivoRechazo;
            Afiliado = afiliado;
            Practica = practica;
        }
        public override string ToString()
        {
            return $"{Afiliado} - {Practica} - {FechaSolicitud}";
        }
    }
}
