using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjectConakry.Web.Ariya.RESTFulAPIs
{
    public class NewsServiceRESTAPIController : ApiController
    {
      
       private readonly NewsManagementService _newsManagementService;
       public NewsServiceRESTAPIController(NewsManagementService newsManagementService)
       {
           _newsManagementService = newsManagementService;
           
       }

        [ConakryAuthorize]
        public IEnumerable<News> Get(DateTime date)
        {
            return _newsManagementService.GetAllByDate(date);
        }
    }
}
