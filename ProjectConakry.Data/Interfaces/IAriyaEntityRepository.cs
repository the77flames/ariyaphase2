using ProjectConakry.DomainObjects.Admin;
using ProjectConakry.DomainObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.Data.Interfaces
{
    public interface IAriyaEntityRepository<T> where T : IAriyaEntity
    {
        List<T> GetAll(Sections sectionId);
    }
}
