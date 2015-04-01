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
    public class SongRepository : GenericRepository<Song>, IAriyaAdminRepository<Song>    {


        public List<Song> GetAll(Sections sectionId)
        {
            var query = Query<Song>.EQ(e => e.SectionId, sectionId);
            var cursor = this.MongoConnectionManager.MongoCollection.FindAs<Song>(query);

            if (!cursor.Any())
                return null;

            return cursor.ToList();
        }

        public override void Update(Song entity)
        {
            throw new NotImplementedException();
        }
    }
}
