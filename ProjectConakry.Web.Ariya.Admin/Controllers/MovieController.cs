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
            ViewBag.ImagePath = ControllerConstants.ImagePath;
            var movies = _movieService.GetAll();
            return View(movies);
        }
        
        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            _movieService.Add(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {            
            var movie = _movieService.GetById(id);
            movie.IdString = id.ToString();
            ViewBag.Genre = movie.Genre;
            ViewBag.Section = movie.SectionId;
            return View("EditMovie", movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {          
            _movieService.Update(movie);
            return RedirectToAction("Index");
        }
    }
}
