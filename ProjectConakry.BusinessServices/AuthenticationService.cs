using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectConakry.Data;
using ProjectConakry.DomainObjects;
using System.Security.Principal;
using System.Threading;

namespace ProjectConakry.BusinessServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private static CustomerRepository _customerRepository;

        public AuthenticationService(CustomerRepository customerRepository)
        {
            _customerRepository = new CustomerRepository();
        }

        public bool Authenticate(string UserName, string Password)
        {
            var customer = _customerRepository.GetCustomerByUserNamePassword(UserName, Password);
            if (customer == null)
                return false;
            CustomPrincipal principal = new CustomPrincipal(new GenericIdentity(customer.LogInName, "User"), new string[] { "User" });
            principal.Customer = customer;            
            System.Web.HttpContext.Current.Session["currentUser"] = principal;
            return true;
        }

       
    }
}
