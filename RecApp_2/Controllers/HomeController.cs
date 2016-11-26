using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecApp_2.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Para ayuda póngase en contacto con el administrador del sistema.";

            return View();
        }

        public ActionResult Mantenimientos()
        {
            //ViewBag.Message = "Para ayuda póngase en contacto con el administrador del sistema.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Para ayuda póngase en contacto con el administrador del sistema.";

            return View();
        }

        public ActionResult Help()
        {
            //ViewBag.Message = "Para ayuda póngase en contacto con el administrador del sistema.";

            return View();
        }
    }
}