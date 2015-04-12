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

            var applicableBooks = _bookService.GetAll(section) ?? Enumerable.Empty<Book>();
            var applicableSongs = _songService.GetAll(section) ?? Enumerable.Empty<Song>();
            var applicableMovies = _movieService.GetAll(section) ?? Enumerable.Empty<Movie>();

            foreach (var book in applicableBooks)
            {
                yield return book;
            }
            foreach (var movie in applicableMovies)
            {
                yield return movie;
            }
            foreach (var song in applicableSongs)
            {
                yield return song;
            }
        }
    }
}
