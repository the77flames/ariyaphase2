using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public interface IAdminUserManagementService
    {
        void Enroll(AdminUser newCustomer);
        bool CheckAdminUserExist(string email);
    }
}
