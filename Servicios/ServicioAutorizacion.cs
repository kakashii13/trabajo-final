using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Servicios
{
    public class ServicioAutorizacion
    {
        private BEUsuario usuarioLogueado;

        public ServicioAutorizacion(BEUsuario usuarioLogueado)
        {
            this.usuarioLogueado = usuarioLogueado;
        }

        public bool TienePermiso(string permiso)
        {
            //if (usuarioLogueado == null || usuarioLogueado.Rol == null)
            //{
            //    return false;
            //}
            //return usuarioLogueado.Rol.TienePermiso(permiso);
            return true;
        }
    }
}
