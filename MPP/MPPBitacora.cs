using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using Servicios;

namespace MPP
{
    public class MPPBitacora
    {
        XDocument xDocument;
        private readonly string rutaArchivo;

        public MPPBitacora()
        {
            rutaArchivo = Path.Combine(ServicioDirectorio.RutaBackups, "bitacora.xml");
            
            if (!File.Exists(rutaArchivo))
            {
                xDocument = new XDocument(
                    new XElement("Bitacoras")
                );
                xDocument.Save(rutaArchivo);
            }
        }

        public void RegistrarAccion(BEBitacora bitacora)
        {
            xDocument = XDocument.Load(rutaArchivo);

            xDocument.Element("Bitacoras").Add(
                new XElement("Bitacora",
                    new XAttribute("Id", bitacora.Id),
                    new XElement("FechaHora", bitacora.FechaHora),
                    new XElement("Usuario", bitacora.Usuario.Id),
                    new XElement("Operacion", bitacora.Operacion),
                    new XElement("Detalle", bitacora.Detalle)
                    ));

                xDocument.Save(rutaArchivo);
        }

        public List<BEBitacora> ListarTodo()
        {
            xDocument = XDocument.Load(rutaArchivo);

            List<BEBitacora> bitacora = xDocument.Descendants(
                "Bitacora").Select(x => new BEBitacora
                {
                    Id = int.Parse(x.Attribute("Id").Value),
                    FechaHora = DateTime.Parse(x.Element("FechaHora").Value),
                    Usuario = new BEUsuario { Id = int.Parse(x.Element("Usuario").Value) },
                    Operacion = x.Element("Operacion").Value,
                    Detalle = x.Element("Detalle").Value
                }).ToList();

            return bitacora;
        }

        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaArchivo);

            var ultimoId = xDocument.Descendants("Bitacora")
                .Select(x => (int)x.Attribute("Id"))
                .DefaultIfEmpty(0)
                .Max();
            
            return ultimoId + 1;
        }
    }
}
