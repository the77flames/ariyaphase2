using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectConakry.DomainObjects;

namespace ProjectConakry.Data.UnitTests
{
    [TestClass]
    public class CustomerRepositoryUnitTest
    {
        private CustomerRepository _customerRepository;

        public CustomerRepositoryUnitTest()
        {
            _customerRepository = new CustomerRepository();
        }

        [TestMethod]
        public void CustomerRepositoryCreateTest()
        {
            var customerID = (int)new Random().Next(10000, 3000000);
            var customer = new Customer
            {
                LogInName="uncleKay@okayhouse.com",
                Password="password",
                FirstName = "Uncle Kay",
                LastName = "Kay",
                CustomerID = customerID
            };
            
           _customerRepository.Create(customer);
           var customerFromDB = _customerRepository.GetCustomerByCustomerID(customerID);
           Assert.IsNotNull(customerFromDB);
           Assert.AreEqual(customerID, customerFromDB.CustomerID);
            
        }
    }
}
