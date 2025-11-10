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
    public class MPPPermiso
    {
        XDocument xDocument;
        private readonly string rutaPermisos;
        private readonly string rutaRolesPermisos;

        public MPPPermiso()
        {
            rutaPermisos = Path.Combine(ServicioDirectorio.RutaDB, "permisos.xml");
            rutaRolesPermisos = Path.Combine(ServicioDirectorio.RutaDB, "roles_permisos.xml");

            if (!File.Exists(rutaPermisos))
            {
                xDocument = new XDocument(new XElement("Permisos"));
                xDocument.Save(rutaPermisos);
            }

            if (!File.Exists(rutaRolesPermisos))
            {
                xDocument = new XDocument(new XElement("RolesPermisos"));
                xDocument.Save(rutaRolesPermisos);
            }
        }
        public void CrearPermiso(BEPermiso permiso, bool esRol)
        {
            xDocument = XDocument.Load(rutaPermisos);

            if (esRol)
            {
                xDocument.Element("Permisos").Add(
                new XElement("Permiso",
                new XAttribute("Id", permiso.Id),
                new XElement("Nombre", permiso.Nombre),
                new XElement("EsRol", true)
                )
            );
            }else
            {
                xDocument.Element("Permisos").Add(
                        new XElement("Permiso",
                        new XAttribute("Id", permiso.Id),
                        new XElement("Nombre", permiso.Nombre),
                        new XElement("EsRol", false))
                    );
            }

            xDocument.Save(rutaPermisos);
        }
        public void BorrarPermiso(BEPermiso permiso)
        {
            xDocument = XDocument.Load(rutaPermisos);

            var permisoAEliminar = xDocument.Descendants("Permiso")
                .FirstOrDefault(p => (int)p.Attribute("Id") == permiso.Id);

            if (permisoAEliminar == null) throw new Exception("El permiso no existe.");
                
            permisoAEliminar.Remove();

            xDocument.Save(rutaPermisos);
        }
        public void ModificarPermiso(BEPermiso permiso)
        {
            xDocument = XDocument.Load(rutaPermisos);

            var permisoAModificar = xDocument.Descendants("Permiso")
                .FirstOrDefault(p => (int)p.Attribute("Id") == permiso.Id);

            if (permisoAModificar == null) throw new Exception("El permiso no existe.");
                
            permisoAModificar.Element("Nombre").Value = permiso.Nombre;

            xDocument.Save(rutaPermisos);
        }
        public List<BEPermisoSimple> ListarPermisos()
        {
            xDocument = XDocument.Load(rutaPermisos);

            List<BEPermisoSimple> permisos = xDocument.Descendants("Permiso")
                .Where(p => (bool)p.Element("EsRol") == false)
                .Select(x => MapearPermisoSimple(x))
                .ToList();

            return permisos;
        }
        public List<BERol> ListarRoles()
        {
            xDocument = XDocument.Load(rutaPermisos);

            List<BERol> roles = xDocument.Descendants("Permiso")
                .Where(p => (bool)p.Element("EsRol") == true)
                .Select(x => MapearRol(x))
                .ToList();

            return roles;
        }
        public bool PermisoEnUso(BEPermiso permiso)
        {
            xDocument = XDocument.Load(rutaRolesPermisos);

            bool enUso = xDocument.Descendants("RolPermiso").Any(rp => (int)rp.Attribute("PermisoId") == permiso.Id);

            return enUso; 
        }
        public bool ExistePermiso(BEPermiso permiso)
        {
            xDocument = XDocument.Load(rutaPermisos);

            bool existe = xDocument.Descendants("Permiso")
                .Any(p => p.Element("Nombre")
                .Value.Equals(permiso.Nombre, StringComparison.OrdinalIgnoreCase));

            return existe;
        }
        public BEPermiso ObtenerPorId(int id)
        {
            xDocument = XDocument.Load(rutaPermisos);

            var elem = xDocument.Descendants("Permiso")
                .FirstOrDefault(p => (int)p.Attribute("Id") == id);

            bool esRol = bool.Parse(elem.Element("EsRol").Value);
                
            if (esRol)
            {
                return MapearRol(elem);
            }
            else
            {
                return MapearPermisoSimple(elem);
            }
        }
        public void AsignarPermiso(BERol rol, BEPermisoSimple permiso)
        {
            xDocument = XDocument.Load(rutaRolesPermisos);

            xDocument.Element("RolesPermisos").Add(
                    new XElement("RolPermiso",
                    new XAttribute("RolId", rol.Id),
                    new XAttribute("PermisoId", permiso.Id))
                );
            xDocument.Save(rutaRolesPermisos);
        }
        public void RemoverPermiso(BERol rol, BEPermisoSimple permiso)
        {
            xDocument = XDocument.Load(rutaRolesPermisos);

            var elem = xDocument.Descendants("RolPermiso")
                .FirstOrDefault(rp => (int)rp.Attribute("RolId") == rol.Id && (int)rp.Attribute("PermisoId") == permiso.Id);
            
            if (elem == null)
            {
                throw new Exception("El permiso no está asignado al rol.");
            }
            
            elem.Remove();

            xDocument.Save(rutaRolesPermisos);
        }
        public List<BEPermisoSimple> ObtenerPermisosDeRol(int rolId)
        {
            XDocument docRolesPermisos = XDocument.Load(rutaRolesPermisos);
            XDocument docPermisos = XDocument.Load(rutaPermisos);

            var idsPermisos = docRolesPermisos.Descendants("RolPermiso")
                .Where(rp => int.Parse(rp.Attribute("RolId").Value) == rolId)
                .Select(rp => int.Parse(rp.Attribute("PermisoId").Value))
                .ToList();

            return docPermisos.Descendants("Permiso")
                .Where(p => idsPermisos.Contains(int.Parse(p.Attribute("Id").Value)))
                .Where(p => p.Element("EsRol")?.Value == "false")
                .Select(p => MapearPermisoSimple(p))
                .ToList();
        }
        public List<BEPermiso> ObtenerPermisosPorIds(List<int> ids)
        {
            XDocument doc = XDocument.Load(rutaPermisos);

            List<BEPermiso> permisos = new List<BEPermiso>();

            foreach (var elemento in doc.Descendants("Permiso")
                .Where(p => ids.Contains(int.Parse(p.Attribute("Id").Value))))
            {
                bool esRol = bool.Parse(elemento.Element("EsRol").Value);

                if (esRol)
                {
                    permisos.Add(MapearRol(elemento));
                }
                else
                {
                    permisos.Add(MapearPermisoSimple(elemento));
                }
            }

            return permisos;
        }
        private BEPermisoSimple MapearPermisoSimple(XElement elemento)
        {
            return new BEPermisoSimple(elemento.Element("Nombre").Value)
            {
                Id = (int)elemento.Attribute("Id")
            };
        }
        private BERol MapearRol(XElement elemento)
        {
            return new BERol(elemento.Element("Nombre").Value)
            {
                Id = (int)elemento.Attribute("Id")
            };
        }
        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaPermisos);

            var ultimoId = xDocument.Descendants("Permiso")
                .Select(p => (int)p.Attribute("Id"))
                .DefaultIfEmpty(0)
                .Max();

            return ultimoId + 1;
        }

    }
}
