using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
    public class WantedController : Controller
    {
       private readonly WantedUserManagementService _wantedUserManagementService;

       public WantedController(WantedUserManagementService wantedUserManagementService)
        {
            _wantedUserManagementService = wantedUserManagementService;
        }

        [ConakryAdminAuthorize]
        public ActionResult Index()
        {
            ViewBag.ImagePath = ControllerConstants.ImagePath;
            var allSubscribers = _wantedUserManagementService.GetWantedSubscribers(0, 20);
            return View(allSubscribers);
        }


    }
}