using PayPal.Api;
using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using ProjectConakry.Web.Ariya.RESTFulAPIs;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class WantedController : Controller
    {
        private static ICustomerManagementService _customerManagementService;
        private static IAddressManagementService _addressManagementService;
        private static IWantedUserManagementService _wantedUserManagementService;

        public WantedController(ICustomerManagementService customerManagementService, IAddressManagementService addressManagementService,
            IWantedUserManagementService wantedUserManagementService)
        {
            _customerManagementService = customerManagementService;
            _addressManagementService = addressManagementService;
            _wantedUserManagementService = wantedUserManagementService;
        }

        [AllowAnonymous]
        [OutputCache(Duration = 36480)]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Subscribe(string customerId)
        {
            ViewBag.CustomerId = customerId;
            return View();
        }

        [AllowAnonymous]
        [OutputCache(Duration = 36480)]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(WantedUser wantedUser, HttpPostedFileBase video)
        {
            Customer customer = null;
            try
            {
                bool emailIsInUse = _customerManagementService.CheckCustomerExist(wantedUser.Email);
                if (emailIsInUse)
                {
                    throw new Exception(ControllerConstants.emailInUse);
                }
                // Create New User
                customer = new Customer
                {
                    Email = wantedUser.Email,
                    CreatedDate = DateTime.Now,
                    FirstName = wantedUser.FirstName,
                    LastName = wantedUser.LastName,
                    Gender = wantedUser.Gender,
                    DOB = wantedUser.DOB
                };
                _customerManagementService.Enroll(customer);
                customer = _customerManagementService.GetCustomerByEmail(wantedUser.Email);
                _addressManagementService.AddNewAddress(new CustomerAddress { CustomerID = customer.Id });

                // Persist Wanted Data
                wantedUser.CustomerId = customer.Id;
                wantedUser.EntryVideoFileName = video.FileName;
                wantedUser.EntryVideoContentType = video.ContentType;

                using (var reader = new BinaryReader(video.InputStream))
                {
                    wantedUser.EntryVideo = reader.ReadBytes(video.ContentLength);
                }
                _wantedUserManagementService.Create(wantedUser);

                return RedirectToAction("Subscribe", new { customerId = customer.Id.ToString() });
            }
            catch (Exception ex)
            {
                if (customer != null)
                {
                    _customerManagementService.RemoveCustomer(customer.Id.ToString());
                }
                TempData["SignUpError"] = ex.Message;
                return RedirectToAction("Register");
            }
        }

        [HttpGet]
        public JsonResult GetNumberRegistered()
        {
            long ret = _wantedUserManagementService.GetTotalRegisteredUsers();
            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UpdateSubscription(string customerId)
        {
            var wantedUser = _wantedUserManagementService.GetWantedUserByCustomerId(customerId);
            wantedUser.Subscribed = true;
            _wantedUserManagementService.Update(wantedUser);
            return RedirectToAction("Wanted", "ThankYou", new { customerId = customerId });
        }
    }
}