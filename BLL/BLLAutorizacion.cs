using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;

namespace BLL
{
    public class BLLAutorizacion
    {
        MPPAutorizacion mppAutorizacion;
        BLLAfiliado bllAfiliado;
        BLLPrestador bllPrestador;
        BLLPractica bllPractica;

        public BLLAutorizacion()
        {
            mppAutorizacion = new MPPAutorizacion();
            bllAfiliado = new BLLAfiliado();
            bllPrestador = new BLLPrestador();
            bllPractica = new BLLPractica();
        }

        public BEAutorizacion CrearAutorizacion(BEAutorizacion autorizacion)
        {
            try
            { 
                autorizacion.Id = mppAutorizacion.ObtenerProximoId();

                autorizacion.NumeroAutorizacion = mppAutorizacion.ObtenerProximoNumeroAutorizacion();

                autorizacion.Facturada = false;

                mppAutorizacion.CrearAutorizacion(autorizacion);

                return autorizacion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la autorizacion." + ex.Message);
            }
        }

        public void ModificarAutorizacion(BEAutorizacion autorizacion)
        {
            try
            {
                if (ObtenerAutorizacionPorNumero(autorizacion.NumeroAutorizacion) == null)
                {
                    throw new Exception("No existe la autorizacion a modificar.");
                }

                mppAutorizacion.ModificarAutorizacion(autorizacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la autorizacion." + ex.Message);
            }
        }

        public List<BEAutorizacion> ListarAutorizaciones()
        {
            try
            {
                List<BEAutorizacion> autorizaciones = mppAutorizacion.ListarAutorizaciones();

                foreach (BEAutorizacion autorizacion in autorizaciones)
                {
                    autorizacion.Afiliado = bllAfiliado.ObtenerAfiliadoPorId(autorizacion.Afiliado.Id);
                    autorizacion.Prestador = bllPrestador.ObtenerPrestadorPorId(autorizacion.Prestador.Id);
                    autorizacion.Practica = bllPractica.ObtenerPracticaPorId(autorizacion.Practica.Id);
                }

                return autorizaciones;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las autorizaciones." + ex.Message);
            }
        }
        public BEAutorizacion ObtenerAutorizacionPorNumero(int numeroAutorizacion)
        {
            try
            {
                return mppAutorizacion.ObtenerAutorizacionPorNumero(numeroAutorizacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la autorizacion por numero." + ex.Message);
            }
        }
    }
}
