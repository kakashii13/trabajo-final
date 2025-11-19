using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEAfiliado : BEEntidad
    {
        public string NombreApellido { get; set; }
        public string Cuil { get; set; }
        public bool Activo { get; set; }
        public string Telefono { get; set; }
        public List<BEHistorialPlan> HistorialPlanes { get; set; }
        public List<BEAporte> Aportes { get; set; }
        public BEPlan PlanActual { get; set; }
        public decimal? UltimoAporteMonto { get; set; }
        public bool CorrespondeCambioPlan { get; set; }
        public int? PlanSugeridoId { get; set; }

        public BEAfiliado()
        {
            HistorialPlanes = new List<BEHistorialPlan>();
            Aportes = new List<BEAporte>();
        }
        public BEAfiliado(int id)
        {
            Id = id;
        }
        public BEAfiliado(int id, string nombreApellido, string cuil, bool activo, string telefono)
        {
            Id = id;
            NombreApellido = nombreApellido;
            Cuil = cuil;
            Activo = activo;
            Telefono = telefono;
        }
        public BEHistorialPlan ObtenerPlanActual()
        {
            if (HistorialPlanes == null || !HistorialPlanes.Any())
                return null;

            return HistorialPlanes.FirstOrDefault(h => h.Activo);
        }
        public BEAporte ObtenerUltimoAporte()
        {
            if (Aportes == null || !Aportes.Any())
                return null;
            return Aportes.OrderByDescending(a => a.Periodo).FirstOrDefault();
        }
        public override string ToString()
        {
            return $"{Cuil} - {NombreApellido}";
        }
    }
}
