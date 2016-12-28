using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusHostel.Web.Controllers
{
    public class LegalController : Controller
    {
        public ActionResult Index()
        {
            return Privacy();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Terms()
        {
            return View();
        }
    }
}