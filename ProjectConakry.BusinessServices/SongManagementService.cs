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
    public class SongManagementService : IAriyaAdminService<Song>
    {
        private SongRepository _songRepository;

        public SongManagementService(SongRepository songRepository)
        {
            _songRepository = songRepository;
        }
        
        public void Add(Song entity)
        {
            _songRepository.Create(entity);
        }
        public List<Song> GetAll()
        {
            return _songRepository.GetAll();
        }

        public List<Song> GetAll(Sections sectionId)
        {
            return _songRepository.GetAll(sectionId);
        }


        public Song GetById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public List<Song> GetAllByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

