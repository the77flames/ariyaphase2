using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class LogInController : Controller
    {
        private IAuthenticationService _authenticationService;

        public LogInController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpGet]        
        [ValidateInput(false)]
        public ActionResult Index()
        {
            ViewBag.Error = TempData["LogInError"];
            ViewBag.ImagePath = ControllerConstants.ImagePath;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> TryLogIn(string email, string passWord)
        {
            string c_defaultAuthErrorMessage = "Bad username or password";
            string redirectUrl = System.Web.HttpContext.Current.Session["redirectPath"] as string;

            if (_authenticationService.Authenticate(email, passWord))
            {
                await LogInUser(email);
                if(!string.IsNullOrEmpty(redirectUrl))
                {
                    Response.Redirect(redirectUrl);
                }
                c_defaultAuthErrorMessage = string.Empty;
               
            }
            TempData["LogInError"] = c_defaultAuthErrorMessage;

            return RedirectToAction("Index", "Account");
        }


        private async Task LogInUser(string email)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;

            //authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var claims = new List<Claim> { new Claim("email", email) };
            var identity = new ClaimsIdentity(claims);

            await Task.Factory.StartNew( () => authenticationManager.SignIn(
                new AuthenticationProperties()
                {
                    IsPersistent = false
                }, identity));

                        
        }

        public ActionResult SignOut()
        {           
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            System.Web.HttpContext.Current.Session["currentUser"] = null;
            System.Web.HttpContext.Current.Session.Abandon();
            return RedirectToAction("Index", "Home");
                
        }




    }
}
