using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectConakry.Data;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.Data.UnitTests
{
    [TestClass]
    public class RepositoryData
    {
        private MovieRepository _movieRepository;
        private List<Movie> movielist;

        public RepositoryData()
        {
            _movieRepository = new MovieRepository();
            movielist = new List<Movie>();
        }

        public void AddMovies()
        {
            var list = Enum.GetValues(typeof(Sections));

            foreach (Sections item in list)
            {
                for (int i = 0; i < 4; i++)
                {
                    var movie = new Movie()
                    {
                        Name = "Batman" + i, 
                        Artists = new List<Artist>(), 
                        SectionId = item,
                        ThumbNailImagePath = ((i % 12) + 1) + ".jpg"
                    };
                    _movieRepository.Create(movie);
                }
            }
        }

        public void DeleteMovies()
        {
            var movies = _movieRepository.GetAll();
            foreach (var movie in movies)
            {
                _movieRepository.Delete(movie.Id.ToString());
            }            
        }
    }
}
