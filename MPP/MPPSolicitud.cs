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
    public class MPPSolicitud
    {
        XDocument xDocument;
        private readonly string rutaSolicitudes;

        public MPPSolicitud()
        {
            rutaSolicitudes = Path.Combine(ServicioDirectorio.RutaDB, "solicitudes.xml");

            // si no existe el archivo, lo creamos con la estructura basica
            if (!File.Exists(rutaSolicitudes))
            {
                xDocument = new XDocument(
                    new XElement("Solicitudes")
                );
                xDocument.Save(rutaSolicitudes);
            }
        }

        public void CrearSolicitud(BESolicitud solicitud)
        {
            xDocument = XDocument.Load(rutaSolicitudes);

            xDocument.Element("Solicitudes").Add(
            new XElement("Solicitud",
                    new XAttribute("Id", solicitud.Id),
                    new XElement("FechaSolicitud", solicitud.FechaSolicitud.ToString("yyyy-MM-dd")),
                    new XElement("Estado", solicitud.Estado),
                    new XElement("MotivoRechazo", solicitud.MotivoRechazo),
                    new XElement("AfiliadoId", solicitud.Afiliado.Id),
                    new XElement("PracticaId", solicitud.Practica.Id
                    )));

            xDocument.Save(rutaSolicitudes);
        }

        public void ModificarSolicitud(BESolicitud solicitud)
        {
            
            xDocument = XDocument.Load(rutaSolicitudes);
            
            var solicitudElement = xDocument.Descendants("Solicitud")
                .FirstOrDefault(x => (int)x.Attribute("Id") == solicitud.Id);
            
            if (solicitudElement == null)
            {
                throw new Exception("No se encontró la solicitud con el ID especificado.");
            }
            
            solicitudElement.Element("Estado").Value = solicitud.Estado;
            solicitudElement.Element("MotivoRechazo").Value = solicitud.MotivoRechazo;

            xDocument.Save(rutaSolicitudes);
        }

        public List<BESolicitud> ListarSolicitudes()
        {
            xDocument = XDocument.Load(rutaSolicitudes);

            List<BESolicitud> solicitudes = xDocument.Descendants("Solicitud")
                .Select(x => MapearSolicitud(x))
                .ToList();
            
            return solicitudes;
        }

        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaSolicitudes);
            
            var ultimoId = xDocument.Descendants("Solicitud")
                .Select(x => (int)x.Attribute("Id"))
                .DefaultIfEmpty(0)
                .Max();
            
            return ultimoId + 1;
        }

        private BESolicitud MapearSolicitud(XElement elemento)
        {
            return new BESolicitud
            (
                (int)elemento.Attribute("Id"),
                DateTime.Parse(elemento.Element("FechaSolicitud").Value),
                elemento.Element("Estado").Value,
                elemento.Element("MotivoRechazo").Value,
                new BEAfiliado { Id = (int)elemento.Element("AfiliadoId") },
                new BEPractica { Id = (int)elemento.Element("PracticaId") }
            );
        }
    }
}
