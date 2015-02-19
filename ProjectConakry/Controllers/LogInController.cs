using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectConakry.Controllers
{
    public class LogInController : Controller
    {
        private IAuthenticationService _authenticationService;

        public LogInController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TryLogIn(string email, string passWord)
        {           
            if (_authenticationService.Authenticate(email, passWord))
            {
                LogInUser(email);
                return RedirectToAction("Index", "Account");
            }

            throw new UnauthorizedAccessException("Bad username or password");
        }


        private void LogInUser(string userName)
        {

            FormsAuthentication.SetAuthCookie(
                    userName, true);

            FormsAuthenticationTicket authTicket =
            new FormsAuthenticationTicket(
                    1,           // version
                    userName,   // get username  from the form
                    DateTime.Now,                        // issue time is now
                    DateTime.Now.AddMinutes(10),         // expires in 10 minutes
                    false,  // cookie is not persistent
                    null
                    );
            HttpCookie authCookie = new HttpCookie(
            FormsAuthentication.FormsCookieName,
            FormsAuthentication.Encrypt(authTicket));

            Response.Cookies.Add(authCookie);

        }




    }
}
