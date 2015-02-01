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
    public class HomeController : Controller
    {
        private IAuthenticationService _authenticationService;

        public HomeController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }
        [HttpGet]
        public ActionResult Index()
        {            
            return View();
        }

        
        public ActionResult TryLogIn(string userName, string passWord)
        {
            if (_authenticationService.Authenticate(userName, passWord))
            {
                LogInUser(userName);
                return Json(true, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index", "Account");
            }
            // ViewBag.UnAuthorizedUser = true;
            return Json(false, JsonRequestBehavior.AllowGet);
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
                FormsAuthentication.Encrypt(authTicket) );

                Response.Cookies.Add(authCookie);
               
        }


       
      
    }
}
