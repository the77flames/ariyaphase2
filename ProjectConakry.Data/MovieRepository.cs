using MongoDB.Bson;
using MongoDB.Driver.Builders;
using ProjectConakry.DomainObjects.Admin;
using ProjectConakry.DomainObjects.Enums;
using ProjectConakry.DomainObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.Data.Interfaces
{
    public class MovieRepository :GenericRepository<Movie>, IAriyaEntityRepository<Movie>    {


        public List<Movie> GetAll(Sections sectionId)
        {
            var query = Query<Movie>.EQ(e => e.SectionId, sectionId);
            var moviesCursor = this.MongoConnectionManager.MongoCollection.FindAs<Movie>(query);

            if (!moviesCursor.Any())
                return null;

            return moviesCursor.ToList();
        }

        public override void Update(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
