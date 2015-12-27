using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class PaypalController : Controller
    {
        /// <summary>
        /// This is the convention used to persist the transaction id between requests.
        /// </summary>
        private const string c_transactionIdTempKey = "transactionId";

        [HttpPost]
        public void ProcessPayPalPayment(string customerId)
        {
            // Non localizable strings
            const string c_sale = "sale";
            const string c_paypalConvention = "paypal";
            const string c_defaultDescription = "Ariya Subscription";
            const string c_currency = "USD";
            const string c_notApplicableValue = "0";
            const string c_defaultTitle = "Wanted Competition Entry Fee";
            const string c_defaultCharge = "20.00";
            const string c_DefaultQuantity = "1";
            const string c_defaultSku = "WantedApp11T";
            const string c_paypalRedirectUrlAppKey = "paypalRedirectUrl";
            const string c_paypalCancelUrlAppKey = "paypalCancelUrl";
            const string c_paypalApprovalUrlAppKey = "paypalApprovalRedirect";
            const string c_tokenParameter = "&token=";

            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);

            // Make an API call
            var payment = Payment.Create(apiContext, new Payment
            {
                intent = c_sale,
                payer = new Payer
                {
                    payment_method = c_paypalConvention
                },
                transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        description = c_defaultDescription,
                        invoice_number = Guid.NewGuid().ToString(null, CultureInfo.InvariantCulture),
                        amount = new Amount
                        {
                            currency = c_currency,
                            total = c_defaultCharge,
                            details = new Details
                            {
                                tax = c_notApplicableValue,
                                shipping = c_notApplicableValue,
                                subtotal = c_defaultCharge
                            }
               },
                     item_list = new ItemList
                     {
                        items = new List<Item>
                        {
                            new Item
                            {
                                name = c_defaultTitle,
                                currency = c_currency,
                                price = c_defaultCharge,
                                quantity = c_DefaultQuantity,
                                sku = c_defaultSku
                            }
                        }
                    }
                }
            },
                redirect_urls = new RedirectUrls
                {
                    return_url = ConfigurationManager.AppSettings[c_paypalRedirectUrlAppKey] + customerId,
                    cancel_url = ConfigurationManager.AppSettings[c_paypalCancelUrlAppKey]
                }
            });
            Response.Redirect(ConfigurationManager.AppSettings[c_paypalApprovalUrlAppKey] + c_tokenParameter + payment.token);
        }

        public ActionResult ExecutePayment(string customerId, string paymentId, string PayerID)
        {
            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            // Execute Payment
            var payment = new Payment
            {
                id = paymentId
            };
            PaymentExecution pymntExecution = new PaymentExecution();
            pymntExecution.payer_id = PayerID;
            payment.Execute(apiContext, pymntExecution);

            return RedirectToAction("UpdateSubscription", "Wanted", new { customerId = customerId });
        }

    }
}
