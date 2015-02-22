using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class RegistrationController : Controller
    {
        private static ICustomerManagementService _customerManagementService;
        private static IAddressManagementService _addressManagementService;
        public RegistrationController(ICustomerManagementService customerManagementService, IAddressManagementService addressManagementService)
        {
            _customerManagementService = customerManagementService;
            _addressManagementService = addressManagementService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult CheckEmailExist(string email)
        {
            return Json(_customerManagementService.CheckCustomerExist(email), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Register(string FirstName, string LastName, string  Email, string Phone, 
                                        string Street, string City, string State, string Password, string PostalCode)
        {
            var customer = new Customer
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    PhoneNumber = Phone,
                    Password = Password
                };
            try
            {
                
                _customerManagementService.Enroll(customer);
                customer = _customerManagementService.GetCustomerByEmail(Email);
                _addressManagementService.AddNewAddress(new CustomerAddress { Street = Street, City = City, State = State, CustomerID = customer.CustomerID, ZipCode = PostalCode  });
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                if (customer != null)
                    _customerManagementService.RemoveCustomer(customer.Id.ToString());
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
