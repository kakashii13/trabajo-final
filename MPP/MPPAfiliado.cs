using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using System.IO;
using Servicios;

namespace MPP
{
    public class MPPAfiliado
    {
        XDocument xDocument;
        private readonly string rutaArchivo;

        public MPPAfiliado()
        {
            rutaArchivo = Path.Combine(ServicioDirectorio.RutaDB, "afiliados.xml");
            if (!File.Exists(rutaArchivo))
            {
                xDocument = new XDocument(
                    new XElement("Afiliados")
                );
                xDocument.Save(rutaArchivo);
            }
        }
        public void CrearAfiliado(BEAfiliado afiliado)
        {
            xDocument = XDocument.Load(rutaArchivo);

            xDocument.Element("Afiliados").Add(
                new XElement("Afiliado",
                    new XElement("Id", afiliado.Id),
                    new XElement("NombreApellido", afiliado.NombreApellido),
                    new XElement("Cuil", afiliado.Cuil),
                    new XElement("Activo", afiliado.Activo.ToString().ToLower()),
                    new XElement("Telefono", afiliado.Telefono)
                )
            );

            xDocument.Save(rutaArchivo);
        }
        public void ModificarAfiliado(BEAfiliado afiliado)
        {
            xDocument = XDocument.Load(rutaArchivo);
            
            var afiliadoElement = xDocument.Descendants("Afiliado")
                .FirstOrDefault(a => (int)a.Element("Id") == afiliado.Id);
            
            if (afiliadoElement == null)
            {
                throw new Exception("Afiliado no encontrado");
            }
            
            afiliadoElement.Element("Activo").Value = afiliado.Activo.ToString().ToLower();
            
            xDocument.Save(rutaArchivo);
        }
        public List<BEAfiliado> ListarAfiliados()
        {
            xDocument = XDocument.Load(rutaArchivo);

            List<BEAfiliado> afiliados = xDocument.Descendants("Afiliado").
                Select(a => MapearAfiliado(a)).ToList();
            
            return afiliados;
        }
        public BEAfiliado ObtenerAfiliadoPorCuil(string cuil)
        {
            xDocument = XDocument.Load(rutaArchivo);

            var afiliado = xDocument.Descendants("Afiliado")
                .Where(a => (string)a.Element("Cuil") == cuil)
                .Select(a => MapearAfiliado(a))
                .FirstOrDefault();
            
            return afiliado;
        }
        public BEAfiliado ObtenerAfiliadoPorId(int id)
        {
            xDocument = XDocument.Load(rutaArchivo);

            var afiliado = xDocument.Descendants("Afiliado")
                .Where(a => (int)a.Element("Id") == id)
                .Select(a => MapearAfiliado(a))
                .FirstOrDefault();

            return afiliado;
        }
        public int ObtenerProximoId()
        {
            string rutaArchivo = Path.Combine(ServicioDirectorio.RutaDB, "afiliados.xml");
            xDocument = XDocument.Load(rutaArchivo);
            var ultimoId = xDocument.Descendants("Afiliado")
                .Select(a => (int)a.Element("Id"))
                .DefaultIfEmpty(0)
                .Max();

            return ultimoId + 1;
        }
        private BEAfiliado MapearAfiliado(XElement elemento)
        {
            return new BEAfiliado(
                 (int)elemento.Element("Id"),
                 elemento.Element("NombreApellido").Value,
                 elemento.Element("Cuil").Value,
                 bool.Parse(elemento.Element("Activo").Value),
                 elemento.Element("Telefono").Value
             );
        }
    }
}
