using MongoDB.Bson;
using MongoDB.Driver.Builders;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.Data
{
    public class BookRepository : GenericRepository<Book>, IAriyaAdminRepository<Book>    {


        public List<Book> GetAll(Sections sectionId)
        {
            var query = Query<Book>.EQ(e => e.SectionId, sectionId);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<Book>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();
        }

        public override void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
