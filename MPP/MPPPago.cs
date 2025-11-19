using BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MPP
{
    public class MPPPago
    {
        XDocument xDocument;
        private readonly string rutaArchivo;
        
        public MPPPago()
        {
            rutaArchivo = Path.Combine(ServicioDirectorio.RutaDB, "pagos.xml");

            if (!File.Exists(rutaArchivo))
            {
                xDocument = new XDocument(
                    new XElement("Pagos")
                );
                xDocument.Save(rutaArchivo);
            }
        }
        public void RegistrarPago(BEPago pago)
        {
            xDocument = XDocument.Load(rutaArchivo);
            
            xDocument.Element("Pagos").Add(
                new XElement("Pago",
                new XAttribute("Id", pago.Id),
                new XElement("FechaPago", pago.FechaPago.ToString("yyyy-MM-dd")),
                new XElement("Importe", pago.Monto),
                new XElement("FormaPago", pago.FormaPago),
                new XElement("NumeroRecibo", pago.NumeroRecibo),
                new XElement("FacturaId", pago.FacturaId)
                ));

            xDocument.Save(rutaArchivo);
        }
        public BEPago ObtenerPagoPorFacturaId(int facturaId)
        {
            xDocument = XDocument.Load(rutaArchivo);

            var pagoElement = xDocument.Descendants("Pago")
                .Where(x => (int)x.Element("FacturaId") == facturaId)
                .Select(element => MapearPago(element))
                .FirstOrDefault();

            return pagoElement;
        }
        public int ObtenerProximoNumeroRecibo()
        {
            xDocument = XDocument.Load(rutaArchivo);
            
            var ultimoNumeroRecibo = xDocument.Descendants("Pago")
                .Select(xDocument => (int)xDocument
                .Element("NumeroRecibo"))
                .DefaultIfEmpty(0)
                .Max();

            return ultimoNumeroRecibo + 1;
        }
        private BEPago MapearPago(XElement element) { 
            return new BEPago
                (
                    (int)element.Attribute("Id"),
                    DateTime.Parse(element.Element("FechaPago").Value),
                    (decimal)element.Element("Importe"),
                    (int)element.Element("NumeroRecibo"),
                    (int)element.Element("FacturaId"),
                    element.Element("FormaPago").Value
                );
        }
        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaArchivo);

            var ultimoId = xDocument.Descendants("Pago")
                .Select(xDocument => (int)xDocument
                .Attribute("Id"))
                .DefaultIfEmpty(0)
                .Max();

            return ultimoId + 1;
        }
    }
}
