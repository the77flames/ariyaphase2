using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
namespace ProjectConakry
{
    public class ConakryAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            return true;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //filterContext.Result = new RedirectToRouteResult(
            //            new RouteValueDictionary(
            //                new
            //                {
            //                    controller = "Error",
            //                    action = "Unauthorised"
            //                })
            //            );
            throw new HttpException((int)HttpStatusCode.Unauthorized, "UnAuthorized Access");
        }
    }
}