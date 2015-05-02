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

       
        public ActionResult Index(string id)
        {
           var eventItem = _eventsManagementService.GetById(id);
           return View(eventItem);
        }
    }
}
