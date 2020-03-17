using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sistema_Liquidacion_de_Haberes.Models.DbModels;

namespace Sistema_Liquidacion_de_Haberes.Models.DbFunctions
{
    public class CreateResources
    {
        public bool CrearEmpleado(string nombre, string apellido, string cuil, int legajo, DateTime antiguedad, DateTime fechaIngreso, DateTime fechaEgreso, int obraSocial, int categoria, byte[] activo)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                empleados nuevoEmpleado = new empleados
                {
                    nombre = nombre,
                    apellido = apellido,
                    cuil = cuil,
                    legajo = legajo,
                    antiguedad = antiguedad,
                    fechaIngreso = fechaIngreso,
                    fechaEgreso = fechaEgreso,
                    obrasSociales_idobrasSociales = obraSocial,
                    categorias_idcategorias = categoria,
                    activo = activo
                };

                db.empleados.Add(nuevoEmpleado);
                db.SaveChanges();

                return true;
            }
        }
    }
}