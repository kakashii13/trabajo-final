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
                    BEUsuario usuario = bllUsuario.ObtenerUsuarioPorId(bitacora.Usuario.Id);

                    if (usuario != null)
                    {
                        bitacora.Usuario = usuario;
                    }
                    else
                    {
                        bitacora.Usuario = new BEUsuario
                        {
                            Id = bitacora.Usuario.Id,
                            NombreUsuario = "[Usuario eliminado]",
                            Nombre = "N/A",
                            Apellido = "N/A"
                        };
                    }
                }
                return bitacoras;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las bitácoras: " + ex.Message);
            }
        }
        public List<BEBitacora> ListarBackups()
        {
            try
            {
                return ListarTodo()
                .Where(b => b.Operacion == "Backup")
                .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los backups: " + ex.Message);
            }
        }
    }
}
