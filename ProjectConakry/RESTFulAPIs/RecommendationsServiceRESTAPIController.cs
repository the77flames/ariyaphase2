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
        public IEnumerable<Media> Get(int entityType, string userId)
        {
            return _recommendationsService.GetMovieRecommendationsForUser(userId);
        }


        [ConakryAuthorize]
        public IEnumerable<Media> GetByGenres(int entityType, int genre, int count)
        {
           return  _recommendationsService.GetMovieRecommendationsByGenre((Genres)genre, count);
        }
    }
}
