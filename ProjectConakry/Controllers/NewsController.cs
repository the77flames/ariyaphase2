using ProjectConakry.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class NewsController : Controller
    {
        private static NewsManagementService _newsManagementService;
        public NewsController(NewsManagementService newsManagementService)
        {
            _newsManagementService = newsManagementService;
        }

        [ConakryAuthorize]
        public ActionResult Index(string id)
        {
            var newsItem = _newsManagementService.GetById(id);
            return View(newsItem);
        }
    }
}
