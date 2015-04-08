using MongoDB.Bson;
using ProjectConakry.BusinessServices;
using ProjectConakry.Data;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public class MovieManagementService : IAriyaAdminService<Movie>
    {
        private MovieRepository _movieRepository;

        public MovieManagementService(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        
        public void Add(Movie entity)
        {
            _movieRepository.Create(entity);
        }
        public List<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public List<Movie> GetAll(Sections sectionId)
        {
            return _movieRepository.GetAll(sectionId);
        }


        public Movie GetById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAllByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

