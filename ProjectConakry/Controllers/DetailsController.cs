using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class DetailsController : AuthenticatedBaseController
    {
        private readonly MovieManagementService _movieManagementService;
        public DetailsController(MovieManagementService movieManagementService)
        {
            _movieManagementService = movieManagementService;
        }

        [ConakryAuthorize]
        [OutputCache(VaryByParam = "id", Duration = 600)]
        public ActionResult Index(int entityType, string id)
        {
            ViewBag.EntityType = entityType;
            ViewBag.Id = id;
            var movieItem = _movieManagementService.GetById(id);
            movieItem.FullSizeImagePath = ControllerConstants.ImagePath + movieItem.FullSizeImagePath ?? String.Empty ;
            return View(movieItem);
        }
    }
}
