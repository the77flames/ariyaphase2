using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Media> Get(string userId, int count)
        {
            var recommendedEvents = _recommendationsService.GetMovieRecommendationsForUser(userId) ?? Enumerable.Empty<Media>();
            return recommendedEvents.Take(count);
        }


        [ConakryAuthorize]
        public IEnumerable<Media> GetByGenres(int entityType, int genre, int count)
        {
           return  _recommendationsService.GetMovieRecommendationsByGenre((Genres)genre, count);
        }
    }
}
