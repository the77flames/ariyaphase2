using ProjectConakry.DomainObjects;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.Data
{
    public interface IAriyaAdminRepository<T> : IGenericRepository<T> where T : IMongoEntity
    {
        List<T> GetAll(Sections sectionId);
    }
}
