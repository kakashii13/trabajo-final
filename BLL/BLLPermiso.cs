using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using MPP;

namespace BLL
{
    public class BLLPermiso
    {
        MPPPermiso mppPermiso = new MPPPermiso();

        public void CrearPermiso(BEPermiso permiso, bool esRol) {
            try
            {
                if (mppPermiso.ExistePermiso(permiso))
                {
                    throw new Exception("El permiso ya existe.");
                }

                permiso.Id = mppPermiso.ObtenerProximoId();
                mppPermiso.CrearPermiso(permiso, esRol);
            }
            catch (Exception ex) { throw new Exception("Error al crear permiso: " + ex.Message); }
        }
        public void ModificarPermiso(BEPermiso permiso)
        {
            try
            {
                if (mppPermiso.ExistePermiso(permiso))
                {
                    throw new Exception($"Ya existe otro permiso con el nombre '{permiso.Nombre}'.");
                }

                mppPermiso.ModificarPermiso(permiso);
            }
            catch (Exception ex) { throw new Exception("Error al modificar permiso: " + ex.Message); }
        }
        public void BorrarPermiso(BEPermiso permiso)
        {
            try
            {
                if (mppPermiso.PermisoEnUso(permiso))
                {
                    throw new Exception("No se puede eliminar el permiso porque está en uso.");
                }
                mppPermiso.BorrarPermiso(permiso);
            }
            catch (Exception ex) { throw new Exception("Error al borrar permiso: " + ex.Message); }
        }
        public List<BEPermisoSimple> ListarPermisos()
        {
            try
            {
                return mppPermiso.ListarPermisos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar permisos: " + ex.Message);
            }
        }
        public List<BERol> ListarRolesConPermisos()
        {
            try
            {
                List<BERol> roles = mppPermiso.ListarRoles();

                foreach(BERol rol in roles)
                {
                    List<BEPermisoSimple> permisos = ListarPermisosDeRol(rol);

                    foreach (var permiso in permisos)
                    {
                        rol.AgregarPermiso(permiso);
                    }
                }

                return roles;
            }
            catch (Exception ex) { throw new Exception("Error al listar roles: " + ex.Message); }
        }
        public BEPermiso ObtenerPorId(int id)
        {
            try
            {
                return mppPermiso.ObtenerPorId(id);
            }
            catch (Exception ex) { throw new Exception("Error al obtener permiso por ID: " + ex.Message); }
        }
        public void AsignarPermiso(BERol rol, BEPermisoSimple permiso)
        {
            try
            {
                if (rol.ObtenerPermisos().Any(p => p.Id == permiso.Id))
                {
                    throw new Exception("El permiso ya está asignado al rol.");
                }

                mppPermiso.AsignarPermiso(rol, permiso);

                rol.AgregarPermiso(permiso);
            }
            catch (Exception ex) { throw new Exception("Error al asignar permiso al rol: " + ex.Message); }
        }
        public void RemoverPermiso(BERol rol, BEPermisoSimple permiso)
        {
            try
            {
                if(!rol.ObtenerPermisos().Any(p => p.Id == permiso.Id)){
                    throw new Exception("El permiso no está asignado al rol.");
                }

                mppPermiso.RemoverPermiso(rol, permiso);

                rol.RemoverPermiso(permiso);
            }
            catch (Exception ex) { throw new Exception("Error al remover permiso del rol: " + ex.Message); }
        }
        public List<BEPermisoSimple> ListarPermisosDeRol(BERol rol)
        {
            try
            {
                return mppPermiso.ObtenerPermisosDeRol(rol.Id);
            }
            catch (Exception ex) { throw new Exception("Error al listar permisos del rol: " + ex.Message); }
        }
        public List<BEPermiso> ObtenerPermisosPorIds(List<int> ids)
        {
            try
            {
                return mppPermiso.ObtenerPermisosPorIds(ids);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener permisos: " + ex.Message);
            }
        }
    }
}
