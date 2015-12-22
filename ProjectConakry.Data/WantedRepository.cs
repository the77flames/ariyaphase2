using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ProjectConakry.DomainObjects;
using MongoDB.Bson;

namespace ProjectConakry.Data
{
    public class WantedRepository : GenericRepository<WantedUser>
    {
        public IEnumerable<WantedUser> GetAllWantedUsers(int limit, int skip)
        {
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAllAs<WantedUser>()
                .SetSortOrder(SortBy<WantedUser>.Descending(g => g.CreatedDate))
                .SetLimit(limit)
                .SetSkip(skip);
            return gamesCursor;
        }

        public IEnumerable<WantedUser> GetAllSubscribedWantedUsers(int limit, int skip)
        {
            var query = Query<WantedUser>.EQ(n => n.Subscribed, true);
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAs<WantedUser>(query)
                .SetSortOrder(SortBy<WantedUser>.Descending(g => g.CreatedDate))
                .SetLimit(limit)
                .SetSkip(skip);
            return gamesCursor;
        }

        public WantedUser GetWantedUserById(ObjectId CustomerID)
        {
            var query = Query<WantedUser>.EQ(e => e.CustomerId, CustomerID);
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAs<WantedUser>(query);

            if (!gamesCursor.Any())
                return null;

            return gamesCursor.FirstOrDefault();
        }

        public WantedUser GetCustomerByEmail(string email)
        {
            var query = Query<WantedUser>.EQ(n => n.Email, email);
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAs<WantedUser>(query);

            if (!gamesCursor.Any())
                return null;

            return gamesCursor.FirstOrDefault();
        }

        public long GetTotalCount()
        {
            MongoCursor<WantedUser> gamesCursor = this.MongoConnectionManager.MongoCollection.FindAll();
            long totalCount = gamesCursor.Count();
            return totalCount;
        }

    }
}