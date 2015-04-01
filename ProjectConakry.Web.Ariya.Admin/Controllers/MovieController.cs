using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
    public class MovieController : Controller
    {
        //
        // GET: /Movie/

        private readonly MovieManagementService _movieService;
        public MovieController(MovieManagementService movieService)
        {
            _movieService = movieService;
        }

        [ConakryAdminAuthorize]
        public ActionResult Index()
        {
            var movies = _movieService.GetAll();
            return View(movies);
        }

        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            _movieService.Add(movie);
            return RedirectToAction("Index");
        }


    }
}
