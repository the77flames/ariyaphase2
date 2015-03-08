using ProjectConakry.BusinessServices;
using ProjectConakry.BusinessServices.Interfaces;
using ProjectConakry.DomainObjects.Admin;
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


        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Add(MovieModel movieModel)
        //{

        //    return "";
        //}


    }
}
