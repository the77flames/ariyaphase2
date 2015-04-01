using MongoDB.Bson;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public interface ICategoryManagementService
    {
        IEnumerable<Media> GetData(Sections section, int count);
    }
}
