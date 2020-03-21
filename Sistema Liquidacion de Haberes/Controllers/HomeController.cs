﻿using Sistema_Liquidacion_de_Haberes.Models.DbFunctions;
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
            return View(dbConnectionResources.ObtenerRecursosCrearEmpleado());
        }

        [HttpGet]
        public PartialViewResult ObtenerCategorias(int idSector)
        {
            return PartialView("_Categorias",dbConnectionResources.ObtenerCategoria(idSector));
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