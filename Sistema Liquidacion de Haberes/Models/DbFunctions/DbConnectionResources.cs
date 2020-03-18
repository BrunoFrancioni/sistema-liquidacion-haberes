using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Sistema_Liquidacion_de_Haberes.Models.DbModels;

namespace Sistema_Liquidacion_de_Haberes.Models.DbFunctions
{
    public class DbConnectionResources
    {

        /*
         * VIEW RESOURCES
         */
        public IEnumerable<empleados> ObtenerEmpleados()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.empleados.ToList();
            }
        }

        public string ObtenerObraSocial(int idObraSocial)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var obraSocial = db.obrasSociales.Where(obra => obra.idObrasSociales == idObraSocial);

                string nombreObraSocial = obraSocial.Select(obra => obra.nombre).ToString();

                return nombreObraSocial;
            }
        }

        public string ObtenerSector(int idCategoria)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var categoria = db.categorias.Single(cat => cat.idCategorias == idCategoria);

                int idSector = categoria.sector_idSector;

                var sector = db.sectores.Where(obtenerSector => obtenerSector.idSector == idSector);

                string nombreSector = sector.Select(s => s.nombre).ToString();

                return nombreSector;
            }
        }

        public string ObtenerCategoria(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var categoria = db.categorias.Where(cat => cat.idCategorias == id);

                string nombreCategoria = categoria.Select(cat => cat.nombre).ToString();

                return nombreCategoria;
            }
        }

        /*
         * CREATE EMPLOYEE RESOURCES
         */

        public bool CrearEmpleado(string nombre, string apellido, string cuil, DateTime antiguedad, DateTime fechaIngreso, int obraSocial, int categoria)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                empleados nuevoEmpleado = new empleados
                {
                    nombre = nombre,
                    apellido = apellido,
                    cuil = cuil,
                    legajo = 1,
                    antiguedad = antiguedad,
                    fechaIngreso = fechaIngreso,
                    obrasSociales_idobrasSociales = obraSocial,
                    categorias_idcategorias = categoria,
                    activo = true
                };

                db.empleados.Add(nuevoEmpleado);
                db.SaveChanges();

                var empleado = db.empleados.Single(emp => emp.cuil == cuil);
                int idEmpleado = empleado.idEmpleados;

                return AsignarLegajo(idEmpleado) ? true : false;
            }
        }

        public bool AsignarLegajo(int idEmpleado)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var empleado = db.empleados.Single(emp => emp.idEmpleados == idEmpleado);
                empleado.legajo = empleado.idEmpleados;

                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
        }

        public IEnumerable<obrasSociales> ObtenerObrasSociales()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var obrasSociales = db.obrasSociales.ToList();

                return obrasSociales;
            }
        }

        public IEnumerable<sectores> ObtenerSectores()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var sectores = db.sectores.ToList();

                return sectores;
            }
        }

        public IEnumerable<categorias> ObtenerCategorias(int idSector)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var categorias = db.categorias.Select(cat => cat.sector_idSector == idSector);

                return (IEnumerable<categorias>)categorias;
            }
        }

        /*
         * EDIT EMPLOYEE RESOURCES
         */

        public empleados ObtenerEmpleado(int idEmpleado)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var empleado = db.empleados.Single(emp => emp.idEmpleados == idEmpleado);

                return empleado;
            }
        }

        public bool EditarEmpleado(int idEmpleado, string nombre, string apellido, string cuil, DateTime antiguedad, DateTime fechaIngreso,  int obraSocial, int categoria)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var empleado = db.empleados.Single(emp => emp.idEmpleados == idEmpleado);

                if(String.IsNullOrEmpty(nombre) != false || empleado.nombre != nombre)
                {
                    empleado.nombre = nombre;
                }

                if (String.IsNullOrEmpty(apellido) != false || empleado.apellido != apellido)
                {
                    empleado.apellido = apellido;
                }

                if (String.IsNullOrEmpty(cuil) != false || empleado.cuil != cuil)
                {
                    empleado.cuil = cuil;
                }

                if (empleado.antiguedad != antiguedad)
                {
                    empleado.antiguedad = antiguedad;
                }

                if (empleado.fechaIngreso != fechaIngreso)
                {
                    empleado.fechaIngreso = fechaIngreso;
                }

                if (empleado.obrasSociales_idobrasSociales != obraSocial)
                {
                    empleado.obrasSociales_idobrasSociales = obraSocial;
                }

                if (empleado.categorias_idcategorias != categoria)
                {
                    empleado.categorias_idcategorias = categoria;
                }

                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
        }

        /*
         * DELETE EMPLOYEE RESOURCES
         */

        public bool EliminarEmpleado(int idEmpleado)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var empleado = db.empleados.Single(emp => emp.idEmpleados == idEmpleado);

                empleado.fechaEgreso = DateTime.Today;
                empleado.activo = false;

                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
        }
    }
}