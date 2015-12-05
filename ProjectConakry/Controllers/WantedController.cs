using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class WantedController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Subscribe()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
    }
}
