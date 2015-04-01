using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
    public class Top10Controller : Controller
    {
        private readonly CategoryManagementService _categoryManagementService;
        public Top10Controller(CategoryManagementService categoryManagementService)
       {
           _categoryManagementService = categoryManagementService;
           
       }

        [ConakryAdminAuthorize]
        public ActionResult Index()
        {
            return View();
        }

      

    }
}
