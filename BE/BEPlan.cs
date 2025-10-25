using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPlan : BEEntidad
    {
        public string Nombre { get; set; }
        public int AporteTope { get; set; }
        public List<BEPractica> Practicas { get; set; }
        public BEPlan() { 
            
        }
        public BEPlan(int id, string nombre, int aporteTope)
        {
            Id = id;
            Nombre = nombre;
            AporteTope = aporteTope;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
