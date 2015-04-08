using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjectConakry.Web.Ariya.RESTFulAPIs
{
    public class LoungeItemServiceRESTAPIController : ApiController
    {
        private readonly LoungeItemManagementService _loungeItemManagementService;
       public LoungeItemServiceRESTAPIController(LoungeItemManagementService loungeItemManagementService)
       {
           _loungeItemManagementService = loungeItemManagementService;
           
       }

        [ConakryAuthorize]
        public IEnumerable<LoungeItem> Get(DateTime date)
        {
            return _loungeItemManagementService.GetAllByDate(date);
        }
    }
}
