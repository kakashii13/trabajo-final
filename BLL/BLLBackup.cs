using BE;
using MPP;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLBackup
    {
        BLLBitacora bllBitacora;

        public BLLBackup()
        {
            bllBitacora = new BLLBitacora();
        }
        public string CrearBackup(BEUsuario usuario)
        {
            string nombreCarpeta = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
            string rutaDestino = Path.Combine(ServicioDirectorio.RutaBackups, nombreCarpeta);

            try
            {
                Directory.CreateDirectory(rutaDestino);

                string[] archivos = Directory.GetFiles(ServicioDirectorio.RutaDB, "*.xml");
                foreach (string archivo in archivos)
                {
                    string nombreArchivo = Path.GetFileName(archivo);
                    string destino = Path.Combine(rutaDestino, nombreArchivo);
                    File.Copy(archivo, destino, true);
                }

                BEBitacora bitacora = new BEBitacora(
                    DateTime.Now,
                    usuario,
                    "Backup",
                    $"Backup creado en {nombreCarpeta}"
                );

                bllBitacora.RegistrarAccion(bitacora);

                return rutaDestino;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el backup." + ex.Message);
            }
        }

        public bool RestaurarBackup(BEUsuario usuario, string nombreBackup)
        {
            try
            {
                string rutaBackup = Path.Combine(ServicioDirectorio.RutaBackups, nombreBackup);

                if (!Directory.Exists(rutaBackup))
                    throw new Exception("El backup no existe");

                string[] archivos = Directory.GetFiles(rutaBackup, "*.xml");
                foreach (string archivo in archivos)
                {
                    string nombreArchivo = Path.GetFileName(archivo);
                    string destino = Path.Combine(ServicioDirectorio.RutaDB, nombreArchivo);
                    File.Copy(archivo, destino, true);
                }

                BEBitacora bitacora = new BEBitacora(
                    DateTime.Now,
                    usuario,
                    "Restore",
                    $"Backup restaurado desde {rutaBackup}"
                );

                bllBitacora.RegistrarAccion(bitacora);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al restaurar el backup." + ex.Message);
            }
        }

        public List<DirectoryInfo> ListarBackupsDisponibles()
        {
            try
            {
                DirectoryInfo dirBackups = new DirectoryInfo(ServicioDirectorio.RutaBackups);
                return dirBackups.GetDirectories()
                                    .OrderByDescending(d => d.CreationTime)
                                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los backups disponibles." + ex.Message);
            }
        }
    }
}
