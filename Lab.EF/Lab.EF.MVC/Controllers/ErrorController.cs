using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string message) {
            ViewBag.Message = message;

            return View();
        }   
        public ViewResult NotFound() {
            Response.StatusCode = 404;
            return View("NotFound");
        }
    }
}