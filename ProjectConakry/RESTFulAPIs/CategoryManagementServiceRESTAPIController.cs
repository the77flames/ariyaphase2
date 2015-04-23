using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Media> Get(int? section, int count = 20)
        {            
            if(section != null && section.GetValueOrDefault() > 0)
             return _categoryManagementService.GetData((Sections)section, count);

            var results = Enumerable.Empty<Media>();
            foreach(var sectionType in Enum.GetValues(typeof(Sections)))
            {
                results = results.Concat(_categoryManagementService.GetData((Sections)sectionType, count));
            }

            return results;
        }
    }
}
