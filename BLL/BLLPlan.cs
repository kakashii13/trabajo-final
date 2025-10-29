
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLPlan
    {
        MPPPlan mppPlan;
        BLLPractica bllPractica;
        public BLLPlan()
        {
            mppPlan = new MPPPlan();
            bllPractica = new BLLPractica();
        }

        public void CrearPlan(BEPlan plan)
        {
            try
            {
                if (mppPlan.ExistePlanPorNombre(plan.Nombre))
                {
                    throw new Exception($"Ya existe un plan con el nombre '{plan.Nombre}'.");
                }

                if (mppPlan.ExistePlanPorTope(plan.AporteTope))
                {
                    throw new Exception($"Ya existe un plan con el aporte tope de ${plan.AporteTope}.");
                }

                plan.Id = mppPlan.ObtenerProximoId();
                mppPlan.CrearPlan(plan);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el plan: " + ex.Message);
            }
        }

        public void ModificarPlan(BEPlan plan)
        {
            try
            {
                if (mppPlan.ExistePlanPorNombre(plan.Nombre, plan.Id))
                {
                    throw new Exception($"Ya existe otro plan con el nombre '{plan.Nombre}'.");
                }

                if (mppPlan.ExistePlanPorTope(plan.AporteTope, plan.Id))
                {
                    throw new Exception($"Ya existe otro plan con el aporte tope de ${plan.AporteTope}.");
                }

                mppPlan.ModificarPlan(plan);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el plan: " + ex.Message);
            }
        }

        public List<BEPlan> ListarPlanes()
        {
            try
            {
                return mppPlan.ListarPlanes();
            }
            catch (Exception ex) {
                throw new Exception("Error al listar los planes: " + ex.Message);
            }
        }

        public List<BEPlan> ListarPlanesCompletos()
        {
            try
            {
                List<BEPlan> planes = mppPlan.ListarPlanes();
                List<BEPlan> planesCompletos = new List<BEPlan>();
                foreach (BEPlan plan in planes)
                {
                    BEPlan planCompleto = ObtenerPlanCompleto(plan.Id);
                    if (planCompleto != null)
                    {
                        planesCompletos.Add(planCompleto);
                    }
                }
                return planesCompletos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los planes completos: " + ex.Message);
            }
        }

        public BEPlan ObtenerPlanPorId(int id)
        {
            try
            {
                return mppPlan.ObtenerPlanPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el plan: " + ex.Message);
            }
        }


        public BEPlan ObtenerPlanCompleto(int id)
        {
            try
            {
                BEPlan plan = mppPlan.ObtenerPlanPorId(id);

                if (plan == null)
                {
                    return null;
                }

                List<int> idsPracticas = mppPlan.ObtenerIdsPracticasDelPlan(id);

                plan.Practicas = new List<BEPractica>();

                foreach (int practicaId in idsPracticas)
                {
                    BEPractica practica = bllPractica.ObtenerPracticaPorId(practicaId);
                    if (practica != null)
                    {
                        plan.Practicas.Add(practica);
                    }
                }

                return plan;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el plan completo: " + ex.Message);
            }
        }

        public List<BEPractica> ListarPracticasDelPlan(BEPlan plan)
        {
            try
            {
                List<int> idsPracticas = mppPlan.ObtenerIdsPracticasDelPlan(plan.Id);
                List<BEPractica> practicas = new List<BEPractica>();

                foreach (int practicaId in idsPracticas)
                {
                    BEPractica practica = bllPractica.ObtenerPracticaPorId(practicaId);
                    if (practica != null)
                    {
                        practicas.Add(practica);
                    }
                }

                return practicas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las prácticas del plan: " + ex.Message);
            }
        }


        public void AsignarPractica(BEPlan plan, BEPractica practica)
        {
            try
            {
                if (mppPlan.ExisteAsignacion(plan.Id, practica.Id))
                {
                    throw new Exception("La práctica ya está asignada al plan.");
                }

                mppPlan.AsignarPractica(plan, practica);
                plan.Practicas.Add(practica);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al asignar la práctica al plan: " + ex.Message);
            }
        }

        public void QuitarPractica(BEPlan plan, BEPractica practica)
        {
            try
            {
                if (!mppPlan.ExisteAsignacion(plan.Id, practica.Id))
                {
                    throw new Exception("La práctica no está asignada al plan.");
                }

                mppPlan.QuitarPractica(plan, practica);
                plan.Practicas.Remove(practica);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al quitar la práctica del plan: " + ex.Message);
            }
        }

        public List<BEPractica> ListarPracticasDisponibles(BEPlan plan)
        {
            try
            {
                List<BEPractica> todasLasPracticas = bllPractica.ListarPracticas();
                List<BEPractica> practicasDelPlan = ListarPracticasDelPlan(plan);

                // practicas que no estan asignadas al plan
                return todasLasPracticas
                    .Where(p => !practicasDelPlan.Any(pp => pp.Id == p.Id))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar prácticas disponibles: " + ex.Message);
            }
        }
    }
}
