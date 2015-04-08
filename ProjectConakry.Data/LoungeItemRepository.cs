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
    public class LoungeItemRepository : GenericRepository<LoungeItem>, IAriyaAdminRepository<LoungeItem>    {


        public List<LoungeItem> GetAllByDate(DateTime date)
        {
            var query = Query<LoungeItem>.GTE(e => e.ExpireDate, date);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<LoungeItem>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();
        }

        public override void Update(LoungeItem entity)
        {
            throw new NotImplementedException();
        }

        public List<LoungeItem> GetAll(Sections sectionId)
        {
            throw new NotImplementedException();
        }
    }
}
