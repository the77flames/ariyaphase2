using ProjectConakry.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class EventDetailsController : Controller
    {
        private static EventsManagementService _eventsManagementService;
        public EventDetailsController(EventsManagementService eventsManagementService)
        {
            _eventsManagementService = eventsManagementService;
        }


        [OutputCache(VaryByParam = "id", Duration = 600)]
        public ActionResult Index(string id)
        {
           var eventItem = _eventsManagementService.GetById(id);
           eventItem.ImageBigPath = ControllerConstants.ImagePath + eventItem.ImageBigPath;
           return View(eventItem);
        }
    }
}
