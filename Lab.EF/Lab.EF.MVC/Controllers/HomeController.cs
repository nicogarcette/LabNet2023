using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Acerca de la aplicacion";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Pestania contacto";

            return View();
        }

        public ActionResult Employee() {
            ViewBag.Message = "Soy employee";

            return View();
        }
    }
}