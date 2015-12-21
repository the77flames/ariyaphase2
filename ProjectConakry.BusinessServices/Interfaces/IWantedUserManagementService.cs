using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public interface IWantedUserManagementService
    {
        void Create(WantedUser newWantedUser);

        void Update(WantedUser wantedUser);

        WantedUser GetWantedUserByCustomerId(string customerId);
    }
}
