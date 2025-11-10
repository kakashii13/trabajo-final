using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using BE;
using Servicios;

namespace MPP
{
    public class MPPFactura
    {
        XDocument xDocument;
        private readonly string rutaArchivo;

        public MPPFactura()
        {
            rutaArchivo = Path.Combine(ServicioDirectorio.RutaDB, "facturas.xml");

            if (!File.Exists(rutaArchivo))
            {
                xDocument = new XDocument(
                    new XElement("Facturas")
                );
                xDocument.Save(rutaArchivo);
            }
        }
        public void CrearFactura(BEFactura factura)
        {
            
            xDocument = XDocument.Load(rutaArchivo);

            xDocument.Element("Facturas").Add(
                new XElement("Factura", 
                    new XAttribute("Id", factura.Id),
                    new XElement("FechaRecibida", factura.FechaRecibida.ToString("yyyy-MM-dd")),
                    new XElement("AutorizacionValidada", factura.AutorizacionValidada.ToString().ToLower()),
                    new XElement("ImporteValidado", factura.ImporteValidado.ToString().ToLower()),
                    new XElement("Monto", factura.Monto.ToString(CultureInfo.InvariantCulture)),
                    new XElement("Estado", factura.Estado),
                    new XElement("Numero", factura.Numero),
                    new XElement("Observacion", factura.Observacion),
                    new XElement("PrestadorId", factura.Prestador.Id),
                    new XElement("AutorizacionNumero", factura.Autorizacion.NumeroAutorizacion),
                    new XElement("RutaPDF", factura.RutaPDF ?? string.Empty)
                ));

            xDocument.Save(rutaArchivo);
        }
        public void ActualizarFactura(BEFactura factura)
        {
            xDocument = XDocument.Load(rutaArchivo);

            var facturaElement = xDocument.Descendants("Factura")
                .FirstOrDefault(x => (int)x.Attribute("Id") == factura.Id);

            if (facturaElement == null)
            {
                throw new Exception("No se encontró la factura para actualizar.");
            }

            facturaElement.Element("Estado").Value = factura.Estado;    
            facturaElement.Element("AutorizacionValidada").Value = factura.AutorizacionValidada.ToString().ToLower();
            facturaElement.Element("ImporteValidado").Value = factura.ImporteValidado.ToString().ToLower();

            xDocument.Save(rutaArchivo);
        }
        public List<BEFactura> ListarFacturas()
        {
            xDocument = XDocument.Load(rutaArchivo);

            List<BEFactura> facturas = xDocument.Descendants("Factura")
                    .Select(x => MapearFactura(x)).ToList();

             return facturas;
        }
        public bool ExisteFactura(int numeroFactura, int prestadorId)
        {
            xDocument = XDocument.Load(rutaArchivo);

            return xDocument.Descendants("Factura")
                .Any(f => (int)f.Element("Numero") == numeroFactura &&
                            (int)f.Element("PrestadorId") == prestadorId);
        }   
        public BEFactura ObtenerFacturaPorId(int facturaId)
        {
             xDocument = XDocument.Load(rutaArchivo);

            var facturaElement = xDocument.Descendants("Factura")
                .Where(x => (int)x.Attribute("Id") == facturaId)
                .Select(x => MapearFactura(x))
                .FirstOrDefault();

            return facturaElement;
        }
        private BEFactura MapearFactura(XElement element)
        {
            return new BEFactura(
                    (int)element.Attribute("Id"),
                    DateTime.Parse(element.Element("FechaRecibida").Value),
                    decimal.Parse(element.Element("Monto").Value, CultureInfo.InvariantCulture),
                    (int)element.Element("Numero"),
                    element.Element("Observacion").Value,
                    element.Element("Estado").Value,
                    new BEPrestador { Id = (int)element.Element("PrestadorId") },
                    new BEAutorizacion { NumeroAutorizacion = (int)element.Element("AutorizacionNumero") },
                    element.Element("RutaPDF").Value,
                    bool.Parse(element.Element("AutorizacionValidada").Value),
                    bool.Parse(element.Element("ImporteValidado").Value)
                );
        }
        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaArchivo);

            var ultimoId = xDocument.Descendants("Factura")
                .Select(x => (int)x.Attribute("Id"))
                .DefaultIfEmpty(0)
                .Max();

            return ultimoId + 1;
        }

    }
}
