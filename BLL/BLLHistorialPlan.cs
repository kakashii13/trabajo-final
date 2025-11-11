using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLHistorialPlan
    {
        MPPHistorialPlan mppHistorialPlan;
        public BLLHistorialPlan()
        {
            mppHistorialPlan = new MPPHistorialPlan();
        }

        public List<BEHistorialPlan> ObtenerPorAfiliado(BEAfiliado afiliado)
        {
            try
            {
                return mppHistorialPlan.ObtenerPorAfiliado(afiliado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el historial de planes del afiliado: " + ex.Message);
            }
        }
        public void CrearHistorialPlan(BEHistorialPlan historialPlan)
        {
            try { mppHistorialPlan.CrearHistorialPlan(historialPlan); }
            catch (Exception ex) { throw new Exception("Error al crear el historial de plan: " + ex.Message); }
        }
        public void ModificarHistorialPlan(BEHistorialPlan historialPlan)
        {
            try
            {
                mppHistorialPlan.ModificarHistorialPlan(historialPlan);
            }
            catch (Exception ex) { throw new Exception("Error al modificar el historial de plan: " + ex.Message); }
        }
        public int ObtenerProximoId()
        {
            try
            {
                return mppHistorialPlan.ObtenerProximoId();
            }
            catch (Exception ex) { throw new Exception("Error al obtener el próximo ID para historial de plan: " + ex.Message); }
        }
    }
}
