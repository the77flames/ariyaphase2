using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjectConakry.Web.Ariya.RESTFulAPIs
{
    public class EventsServiceRESTAPIController : ApiController
    {
       private readonly EventsManagementService _eventManagementService;
       public EventsServiceRESTAPIController(EventsManagementService eventManagementService)
       {
           _eventManagementService = eventManagementService;
           
       }

        [ConakryAuthorize]
        public IEnumerable<Events> Get(DateTime date)
        {
            var events = _eventManagementService.GetAllByDate(date);
            return events;
        }
    }
}
