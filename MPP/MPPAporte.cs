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
    public class MPPAporte
    {
        XDocument xDocument;
        private readonly string rutaArchivo;
        private const string FORMATO_PERIODO = "yyyy-MM";
        private const string FORMATO_FECHA = "yyyy-MM-dd";

        public MPPAporte()
        {
            rutaArchivo = Path.Combine(ServicioDirectorio.RutaDB, "aportes.xml");
            if (!File.Exists(rutaArchivo))
            {
                xDocument = new XDocument(
                    new XElement("Aportes")
                );
                xDocument.Save(rutaArchivo);
            }
        }
        public void CrearAporte(BEAporte aporte)
        {
            xDocument = XDocument.Load(rutaArchivo);

            xDocument.Element("Aportes").Add(
                    new XElement("Aporte",
                        new XElement("Id", aporte.Id),
                        new XElement("AfiliadoId", aporte.AfiliadoId),
                        new XElement("Periodo", aporte.Periodo.ToString("yyyy-MM")),
                        new XElement("FechaRecibido", aporte.FechaRecibido.ToString("yyyy-MM-dd")),
                        new XElement("Monto", aporte.Monto)
                    )
                );
            xDocument.Save(rutaArchivo);
        }
        public List<BEAporte> ObtenerAportesPorAfiliado(BEAfiliado afiliado)
        {
            xDocument = XDocument.Load(rutaArchivo);

            List<BEAporte> aportes = xDocument.Descendants("Aporte")
                .Where(ap => (int)ap.Element("AfiliadoId") == afiliado.Id)
                .Select(ap => MapearAporte(ap))
                .ToList();

            return aportes;
        }
        public BEAporte ObtenerUltimoAportePorAfiliado(BEAfiliado afiliado)
        {
            xDocument = XDocument.Load(rutaArchivo);

            var ultimoAporte = xDocument.Descendants("Aporte")
                 .Where(ap => (int)ap.Element("AfiliadoId") == afiliado.Id)
                 .OrderByDescending(ap => DateTime.ParseExact(ap.Element("Periodo").Value, FORMATO_PERIODO, null))
                 .Select(ap => MapearAporte(ap))
                 .FirstOrDefault();

            return ultimoAporte;
        }
        public List<BEAporte> ListarAportes()
        {
            xDocument = XDocument.Load(rutaArchivo);
           
            List<BEAporte> aportes = xDocument.Descendants("Aporte").Select(ap => MapearAporte(ap)).ToList();

            return aportes;
        }
        private BEAporte MapearAporte(XElement elemento)
        {
          return new BEAporte(
                (int)elemento.Element("Id"),
                (decimal)elemento.Element("Monto"),
                (DateTime)elemento.Element("FechaRecibido"),
                DateTime.ParseExact((string)elemento.Element("Periodo"), "yyyy-MM", null),
                (int)elemento.Element("AfiliadoId")
           );
        }
        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaArchivo);

            var ultimoId = xDocument.Descendants("Aporte")
                .Select(a => (int)a.Element("Id"))
                .DefaultIfEmpty(0)
                .Max();

            return ultimoId + 1;
        }
    }
}
