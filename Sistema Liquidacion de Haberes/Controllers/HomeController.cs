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

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(dbConnectionResources.ObtenerEmpleados());
        }

        public ActionResult Details(int idEmpleado)
        {
            return View(dbConnectionResources.ObtenerEmpleado(idEmpleado));
        }

        [HttpGet]
        public ActionResult Delete(int idEmpleado)
        {
            return View(dbConnectionResources.ObtenerEmpleado(idEmpleado));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployee(int idEmpleado)
        {
            dbConnectionResources.DarDeBajaEmpleado(idEmpleado);

            return RedirectToAction("Index");
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
            var empleado = dbConnectionResources.ObtenerRecursosEditarEmpleado(idEmpleado);

            return View(empleado);
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
                return RedirectToAction("Index");
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

        public string ObtenerMesEnLetras(string numero)
        {
            return dbConnectionResources.ObtenerMesEnLetras(numero);
        }

        public string ObtenerNumeroEnLetras(string numero)
        {            
            return dbConnectionResources.ObtenerNumeroEnLetras(numero);
        }
    }
}