using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using Microsoft.SqlServer.Server;
using Servicios;

namespace MPP
{
    public class MPPPrestador
    {
        XDocument xDocument;
        private readonly string rutaArchivoPrestadores;
        private readonly string rutaArchivoPracticasPrestadores;

        public MPPPrestador()
        {
            rutaArchivoPrestadores = Path.Combine(ServicioDirectorio.RutaDB, "prestadores.xml");
            rutaArchivoPracticasPrestadores = Path.Combine(ServicioDirectorio.RutaDB, "practicas_prestadores.xml");

            // si el archivo no existe, lo creamos con la estructura basica
            if (!File.Exists(rutaArchivoPrestadores))
            {
                xDocument = new XDocument(
                    new XElement("Prestadores")
                );
                xDocument.Save(rutaArchivoPrestadores);
            }
        }

        public void CrearPrestador(BEPrestador prestador)
        {
            xDocument = XDocument.Load(rutaArchivoPrestadores);

            xDocument.Element("Prestadores").Add(
                    new XElement("Prestador",
                    new XAttribute("Id", prestador.Id),
                    new XElement("Cuit", prestador.Cuit),
                    new XElement("RazonSocial", prestador.RazonSocial)
            ));
            
            xDocument.Save(rutaArchivoPrestadores);
        }

        public bool ExistePrestador(string cuit)
        {
            xDocument = XDocument.Load(rutaArchivoPrestadores);
           
            var prestador = xDocument.Descendants("Prestador")
                .FirstOrDefault(p => p.Element("Cuit")?.Value == cuit);
            
            return prestador != null;
        }

        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaArchivoPrestadores);
            
            var ultimoId = xDocument.Descendants("Prestador")
                .Select(p => (int)p.Attribute("Id"))
                .DefaultIfEmpty(0)
                .Max();

            return ultimoId + 1;
        }

        public List<BEPrestador> ListarPrestadores()
        {
            xDocument = XDocument.Load(rutaArchivoPrestadores);

            List<BEPrestador> prestadores = xDocument.Descendants("Prestador")
                .Select(p => MapearPrestador(p))
                .ToList();

            return prestadores;
        }

        public List<int> ListarPrestadoresIdsSegunPractica(BEPractica practica)
        {
            xDocument = XDocument.Load(rutaArchivoPracticasPrestadores);

            List<int> idsPrestadores = xDocument.Descendants("PracticaPrestador")
                .Where(pp => (int)pp.Attribute("PracticaId") == practica.Id)
                .Select(pp => (int)pp.Attribute("PrestadorId"))
                .ToList();

            return idsPrestadores;
        }

        public BEPrestador ObtenerPrestadorPorId(int id)
        {
            xDocument = XDocument.Load(rutaArchivoPrestadores);

            var prestador = xDocument.Descendants("Prestador")
                .Where(p => (int)p.Attribute("Id") == id)
                .Select(p => MapearPrestador(p))
                .FirstOrDefault();

            return prestador; 
        }

        public List<int> ListarPracticasIdsPorPrestador(BEPrestador prestador)
        {
            xDocument = XDocument.Load(rutaArchivoPracticasPrestadores);

            List<int> idsPracticas = xDocument.Descendants("PracticaPrestador")
                    .Where(pp => (int)pp.Attribute("PrestadorId") == prestador.Id)
                    .Select(pr => (int)pr.Attribute("PracticaId"))
                    .ToList();

            return idsPracticas;
        }

        public void AsignarPractica(BEPrestador prestador, BEPractica practica)
        {
            xDocument = XDocument.Load(rutaArchivoPracticasPrestadores);
            
            xDocument.Element("PracticasPrestadores").Add(
                      new XElement("PracticaPrestador",
                            new XAttribute("PrestadorId", prestador.Id),
                            new XAttribute("PracticaId", practica.Id)
                    ));

            xDocument.Save(rutaArchivoPracticasPrestadores);
        }

        public void QuitarPractica(BEPrestador prestador, BEPractica practica)
        {
            try
            {
                xDocument = XDocument.Load(rutaArchivoPracticasPrestadores);
                
                var relacionElem = xDocument.Descendants("PracticaPrestador")
                    .FirstOrDefault(pp => (int)pp.Attribute("PrestadorId") == prestador.Id &&
                                         (int)pp.Attribute("PracticaId") == practica.Id);
                if (relacionElem == null)
                {
                    throw new Exception("La práctica no está asignada al prestador.");
                }
                
                relacionElem.Remove();

                xDocument.Save(rutaArchivoPracticasPrestadores);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool ExisteAsignacion(BEPrestador prestador, BEPractica practica)
        {
            xDocument = XDocument.Load(rutaArchivoPracticasPrestadores);

            var relacionElem = xDocument.Descendants("PracticaPrestador")
                .FirstOrDefault(pp => (int)pp.Attribute("PrestadorId") == prestador.Id &&
                                     (int)pp.Attribute("PracticaId") == practica.Id);

            return relacionElem != null;
        }

        private BEPrestador MapearPrestador(XElement prestadorElem)
        {
            return new BEPrestador
            (
                (int)prestadorElem.Attribute("Id"),
                prestadorElem.Element("Cuit").Value,
                prestadorElem.Element("RazonSocial").Value
            );
        }
    }
}
