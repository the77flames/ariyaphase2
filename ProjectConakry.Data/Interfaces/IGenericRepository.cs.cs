using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectConakry.DomainObjects;

namespace ProjectConakry.Data
{
    public interface IGenericRepository<T> where T : IMongoEntity
    {
        void Create(T entity);

        void Delete(string id);

        T GetById(string id);

        void Update(T entity);
    }
}
