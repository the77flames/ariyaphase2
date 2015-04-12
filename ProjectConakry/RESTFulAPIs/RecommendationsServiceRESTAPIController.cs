using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjectConakry.Web.Ariya.RESTFulAPIs
{
    public class RecommendationsServiceRESTAPIController : ApiController
    {
       private readonly IRecommendationsService _recommendationsService;
       public RecommendationsServiceRESTAPIController(IRecommendationsService recommendationsService)
       {
           _recommendationsService = recommendationsService;
           
       }

        [ConakryAuthorize]
        public IEnumerable<Media> Get(int section, int count = 20)
        {
            return null;
        }


        [ConakryAuthorize]
        public IEnumerable<Media> GetByGenres(Genres genre, int count)
        {
            return null;
        }
    }
}
