using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Sistema_Liquidacion_de_Haberes.Models.DbModels;
using System.Web.Mvc;

namespace Sistema_Liquidacion_de_Haberes.Models.DbFunctions
{
    public class DbConnectionResources
    {

        /*
         * VIEW RESOURCES
         */
        public IEnumerable<ViewModelEmployee> ObtenerEmpleados()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var idEmpleados = (from empleado in db.empleados
                                   select empleado.idEmpleados).ToList();

                List<ViewModelEmployee> empleados = new List<ViewModelEmployee>();

                foreach(var id in idEmpleados)
                {
                    empleados.Add(ObtenerEmpleado(id));
                }

                return (IEnumerable<ViewModelEmployee>) empleados;
            }
        }

        public ViewModelEmployee ObtenerEmpleado(int idEmpleado)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var empleado = db.empleados.Single(emp => emp.idEmpleados == idEmpleado);

                var categoria = db.categorias.Single(cat => cat.idCategorias == empleado.categorias_idcategorias);

                var sector = db.sectores.Single(sec => sec.idSector == categoria.sector_idSector);

                var obraSocial = db.obrasSociales.Single(obra => obra.idObrasSociales == empleado.obrasSociales_idobrasSociales);

                var cuentaBancaria = db.cuentasBancarias.Single(cuenta => cuenta.idCuentasBancarias == empleado.cuentasBancarias_idcuentasBancarias);

                var banco = db.bancos.Single(banc => banc.idBancos == cuentaBancaria.bancos_idbancos);

                var retornoEmpleado = new ViewModelEmployee()
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
                    NombreSector = sector.nombre,
                    NombreCategoria = categoria.nombre,
                    Salario = categoria.salario,
                    Activo = empleado.activo,
                    ObraSocial = obraSocial.nombre,
                    Plan = obraSocial.plan,
                    NombreBanco = banco.nombre,
                    Cbu = cuentaBancaria.cbu
                };

                return retornoEmpleado;
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

        public ViewModelCreateEmployee ObtenerRecursosCrearEmpleado()
        {
            ViewModelCreateEmployee createEmployeeModel = new ViewModelCreateEmployee()
            {
                LugarTrabajo = "Capital Federal",
                ObrasSociales = ObtenerObrasSociales(),
                Bancos = ObtenerBancos(),
                Sectores = ObtenerSectores(),
                Categorias = ObtenerCategorias(1)
            };

            return createEmployeeModel;
        }

        public IEnumerable<SelectListItem> ObtenerObrasSociales()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var obrasSociales = db.obrasSociales.ToList();

                var listado = new List<SelectListItem>();

                foreach(var obraSocial in obrasSociales)
                {
                    listado.Add(new SelectListItem
                    {
                        Text = obraSocial.nombre,
                        Value = Convert.ToString(obraSocial.idObrasSociales)
                    });
                }

                return (IEnumerable<SelectListItem>) listado;
            }
        }

        public IEnumerable<sectores> ObtenerSectores()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var sectores = db.sectores.ToList();

                return (IEnumerable<sectores>) sectores;
            }
        }

        public IEnumerable<SelectListItem> ObtenerCategorias(int idSector)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var categorias = db.categorias.Where(cat => cat.sector_idSector == idSector).ToList();

                List<SelectListItem> listado = new List<SelectListItem>();

                foreach(var categoria in categorias)
                {
                    listado.Add(new SelectListItem
                    {
                        Text = categoria.nombre,
                        Value = Convert.ToString(categoria.idCategorias)
                    });
                }

                return (IEnumerable<SelectListItem>) listado;
            }
        }

        public IEnumerable<SelectListItem> ObtenerBancos()
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var bancos = db.bancos.ToList();

                var listado = new List<SelectListItem>();

                foreach(var banco in bancos)
                {
                    listado.Add(new SelectListItem
                    {
                        Text = banco.nombre,
                        Value = Convert.ToString(banco.idBancos)
                    });
                }

                return (IEnumerable<SelectListItem>) listado;
            }
        }

        /*
         * EDIT EMPLOYEE RESOURCES
         */

        public ViewModelEditEmployee ObtenerRecursosEditarEmpleado(int idEmpleado)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var empleado = db.empleados.Single(emp => emp.idEmpleados == idEmpleado);

                var categoria = db.categorias.Single(cat => cat.idCategorias == empleado.categorias_idcategorias);

                var sector = db.sectores.Single(sec => sec.idSector == categoria.sector_idSector);

                ViewModelEditEmployee editEmployeeModel = new ViewModelEditEmployee()
                {
                    IdEmpleado = empleado.idEmpleados,
                    Nombre = empleado.nombre,
                    Apellido = empleado.apellido,
                    Cuil = empleado.cuil,
                    LugarTrabajo = empleado.lugarTrabajo,
                    Antiguedad = empleado.antiguedad,
                    FechaIngreso = empleado.fechaIngreso,
                    ObrasSociales = ObtenerEditarObraSocial(empleado.obrasSociales_idobrasSociales),
                    IdSectorActivo = sector.idSector,
                    Sectores = ObtenerSectores(),
                    Categorias = ObtenerEditarCategorias(sector.idSector, empleado.categorias_idcategorias)
                };

                return editEmployeeModel;
            }
        }

        public IEnumerable<SelectListItem> ObtenerEditarObraSocial(int idObrasocial)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var obrasSociales = db.obrasSociales.ToList();

                var listado = new List<SelectListItem>();

                foreach (var obraSocial in obrasSociales)
                {
                    listado.Add(new SelectListItem
                    {
                        Text = obraSocial.nombre,
                        Value = Convert.ToString(obraSocial.idObrasSociales),
                        Selected = (obraSocial.idObrasSociales == idObrasocial) ? true : false
                    });
                }

                return (IEnumerable<SelectListItem>)listado;
            }
        }

        public IEnumerable<SelectListItem> ObtenerEditarCategorias(int idSector, int idCategoria)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var categorias = db.categorias.Where(cat => cat.sector_idSector == idSector).ToList();

                List<SelectListItem> listado = new List<SelectListItem>();

                foreach (var categoria in categorias)
                {
                    listado.Add(new SelectListItem
                    {
                        Text = categoria.nombre,
                        Value = Convert.ToString(categoria.idCategorias),
                        Selected = (categoria.idCategorias == idCategoria) ? true : false //TODO: fix this shit
                    });
                }

                return (IEnumerable<SelectListItem>)listado;
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