using Sistema_Liquidacion_de_Haberes.Models.DbFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Liquidacion_de_Haberes.Models.DbModels;
using System.Data.Entity.Validation;
using System.Text;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int idEmpleados, string nombre, string apellido, string cuil, DateTime antiguedad, DateTime fechaIngreso, int obraSocial, int categoria)
        {
            dbConnectionResources.EditarEmpleado(idEmpleados, nombre, apellido, cuil, antiguedad, fechaIngreso, obraSocial, categoria);

            return RedirectToAction("Index");
        }
    }
}