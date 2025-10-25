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

            // si el archivo no existe, lo creo con la estructura base
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
                new XElement("NumeroRecibo", pago.NumeroRecibo),
                new XElement("FacturaId", pago.Factura.Id)
                ));

            xDocument.Save(rutaArchivo);
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
