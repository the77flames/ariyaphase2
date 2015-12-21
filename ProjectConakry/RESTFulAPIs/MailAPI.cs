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
        public static IRestResponse SendWelcomeMessage(string sendToEmail, string firstName, bool isWanted = false)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v2");
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               ControllerConstants.mailGunApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                 "ariyaunlimited.com", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", ControllerConstants.sender);
            request.AddParameter("to", sendToEmail);
            request.AddParameter("subject", ControllerConstants.emailSubject);
            request.AddParameter("html", ControllerConstants.content + firstName + (isWanted ? ControllerConstants.content3 : ControllerConstants.content2));
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}
