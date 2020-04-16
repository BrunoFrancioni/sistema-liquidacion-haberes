using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_Liquidacion_de_Haberes;
using Sistema_Liquidacion_de_Haberes.Controllers;

namespace Sistema_Liquidacion_de_Haberes.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Busqueda()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Busqueda() as ViewResult;

            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void Detalles()
        {
            HomeController controller = new HomeController();

            ActionResult result = controller.Details(1) as ActionResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            HomeController controller = new HomeController();

            ActionResult result = controller.Delete(1) as ActionResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
