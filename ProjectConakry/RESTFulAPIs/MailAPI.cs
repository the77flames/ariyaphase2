using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectConakry.Web.Ariya.RESTFulAPIs
{
    public static class MailAPI
    {
        private const string c_apiConvention = "api";
        private const string c_htmlParameterNameConvention = "html";
        private const string c_apiBaseUrl = "https://api.mailgun.net/v2";

        public static IRestResponse SendWelcomeMessage(string sendToEmail, string firstName, bool isWanted = false)
        {
            string message = (isWanted ? ControllerConstants.wantedRegistrationMessageStart : ControllerConstants.defaultWelcomeMessage);
            return SendMessage(sendToEmail, firstName, message, null);
        }

        public static IRestResponse SendMessage(string sendToEmail, string firstName, string message, string subject)
        {
            RestClient client = GetRestClient();
            RestRequest request = GetRestRequest(sendToEmail, subject);
            request.AddParameter(c_htmlParameterNameConvention, ControllerConstants.content + firstName + message);
            request.Method = Method.POST;
            return client.Execute(request);
        }

        private static RestClient GetRestClient()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri(c_apiBaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(c_apiConvention, ControllerConstants.mailGunApiKey);

            return client;
        }
        private static RestRequest GetRestRequest(string sendToEmail, string subject)
        {
            // Non-localizable strings.
            const string c_domain = "domain";
            const string c_applicationIdentifier = "ariyaunlimited.com";
            const string c_resourceMessageFormat = "{domain}/messages";
            const string c_emailFromConvention = "from";
            const string c_emailToConvention = "to";
            const string c_emailSubjectConvention = "subject";

            if(string.IsNullOrEmpty(subject))
            {
                subject = ControllerConstants.emailSubject;
            }

            RestRequest request = new RestRequest();
            request.AddParameter(c_domain, c_applicationIdentifier, ParameterType.UrlSegment);
            request.Resource = c_resourceMessageFormat;
            request.AddParameter(c_emailFromConvention, ControllerConstants.sender);
            request.AddParameter(c_emailToConvention, sendToEmail);
            request.AddParameter(c_emailSubjectConvention, subject);

            return request;
        }
    }
}
