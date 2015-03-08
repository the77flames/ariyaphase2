using MongoDB.Bson;
using ProjectConakry.DomainObjects.Enums;
using ProjectConakry.DomainObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.DomainObjects.Admin
{
    public class Movie : AriyaEntity
    {
        public List<Artist> Artists { get; set; }

    }
}
