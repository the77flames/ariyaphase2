using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class RegistrationController : Controller
    {
        private static ICustomerManagementService _customerManagementService;
        private static IAddressManagementService _addressManagementService;
        private static IMailService _mailService;

        public RegistrationController(ICustomerManagementService customerManagementService, IAddressManagementService addressManagementService,
            MailService mailService)
        {
            _customerManagementService = customerManagementService;
            _addressManagementService = addressManagementService;
            _mailService = mailService;
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
        public ActionResult Register(string firstname, string lastname, string email, string phone,
                        string gender, string dob, string accounttype, string password)
        {
            var dateofbirth = new DateTime();
            DateTime.TryParse(dob, out dateofbirth);
            var customer = new Customer
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    PhoneNumber = phone,
                    Password = password,
                    Gender = gender,
                    DOB = dateofbirth,
                    AccountType = accounttype
                    
                };
            try
            {
                
                _customerManagementService.Enroll(customer);
                customer = _customerManagementService.GetCustomerByEmail(email);
                _addressManagementService.AddNewAddress(new CustomerAddress { CustomerID = customer.Id  });
                _mailService.Send(ControllerConstants.sender, email, ControllerConstants.emailSubject, ControllerConstants.content);
                return RedirectToAction("Index", "LogIn");
            }
            catch (Exception)
            {
                if (customer != null)
                    _customerManagementService.RemoveCustomer(customer.Id.ToString());
                return RedirectToAction("Index");
            }

        }
    }
}
