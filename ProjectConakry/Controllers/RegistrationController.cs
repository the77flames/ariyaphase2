using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using ProjectConakry.Web.Ariya.RESTFulAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
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
            IMailService mailService)
        {
            _customerManagementService = customerManagementService;
            _addressManagementService = addressManagementService;
            _mailService = mailService;
        }

        [AllowAnonymous]
        [OutputCache(Duration = 86400)]
        public ActionResult Index()
        {
            ViewBag.Error = TempData["SignUpError"];
            return View();
        }

        [AllowAnonymous]
        public async Task<ActionResult> CheckEmailExist(string email)
        {
            bool exists = await CheckIfEmailExists(email);
            return Json(exists, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> CheckIfEmailExists(string email)
        {
            return await Task.Run(() => _customerManagementService.CheckCustomerExist(email));
        }

        [AllowAnonymous]
        public async Task<ActionResult> Register(string firstname, string lastname, string email, string phone,
                        string gender, string dob, string accounttype, string password, string agreeToTos)
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
               
               if(String.IsNullOrEmpty(password) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(dob)
                   || String.IsNullOrEmpty(firstname) || String.IsNullOrEmpty(agreeToTos))
               {
                   throw new Exception(ControllerConstants.missingRequiredFields);
               }
               bool emailIsInUse = await CheckIfEmailExists(email);
               if (emailIsInUse)
               {
                   throw new Exception(ControllerConstants.emailInUse);
               }
                _customerManagementService.Enroll(customer);
                customer = _customerManagementService.GetCustomerByEmail(email);
                _addressManagementService.AddNewAddress(new CustomerAddress { CustomerID = customer.Id });
                MailAPI.SendWelcomeMessage(email, firstname);
                return RedirectToAction("Index", "LogIn");
            }
            catch (Exception ex)
            {
                if (customer != null)
                {
                    _customerManagementService.RemoveCustomer(customer.Id.ToString());
                }
                TempData["SignUpError"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
    }
}