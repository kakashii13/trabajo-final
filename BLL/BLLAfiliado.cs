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
                BEAfiliado afiliadoExistente = ObtenerAfiliadoPorCuil(afiliado.Cuil);

                if (afiliadoExistente != null)
                {
                    throw new Exception("Ya existe un afiliado con ese CUIL.");
                }

                afiliado.Id = mppAfiliado.ObtenerProximoId();
                mppAfiliado.CrearAfiliado(afiliado);

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
                
                afiliado.HistorialPlanes = bllHistorialPlan.ObtenerPorAfiliado(afiliado);

                foreach (BEHistorialPlan historial in afiliado.HistorialPlanes)
                {
                    historial.Plan = bllPlan.ObtenerPlanPorId(historial.PlanId);
                }

                afiliado.Aportes = bllAporte.ObtenerAportesPorAfiliado(afiliado);

                return afiliado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener afiliado completo: " + ex.Message);
            }
        }
        public List<BEAfiliado> ListarAfiliadosConDatosCambioPlan()
        {
            try
            {
                List<BEAfiliado> afiliados = ListarAfiliados();
                List<BEPlan> planes = bllPlan.ListarPlanes();

                Dictionary<int, BEPlan> planesPorId = planes.ToDictionary(p => p.Id);

                foreach (var afiliado in afiliados)
                {
                    BEAporte ultimoAporte = bllAporte.ObtenerUltimoAportePorAfiliado(afiliado);

                    afiliado.HistorialPlanes = bllHistorialPlan.ObtenerPorAfiliado(afiliado);

                    foreach (var historial in afiliado.HistorialPlanes)
                    {
                        if (planesPorId.TryGetValue(historial.PlanId, out BEPlan plan))
                        {
                            historial.Plan = plan;
                        }
                    }

                    BEPlan planActual = afiliado.ObtenerPlanActual()?.Plan;
                    afiliado.PlanActual = planActual;

                    if (ultimoAporte != null)
                    {
                        afiliado.UltimoAporteMonto = ultimoAporte.Monto;

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
        public void CambiarPlan(BEAfiliado afiliado, BEPlan nuevoPlan, DateTime fechaDesde)
        {
            try
            {
                BEHistorialPlan historialActual = afiliado.ObtenerPlanActual();

                if (historialActual != null)
                {
                    if(historialActual.PlanId == nuevoPlan.Id)
                    {
                        throw new Exception("El afiliado ya se encuentra en el plan seleccionado.");
                    }

                    if (fechaDesde < historialActual.FechaDesde)
                    {
                        throw new Exception("La fecha del nuevo plan no puede ser anterior a la del plan actual.");
                    }

                    historialActual.Activo = false;
                    bllHistorialPlan.ModificarHistorialPlan(historialActual);
                }
                int proximoId = bllHistorialPlan.ObtenerProximoId();
                BEHistorialPlan nuevoHistorial = new BEHistorialPlan(
                    proximoId,
                    afiliado.Id,
                    nuevoPlan.Id,
                    true,
                    fechaDesde);

                bllHistorialPlan.CrearHistorialPlan(nuevoHistorial);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar plan del afiliado: " + ex.Message);
            }
        }
        private (bool Corresponde, int? PlanSugeridoId) VerificarCambioPlan(BEAfiliado afiliado, BEAporte ultimoAporte, List<BEPlan> planes)
        {
            BEPlan planActual = afiliado.ObtenerPlanActual().Plan;
            
            if (planActual == null)
                return (false, null);

            if (ultimoAporte.Monto <= planActual.AporteTope)
                return (false, null);

            var planesOrdenados = planes.OrderBy(p => p.AporteTope).ToList();

            BEPlan planSugerido = planesOrdenados
                .FirstOrDefault(p =>
                p.AporteTope >= ultimoAporte.Monto &&    
                p.AporteTope > planActual.AporteTope);

            if (planSugerido == null)
            {
                BEPlan planMasAlto = planesOrdenados.LastOrDefault();

                if (planMasAlto != null && planMasAlto.Id != planActual.Id)
                {
                    planSugerido = planMasAlto;
                }
            }

            return (planSugerido != null, planSugerido?.Id);
        }
    }
}
