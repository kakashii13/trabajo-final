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
        public BEFactura Factura { get; set; }

        public BEPago()
        {

        }
        public BEPago(int id, DateTime fechaPago, decimal monto, int numeroRecibo, BEFactura factura)
        {
            Id = id;
            FechaPago = fechaPago;
            Monto = monto;
            NumeroRecibo = numeroRecibo;
            Factura = factura;
        }

        public override string ToString()
        {
            return $"{NumeroRecibo} - {Monto}";
        }
    }
}
