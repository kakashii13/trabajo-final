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
    public class MPPHistorialPlan
    {
        XDocument xDocument;
        private readonly string rutaArchivo; 

        public MPPHistorialPlan()
        {
            rutaArchivo = Path.Combine(ServicioDirectorio.RutaDB, "historial_planes.xml");
            if (!File.Exists(rutaArchivo))
            {
                xDocument = new XDocument(
                    new XElement("HistorialPlanes")
                );
                xDocument.Save(rutaArchivo);
            }
        }
        public void CrearHistorialPlan(BEHistorialPlan historialPlan)
        {
            xDocument = XDocument.Load(rutaArchivo);

            xDocument.Element("HistorialPlanes").Add(
                new XElement("HistorialPlan",
                    new XAttribute("Id", historialPlan.Id),
                    new XElement("AfiliadoId", historialPlan.AfiliadoId),
                    new XElement("PlanId", historialPlan.PlanId),
                    new XElement("FechaDesde", historialPlan.FechaDesde.ToString("yyyy-MM-dd")),
                    new XElement("Activo", historialPlan.Activo)
                )
            );
            xDocument.Save(rutaArchivo);
        }
        public List<BEHistorialPlan> ObtenerHistorialPlanPorAfiliado(BEAfiliado afiliado)
        {
            xDocument = XDocument.Load(rutaArchivo);
           
            List<BEHistorialPlan> historialPlanes = xDocument.Descendants("HistorialPlan")
                .Where(hp => (int)hp.Element("AfiliadoId") == afiliado.Id)
                .Select(hp => MapearHistorialPlan(hp))
                .ToList();

            return historialPlanes;
        }
        public void ModificarHistorialPlan(BEHistorialPlan historialPlan)
        {
            xDocument = XDocument.Load(rutaArchivo);

            var resultado = xDocument.Descendants("HistorialPlan")
            .FirstOrDefault(hp => (int)hp.Attribute("Id") == historialPlan.Id);

            if (resultado == null)
            {
                throw new Exception("No se encontró el historial de plan con el ID proporcionado.");
            }

            resultado.Element("AfiliadoId").Value = historialPlan.AfiliadoId.ToString();
            resultado.Element("PlanId").Value = historialPlan.PlanId.ToString();
            resultado.Element("FechaDesde").Value = historialPlan.FechaDesde.ToString("yyyy-MM-dd");
            resultado.Element("Activo").Value = historialPlan.Activo.ToString().ToLower();

            xDocument.Save(rutaArchivo);
        }
        private BEHistorialPlan MapearHistorialPlan(XElement elemento)
        {
            return new BEHistorialPlan(
                (int)elemento.Attribute("Id"),
                (int)elemento.Element("AfiliadoId"),
                (int)elemento.Element("PlanId"),
                (bool)elemento.Element("Activo"),
                (DateTime)elemento.Element("FechaDesde")
            );
        }
        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaArchivo);

            var maxId = xDocument.Descendants("HistorialPlan")
                        .Select(hp => (int)hp.Attribute("Id"))
                        .DefaultIfEmpty(0)
                        .Max();

            return maxId + 1;
        }

    }
}
