using ProjectConakry.Data;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public class CustomerManagermentService : ICustomerManagementService
    {
        private CustomerRepository _customerRepository;

        public CustomerManagermentService(CustomerRepository cusotmerRepository)
        {
            _customerRepository = cusotmerRepository;
        }
        
        public void Enroll(Customer newCustomer)
        {
            _customerRepository.Create(newCustomer);
        }

        public bool CheckCustomerExist(string email)
        { 
           return _customerRepository.GetCustomerByEmail(email) != null;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customerRepository.GetCustomerByEmail(email);
        }

        public void RemoveCustomer(string id)
        {
            _customerRepository.Delete(id);
        }

    }
}
