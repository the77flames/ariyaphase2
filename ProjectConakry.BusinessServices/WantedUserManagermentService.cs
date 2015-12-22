using MongoDB.Bson;
using ProjectConakry.Data;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;

namespace ProjectConakry.BusinessServices
{
    public class WantedUserManagementService : IWantedUserManagementService
    {
        private WantedRepository _wantedRepository;

        public WantedUserManagementService(WantedRepository wantedRepository)
        {
            _wantedRepository = wantedRepository;
        }


        public void Create(WantedUser newWantedUser)
        {
            _wantedRepository.Create(newWantedUser);
        }

        public void Update(WantedUser wantedUser)
        {
            _wantedRepository.Update(wantedUser);
        }

        public WantedUser GetWantedUserByCustomerId(string customerId)
        {
            var customerObjectId = new ObjectId(customerId);
            WantedUser wantedUser = _wantedRepository.GetWantedUserById(customerObjectId);
            return wantedUser;
        }

        public long GetTotalRegisteredUsers()
        {
            long ret = _wantedRepository.GetTotalCount();
            return ret;
        }

        public IEnumerable<WantedUser> GetWantedSubscribers(int skip, int pagesize)
        {
            IEnumerable<WantedUser> ret = _wantedRepository.GetAllWantedUsers(pagesize, skip);
            return ret;
        }
    }
}