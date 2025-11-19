using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BERol : BEPermiso
    {

        private List<BEPermiso> _permisos;

        public BERol(string nombre) : base (nombre)
        {
            _permisos = new List<BEPermiso>();
        }
        public override void AgregarPermiso(BEPermiso permiso)
        {
            _permisos.Add(permiso);
        }
        public override List<BEPermiso> ObtenerPermisos()
        {
            return _permisos;
        }
        public override void RemoverPermiso(BEPermiso permiso)
        {

            if (_permisos != null)
            {
                var permisoARemover = _permisos.FirstOrDefault(p => p.Id == permiso.Id);
                if (permisoARemover != null)
                {
                    _permisos.Remove(permisoARemover);
                }
            }
        }
        public override bool TienePermiso(string nombre)
        {
            foreach (var permiso in _permisos)
            {
                if(permiso.TienePermiso(nombre)) 
                    { return true; }
            }
            return false;
        }
    }
}
