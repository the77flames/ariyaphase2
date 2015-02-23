using ProjectConakry.Data;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public class AdminUserManagementService : IAdminUserManagementService
    {
        private AdminUserRepository _AdminUserRepository;

        public AdminUserManagementService(AdminUserRepository adminUserRepository)
        {
            _AdminUserRepository = adminUserRepository;
        }
        
        public void Enroll(AdminUser newAdminUser)
        {
            _AdminUserRepository.Create(newAdminUser);
        }

        public bool CheckAdminUserExist(string email)
        { 
           return _AdminUserRepository.GetAdminUserByEmail(email) != null;
        }




    }
}
