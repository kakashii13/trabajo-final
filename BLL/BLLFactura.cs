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

        public void CrearFactura(BEFactura factura)
        {
            try
            {
                if (mppFactura.ExisteFactura(factura.Numero, factura.Prestador.Id))
                {
                    throw new Exception("La factura ya existe.");
                }

                // asignamos el proximo id
                factura.Id = mppFactura.ObtenerProximoId();
                factura.Estado = "Pendiente";
                factura.AutorizacionValidada = false;
                factura.ImporteValidado = false;

                mppFactura.CrearFactura(factura);
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
                List<BEFactura> facturas = mppFactura.ListarFacturas();
                foreach (BEFactura factura in facturas)
                {
                    factura.Prestador = bllPrestador.ObtenerPrestadorPorId(factura.Prestador.Id);
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

                // actualizamos la factura
                factura.AutorizacionValidada = true;
                ActualizarFactura(factura);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar la autorización: " + ex.Message);
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
                if (factura.ImporteValidado)
                    throw new Exception("La factura ya fue validada anteriormente.");

                BEAutorizacion autorizacion = bllAutorizacion.ObtenerAutorizacionPorNumero(factura.Autorizacion.NumeroAutorizacion);

                if (autorizacion == null)
                    throw new Exception($"No existe la autorización N° {factura.Autorizacion.NumeroAutorizacion}");

                autorizacion.Practica = bllPractica.ObtenerPracticaPorId(autorizacion.Practica.Id);

                if (factura.Monto > autorizacion.Practica.Precio)
                    throw new Exception($"El monto de la factura ({factura.Monto}) es mayor al precio de la práctica ({autorizacion.Practica.Precio}).");

                // actualizamos la factura
                factura.ImporteValidado = true;
                ActualizarFactura(factura);
            }
            catch (Exception ex) { throw new Exception("Error al validar el importe: " + ex.Message); }
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
