using MongoDB.Bson;
using ProjectConakry.DomainObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.DomainObjects.Admin
{
    public class AriyaEntity : MongoEntity, IAriyaEntity
    {
        public string Name { get; set; }
        public ObjectId Id { get; set; }
        public Sections SectionId { get; set; }

        public List<Artist> Artists { get; set; }
    }
}
