using Sistema_Liquidacion_de_Haberes.Models.DbFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Liquidacion_de_Haberes.Models.DbModels;
using System.Data.Entity.Validation;
using System.Text;
using Rotativa;

namespace Sistema_Liquidacion_de_Haberes.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnectionResources dbConnectionResources = new DbConnectionResources();

        public ActionResult Index(int pagina = 1)
        {
            ViewBag.Title = "Home Page";

            var empleados = new IndexViewModel();

            try
            {
                empleados = dbConnectionResources.ObtenerEmpleados(pagina);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return View(empleados);
        }

        [HttpGet]
        public ActionResult Busqueda(int pagina = 1, string cadena = "")
        {
            var empleados = new IndexViewModel();

            try
            {
                empleados = dbConnectionResources.ObtenerBusquedaEmpleados(pagina, cadena);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return View(empleados);
        }

        public ActionResult Details(int idEmpleado)
        {
            try
            {
                return View(dbConnectionResources.ObtenerEmpleado(idEmpleado));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public ActionResult Delete(int idEmpleado)
        {
            try
            {
                return View(dbConnectionResources.ObtenerEmpleado(idEmpleado));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployee(int idEmpleado)
        {
            try
            {
                dbConnectionResources.DarDeBajaEmpleado(idEmpleado);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return RedirectToAction("Delete", new { idEmpleado });
            }
        }

        public ActionResult Create()
        {
            return View(new ViewModelCreateEmployee());
        }

        [HttpPost]
        public ActionResult Create(ViewModelCreateEmployee empleado)
        {
            if (ModelState.IsValid)
            {
                try {
                    dbConnectionResources.CrearEmpleado(empleado);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return RedirectToAction("Create");
                }
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        [HttpGet]
        public ActionResult Edit(int idEmpleado)
        {
            try
            {
                var empleado = dbConnectionResources.ObtenerRecursosEditarEmpleado(idEmpleado);

                return View(empleado);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public PartialViewResult ObtenerObrasSocialesEdit(ViewModelEditEmployee empleado)
        {
            return PartialView("_ObrasSocialesEdit", empleado);
        }

        [HttpGet]
        public PartialViewResult ObtenerCategoriasEdit(ViewModelEditEmployee empleado)
        {
            return PartialView("_CategoriasEdit", empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditEmployee empleado)
        {
            try
            {
                dbConnectionResources.EditarEmpleado(empleado);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return RedirectToAction("Edit", new { empleado });
            }
        }

        public ViewAsPdf ObtenerReciboDeSueldo(int idEmpleado)
        {
            return dbConnectionResources.ObtenerReciboEmpleado(idEmpleado);
        }

        public ActionResult LayoutRecibo(int idEmpleado)
        {
            return View(dbConnectionResources.ObtenerViewModelReciboEmpleado(idEmpleado));
        }
    }
}