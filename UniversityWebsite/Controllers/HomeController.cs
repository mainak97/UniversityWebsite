using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Event");
            }
            return View();
        }
        [Authorize]
        public ActionResult Event()
        {
            ViewBag.Name = User.Identity.Name;
            return View();
        }
    }
}