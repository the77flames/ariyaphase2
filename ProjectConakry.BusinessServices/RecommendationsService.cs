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
                var moviesByGenre = _movieManagementService.GetAllByGenre((Genres)item, 1, 20).ToList();
                moviesByGenre.Shuffle();
                foreach (var suggestedMoovieItem in moviesByGenre)
                {
                    if (!result.Any(k => k.Id == suggestedMoovieItem.Id))
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
            var holder = _movieManagementService.GetAllByGenre(genre, 1, sampleSize).ToList();
            holder.Shuffle();
            return holder;
        }

        
    }

    public static class EnumerableExtensions
    {
        public static void Shuffle<T>(this List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
