using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
    public class LoungeController : Controller
    {
        private readonly LoungeItemManagementService _loungeItemService;
        public LoungeController(LoungeItemManagementService loungeItemService)
        {
            _loungeItemService = loungeItemService;
        }

        [ConakryAdminAuthorize]
        public ActionResult Index()
        {
            var allLoungeItems = _loungeItemService.GetAll();
            return View(allLoungeItems);
        }

        [HttpPost]
        public ActionResult Add(LoungeItem loungeItem)
        {
            loungeItem.CreatedDate = DateTime.Now;
            _loungeItemService.Add(loungeItem);
            return RedirectToAction("Index");
        }

      
    }
}
