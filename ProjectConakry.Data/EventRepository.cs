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
    public class EventRepository : GenericRepository<Events>, IAriyaAdminRepository<Events>
    {
        public List<Events> GetAllByDate(DateTime date)
        {
            var query = Query<Events>.GTE(e => e.EventDate, date);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<Events>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();
        }

       
        public List<Events> GetAll(Sections sectionId)
        {
            throw new NotImplementedException();
        }
    }
}
