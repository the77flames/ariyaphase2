using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectConakry.Data.Interfaces;
using ProjectConakry.DomainObjects.Admin;
using ProjectConakry.DomainObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.Data.UnitTests
{
    [TestClass]
    public class MovieRepositoryTest
    {
        private MovieRepository _movieRepository;
        private List<Movie> movielist;
        public MovieRepositoryTest()
        {
            _movieRepository = new MovieRepository();
            movielist = new List<Movie>();


        }

        [TestMethod]
        public void AddMovie()
        {
            var movie = new Movie()
            {
                Name = "Batman",
                Artists = new List<Artist>(),
                SectionId = Sections.Top10
            };
            _movieRepository.Create(movie);
        }

        [TestMethod]
        public void GetTop10Movies()
        {
            Assert.IsNotNull(_movieRepository.GetAll(Sections.Top10));
        }

        [TestMethod]
        public void GetTrendingMovies()
        {
            Assert.IsNull(_movieRepository.GetAll(Sections.Trending));
        }
    }
}
