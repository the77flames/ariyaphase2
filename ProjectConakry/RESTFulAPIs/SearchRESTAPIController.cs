using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProjectConakry.Web.Ariya.RESTFulAPIs
{
    public class SearchRESTAPIController : ApiController
    {
       public static MovieManagementService _movieManagementService;
      
       public SearchRESTAPIController(MovieManagementService movieManagementService)
       {
           _movieManagementService = movieManagementService;          
           
       }

       public Func<IEnumerable<Media>> DataFetcher = () => { return _movieManagementService.GetAll(); };

        [ConakryAuthorize]
        public IEnumerable<Media> Get(string searchTerm, int count = 6)
        {
            if (String.IsNullOrEmpty(searchTerm))
                return Enumerable.Empty<Media>();
            var searchService = new SearchService<Media>(DataFetcher);
            var results = searchService.Search<string>(searchTerm, 0, count, null);
            return results;
        }
    }
}
