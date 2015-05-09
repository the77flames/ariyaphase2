using ProjectConakry.Data;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ProjectConakry.BusinessServices
{
    public class RecommendationsService : IRecommendationsService
    {
        private readonly MovieManagementService _movieManagementService;

        public RecommendationsService(MovieRepository movieRepository)
        {

            _movieManagementService = new MovieManagementService(movieRepository);
        }

        public IEnumerable<Movie> GetMovieRecommendationsForUser(string userId)
        {
            var result = new List<Movie>();
            foreach(var item in Enum.GetValues(typeof(Genres)))
            {
                foreach (var suggestedMoovieItem in _movieManagementService.GetAllByGenre((Genres)item, 1, 20).GetRandomSequence<Movie>(5))
                {
                    if (!result.Contains(suggestedMoovieItem))
                        result.Add(suggestedMoovieItem);
                }
            }
            return result.Where(n => n != null);
        }

        public IEnumerable<Movie> GetMovieRecommendations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMovieRecommendationsByGenre(Genres genre, int sampleSize)
        {
           return _movieManagementService.GetAllByGenre(genre, 1, sampleSize * 2).GetRandomSequence<Movie>(5);
        }

        
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> GetRandomSequence<T>(this IEnumerable<T> holder, int sampleSize)
        {
            if (holder.Count() != 0)
            {
                var randomIndexList = new List<int>();
                var size = holder.Count();
                for (int i = 0; i <= size; i++)
                {
                    var randomIndex = new Random();
                    yield return holder.ElementAt(randomIndex.Next(1, size) - 1);
                }
            }
            else
                yield return default(T);
        }
    }
}
