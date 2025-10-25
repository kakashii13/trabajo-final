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
    public class MPPPlan
    {
        XDocument xDocument;
        private readonly string rutaPlanes;
        private readonly string rutaPlanesPracticas;

        public MPPPlan()
        {
            rutaPlanes = Path.Combine(ServicioDirectorio.RutaDB, "planes.xml");
            rutaPlanesPracticas = Path.Combine(ServicioDirectorio.RutaDB, "planes_practicas.xml");

            if (!File.Exists(rutaPlanes))
            {
                xDocument = new XDocument(
                    new XElement("Planes")
                );
                xDocument.Save(rutaPlanes);
            }

            if (!File.Exists(rutaPlanesPracticas))
            {
                xDocument = new XDocument(
                    new XElement("PlanesPracticas")
                );
                xDocument.Save(rutaPlanesPracticas);
            }
        }

        public void CrearPlan(BEPlan plan)
        {
            xDocument = XDocument.Load(rutaPlanes);

            xDocument.Element("Planes").Add(
                    new XElement("Plan",
                        new XAttribute("Id", plan.Id),
                        new XElement("Nombre", plan.Nombre),
                        new XElement("AporteTope", plan.AporteTope)
                ));

            xDocument.Save(rutaPlanes);
        }

        public void ModificarPlan(BEPlan plan)
        {
            xDocument = XDocument.Load(rutaPlanes);

            var planElem = xDocument.Descendants("Plan")
                .FirstOrDefault(p => (int)p.Attribute("Id") == plan.Id);

            if (planElem == null) {
                throw new Exception("Plan no encontrado.");
            }

            planElem.Element("Nombre").Value = plan.Nombre;
            planElem.Element("AporteTope").Value = plan.AporteTope.ToString();

            xDocument.Save(rutaPlanes);
        }
        public List<BEPlan> ListarPlanes()
        {
            xDocument = XDocument.Load(rutaPlanes);

            List<BEPlan> planes = xDocument.Descendants("Plan")
                .Select(p => MapearPlan(p))
                .ToList();

            return planes;
        }

        public BEPlan ObtenerPlanPorId(int id)
        {
            xDocument = XDocument.Load(rutaPlanes);

            var plan = xDocument.Descendants("Plan")
                        .Where(p => (int)p.Attribute("Id") == id)
                        .Select(p => MapearPlan(p))
                        .FirstOrDefault();

            return plan;
        }

        public bool ExistePlanPorNombre(string nombre, int? idExcluir = null)
        {
            xDocument = XDocument.Load(rutaPlanes);

            return xDocument.Descendants("Plan")
                .Where(p => idExcluir == null || (int)p.Attribute("Id") != idExcluir.Value)
                .Any(p => p.Element("Nombre").Value.Trim().Equals(nombre.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public bool ExistePlanPorTope(int aporteTope, int? idExcluir = null)
        {
            xDocument = XDocument.Load(rutaPlanes);

            return xDocument.Descendants("Plan")
                .Where(p => idExcluir == null || (int)p.Attribute("Id") != idExcluir.Value)
                .Any(p => (int)p.Element("AporteTope") == aporteTope);
        }

        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaPlanes);

            var ultimoId = xDocument.Descendants("Plan")
                            .Select(p => (int)p.Attribute("Id"))
                            .DefaultIfEmpty(0)
                            .Max();

            return ultimoId + 1;
        }

        public List<int> ObtenerIdsPracticasDelPlan(int id)
        {
            xDocument = XDocument.Load(rutaPlanesPracticas);

            List<int> practicas = new List<int>();

            practicas = xDocument.Descendants("PracticaPlan")
                .Where(pp => (int)pp.Attribute("PlanId") == id)
                .Select(pp => (int)pp.Attribute("PracticaId")).ToList();

            return practicas;
        }

        public void AsignarPractica(BEPlan plan, BEPractica practica)
        {
            xDocument = XDocument.Load(rutaPlanesPracticas);

            xDocument.Element("PlanesPracticas").Add(
                    new XElement("PracticaPlan",
                        new XAttribute("PlanId", plan.Id),
                        new XAttribute("PracticaId", practica.Id)
                ));

            xDocument.Save(rutaPlanesPracticas);
        }

        public void QuitarPractica(BEPlan plan, BEPractica practica)
        {
            xDocument = XDocument.Load(rutaPlanesPracticas);
            
            var relacionElem = xDocument.Descendants("PracticaPlan")
                .FirstOrDefault(pp => (int)pp.Attribute("PlanId") == plan.Id && (int)pp.Attribute("PracticaId") == practica.Id);
            
            if (relacionElem == null)
            {
                throw new Exception("La práctica no está asignada al plan.");
            }

            relacionElem.Remove();
            
            xDocument.Save(rutaPlanesPracticas);
        }
        public bool ExisteAsignacion(int planId, int practicaId)
        {
            xDocument = XDocument.Load(rutaPlanesPracticas);

            return xDocument.Descendants("PracticaPlan")
                .Any(pp => (int)pp.Attribute("PlanId") == planId && (int)pp.Attribute("PracticaId") == practicaId);
        }

        private BEPlan MapearPlan(XElement element)
        {
            return new BEPlan(
                   (int)element.Attribute("Id"),
                   element.Element("Nombre").Value,
                   (int)element.Element("AporteTope")
                );
        }
    }
}
