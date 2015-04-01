using MongoDB.Bson;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public interface IAriyaAdminService<T> where T : IMongoEntity
    {
        void Add(T entity);
        List<T> GetAll(Sections sectionId);
        T GetById(ObjectId id);
    }
}
