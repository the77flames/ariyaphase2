using MongoDB.Bson;
using ProjectConakry.DomainObjects.Admin;
using ProjectConakry.DomainObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.DomainObjects.Interfaces
{
    public interface IMovie
    {
         string Name { get; set; }
         ObjectId MovieId { get; set; }
         List<Artist> Artists { get; set; }
         Sections SectionId { get; set; }
    }
}
