using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Servicios;

namespace BLL
{
    public class BLLUsuario
    {
        MPPUsuario mppUsuario;
        BLLPermiso bllPermiso;

        public BLLUsuario (){
            mppUsuario = new MPPUsuario();
            bllPermiso = new BLLPermiso();
        }

        public void CrearUsuario(BEUsuario usuario)
        {
            try
            {
                if (mppUsuario.ObtenerPorNombreUsuario(usuario.NombreUsuario) != null)
                {
                    throw new Exception("El nombre de usuario ya existe en la base de datos.");
                }

                usuario.Id = mppUsuario.ObtenerProximoId();

                string passwordUsuario = usuario.Password;
                usuario.Password = ServicioSeguridad.Encriptar(passwordUsuario);

                usuario.Activo = true;
                usuario.Eliminado = false;

                mppUsuario.CrearUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear usuario: " + ex.Message);
            }
        }
        public void ModificarUsuario(BEUsuario usuario)
        {
            try
            {
                if (mppUsuario.ObtenerPorNombreUsuario(usuario.NombreUsuario) == null)
                {
                    throw new Exception("El usuario no existe.");
                }

                if(usuario.Nombre == "admin")
                {
                    throw new Exception("No se puede modificar el usuario administrador.");
                }

                mppUsuario.ActualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar usuario: " + ex.Message);
            }
        }
        public void DesactivarUsuario(BEUsuario usuario)
        {
            try
            {
                if(usuario.NombreUsuario == "admin")
                {
                    throw new Exception("No se puede desactivar el usuario administrador.");
                }

                if (!usuario.Activo)
                {
                    throw new Exception("El usuario ya está desactivado.");
                }

                usuario.Desactivar();
                mppUsuario.ActualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar usuario: " + ex.Message);
            }
        }

        public void ActivarUsuario(BEUsuario usuario)
        {
            try
            {
                if (usuario.Activo)
                {
                    throw new Exception("El usuario ya está activado.");
                }

                usuario.Activar();
                mppUsuario.ActualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al activar usuario: " + ex.Message);
            }
        }

        public void EliminarUsuario(BEUsuario usuario)
        {
            try {

                if(usuario.NombreUsuario == "admin")
                {
                    throw new Exception("No se puede eliminar el usuario administrador.");
                }

                if (usuario.Eliminado)
                {
                    throw new Exception("El usuario ya está eliminado.");
                }

                usuario.Eliminar();
                mppUsuario.EliminarUsuario(usuario);
            }
            catch (Exception ex) { throw new Exception("Error al eliminar usuario: " + ex.Message); }
        }
        public List<BEUsuario> ListarUsuarios()
        {
            try
            {
                List<BEUsuario> usuarios = mppUsuario.ObtenerTodos();

                foreach (BEUsuario usuario in usuarios) {
                    usuario.Permisos = ListarPermisosDeUsuario(usuario);
                }

                return usuarios;
            }
            catch (Exception ex) { throw new Exception("Error al listar usuarios: " + ex.Message); }
        }
        public void AsignarRol(BEUsuario usuario, BERol rol)
        {
            try
            {
                mppUsuario.AsignarRol(usuario, rol);
                usuario.AgregarPermiso(rol);
            }
            catch (Exception ex) { throw new Exception("Error al asignar rol: " + ex.Message); }
        }
        public void QuitarRol(BEUsuario usuario, BERol rol)
        {
            try
            {
                mppUsuario.QuitarRol(usuario, rol);
                usuario.RemoverPermiso(rol);
            }
            catch (Exception ex) { throw new Exception("Error al quitar rol: " + ex.Message); }
        }
        public void AsignarPermiso(BEUsuario usuario, BEPermisoSimple permiso)
        {
            try
            {
                if (usuario.TienePermiso(permiso.Nombre))
                {
                    throw new Exception("El usuario ya tiene este permiso asignado.");
                }
                mppUsuario.AsignarPermiso(usuario, permiso);
                usuario.AgregarPermiso(permiso);
            }
            catch (Exception ex) { throw new Exception("Error al asignar permiso: " + ex.Message); }
        }
        public void QuitarPermiso(BEUsuario usuario, BEPermiso permiso)
        {
            try
            {
                if (!usuario.TienePermiso(permiso.Nombre))
                {
                    throw new Exception("El usuario no tiene este permiso asignado.");
                }
                mppUsuario.QuitarPermiso(usuario, permiso);
                usuario.RemoverPermiso(permiso);
            }
            catch(Exception ex) { throw new Exception("Error al quitar permiso: " + ex.Message); }
        }
       
        public BEUsuario ObtenerUsuarioPorId(int id)
        {
            try
            {
                return mppUsuario.ObtenerPorId(id);
            }
            catch (Exception ex) { throw new Exception("Error al obtener usuario por ID: " + ex.Message); }
        }
        public BEUsuario ValidarLogin(BEUsuario usuarioLogin)
        {
            try
            {
                BEUsuario usuario = mppUsuario.ObtenerPorNombreUsuario(usuarioLogin.NombreUsuario);

                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                if (!usuario.Activo)
                {
                    throw new Exception("El usuario está desactivado.");
                }

                if(usuario.Eliminado)
                {
                    throw new Exception("El usuario ha sido eliminado.");
                }

                string passwordDesencriptada = ServicioSeguridad.Desencriptar(usuario.Password);

                if (passwordDesencriptada != usuarioLogin.Password)
                {
                    throw new Exception("Contraseña incorrecta.");
                }
                return usuario;
            }
            catch (Exception ex) { throw new Exception("Error al validar login: " + ex.Message); }
        }
        public void CambiarPassword(BEUsuario usuario, string nuevaPassword)
        {
            try
            {
                nuevaPassword = ServicioSeguridad.Encriptar(nuevaPassword);
                usuario.CambiarPassword(nuevaPassword);
                mppUsuario.ActualizarUsuario(usuario);
            }
            catch (Exception ex) { throw new Exception("Error al cambiar password: " + ex.Message); }
        }

        public void ResetearPassword(BEUsuario usuario)
        {
            try
            {
                if(usuario.Nombre == "admin")
                {
                    throw new Exception("No se puede resetear la contraseña del usuario administrador.");
                }

                string passwordDefault = "1234";
                string passwordEncriptada = ServicioSeguridad.Encriptar(passwordDefault);

                usuario.CambiarPassword(passwordEncriptada);
                
                mppUsuario.ActualizarUsuario(usuario);
            }
            catch (Exception ex) { throw new Exception("Error al resetear password: " + ex.Message); }
        }
        public List<BEPermiso> ListarPermisosDeUsuario(BEUsuario usuario)
        {
            try
            {
                List<int> permisosIdUsuario = mppUsuario.ListarPermisosDeUsuario(usuario);

                List<BEPermiso> permisos = new List<BEPermiso>();

                foreach(int permisoId in permisosIdUsuario)
                {
                    BEPermiso permiso = bllPermiso.ObtenerPorId(permisoId);
                    if(permiso is BERol)
                    {
                        BERol rol = (BERol)permiso;
                        List<BEPermisoSimple> permisosDelRol = bllPermiso.ListarPermisosDeRol(rol);

                        foreach (BEPermisoSimple permisoSimple in permisosDelRol)
                        {
                            rol.AgregarPermiso(permisoSimple);
                        }

                        permisos.Add(rol);
                    }else
                    {
                        permisos.Add(permiso);
                    }
                }

                return permisos;
            }
            catch (Exception ex) { throw new Exception("Error al listar permisos de usuario: " + ex.Message); }
        }
    }
}
