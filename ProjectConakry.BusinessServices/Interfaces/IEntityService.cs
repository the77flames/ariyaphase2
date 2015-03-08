using MongoDB.Bson;
using ProjectConakry.DomainObjects.Admin;
using ProjectConakry.DomainObjects.Enums;
using ProjectConakry.DomainObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices.Interfaces
{
    public interface IAriyaEntityService<T> where T : IAriyaEntity
    {
        void AddMovie(T entity);
        List<T> GetAll(Sections sectionId);
        T GetById(ObjectId id);
    }
}
