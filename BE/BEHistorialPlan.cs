using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEHistorialPlan : BEEntidad
    {
        public int AfiliadoId { get; set; }
        public int PlanId { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaDesde { get; set; }

        public BEPlan Plan;
        public BEHistorialPlan(int id, int afiliadoId, int planId, bool activo, DateTime fechaDesde)
        {
            Id = id;
            AfiliadoId = afiliadoId;
            PlanId = planId;
            Activo = activo;
            FechaDesde = fechaDesde;
        }

        public override string ToString() { 
            return Plan != null ? Plan.ToString() : $"PlanId: {PlanId}";
        }
    }
}
