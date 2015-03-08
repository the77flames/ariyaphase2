using MongoDB.Bson;
using ProjectConakry.BusinessServices.Interfaces;
using ProjectConakry.Data.Interfaces;
using ProjectConakry.DomainObjects.Admin;
using ProjectConakry.DomainObjects.Enums;
using ProjectConakry.DomainObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public class MovieService : IAriyaEntityService<Movie>
    {
        private MovieRepository _movieRepository;

        public MovieService(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        public void AddMovie(Movie entity)
        {
            _movieRepository.Create(entity);
        }

        public List<Movie> GetAll(Sections sectionId)
        {
            return _movieRepository.GetAll(sectionId);
        }


        public Movie GetById(ObjectId id)
        {
            throw new NotImplementedException();
        }
    }
}

