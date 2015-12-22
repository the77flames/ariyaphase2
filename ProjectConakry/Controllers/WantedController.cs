using PayPal.Api;
using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using ProjectConakry.Web.Ariya.RESTFulAPIs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
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

        [HttpPost]
        public void ProcessPayPalPayment(string customerId)
        {
            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);

            // Make an API call
            var payment = Payment.Create(apiContext, new Payment
            {
                intent = "sale",
                payer = new Payer
                {
                    payment_method = "paypal"
                },
                transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        description = "Transaction description.",
                        invoice_number = "001",
                        amount = new Amount
                        {
                            currency = "USD",
                            total = "20.00",
                            details = new Details
                            {
                                tax = "0",
                                shipping = "0",
                                subtotal = "20"
                            }
               },
                     item_list = new ItemList
                     {
                        items = new List<Item>
                        {
                            new Item
                            {
                                name = "Wanted Competition Entry Fee",
                                currency = "USD",
                                price = "20",
                                quantity = "1",
                                sku = "sku"
                            }
                        }
                    }
                }
            },
                redirect_urls = new RedirectUrls
                {
                    return_url = ConfigurationManager.AppSettings["paypalRedirectUrl"] + customerId,
                    cancel_url = ConfigurationManager.AppSettings["paypalCancelUrl"]
                }
            });
            TempData["transactionId"] = payment.id;
            Response.Redirect(ConfigurationManager.AppSettings["paypalApprovalRedirect"] +"&token="+ payment.token);
        }

        public ActionResult ExecutePayment(string customerId, string PayerID)
        {
            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            string id = TempData["transactionId"].ToString();
            // Execute Payment
            var payment = new Payment
            {
                id = id
            };
            PaymentExecution pymntExecution = new PaymentExecution();
            pymntExecution.payer_id = PayerID;
            payment.Execute(apiContext, pymntExecution);

            return RedirectToAction("ThankYou", new { customerId = customerId });
        }

        public ActionResult ThankYou(string customerId)
        {
            Customer wantedUser = _customerManagementService.GetCustomerbyId(customerId);
            ViewBag.FirstName = wantedUser.FirstName;
            MailAPI.SendWelcomeMessage(wantedUser.Email, wantedUser.FirstName);
            return View();
        }

        [AllowAnonymous]
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
                // Create new user
                customer = (Customer)wantedUser;
                _customerManagementService.Enroll(customer);
                customer = _customerManagementService.GetCustomerByEmail(wantedUser.Email);
                _addressManagementService.AddNewAddress(new CustomerAddress { CustomerID = customer.Id });
                // add wanted details
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
            return Json(ret);
        }
    }
}