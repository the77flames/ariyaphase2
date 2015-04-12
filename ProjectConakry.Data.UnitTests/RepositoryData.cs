using System.IO;

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
        private NewsRepository _newsRepository;
        private LoungeItemRepository _loungeRepository;
        private EventRepository _eventRepository;

        private List<Movie> movielist;

        public RepositoryData()
        {
            _movieRepository = new MovieRepository();
            _newsRepository = new NewsRepository();
            _eventRepository = new EventRepository();
            _loungeRepository= new LoungeItemRepository();

            movielist = new List<Movie>();
        }

        public void AddMovies()
        {
            var list = Enum.GetValues(typeof(Sections));

            foreach (Sections item in list)
            {
                for (int i = 0; i < 24; i++)
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

        private string[] ReadFile(string fileName)
        {
            const string filePath = @"..\..\Files";
            var data = File.ReadAllLines(Path.Combine(filePath, fileName));
            return data.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        }

        public void AddNews()
        {
            var lines = ReadFile("news.html");
            for (int i = 0; i < lines.Length; i++)
            {
                var news = new News()
                {
                    Caption = "News " + i,
                    CreatedDate = DateTime.Now,
                    ExpireDate = DateTime.Today.AddYears(1),
                    ImagePath = ((i % 12) + 1) + ".jpg",
                    Text = lines[i]
                };
                _newsRepository.Create(news);
            }
        }

        public void DeleteNews()
        {
            var list = _newsRepository.GetAll();
            foreach (var news in list)
            {
                _newsRepository.Delete(news.Id.ToString());
            }
        }

        public void AddLounge()
        {
            var lines = ReadFile("lounge.html");
            for (int i = 0; i < lines.Length; i++)
            {
                var lounge = new LoungeItem()
                {
                    Caption = "Lounge " + i,
                    CreatedDate = DateTime.Now,
                    ExpireDate = DateTime.Today.AddYears(1),
                    ImagePath = ((i % 12) + 1) + ".jpg",
                    Text = lines[i]
                };
                _loungeRepository.Create(lounge);
            }
        }

        public void DeleteLounge()
        {
            var list = _loungeRepository.GetAll();
            foreach (var news in list)
            {
                _loungeRepository.Delete(news.Id.ToString());
            }
        }

        public void AddEvent()
        {
            for (int i = 0; i < 20; i++)
            {
                var @event = new Events()
                {
                    EventName = "PSquare Live " + i,
                    EventDate = DateTime.Today.AddDays(i * 5),
                    Time = DateTime.MinValue.AddHours(10).ToString("HH:mm"),
                    Venue = "Muson",
                    ImageThumbNailPath = ((i % 12) + 1) + ".jpg",
                    TicketPrice = 10.ToString("c")
                };
                _eventRepository.Create(@event);
            }
        }

        public void DeleteEvent()
        {
            var list = _eventRepository.GetAll();
            foreach (var item in list)
            {
                _eventRepository.Delete(item.Id.ToString());
            }
        }
    }
}
