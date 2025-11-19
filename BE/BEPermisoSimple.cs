using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPermisoSimple : BEPermiso
    {
        public BEPermisoSimple(string nombre) : base(nombre) { }
        public override void AgregarPermiso(BEPermiso permiso)
        {
            throw new InvalidOperationException("No se pueden agregar permisos a un permiso simple.");
        }
        public override void RemoverPermiso(BEPermiso permiso)
        {
            throw new InvalidOperationException("No se pueden eliminar permisos de un permiso simple.");
        }
        public override List<BEPermiso> ObtenerPermisos()
        {
            return new List<BEPermiso>();
        }
        public override bool TienePermiso(string nombre)
        {
            return Nombre.Equals(nombre);
        }
    }
}
