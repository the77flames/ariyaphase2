using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using ProjectConakry.Web.Ariya.RESTFulAPIs;
using System.Configuration;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class ThankYouController : Controller
    {
        private static ICustomerManagementService _customerManagementService;

        public ThankYouController(ICustomerManagementService customerManagementService)
        {
            _customerManagementService = customerManagementService;
        } 

        [HttpGet]
        public ActionResult Index(string customerId, string message = null, string subject = null)
        {
            if(string.IsNullOrEmpty(message))
            {
                message = ControllerConstants.defaultThankYouMessage;
            }
            if (string.IsNullOrEmpty(subject))
            {
                subject = ControllerConstants.defaultThankYouSubject;
            }
            Customer user = _customerManagementService.GetCustomerbyId(customerId);
            ViewBag.FirstName = user.FirstName;
            MailAPI.SendMessage(user.Email, user.FirstName, message, subject);
            return View();
        }

        [HttpGet]
        public ActionResult Wanted(string customerId)
        {
            const string c_votingUrlKey = "votingUrl";
            const string c_subject = "Wanted Comedy Competition Entry Confirmation";

            Customer user = _customerManagementService.GetCustomerbyId(customerId);
            ViewBag.FirstName = user.FirstName;
            string votingLink = ConfigurationManager.AppSettings[c_votingUrlKey] + customerId;
            string message = ControllerConstants.wantedRegistrationMessageStart + votingLink + ControllerConstants.wantedRegistrationMessageEnd;
            MailAPI.SendMessage(user.Email, user.FirstName, message, c_subject);
            return View("Index");
        }
    }
}