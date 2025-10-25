using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;

namespace BLL
{
    public class BLLPago
    {
        MPPPago mppPago;
        BLLFactura bllFactura;

        public BLLPago()
        {
            mppPago = new MPPPago();
            bllFactura = new BLLFactura();
        }

        public void RegistrarPago(decimal importe, int numeroRecibo, DateTime fechaPago, BEFactura factura)
        {
            try
            {
                if (factura.Estado == "Pagada")
                {
                    throw new Exception("La factura ya fue pagada.");
                }

                // obtenemos el ultimo id
                int id = mppPago.ObtenerProximoId();
                BEPago pago = new BEPago(id, fechaPago, importe, numeroRecibo, factura);

                mppPago.RegistrarPago(pago);

                factura.Estado = "Pagada";
                bllFactura.ActualizarFactura(factura);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el pago." + ex.Message);
            }
        }
    }
}
