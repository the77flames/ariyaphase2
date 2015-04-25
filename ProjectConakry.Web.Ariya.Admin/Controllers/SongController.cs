using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
    public class SongController : Controller
    {
         private readonly SongManagementService _songService;
         public SongController(SongManagementService songService)
        {
            _songService = songService;
        }

        [ConakryAdminAuthorize]
        public ActionResult Index()
        {
            ViewBag.ImagePath = ControllerConstants.ImagePath;
            var songs = _songService.GetAll();
            return View(songs);
        }

        [HttpPost]
        public ActionResult Add(Song song)
        {
            _songService.Add(song);
            return RedirectToAction("Index");
        }

    }
}
