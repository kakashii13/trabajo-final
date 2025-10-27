using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BLL;
using Servicios;

namespace Infraestructura
{
    public class Inicializacion
    {
        private static BLLPermiso bllPermiso;
        private static BLLUsuario bllUsuario;

        // creamos un archivo control para verificar que la inicializacion ya se realizo
        private static readonly string ArchivoControl = Path.Combine(
        ServicioDirectorio.RutaSystem,
        "inicializado.txt"
        );

        public static void InicializarSistema()
        {
            // inicializamos la estructura de directorios
            ServicioDirectorio.InicializarEstructura();

            // verificamos si el archivo de control existe
            if (!File.Exists(ArchivoControl))
            {
                bllPermiso = new BLLPermiso();
                bllUsuario = new BLLUsuario();

                // creamos el archivo de control para futuras ejecuciones
                File.WriteAllText(ArchivoControl, DateTime.Now.ToString());

                try
                {
                    CrearPermisosDefault();
                    CrearRolDefault();
                    CrearUsuarioAdmin();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al inicializar el sistema: {ex.Message}");
                }
            }
        }

        private static void CrearPermisosDefault()
        {
            List<BEPermiso> permisos = new List<BEPermiso>
        {
            //new BEPermisoSimple("inicio.cambiarClave"),
            //new BEPermisoSimple("inicio.cerrarSesion"),
            new BEPermisoSimple("admin.usuarios"),
            new BEPermisoSimple("admin.rolesPermisos"),
            new BEPermisoSimple("padron.registrarAfiliado"),
            new BEPermisoSimple("padron.listadoAfiliados"),
            new BEPermisoSimple("padron.registrarAporte"),
            new BEPermisoSimple("padron.consultarAportes"),
            new BEPermisoSimple("autorizaciones.crearSolicitud"),
            new BEPermisoSimple("autorizaciones.resolverSolicitud"),
            new BEPermisoSimple("autorizaciones.listarAutorizaciones"),
            new BEPermisoSimple("facturacion.registrarFactura"),
            new BEPermisoSimple("facturacion.consultarFacturas"),
            new BEPermisoSimple("facturacion.registrarPago"),
            new BEPermisoSimple("prestadores.registrarPrestador"),
            new BEPermisoSimple("prestadores.administrarPracticaPorPlan"),
            new BEPermisoSimple("prestadores.consultarPracticasPorPlan"),
            new BEPermisoSimple("prestadores.administrarPrestadorPorPractica"),
            new BEPermisoSimple("prestadores.consultarPrestadoresPorPractica"),
            new BEPermisoSimple("prestadores.abmPlanes"),
            new BEPermisoSimple("prestadores.abmPracticas"),
            new BEPermisoSimple("baseDatos.backup"),
            new BEPermisoSimple("baseDatos.restore"),
            new BEPermisoSimple("baseDatos.bitacora"),
            new BEPermisoSimple("dashboard")
        };

            foreach (var permiso in permisos)
            {
                bllPermiso.CrearPermiso(permiso, false);
            }
        }
        private static void CrearRolDefault()
        {
            BERol rolAdmin = new BERol("admin");

            var permisos = bllPermiso.ListarPermisos()
                .Where(p => p.Nombre != "admin");

            bllPermiso.CrearPermiso(rolAdmin, true);

            foreach (var permiso in permisos)
            {
                bllPermiso.AsignarPermiso(rolAdmin, permiso);
            }
        }

        private static void CrearUsuarioAdmin()
        {
            BERol rol = bllPermiso.ListarRolesConPermisos()
                .FirstOrDefault(r => r.Nombre == "admin");

            BEUsuario usuarioAdmin = new BEUsuario("admin","admin", "admin", "admin", 0, true, false);

            bllUsuario.CrearUsuario(usuarioAdmin);
            bllUsuario.AsignarRol(usuarioAdmin, rol);
        }
    }
}
