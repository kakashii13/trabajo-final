using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPractica
    {
        MPPPractica mppPractica;

        public BLLPractica()
        {
            mppPractica = new MPPPractica();
        }
        public void CrearPractica(BEPractica practica)
        {
            try
            {
                if (mppPractica.ExistePractica(practica.Codigo, null))
                {
                    throw new Exception("Ya existe una práctica con el código ingresado.");
                }

                practica.Id = mppPractica.ObtenerProximoId();
                mppPractica.CrearPractica(practica);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la práctica: " + ex.Message);
            }
        }

        public void ModificarPractica(BEPractica practica)
        {
            try
            {
                if (mppPractica.ExistePractica(practica.Codigo, practica.Id))
                {
                    throw new Exception("Ya existe una práctica con el código ingresado.");
                }

                mppPractica.ModificarPractica(practica);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la práctica: " + ex.Message);
            }
        }

        public List<BEPractica> ListarPracticas()
        {
            try
            {
                return mppPractica.ListarPracticas();
            }
            catch (Exception ex) { throw new Exception("Error al listar las prácticas: " + ex.Message); }
        }

        public BEPractica ObtenerPracticaPorId(int id)
        {
            try
            {
                return mppPractica.ObtenerPracticaPorId(id);
            }
            catch (Exception ex) { throw new Exception("Error al obtener la práctica: " + ex.Message);
            }
        }
    }
}
