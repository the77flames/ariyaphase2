using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.DomainObjects.Admin
{
    public interface IAriyaEntity    {

         string Name { get; set; }
         ObjectId Id { get; set; }
    }
}
