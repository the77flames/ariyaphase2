using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProjectConakry.Web.Ariya.RESTFulAPIs
{
    public class DetailsRESTAPIController : ApiController
    {
       
       public DetailsRESTAPIController()
       {           
       }

        [ConakryAuthorize]
        public DetailsViewModel Get(int entityType, string id)
        {
            return DetailsViewHandler.Invoke((EntityTypes)entityType, id);
        }
    }
}
