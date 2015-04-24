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
    public class EventsManagementService : IAriyaAdminService<Events>
    {
        private EventRepository _eventRepository;

        public EventsManagementService(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        
        public void Add(Events entity)
        {
            _eventRepository.Create(entity);
        }
        public List<Events> GetAll()
        {
            return _eventRepository.GetAll();
        }


        public List<Events> GetAll(Sections sectionId)
        {
            throw new Exception("Operation Not Supported !");
        }


        public List<Events> GetAllByDate(DateTime date)
        {
            var result = _eventRepository.GetAllByDate(date) ?? Enumerable.Empty<Events>();
            return result.OrderByDescending(n => n.EventDate).ToList();
        }


        public void Update(Events entity)
        {
            entity.Id = String.IsNullOrEmpty(entity.IdString) ? entity.Id : new ObjectId(entity.IdString);
            _eventRepository.Update(entity);
        }

        public Events GetById(string id)
        {
            return _eventRepository.GetById(id);
        }

        public Events MostPopularItem(string fieldName)
        {
           return _eventRepository.GetMostPopularItemByField(fieldName);
        }
    }
}

