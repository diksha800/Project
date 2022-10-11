using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeCare.Controllers
{
    public class HomeHealthCareController : Controller
    {
        // GET: HomeHealthCare

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult Audit()
        {
            return View();
           
        }
    }
}