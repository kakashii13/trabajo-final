using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLFactura
    {
        MPPFactura mppFactura;
        BLLPrestador bllPrestador;
        BLLAutorizacion bllAutorizacion;
        BLLPractica bllPractica;

        public BLLFactura()
        {
            mppFactura = new MPPFactura();
            bllPrestador = new BLLPrestador();
            bllAutorizacion = new BLLAutorizacion();
            bllPractica = new BLLPractica();
        }
        public void RegistrarFactura(BEFactura factura)
        {
            try
            {
                if (mppFactura.ExisteFactura(factura.Numero, factura.Prestador.Id))
                {
                    throw new Exception("La factura ya existe.");
                }

                factura.Id = mppFactura.ObtenerProximoId();
                factura.Estado = "Pendiente";
                factura.AutorizacionValidada = false;
                factura.ImporteValidado = false;

                mppFactura.RegistrarFactura(factura);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la factura: " + ex.Message);
            }
        }
        public List<BEFactura> ListarFacturas()
        {
            try
            {
                BLLPago bllPago = new BLLPago();

                List<BEFactura> facturas = mppFactura.ListarFacturas();
                foreach (BEFactura factura in facturas)
                {
                    factura.Prestador = bllPrestador.ObtenerPrestadorPorId(factura.Prestador.Id);
                    factura.Pago = bllPago.ObtenerPagoPorFacturaId(factura.Id);
                }
                return facturas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las facturas: " + ex.Message);
            }
        }
        public void ValidarAutorizacion(BEFactura factura)
        {
            try
            {
                if (factura.Estado != "Pendiente")
                {
                    throw new Exception("Solo se pueden validar facturas en estado Pendiente.");
                }

                if (factura.AutorizacionValidada)
                    throw new Exception("La factura ya fue validada anteriormente.");

                BEAutorizacion autorizacion = bllAutorizacion.ObtenerAutorizacionPorNumero(factura.Autorizacion.NumeroAutorizacion);

                if (autorizacion == null)
                    throw new Exception($"No existe la autorización N° {factura.Autorizacion.NumeroAutorizacion}");

                if (autorizacion.Facturada && factura.Estado != "Pendiente")
                    throw new Exception("La autorización ya tiene una factura asociada.");

                if (autorizacion.Prestador.Id != factura.Prestador.Id)
                    throw new Exception("El prestador de la factura no coincide con el de la autorización.");


                MarcarComoFacturada(autorizacion);

                factura.AutorizacionValidada = true;
                ActualizarFactura(factura);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar la autorización: " + ex.Message);
            }
        }
        public BEFactura ObtenerFacturaPorId(int facturaId)
        {
            try
            {
                return mppFactura.ObtenerFacturaPorId(facturaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la factura por ID: " + ex.Message);
            }
        }
        private void MarcarComoFacturada(BEAutorizacion autorizacion) {
            try
            {
                if (autorizacion.Facturada)
                {
                    throw new Exception("La autorización ya está facturada.");
                }

                autorizacion.Facturada = true;
                bllAutorizacion.ModificarAutorizacion(autorizacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al marcar autorización como facturada: " + ex.Message);
            }
        }
        public void ValidarImporte(BEFactura factura)
        {
            try
            {
                if(factura.Estado != "Pendiente")
                    throw new Exception("Solo se pueden validar facturas en estado Pendiente.");

                if (factura.ImporteValidado)
                    throw new Exception("El importe de la factura ya fue validado anteriormente.");

                BEAutorizacion autorizacion = bllAutorizacion.ObtenerAutorizacionPorNumero(factura.Autorizacion.NumeroAutorizacion);

                if (autorizacion == null)
                    throw new Exception($"No existe la autorización N° {factura.Autorizacion.NumeroAutorizacion}");

                autorizacion.Practica = bllPractica.ObtenerPracticaPorId(autorizacion.Practica.Id);

                if (factura.Monto != autorizacion.Practica.Precio)
                    throw new Exception($"El monto de la factura ({factura.Monto}) difiere del precio de la práctica ({autorizacion.Practica.Precio}).");

                factura.ImporteValidado = true;
                ActualizarFactura(factura);
            }
            catch (Exception ex) { throw new Exception("Error al validar el importe: " + ex.Message); }
        }
        public void RechazarFactura(BEFactura factura)
        {
            try
            {
                if(factura.Estado != "Pendiente")
                    throw new Exception("Solo se pueden rechazar facturas en estado Pendiente.");

                BEAutorizacion autorizacion = bllAutorizacion.ObtenerAutorizacionPorNumero(factura.Autorizacion.NumeroAutorizacion);
                
                if (autorizacion != null) { 
                    autorizacion.Facturada = false;
                    bllAutorizacion.ModificarAutorizacion(autorizacion);
                }

                factura.Estado = "Rechazada";
                ActualizarFactura(factura);
            }
            catch (Exception ex) { throw new Exception("Error al rechazar la factura: " + ex.Message); }
        }
        public void AceptarFactura(BEFactura factura)
        {
            try
            {
                if (factura.Estado != "Pendiente")
                {
                    throw new Exception("Solo se pueden aceptar facturas en estado Pendiente.");
                }

                if (!factura.ImporteValidado || !factura.AutorizacionValidada)
                    throw new Exception("La factura debe tener importe y autorización validados.");

                factura.Estado = "Aceptada";
                mppFactura.ActualizarFactura(factura);
            }
            catch (Exception ex) { throw new Exception("Error al aceptar la factura: " + ex.Message); }
        }
        public void ActualizarFactura(BEFactura factura)
        {
            try
            {
                mppFactura.ActualizarFactura(factura);
            }
            catch (Exception ex) { throw new Exception("Error al actualizar la factura: " + ex.Message); }
        }
    }
}
