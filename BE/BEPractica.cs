using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPractica : BEEntidad
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public BEPractica()
        {
        }
        public BEPractica(int id)
        {
            Id = id;
        }
        public BEPractica(int id, int codigo, string nombre, decimal precio)
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Nombre}";
        }
    }
}
