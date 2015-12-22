using System.Collections.Generic;
using ProjectConakry.DomainObjects;

namespace ProjectConakry.BusinessServices
{
    public interface IWantedUserManagementService
    {
        void Create(WantedUser newWantedUser);

        void Update(WantedUser wantedUser);

        WantedUser GetWantedUserByCustomerId(string customerId);

        long GetTotalRegisteredUsers();

        IEnumerable<WantedUser> GetWantedSubscribers(int skip, int pagesize);
    }
}