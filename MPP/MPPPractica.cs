using BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MPP
{
    public class MPPPractica
    {
        XDocument xDocument;
        private readonly string rutaPracticas;

        public MPPPractica()
        {
            rutaPracticas = Path.Combine(ServicioDirectorio.RutaDB, "practicas.xml");

            // si no existe el archivo, lo creamos
            if (!File.Exists(rutaPracticas))
            {
                xDocument = new XDocument(
                    new XElement("Practicas")
                );
                xDocument.Save(rutaPracticas);
            }
        }

        public void CrearPractica(BEPractica practica)
        {
            xDocument = XDocument.Load(rutaPracticas);

            xDocument.Element("Practicas").Add(
                    new XElement("Practica",
                        new XAttribute("Id", practica.Id),
                        new XElement("Codigo", practica.Codigo),
                        new XElement("Nombre", practica.Nombre),
                        new XElement("Precio", practica.Precio.ToString(CultureInfo.InvariantCulture))
                ));

            xDocument.Save(rutaPracticas);
        }

        public void ModificarPractica(BEPractica practica)
        {
            xDocument = XDocument.Load(rutaPracticas);

            var practicaElem = xDocument.Descendants("Practica")
                .FirstOrDefault(p => (int)p.Attribute("Id") == practica.Id);

            if (practicaElem == null)
            {
                throw new Exception("Práctica no encontrada.");
            }

            practicaElem.Element("Codigo").Value = practica.Codigo.ToString();
            practicaElem.Element("Nombre").Value = practica.Nombre;
            practicaElem.Element("Precio").Value = practica.Precio.ToString(CultureInfo.InvariantCulture);

            xDocument.Save(rutaPracticas);
        }

        public List<BEPractica> ListarPracticas()
        {
            xDocument = XDocument.Load(rutaPracticas);

            List<BEPractica> practicas = xDocument.Descendants("Practica")
                .Select(p => MapearPractica(p))
                .ToList();

            return practicas;
        }

        public BEPractica ObtenerPracticaPorId(int id)
        {
            xDocument = XDocument.Load(rutaPracticas);

            var practica = xDocument.Descendants("Practica")
                .Where(p => (int)p.Attribute("Id") == id)
                .Select(p => MapearPractica(p))
                .FirstOrDefault();
            
            return practica;
        }

        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaPracticas);
            
            var ultimoId = xDocument.Descendants("Practica")
                .Select(p => (int)p.Attribute("Id"))
                .DefaultIfEmpty(0)
                .Max();
            
            return ultimoId + 1;
        }

        public bool ExistePractica(int codigo, int? id)
        {
            xDocument = XDocument.Load(rutaPracticas);
            
            var practica = xDocument.Descendants("Practica")
                .Where(p => id == null || (int)p.Attribute("Id") != id.Value)
                .FirstOrDefault(p => (int)p.Element("Codigo") == codigo);

            return practica != null;
        }

        private BEPractica MapearPractica(XElement practicaElem)
        {
            return new BEPractica
            (
                (int)practicaElem.Attribute("Id"),
                (int)practicaElem.Element("Codigo"),
                (string)practicaElem.Element("Nombre"),
                decimal.Parse(practicaElem.Element("Precio").Value, CultureInfo.InvariantCulture)
            );
        }
    }
}
