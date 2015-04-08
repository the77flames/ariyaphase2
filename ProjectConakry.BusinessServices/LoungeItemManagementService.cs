using MongoDB.Bson;
using ProjectConakry.BusinessServices;
using ProjectConakry.Data;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public class LoungeItemManagementService : IAriyaAdminService<LoungeItem>
    {
        private LoungeItemRepository _loungeItemRepository;

        public LoungeItemManagementService(LoungeItemRepository loungeItemRepository)
        {
            _loungeItemRepository = loungeItemRepository;
        }
        
        public void Add(LoungeItem entity)
        {
            _loungeItemRepository.Create(entity);
        }
        public List<LoungeItem> GetAll()
        {
            return _loungeItemRepository.GetAll();
        }

        public List<LoungeItem> GetAll(Sections sectionId)
        {
            throw new Exception("Operation Not Supported !");
        }

        public LoungeItem GetById(ObjectId id)
        {
            throw new NotImplementedException();
        }
        public List<LoungeItem> GetAllByDate(DateTime date)
        {
            return _loungeItemRepository.GetAllByDate(date);
        }
    }
}

