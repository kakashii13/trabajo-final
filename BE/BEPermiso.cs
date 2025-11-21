using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEPermiso
    {
        public int Id { get; set; }
        private string _nombre;
        public BEPermiso(string nombre) {
            _nombre = nombre;
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; } 
        }
        public abstract void AgregarPermiso(BEPermiso permiso);
        public abstract void RemoverPermiso(BEPermiso permiso);
        public abstract List<BEPermiso> ObtenerPermisos();
        public abstract bool TienePermiso(string nombre);
        public override string ToString()
        {
            return _nombre;
        }

    }
}
