using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPrestador : BEEntidad
    {
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public List<BEPractica> Practicas { get; set; } 
        public BEPrestador()
        {
            Practicas = new List<BEPractica>();
        }
        public BEPrestador(int id)
        {
            Id = id;
            Practicas = new List<BEPractica>();
        }

        public BEPrestador(int id, string cuit, string razonSocial) {
            Id = id;
            Cuit = cuit;
            RazonSocial = razonSocial;
        }

        public override string ToString()
        {
            return $"{RazonSocial} - {Cuit}";
        }
    }
}
