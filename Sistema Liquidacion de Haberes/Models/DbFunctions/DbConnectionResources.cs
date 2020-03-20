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
        public IEnumerable<ViewModelEmpleado> ObtenerEmpleados()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var idEmpleados = (from empleado in db.empleados
                                   select empleado.idEmpleados).ToList();

                List<ViewModelEmpleado> empleados = new List<ViewModelEmpleado>();

                foreach(var id in idEmpleados)
                {
                    empleados.Add(ObtenerEmpleado(id));
                }

                return (IEnumerable<ViewModelEmpleado>) empleados;
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

                return (IEnumerable<obrasSociales>) obrasSociales;
            }
        }

        public IEnumerable<sectores> ObtenerSectores()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var sectores = db.sectores.ToList();

                return (IEnumerable<sectores>)sectores;
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

        public ViewModelEmpleado ObtenerEmpleado(int idEmpleado)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var empleado = db.empleados.Single(emp => emp.idEmpleados == idEmpleado);

                var obraSocial = db.obrasSociales.Single(o => o.idObrasSociales == empleado.obrasSociales_idobrasSociales);

                var categoria = db.categorias.Single(cat => cat.idCategorias == empleado.categorias_idcategorias);

                var sector = db.sectores.Single(s => s.idSector == categoria.sector_idSector);

                string nombreSector = sector.nombre;

                var cuentaBancaria = db.cuentasBancarias.Single(cuenta => cuenta.idCuentasBancarias == empleado.cuentasBancarias_idcuentasBancarias);

                var banco = db.bancos.Single(b => b.idBancos == cuentaBancaria.bancos_idbancos);

                string nombreBanco = banco.nombre;

                ViewModelEmpleado viewEmpleado = new ViewModelEmpleado()
                {
                    IdEmpleado = empleado.idEmpleados,
                    Nombre = empleado.nombre,
                    Apellido = empleado.apellido,
                    Cuil = empleado.cuil,
                    LugarTrabajo = empleado.lugarTrabajo,
                    Legajo = empleado.legajo,
                    Antiguedad = empleado.antiguedad,
                    FechaIngreso = empleado.fechaIngreso,
                    FechaEgreso = empleado.fechaEgreso,
                    NombreSector = nombreSector,
                    NombreCategoria = categoria.nombre,
                    Salario = categoria.salario,
                    Activo = empleado.activo,
                    ObraSocial = obraSocial.nombre,
                    Plan = obraSocial.plan,
                    NombreBanco = nombreBanco,
                    Cbu = cuentaBancaria.cbu
                };

                return viewEmpleado;
            }
        }

        public bool EditarEmpleado(int idEmpleado, string nombre, string apellido, string cuil, DateTime antiguedad, DateTime fechaIngreso,  int obraSocial, int categoria)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var empleado = db.empleados.Single(emp => emp.idEmpleados == idEmpleado);

                if(!(String.IsNullOrEmpty(nombre)) || empleado.nombre != nombre)
                {
                    empleado.nombre = nombre;
                }

                if (!(String.IsNullOrEmpty(apellido)) || empleado.apellido != apellido)
                {
                    empleado.apellido = apellido;
                }

                if (!(String.IsNullOrEmpty(cuil)) || empleado.cuil != cuil)
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

        public bool DarDeBajaEmpleado(int idEmpleado)
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