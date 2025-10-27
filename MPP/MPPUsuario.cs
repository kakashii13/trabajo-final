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
    public class MPPUsuario
    {
        XDocument xDocument;
        private readonly string rutaUsuarios;
        private readonly string rutaUsuariosPermisos;

        public MPPUsuario()
        {
            rutaUsuarios = Path.Combine(ServicioDirectorio.RutaDB, "usuarios.xml");
            rutaUsuariosPermisos = Path.Combine(ServicioDirectorio.RutaDB, "usuarios_permisos.xml");
            // si el archivo no existe, lo creamos con la estructura base
            if (!File.Exists(rutaUsuarios))
            {
                xDocument = new XDocument(
                    new XElement("Usuarios")
                );
                xDocument.Save(rutaUsuarios);
            }

            if (!File.Exists(rutaUsuariosPermisos))
            {
                xDocument = new XDocument(
                    new XElement("UsuariosPermisos")
                );
                xDocument.Save(rutaUsuariosPermisos);
            }
        }

        public void CrearUsuario(BEUsuario usuario)
        {
            xDocument = XDocument.Load(rutaUsuarios);

            xDocument.Element("Usuarios").Add(
                new XElement("Usuario",
                new XAttribute("Id", usuario.Id),
                new XElement("Nombre", usuario.Nombre),
                new XElement("Apellido", usuario.Apellido),
                new XElement("NombreUsuario", usuario.NombreUsuario),
                new XElement("Password", usuario.Password),
                new XElement("Activo", usuario.Activo.ToString().ToLower()),
                new XElement("Eliminado", usuario.Eliminado.ToString().ToLower())
                ));
            xDocument.Save(rutaUsuarios);
        }
        public void ActualizarUsuario(BEUsuario usuario)
        {
            xDocument = XDocument.Load(rutaUsuarios);
            
            var usuarioElem = xDocument.Descendants("Usuario")
                .FirstOrDefault(u => (int)u.Attribute("Id") == usuario.Id);

            if( usuarioElem == null)
            {
                throw new Exception("Usuario no encontrado.");
            }
            
            usuarioElem.Element("Nombre").Value = usuario.Nombre;
            usuarioElem.Element("Apellido").Value = usuario.Apellido;
            usuarioElem.Element("NombreUsuario").Value = usuario.NombreUsuario;
            usuarioElem.Element("Password").Value = usuario.Password;
            usuarioElem.Element("Activo").Value = usuario.Activo.ToString().ToLower();
            
            xDocument.Save(rutaUsuarios);
        }

        public void EliminarUsuario(BEUsuario usuario)
        {
            xDocument = XDocument.Load(rutaUsuarios);

            var usuarioElem = xDocument.Descendants("Usuario")
                .FirstOrDefault(u => (int)u.Attribute("Id") == usuario.Id);

            if (usuarioElem == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            usuarioElem.Element("Eliminado").Value = true.ToString().ToLower();

            xDocument.Save(rutaUsuarios);
        }
        public BEUsuario ObtenerPorNombreUsuario(string nombreUsuario)
        {
            xDocument = XDocument.Load(rutaUsuarios);

            var usuario = xDocument.Descendants("Usuario")
                .Where(u => u.Element("NombreUsuario").Value == nombreUsuario)
                .Select(u => MapearUsuario(u))
                .FirstOrDefault();

            return usuario;
        }
        public BEUsuario ObtenerPorId(int id)
        {
            xDocument = XDocument.Load(rutaUsuarios);
            
            var usuario = xDocument.Descendants("Usuario")
                .Where(u => (int)u.Attribute("Id") == id)
                .Select(u => MapearUsuario(u))
                .FirstOrDefault();

            return usuario;
        }
        public List<BEUsuario> ObtenerTodos()
        {
            xDocument = XDocument.Load(rutaUsuarios);

            List<BEUsuario> usuarios = xDocument.Descendants("Usuario")
                .Where(u => bool.Parse(u.Element("Eliminado").Value) == false)
                .Select(u => MapearUsuario(u))
                .ToList();
            
            return usuarios;
        }
        public int ObtenerProximoId()
        {
            xDocument = XDocument.Load(rutaUsuarios);
            
            var ultimoId = xDocument.Descendants("Usuario")
                .Select(u => (int)u.Attribute("Id"))
                .DefaultIfEmpty(0)
                .Max();

            return ultimoId + 1;
        }
        public void AsignarRol(BEUsuario usuario, BERol rol)
        {
            xDocument = XDocument.Load(rutaUsuariosPermisos);

            xDocument.Element("UsuariosPermisos").Add(
                new XElement("UsuarioPermiso",
                    new XElement("UsuarioId", usuario.Id),
                    new XElement("PermisoId", rol.Id) 
                )
            );

            xDocument.Save(rutaUsuariosPermisos);
        }
        public void QuitarRol(BEUsuario usuario, BERol rol)
        {
            xDocument = XDocument.Load(rutaUsuariosPermisos);
            
            var permisoElem = xDocument.Descendants("UsuarioPermiso")
                .FirstOrDefault(r => (int)r.Element("UsuarioId") == usuario.Id &&
                                        (int)r.Element("PermisoId") == rol.Id);
            if (permisoElem == null)
            {
                throw new Exception("El rol no está asignado al usuario.");
            }

            permisoElem.Remove();

            xDocument.Save(rutaUsuariosPermisos);
        }
        public void AsignarPermiso(BEUsuario usuario, BEPermisoSimple permiso)
        {
            xDocument = XDocument.Load(rutaUsuariosPermisos);

            xDocument.Element("UsuariosPermisos").Add(
                new XElement("UsuarioPermiso",
                new XElement("UsuarioId", usuario.Id),
                new XElement("PermisoId", permiso.Id)
                )
            );

            xDocument.Save(rutaUsuariosPermisos);
        }
        public void QuitarPermiso(BEUsuario usuario, BEPermiso permiso)
        {
            xDocument = XDocument.Load(rutaUsuariosPermisos);
            
            var permisoElem = xDocument.Descendants("UsuarioPermiso")
                .FirstOrDefault(r => (int)r.Element("UsuarioId") == usuario.Id &&
                                        (int)r.Element("PermisoId") == permiso.Id);
            if (permisoElem == null)
            {
                throw new Exception("El permiso no está asignado al usuario o está asignado a traves de un rol.");
            }
            
            permisoElem.Remove();

            xDocument.Save(rutaUsuariosPermisos);
        }
        public bool ExistePermisoAsignado(BEUsuario usuario, BEPermiso permiso)
        {
            xDocument = XDocument.Load(rutaUsuariosPermisos);

            var existe = xDocument.Descendants("UsuarioPermiso")
                .Any(r => (int)r.Element("UsuarioId") == usuario.Id &&
                          (int)r.Element("PermisoId") == permiso.Id);
            return existe;
        }
        public List<int> ListarPermisosDeUsuario(BEUsuario usuario)
        {
            xDocument = XDocument.Load(rutaUsuariosPermisos);

            var permisosIds = xDocument.Descendants("UsuarioPermiso")
            .Where(r => (int)r.Element("UsuarioId") == usuario.Id)
            .Select(r => (int)r.Element("PermisoId"))
            .ToList();

            return permisosIds;
        }

        private BEUsuario MapearUsuario(XElement element)
        {
            return new BEUsuario(
                element.Element("Nombre").Value,
                element.Element("Apellido").Value,
                element.Element("Password").Value,
                element.Element("NombreUsuario").Value,
                (int)element.Attribute("Id"),
                bool.Parse(element.Element("Activo").Value),
                bool.Parse(element.Element("Eliminado").Value)
            );
        }
    }
}
