using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUsuario : BEEntidad
    {
        public string Nombre { get; set; }
        public string Apellido { get;  set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public bool Eliminado { get; set; }
        public List<BEPermiso> Permisos { get; set; }

        public BEUsuario() { 
        }
        public BEUsuario(string nombreUsuario, string password)
        {
            this.NombreUsuario = nombreUsuario;
            this.Password = password;
            this.Permisos = new List<BEPermiso>();
        }
        public BEUsuario(string nombre, string apellido, string password,string nombreUsuario,int id, bool activo, bool eliminado)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = nombreUsuario;
            this.Password = password;
            this.Id = id;
            this.Permisos = new List<BEPermiso>();
            Activo = activo;
            Eliminado = eliminado;
        }
        public void ActualizarDatos(string nombre, string apellido, string nombreUsuario)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = nombreUsuario;
        }
        public bool TienePermiso(string nombrePermiso)
        {
            foreach (var permiso in Permisos)
            {
                if (permiso.TienePermiso(nombrePermiso))
                {
                    return true;
                }
            }
            return false;
        }
        public void AgregarPermiso(BEPermiso permiso)
        {
            if (!Permisos.Contains(permiso))
            {
                Permisos.Add(permiso);
            }
        }
        public void RemoverPermiso(BEPermiso permiso)
        {
            if (Permisos.Contains(permiso))
            {
                Permisos.Remove(permiso);
            }
        }
        public void Desactivar()
        {
            this.Activo = false;
        }
        public void Activar()
        {
            this.Activo = true;
        }   
        public void Eliminar()
        {
            this.Eliminado = true;
        }
        public void CambiarPassword(string nuevaPassword)
        {
            this.Password = nuevaPassword;
        }
        public override string ToString()
        {
            return $"{NombreUsuario}";
        }
    }
}
