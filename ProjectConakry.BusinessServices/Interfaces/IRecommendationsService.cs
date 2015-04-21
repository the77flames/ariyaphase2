using MongoDB.Bson;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public interface IRecommendationsService
    {
        IEnumerable<Movie> GetMovieRecommendationsForUser(string userId);

        IEnumerable<Movie> GetMovieRecommendations();

        IEnumerable<Movie> GetMovieRecommendationsByGenre(Genres genre, int sampleSize);
    }
}
