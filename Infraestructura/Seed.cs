using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public static class Seed
    {
        public static void Ejecutar()
        {
            try
            {
                CrearPlanesDemo();
                CrearPrestadoresDemo();
                CrearPracticasDemo();
                CrearAfiliadosDemo();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el seed de datos de ejemplo: " + ex.Message);
            }
        }

        private static void CrearPlanesDemo()
        {
            var bllPlan = new BLLPlan();

            List<BEPlan> planes = new List<BEPlan>
            {
                new BEPlan
                {
                    Nombre = "Plan Oro",
                    AporteTope = 150000,
                },
                new BEPlan
                {
                    Nombre = "Plan Platino",
                    AporteTope = 300000,
                },
                new BEPlan
                {
                    Nombre = "Plan Plata",
                    AporteTope = 80000,
                }
            };

            foreach (var plan in planes)
            {
                bllPlan.CrearPlan(plan);
            }
        }

        private static void CrearPrestadoresDemo()
        {
            var bllPrestador = new BLLPrestador();

            List<BEPrestador> prestadores = new List<BEPrestador>
            {
                new BEPrestador
                {
                    RazonSocial = "Hospital Italiano",
                    Cuit = "30524535508",
                },
                new BEPrestador
                {
                    RazonSocial = "Sanatorio Otamendi",
                    Cuit = "30506872941",
                },
                new BEPrestador
                {
                    RazonSocial = "Clínica San Pedro",
                    Cuit = "30689451237",
                }
            };

            foreach (var prestador in prestadores)
            {
                bllPrestador.CrearPrestador(prestador);
            }
        }

        private static void CrearPracticasDemo()
        {
            var bllPractica = new BLLPractica();
            List<BEPractica> practicas = new List<BEPractica>
            {
                new BEPractica
                {
                    Codigo = 0101,
                    Nombre = "Consulta General",
                    Precio = 20000,
                },
                new BEPractica
                {
                    Codigo = 0202,
                    Nombre = "Tomografia computada",
                    Precio = 120000,
                },
                new BEPractica
                {
                    Codigo = 0203,
                    Nombre = "Radiografía",
                    Precio = 68000,
                }
            };
            foreach (var practica in practicas)
            {
                bllPractica.CrearPractica(practica);
            }
        }

       private static void CrearAfiliadosDemo()
        {
            var bllAfiliado = new BLLAfiliado();
            var bllPlan = new BLLPlan();
            List<BEPlan> planes = bllPlan.ListarPlanes();

            List<BEAfiliado> afiliados = new List<BEAfiliado>
            {
                new BEAfiliado
                {
                    NombreApellido = "Juan Perez",
                    Telefono = "12345678",
                    Cuil = "20123456783",
                    Activo = true,
                },
                new BEAfiliado
                {
                    NombreApellido = "Maria Gomez",
                    Telefono = "87654321",
                    Cuil = "27234567890",
                    Activo = true,
                },
                new BEAfiliado
                {
                    NombreApellido = "Carlos Rodriguez",
                    Telefono = "55555555",
                    Cuil = "23123456789",
                    Activo = false,
                }
            };

            var id = 0;

            foreach (var afiliado in afiliados)
            {
                bllAfiliado.CrearAfiliado(afiliado, planes[id]);
                id++;
            }
        }
    }
}
