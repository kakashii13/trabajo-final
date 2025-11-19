using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLPrestador
    {
        MPPPrestador mppPrestador;
        BLLPractica bllPractica;

        public BLLPrestador()
        {
            mppPrestador = new MPPPrestador();
            bllPractica = new BLLPractica();
        }
        public void CrearPrestador(BEPrestador prestador)
        {
            try
            {
                if (mppPrestador.ExistePrestador(prestador.Cuit))
                {
                    throw new Exception("El prestador con CUIT " + prestador.Cuit + " ya existe.");
                }

                 prestador.Id = mppPrestador.ObtenerProximoId();
                mppPrestador.CrearPrestador(prestador);
            }
            catch (Exception ex) {
                throw new Exception("Error al crear el prestador." + ex.Message);
            }
        }
        public List<BEPrestador> ListarPrestadores()
        {
            try
            {
                return mppPrestador.ListarPrestadores();
            }
            catch (Exception ex) { throw new Exception("Error al listar los prestadores." + ex.Message);
            }
        }
        public List<BEPrestador> ListarPrestadoresCompletos()
        {
            try
            {
                List<BEPrestador> prestadores = mppPrestador.ListarPrestadores();

                List<BEPractica> todasLasPracticas = bllPractica.ListarPracticas();

                Dictionary<int, BEPractica> practicasPorId = todasLasPracticas
                    .ToDictionary(p => p.Id);

                foreach (BEPrestador prestador in prestadores)
                {
                    List<int> practicasIds = mppPrestador.ListarPracticasIdsPorPrestador(prestador);
                    
                    if (prestador.Practicas == null)
                    {
                        prestador.Practicas = new List<BEPractica>();
                    }

                    foreach (int id in practicasIds)
                    {
                        if (practicasPorId.TryGetValue(id, out BEPractica practica))
                        {
                            prestador.Practicas.Add(practica);
                        }
                    }
                }

                return prestadores;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los prestadores completos." + ex.Message);
            }
        }
        public List<int> ListarPracticasIdsDelPrestador(BEPrestador prestador)
        {
            try
            {
                return mppPrestador.ListarPracticasIdsPorPrestador(prestador);
            }
            catch (Exception ex) { throw new Exception("Error al listar las prácticas del prestador." + ex.Message);
            }
        }
        public List<BEPrestador> ListarPrestadoresSegunPractica(BEPractica practica)
        {
            try
            {
                List<int> prestadoresIds = mppPrestador.ListarPrestadoresIdsSegunPractica(practica);
                List<BEPrestador> prestadores = new List<BEPrestador>();

                foreach(int id in prestadoresIds)
                {
                   prestadores.Add(mppPrestador.ObtenerPrestadorPorId(id));
                }

                return prestadores;

            }
            catch(Exception ex) { throw new Exception("Error al listar los prestadores según la práctica: " + ex.Message);
            }
        }
        public void AsignarPractica(BEPrestador prestador, BEPractica practica)
        {
            try
            {
                if(mppPrestador.ExisteAsignacion(prestador, practica))
                {
                    throw new Exception("La práctica ya está asignada al prestador.");
                }

                mppPrestador.AsignarPractica(prestador, practica);
                prestador.Practicas.Add(practica);
            }
            catch (Exception ex) { throw new Exception("Error al asignar la práctica al prestador: " + ex.Message);
            }
        }
        public void QuitarPractica(BEPrestador prestador, BEPractica practica)
        {
            try {
                if(!mppPrestador.ExisteAsignacion(prestador, practica))
                {
                    throw new Exception("La práctica no está asignada al prestador.");
                }

                mppPrestador.QuitarPractica(prestador, practica);
                prestador.Practicas.Remove(practica);
            }
            catch (Exception ex) { throw new Exception("Error al quitar la práctica del prestador: " + ex.Message);
            }
        }
        public BEPrestador ObtenerPrestadorPorId(int id)
        {
            try
            {
                return mppPrestador.ObtenerPrestadorPorId(id);
            }
            catch (Exception ex) { throw new Exception("Error al obtener el prestador por ID: " + ex.Message);
            }
        }
    }
}
