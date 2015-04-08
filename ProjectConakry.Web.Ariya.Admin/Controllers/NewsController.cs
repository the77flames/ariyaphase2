using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
    public class NewsController : Controller
    {
       private readonly NewsManagementService _newsService;
       public NewsController(NewsManagementService newsService)
        {
            _newsService = newsService;
        }

        [ConakryAdminAuthorize]
        public ActionResult Index()
        {
            var allNews = _newsService.GetAll();
            return View(allNews);
        }

        [HttpPost]
        public ActionResult Add(News news)
        {
            news.CreatedDate = DateTime.Now;
            _newsService.Add(news);
            return RedirectToAction("Index");
        }

    }
}
