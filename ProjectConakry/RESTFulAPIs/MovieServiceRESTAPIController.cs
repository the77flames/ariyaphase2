using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjectConakry.Web.Ariya.RESTFulAPIs
{
    public class MovieServiceRESTAPIController : ApiController
    {
       private readonly MovieManagementService _movieService;

       public MovieServiceRESTAPIController(MovieManagementService movieService)
       {
           _movieService = movieService;
           
       }

        [ConakryAuthorize]
        public bool UpdateNumberOfViews(string id)
        {            
            var movie = _movieService.GetById(id);
            movie.NumberOfViews += 1;
            _movieService.Update(movie);
            return true;
        }


        [ConakryAuthorize]
        public bool UpdateRating(string id, int rating)
        {
            var movie = _movieService.GetById(id);
            var avgRating = (movie.AverageRating * movie.TotalVoters) + rating / (movie.TotalVoters + 1);
            movie.AverageRating = avgRating;
            _movieService.Update(movie);
            UpdateTotalNumberOfVoters(movie);
            return true;
        }

        private void UpdateTotalNumberOfVoters(Movie movie)
        {
            movie.TotalVoters += 1;
            _movieService.Update(movie);
        }
    }
}
