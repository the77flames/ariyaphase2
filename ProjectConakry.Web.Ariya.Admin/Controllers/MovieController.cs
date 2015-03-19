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

        private readonly MovieService _movieService;
        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [ConakryAdminAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            _movieService.Add(movie);
            return RedirectToAction("Index");
        }


    }
}
