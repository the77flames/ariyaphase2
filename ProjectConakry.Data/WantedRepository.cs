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
                .SetSkip(skip)
                .SetFields(Fields<WantedUser>.Include(g => g.Id, g => g.LastName, g => g.FirstName));
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

    }
}