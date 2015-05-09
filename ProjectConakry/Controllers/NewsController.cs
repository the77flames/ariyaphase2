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

        
        [OutputCache(VaryByParam = "id", Duration= 600) ]
        public ActionResult Index(string id)
        {
            var newsItem = _newsManagementService.GetById(id);
            newsItem.ImagePath = ControllerConstants.ImagePath + newsItem.ImagePath;
            return View(newsItem);
        }
    }
}
