using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLSolicitud
    {
        MPPSolicitud mppSolicitud;
        BLLAfiliado bllAfiliado;
        BLLPractica bllPractica;

        public BLLSolicitud()
        {
            mppSolicitud = new MPPSolicitud();
            bllAfiliado = new BLLAfiliado();
            bllPractica = new BLLPractica();
        }

        public void CrearSolicitud(BESolicitud solicitud)
        {
            try
            {
                solicitud.Id = mppSolicitud.ObtenerProximoId();
                solicitud.Estado = "Pendiente";
                solicitud.MotivoRechazo = "";

                mppSolicitud.CrearSolicitud(solicitud);
            }
            catch (Exception ex){
                throw new Exception("Error al crear la solicitud." + ex.Message);
            }
        }

        public List<BESolicitud> ListarSolicitudes()
        {
            try
            {
                List<BESolicitud> solicitudes = mppSolicitud.ListarSolicitudes();

                foreach (var solicitud in solicitudes)
                {
                    solicitud.Afiliado = bllAfiliado.ObtenerAfiliadoCompleto(solicitud.Afiliado.Id);
                    solicitud.Practica = bllPractica.ObtenerPracticaPorId(solicitud.Practica.Id);
                }

                return solicitudes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las solicitudes." + ex.Message);
            }

        }

        public void ModificarSolicitud(BESolicitud solicitud)
        {
            try
            {
                mppSolicitud.ModificarSolicitud(solicitud);
            }
            catch (Exception ex) { throw new Exception("Error al modificar la solicitud." + ex.Message); }
        }
    }
}
