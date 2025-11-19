using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPago : BEEntidad
    {
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public int NumeroRecibo { get; set; }
        public string FormaPago { get; set; }
        public int FacturaId { get; set; }

        public BEPago()
        {

        }
        public BEPago(int id, DateTime fechaPago, decimal monto, int numeroRecibo, int facturaId, string formaPago)
        {
            Id = id;
            FechaPago = fechaPago;
            Monto = monto;
            NumeroRecibo = numeroRecibo;
            FacturaId = facturaId;
            FormaPago = formaPago;
        }
        public override string ToString()
        {
            return $"{NumeroRecibo} - ${Monto} - {FechaPago.ToString("yyyy-MM-dd")}";
        }
    }
}
