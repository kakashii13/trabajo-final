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
        public BEPago RegistrarPago(BEPago pago)
        {
            try
            {
                BEFactura factura = bllFactura.ObtenerFacturaPorId(pago.FacturaId); 

                if (factura.Estado == "Pagada")
                {
                    throw new Exception("La factura ya fue pagada.");
                }

                pago.Id = mppPago.ObtenerProximoId();
                pago.NumeroRecibo = mppPago.ObtenerProximoNumeroRecibo();

                mppPago.RegistrarPago(pago);

                factura.Estado = "Pagada";
                bllFactura.ActualizarFactura(factura);

                return pago;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el pago." + ex.Message);
            }
        }
        public BEPago ObtenerPagoPorFacturaId(int facturaId)
        {
            try
            {
                return mppPago.ObtenerPagoPorFacturaId(facturaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el pago por ID de factura: " + ex.Message);
            }
        }   
    }
}
