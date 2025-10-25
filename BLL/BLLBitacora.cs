using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public  class BLLBitacora
    {
        MPPBitacora mppBitacora;
        BLLUsuario bllUsuario;

        public BLLBitacora()
        {
            mppBitacora = new MPPBitacora();
            bllUsuario = new BLLUsuario();
        }

        public void RegistrarAccion(BEBitacora bitacora)
        {
            try
            {
                // asignamos el proximo id 
                bitacora.Id = mppBitacora.ObtenerProximoId();

                mppBitacora.RegistrarAccion(bitacora);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al registrar la acción en la bitácora: " + ex.Message);
            }
        }
        public List<BEBitacora> ListarTodo()
        {
            try
            {
                List<BEBitacora> bitacoras = mppBitacora.ListarTodo();
                foreach (BEBitacora bitacora in bitacoras)
                {
                    bitacora.Usuario = bllUsuario.ObtenerUsuarioPorId(bitacora.Usuario.Id);
                }
                return bitacoras;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las bitácoras: " + ex.Message);
            }
        }

    }
}
