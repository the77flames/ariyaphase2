using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class DetailsController : Controller
    {
        public DetailsController()
        {

        }

        [ConakryAuthorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
