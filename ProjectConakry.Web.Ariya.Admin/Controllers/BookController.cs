using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
    public class BookController : Controller
    {
       private readonly BookManagementService _bookService;
       public BookController(BookManagementService bookService)
        {
            _bookService = bookService;
        }

        [ConakryAdminAuthorize]
        public ActionResult Index()
        {
            ViewBag.ImagePath = ControllerConstants.ImagePath;
            var books = _bookService.GetAll();
            return View(books);
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            _bookService.Add(book);
            return RedirectToAction("Index");
        }

    }
}
