using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLAfiliado
    {
        MPPAfiliado mppAfiliado;
        BLLHistorialPlan bllHistorialPlan;
        BLLAporte bllAporte;
        BLLPlan bllPlan;
        public BLLAfiliado()
        {
            mppAfiliado = new MPPAfiliado();
            bllAporte = new BLLAporte();
            bllPlan = new BLLPlan();
            bllHistorialPlan = new BLLHistorialPlan();
        }

        public void CrearAfiliado(BEAfiliado afiliado, BEPlan plan)
        {
            try
            {
                // validamos que no exista ese cuil
                BEAfiliado afiliadoExistente = ObtenerAfiliadoPorCuil(afiliado.Cuil);

                if (afiliadoExistente != null)
                {
                    throw new Exception("Ya existe un afiliado con ese CUIL.");
                }

                // obtenemos proximo id
                afiliado.Id = mppAfiliado.ObtenerProximoId();
                mppAfiliado.CrearAfiliado(afiliado);

                // creamos el historial de planes del afiliado
                if (plan != null)
                {
                    int proximoId = bllHistorialPlan.ObtenerProximoId();
                    BEHistorialPlan historialPlan = new BEHistorialPlan(proximoId, afiliado.Id, plan.Id, true, DateTime.Now);
                    bllHistorialPlan.CrearHistorialPlan(historialPlan);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear afiliado: " + ex.Message);
            }
        }
        public void ActivarAfiliado(BEAfiliado afiliado)
        {
            try {
                if (afiliado.Activo)
                {
                    throw new Exception("El afiliado ya se encuentra activo."); 
                }
                afiliado.Activo = true;
                mppAfiliado.ModificarAfiliado(afiliado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al activar al afiliado: " + ex.Message);
            }
        }
        public void InactivarAfiliado(BEAfiliado afiliado)
        {
            try
            {
                if (!afiliado.Activo)
                {
                    throw new Exception("El afiliado ya se encuentra inactivo.");
                }
                afiliado.Activo = false;
                mppAfiliado.ModificarAfiliado(afiliado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al inactivar al afiliado: "+ ex.Message);
            }
        }
        public List<BEAfiliado> ListarAfiliados()
        {
            try
            {
                return mppAfiliado.ListarAfiliados();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar afiliados" + ex.Message);
            }
        }
        public BEAfiliado ObtenerAfiliadoPorCuil(string cuil) {
            try
            {
                return mppAfiliado.ObtenerAfiliadoPorCuil(cuil);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener afiliado por CUIL" + ex.Message);
            }
        }
        public BEAfiliado ObtenerAfiliadoPorId(int id)
        {
            try
            {
                return mppAfiliado.ObtenerAfiliadoPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener afiliado por ID" + ex.Message);
            }
        }
        public BEAfiliado ObtenerAfiliadoCompleto(int afiliadoId)
        {
            try
            {
                BEAfiliado afiliado = mppAfiliado.ObtenerAfiliadoPorId(afiliadoId);
                
                if(afiliado == null) {
                    throw new Exception("Afiliado no encontrado");
                }
                
                // cargamos historial de planes
                afiliado.HistorialPlanes = bllHistorialPlan.ObtenerPorAfiliado(afiliado);

                // cargamos los planes relacionados a los historiales
                foreach (BEHistorialPlan historial in afiliado.HistorialPlanes)
                {
                    historial.Plan = bllPlan.ObtenerPlanPorId(historial.PlanId);
                }

                // cargamos aportes
                afiliado.Aportes = bllAporte.ObtenerAportesPorAfiliado(afiliado);

                return afiliado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener afiliado completo: " + ex.Message);
            }
        }
        // listamos los afiliados y les agregamos datos para facilitar el cambio de plan
        public List<BEAfiliado> ListarAfiliadosConDatosCambioPlan()
        {
            try
            {
                List<BEAfiliado> afiliados = ListarAfiliados();
                List<BEPlan> planes = bllPlan.ListarPlanes();

                foreach (var afiliado in afiliados)
                {
                    // obtenemos el ultimo aporte por afiliado
                    BEAporte ultimoAporte = bllAporte.ObtenerUltimoAportePorAfiliado(afiliado);

                    // cargamos historial de planes
                    afiliado.HistorialPlanes = bllHistorialPlan.ObtenerPorAfiliado(afiliado);

                    foreach (var historial in afiliado.HistorialPlanes)
                    {
                        historial.Plan = bllPlan.ObtenerPlanPorId(historial.PlanId);
                    }

                    if (ultimoAporte != null)
                    {
                        afiliado.UltimoAporteMonto = ultimoAporte.Monto;

                        // verificamos si corresponde cambio
                        var resultado = VerificarCambioPlan(afiliado, ultimoAporte, planes);
                        afiliado.CorrespondeCambioPlan = resultado.Corresponde;
                        afiliado.PlanSugeridoId = resultado.PlanSugeridoId;
                    }
                    else
                    {
                        afiliado.UltimoAporteMonto = null;
                        afiliado.CorrespondeCambioPlan = false;
                        afiliado.PlanSugeridoId = null;
                    }
                }

                return afiliados;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar afiliados con datos de cambio de plan: " + ex.Message);
            }
        }
        public void CambiarPlan(BEAfiliado afiliado, BEPlan nuevoPlan)
        {
            try
            {
                // desactivamos el historial de plan actual
                BEHistorialPlan historialActual = afiliado.ObtenerPlanActual();
                if (historialActual != null)
                {
                    if(historialActual.PlanId == nuevoPlan.Id)
                    {
                        throw new Exception("El afiliado ya se encuentra en el plan seleccionado.");
                    }

                    historialActual.Activo = false;
                    bllHistorialPlan.ModificarHistorialPlan(historialActual);
                }
                // creamos un nuevo historial de plan
                int proximoId = bllHistorialPlan.ObtenerProximoId();
                BEHistorialPlan nuevoHistorial = new BEHistorialPlan(
                    proximoId,
                    afiliado.Id,
                    nuevoPlan.Id,
                    true,
                    DateTime.Now);

                bllHistorialPlan.CrearHistorialPlan(nuevoHistorial);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar plan del afiliado" + ex.Message);
            }
        }
        // verificamos si al afiliado le corresponde un cambio de plan
        private (bool Corresponde, int? PlanSugeridoId) VerificarCambioPlan(BEAfiliado afiliado, BEAporte ultimoAporte, List<BEPlan> planes)
        {
            BEPlan planActual = afiliado.ObtenerPlanActual().Plan;
            if (planActual == null)
                return (false, null);

            // ordenamos los planes por tope de aporte
            var planesOrdenados = planes.OrderBy(p => p.AporteTope).ToList();
            BEPlan planMasAlto = planesOrdenados.LastOrDefault();

            // si ya esta en el plan mas alto, no corresponde cambio
            if (planActual.Id == planMasAlto?.Id)
                return (false, null);

            // buscamos el primer plan que cumpla la condicion de tope de aporte
            BEPlan planSugerido = planesOrdenados
                .FirstOrDefault(p => ultimoAporte.Monto <= p.AporteTope && p.AporteTope > planActual.AporteTope);

            // corresponde cambio si el aporte supera el tope del plan actual y encontramos un plan sugerido
            bool corresponde = ultimoAporte.Monto > planActual.AporteTope && planSugerido != null;

            return (corresponde, corresponde ? planSugerido?.Id : null);
        }
    }
}
