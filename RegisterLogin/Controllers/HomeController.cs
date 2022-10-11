using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterLogin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Register()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
