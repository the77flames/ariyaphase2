using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public class CategoryManagementService : ICategoryManagementService
    {
        private readonly BookManagementService _bookService;
        private readonly SongManagementService _songService;
        private readonly MovieManagementService _movieService;

        public CategoryManagementService(
            BookManagementService bookService,
            SongManagementService songService,
            MovieManagementService movieService)
        {
            _bookService = bookService;
            _songService = songService;
            _movieService = movieService;
        }

        public IEnumerable<Media> GetData(Sections section, int count)
        {

            foreach (var book in  _bookService.GetAll(section) ?? new List<Book>())
            {
                yield return book;
            }
            foreach (var movie in _movieService.GetAll(section) ?? new List<Movie>())
            {
                yield return movie;
            }
            foreach (var song in _songService.GetAll(section) ?? new List<Song>())
            var applicableSongs = _songService.GetAll(section) ?? Enumerable.Empty<Song>();
            var applicableMovies = _movieService.GetAll(section) ?? Enumerable.Empty<Movie>();

            foreach(var book in applicableBooks )
            {
                yield return song;
            }
        }
    }
}
