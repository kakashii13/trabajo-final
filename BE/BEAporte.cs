using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEAporte : BEEntidad
    {
        public decimal Monto { get; set; }
        public DateTime FechaRecibido { get; set; }
        public DateTime Periodo { get; set; }
        public int AfiliadoId { get; set; }
        public BEAporte(int id, decimal monto, DateTime fecha,DateTime periodo, int afiliadoId)
        {
            Id = id;
            Monto = monto;
            FechaRecibido = fecha;
            Periodo = periodo;
            AfiliadoId = afiliadoId;
        }

        public override string ToString()
        {
            return $"{Monto} - {Periodo.ToString("MM/yyyy")}";
        }
    }
}
