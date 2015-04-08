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
    public class BookManagementService : IAriyaAdminService<Book>
    {
        private BookRepository _bookRepository;

        public BookManagementService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        public void Add(Book entity)
        {
            _bookRepository.Create(entity);
        }
        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public List<Book> GetAll(Sections sectionId)
        {
            return _bookRepository.GetAll(sectionId);
        }


        public Book GetById(ObjectId id)
        {
            throw new NotImplementedException();
        }


        public List<Book> GetAllByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

