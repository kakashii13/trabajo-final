using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLAporte
    {
        MPPAporte mppAporte;

        public BLLAporte()
        {
            mppAporte = new MPPAporte();
        }

        public void CrearAporte(BEAporte aporte)
        {
            try
            {
                if (ExisteAporteEnPeriodo(aporte.AfiliadoId, aporte.Periodo))
                {
                    throw new Exception("Ya existe un aporte registrado para este afiliado en el período seleccionado.");
                }

                aporte.Id = mppAporte.ObtenerProximoId();

                mppAporte.CrearAporte(aporte);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el aporte: " + ex.Message);
            }
        }
        public List<BEAporte> ObtenerAportesPorAfiliado(BEAfiliado afiliado)
        {
            try
            {
                return mppAporte.ObtenerAportesPorAfiliado(afiliado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los aportes del afiliado: " + ex.Message);
            }
        }
        public BEAporte ObtenerUltimoAportePorAfiliado(BEAfiliado afiliado)
        {
            try
            {
                return mppAporte.ObtenerUltimoAportePorAfiliado(afiliado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último aporte del afiliado: " + ex.Message);
            }
        }
        public List<BEAporte> ListarAportes()
        {
            try
            {
                return mppAporte.ListarAportes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los aportes: " + ex.Message);
            }
        }
        private bool ExisteAporteEnPeriodo(int afiliadoId, DateTime periodo)
        {
            var aportesAfiliado = mppAporte.ObtenerAportesPorAfiliado(new BEAfiliado { Id = afiliadoId });
            return aportesAfiliado.Any(a => a.Periodo.Year == periodo.Year && a.Periodo.Month == periodo.Month);
        }
    }
}
