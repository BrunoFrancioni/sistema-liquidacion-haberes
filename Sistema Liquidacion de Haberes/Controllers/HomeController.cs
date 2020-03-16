using Sistema_Liquidacion_de_Haberes.Models.DbFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Liquidacion_de_Haberes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ViewResources recursos = new ViewResources();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(recursos.ObtenerEmpleados());
        }

        public string RetornarObraSocial(int idObraSocial)
        {
            return recursos.ObtenerObraSocial(idObraSocial);
        }

        public string RetornarSector(int idCategoria)
        {
            return recursos.ObtenerSector(idCategoria);
        }

        public string RetornarCategoria(int idCategoria)
        {
            return recursos.ObtenerCategoria(idCategoria);
        }
    }
}