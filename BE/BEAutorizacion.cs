using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEAutorizacion : BEEntidad
    {
        public int NumeroAutorizacion { get; set; }
        public DateTime FechaAutorizacion { get; set; }
        public bool Facturada { get; set; }
        public BEPrestador Prestador { get; set; }
        public BEPractica Practica { get; set; }
        public BEAfiliado Afiliado { get; set; }

        public BEAutorizacion() { }
        public BEAutorizacion(int numeroAutorizacion)
        {
            NumeroAutorizacion = numeroAutorizacion;
        }
        public BEAutorizacion(int id, int numeroAutorizacion, DateTime fechaAutorizacion, bool facturada, BEPrestador prestador, BEPractica practica, BEAfiliado afiliado) 
        {
            Id = id;
            NumeroAutorizacion = numeroAutorizacion;
            FechaAutorizacion = fechaAutorizacion;
            Facturada = facturada;
            Prestador = prestador;
            Practica = practica;
            Afiliado = afiliado;
        }
        public override string ToString()
        {
            if(Afiliado != null)
                return $"Nro aut: {NumeroAutorizacion} - Afiliado: {Afiliado}";
            else
                return $"Nro aut: {NumeroAutorizacion}";
        }
    }
}
