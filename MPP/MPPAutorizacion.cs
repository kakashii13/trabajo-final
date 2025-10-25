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
    public class MPPAutorizacion
    {
        XDocument xDocument;
        private readonly string rutaArchivo;

        public MPPAutorizacion()
        {
            rutaArchivo = Path.Combine(ServicioDirectorio.RutaDB, "autorizaciones.xml");
            if (!File.Exists(rutaArchivo))
            {
                // si no existe el archivo, crear uno nuevo con la estructura base
                xDocument = new XDocument(
                    new XElement("Autorizaciones")
                );
                xDocument.Save(rutaArchivo);
            }
        }

        public void CrearAutorizacion(BEAutorizacion autorizacion)
        {
            xDocument = XDocument.Load(rutaArchivo);

            xDocument.Element("Autorizaciones").Add(
                        new XElement("Autorizacion", 
                        new XAttribute("Id", autorizacion.Id),
                            new XElement("FechaAutorizacion", autorizacion.FechaAutorizacion.ToString("yyyy-MM-dd")),
                            new XElement("NumeroAutorizacion", autorizacion.NumeroAutorizacion),
                            new XElement("Facturada", autorizacion.Facturada.ToString().ToLower()),
                            new XElement("PrestadorId", autorizacion.Prestador.Id),
                            new XElement("PracticaId", autorizacion.Practica.Id),
                            new XElement("AfiliadoId", autorizacion.Afiliado.Id)
                        )
                );
            xDocument.Save(rutaArchivo);
        }

        public void ModificarAutorizacion(BEAutorizacion autorizacion)
        {
            xDocument = XDocument.Load(rutaArchivo);

            var elemento = xDocument.Descendants("Autorizacion")
                .Where(x => (int)x.Attribute("Id") == autorizacion.Id)
                .FirstOrDefault();

            if (elemento == null)
                throw new Exception("No se encontro la autorización a modificar.");

            elemento.Element("Facturada").Value = autorizacion.Facturada.ToString().ToLower();

            xDocument.Save(rutaArchivo);
        }

        public List<BEAutorizacion> ListarAutorizaciones()
        {
           xDocument = XDocument.Load(rutaArchivo);
           
            List<BEAutorizacion> autorizaciones = xDocument.Descendants("Autorizacion")
                .Select(x => MapearAutorizacion(x))
                .ToList();

            return autorizaciones;
        }

        public BEAutorizacion ObtenerAutorizacionPorNumero(int numeroAutorizacion) {
            
            xDocument = XDocument.Load(rutaArchivo);

            var autorizacion = xDocument.Descendants("Autorizacion")
                .Where(x => (int)x.Element("NumeroAutorizacion") == numeroAutorizacion)
                .Select(x => MapearAutorizacion(x))
                .FirstOrDefault();

            return autorizacion;
        }

        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaArchivo);
            
            int ultimoId = xDocument.Descendants("Autorizacion")
                .Select(x => (int)x.Attribute("Id"))
                .DefaultIfEmpty(0)
                .Max();

            return ultimoId + 1;
        }

        public int ObtenerProximoNumeroAutorizacion()
        {
            xDocument = XDocument.Load(rutaArchivo);

            int ultimoNro = xDocument.Descendants("Autorizacion")
                .Select(x => (int)x.Element("NumeroAutorizacion"))
                .DefaultIfEmpty(1)
                .Max();

            return ultimoNro + 1;
        }

        private BEAutorizacion MapearAutorizacion(XElement elemento)
        {
            return new BEAutorizacion(
                (int)elemento.Attribute("Id"),
                (int)elemento.Element("NumeroAutorizacion"),
                DateTime.Parse((string)elemento.Element("FechaAutorizacion")),
                bool.Parse(elemento.Element("Facturada").Value),
                new BEPrestador { Id = (int)elemento.Element("PrestadorId") },
                new BEPractica { Id = (int)elemento.Element("PracticaId") },
                new BEAfiliado { Id = (int)elemento.Element("AfiliadoId") }
            );
        }
    }
}
