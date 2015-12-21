using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public interface ICustomerManagementService
    {
        void Enroll(Customer newCustomer);

        bool CheckCustomerExist(string email);

        void RemoveCustomer(string id);

        Customer GetCustomerByEmail(string email);

        Customer GetCustomerbyId(string Id);
    }
}
