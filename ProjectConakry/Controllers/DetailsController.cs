using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class DetailsController : AuthenticatedBaseController
    {
        public DetailsController()
        {

        }

        [ConakryAuthorize]
        public ActionResult Index(int entityType, string id)
        {
            ViewBag.EntityType = entityType;
            ViewBag.Id = id;
            return View();
        }
    }
}
