using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
    public class EventsController : Controller
    {
       private readonly EventsManagementService _eventsService;
       public EventsController(EventsManagementService eventsService)
        {
            _eventsService = eventsService;
        }

        [ConakryAdminAuthorize]
        public ActionResult Index()
        {
            ViewBag.ImagePath = ControllerConstants.ImagePath;
            var allEvents = _eventsService.GetAll();
            return View(allEvents);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Events eventItem)
        {
            eventItem.EventDate = DateTime.Parse(eventItem.EventDateString);
            _eventsService.Add(eventItem);
            return RedirectToAction("Index");
        }

        [ValidateInput(false)]
        public ActionResult Edit(string id)
        {
            var eventItem = _eventsService.GetById(id);
            eventItem.IdString = id.ToString();
            return View("EditEvent", eventItem);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Events eventItem)
        {
             eventItem.EventDate = DateTime.Parse(eventItem.EventDateString);
            _eventsService.Update(eventItem);
            return RedirectToAction("Index");
        }

    }
}
