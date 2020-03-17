using Sistema_Liquidacion_de_Haberes.Models.DbFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Liquidacion_de_Haberes.Models.DbModels;

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

        [HttpGet]
        public string RetornarObraSocial(int idObraSocial)
        {
            return dbConnectionResources.ObtenerObraSocial(idObraSocial);
        }

        [HttpGet]
        public string RetornarSector(int idCategoria)
        {
            return dbConnectionResources.ObtenerSector(idCategoria);
        }

        [HttpGet]
        public string RetornarCategoria(int idCategoria)
        {
            return dbConnectionResources.ObtenerCategoria(idCategoria);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int idEmpleado)
        {
            var empleado = dbConnectionResources.ObtenerEmpleado(idEmpleado);

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