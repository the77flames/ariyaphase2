using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class VotingProfileController : AuthenticatedBaseController
    {
        private static ICustomerManagementService _customerManagementService;
        private static IWantedUserManagementService _wantedUserManagementService;

        public VotingProfileController(ICustomerManagementService customerManagementService, IWantedUserManagementService wantedUserManagementService)
        {
            _customerManagementService = customerManagementService;
            _wantedUserManagementService = wantedUserManagementService;
        }

        [ConakryAuthorize]
        public ActionResult Index(string customerId)
        {
            var wantedUser = _wantedUserManagementService.GetWantedUserByCustomerId(customerId);
            DownloadVideoToFile(wantedUser);
            ViewBag.ShowVoteButton = CurrentUser.HasVoted;
            return View(wantedUser);
        }

        [ConakryAuthorize]
        [HttpPost]
        public ActionResult Vote(string customerId)
        {
            WantedUser wantedUser = _wantedUserManagementService.GetWantedUserByCustomerId(customerId);
            wantedUser.TotalVotes += 1;
            _wantedUserManagementService.Update(wantedUser);

            CurrentUser.HasVoted = true;
            _customerManagementService.Update(CurrentUser);

            return RedirectToAction("Index", "ThankYou", new { customerId = CurrentUser.Id });
        }

        private void DownloadVideoToFile(WantedUser wantedUser)
        {
            var memoryStream = new MemoryStream(wantedUser.EntryVideo);
            memoryStream.Seek(0, SeekOrigin.Begin);
            string mime = MimeMapping.GetMimeMapping(wantedUser.EntryVideoFileName);
            string fileExtension = Path.GetExtension(wantedUser.EntryVideoFileName);
            FileStream fileStream = System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + @"\media\" + wantedUser.CustomerId + fileExtension);
            memoryStream.CopyTo(fileStream);
            fileStream.Close();
        }
    }
}