using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectConakry.Web.Ariya.RESTFulAPIs
{
    public class CategoryManagementServiceRESTAPIController : ApiController
    {
       private readonly CategoryManagementService _categoryManagementService;
       public CategoryManagementServiceRESTAPIController(CategoryManagementService categoryManagementService)
       {
           _categoryManagementService = categoryManagementService;
           
       }

        [ConakryAuthorize]
        public IEnumerable<Media> Get(int section, int count = 20)
        {
            return _categoryManagementService.GetData((Sections)section, count);
        }
    }
}
