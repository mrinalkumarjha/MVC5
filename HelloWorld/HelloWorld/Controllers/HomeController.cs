using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // return View();
            ViewBag.MyTime = DateTime.Now.ToString();
            TempData["MyTimeTemp"] = DateTime.Now.ToString();
            Session["MyTimeSession"] = DateTime.Now.ToString();
            return RedirectToAction("GoToHome", "Home");
        }

        public ActionResult GoToHome()
        {
            ViewData["MyTime"] = DateTime.Now.ToString();
           
            return View();
        }
    }
}