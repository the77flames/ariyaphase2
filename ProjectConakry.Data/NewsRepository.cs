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
    public class NewsRepository : GenericRepository<News>, IAriyaAdminRepository<News>    {


        public List<News> GetAllByDate(DateTime date)
        {
            var query = Query<News>.GTE(e => e.ExpireDate, date);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<News>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();
        }

       
        public List<News> GetAll(Sections sectionId)
        {
            throw new NotImplementedException();
        }
    }
}
