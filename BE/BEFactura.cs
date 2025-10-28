using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEFactura : BEEntidad
    {

        public int Numero { get; set; }
        public DateTime FechaRecibida { get; set; }
        public Decimal Monto { get; set; }
        public string Estado { get; set; }
        public bool AutorizacionValidada { get; set; }
        public bool ImporteValidado { get; set; }
        public string Observacion { get; set; }
        public string RutaPDF { get; set; }
        public BEPrestador Prestador { get; set; }
        public BEAutorizacion Autorizacion {get; set;}
        public BEPago Pago { get; set; }
        public BEFactura()
        {

        }

        public BEFactura(int id, 
            DateTime fechaRecibida, 
            decimal monto, int numero, 
            string observacion, 
            string estado, 
            BEPrestador prestador, 
            BEAutorizacion autorizacion, 
            string rutaPDF, 
            bool autorizacionValidada, 
            bool importeValidado)
        {
            Id = id;
            FechaRecibida = fechaRecibida;
            Monto = monto;
            Numero = numero;
            Observacion = observacion;
            Estado = estado;
            Autorizacion = autorizacion;
            Prestador = prestador;
            RutaPDF = rutaPDF;
            AutorizacionValidada = autorizacionValidada;
            ImporteValidado = importeValidado;
        }

        public override string ToString()
        {
            return $"{Numero} - ${Monto}";
        }
    }
}
