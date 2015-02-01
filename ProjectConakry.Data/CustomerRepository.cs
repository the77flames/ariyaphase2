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
    public class CustomerRepository : GenericRepository<Customer>
    {


        public IEnumerable<Customer> GetAllCustomers(int limit, int skip)
        {
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAllAs<Customer>()
                .SetSortOrder(SortBy<Customer>.Descending(g => g.CreatedDate))
                .SetLimit(limit)
                .SetSkip(skip)
                .SetFields(Fields<Customer>.Include(g => g.Id, g => g.CustomerID, g => g.LastName, g => g.FirstName));
            return gamesCursor;
        }

        public Customer GetCustomerByCustomerID(int CustomerID)
        {
            var query = Query<Customer>.EQ(e => e.CustomerID, CustomerID);
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAs<Customer>(query);

            if (!gamesCursor.Any())
                return null;

            return gamesCursor.FirstOrDefault();
        }

        public Customer GetCustomerByUserNamePassword(string UserName, string Password)
        {
            var query = Query.And(Query<Customer>.EQ(e => e.LogInName, UserName), Query<Customer>.EQ( f => f.Password, Password));
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAs<Customer>(query);

            if (!gamesCursor.Any())
                return null;

            return gamesCursor.FirstOrDefault();
        }

        public Customer GetCustomerByEmail(string email)
        {
            var query = Query<Customer>.EQ(n => n.Email, email);
            var gamesCursor = this.MongoConnectionManager.MongoCollection.FindAs<Customer>(query);

            if (!gamesCursor.Any())
                return null;

            return gamesCursor.FirstOrDefault();
        }

        public override void Update(Customer entity)
        {
            //// Not necessary for the example
        }

    }
}