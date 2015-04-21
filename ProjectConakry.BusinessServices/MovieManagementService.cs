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
        
        public Movie GetById(string id)
        {
            return _movieRepository.GetById(id);
        }

        public IEnumerable<Movie> GetAllWithPaging(int pageNumber, int pageSize)
        {
            var numberToSkip = pageNumber * pageSize;
            return _movieRepository.GetAllWithPaging(numberToSkip, pageSize);
        }

        public IEnumerable<Movie> GetAllByGenre(Genres genre, int pageNumber, int pageSize)
        {
            var propertyName = "Genre";
            object propertyValue = null;
            var numberToSkip =  (pageNumber - 1) * pageSize;
            foreach(var item in Enum.GetValues(typeof(Genres)))
            {
                if ((int)item == (int)genre)
                    propertyValue = item;
            }
            return _movieRepository.GetByPropertyValue(propertyName, propertyValue, numberToSkip, pageSize) ?? Enumerable.Empty<Movie>();
        }
        public List<Movie> GetAllByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Movie MostPopularItem(string fieldName)
        {
            return _movieRepository.GetMostPopularItemByField(fieldName);
        }
        
        public void Update(Movie entity)
        {
            _movieRepository.Update(entity);
        }
    }
}

