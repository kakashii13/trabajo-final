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
        BLLAutorizacion bllAutorizacion;

        public BLLSolicitud()
        {
            mppSolicitud = new MPPSolicitud();
            bllAfiliado = new BLLAfiliado();
            bllPractica = new BLLPractica();
            bllAutorizacion = new BLLAutorizacion();
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

        public void RechazarSolicitud(BESolicitud solicitud, string motivoRechazo)
        {
            try
            {
                if (solicitud == null)
                    throw new Exception("La solicitud no puede ser nula.");

                if (solicitud.Estado != "Pendiente")
                    throw new Exception("Solo se pueden rechazar solicitudes pendientes.");

                if (string.IsNullOrWhiteSpace(motivoRechazo))
                    throw new Exception("Debe indicar un motivo de rechazo.");

                solicitud.Estado = "Rechazado";
                solicitud.MotivoRechazo = motivoRechazo;

                mppSolicitud.ModificarSolicitud(solicitud);
            }
            catch (Exception ex) { throw new Exception("Error al rechazar la solicitud." + ex.Message); }
        }

        public BEAutorizacion AutorizarSolicitud(BESolicitud solicitud, BEPrestador prestador)
        {
            try
            {
                if (solicitud == null)
                    throw new Exception("La solicitud no puede ser nula.");

                if (solicitud.Estado != "Pendiente")
                    throw new Exception("Solo se pueden autorizar solicitudes pendientes.");

                if (prestador == null)
                    throw new Exception("Debe asignar un prestador.");

                BEAutorizacion autorizacion = new BEAutorizacion
                {
                    Afiliado = solicitud.Afiliado,
                    Practica = solicitud.Practica,
                    Prestador = prestador,
                    FechaAutorizacion = DateTime.Now,
                    Facturada = false
                };

                autorizacion = bllAutorizacion.CrearAutorizacion(autorizacion);

                solicitud.Estado = "Aceptado";
                mppSolicitud.ModificarSolicitud(solicitud);

               return autorizacion;
            }
            catch (Exception ex) { throw new Exception("Error al aceptar la solicitud." + ex.Message); }
        }
    }
}
