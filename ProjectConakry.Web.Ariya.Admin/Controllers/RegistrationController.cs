using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
   
    public class RegistrationController : Controller
    {

        private static IAdminUserManagementService _adminUserManagementService;
        public RegistrationController(IAdminUserManagementService adminUserManagementService)
        {
            _adminUserManagementService = adminUserManagementService;            
        }


        public ActionResult Register(string firstname, string lastname, string email,  string password)
        {
           
            var adminUser = new AdminUser
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = password

            };
            try
            {

                _adminUserManagementService.Enroll(adminUser);
                return RedirectToAction("Index", "LogIn");
            }
            catch (Exception)
            {               
                return RedirectToAction("Index");
            }

        }
    }
}
