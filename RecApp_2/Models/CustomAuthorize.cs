using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecApp_2.Models
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //   // redire
        //    //filterContext.Result = new HttpUnauthorizedResult(); // Try this but i'm not sure
        //   // filterContext.Result = new RedirectResult("Action", "Controller");
        //}

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (this.AuthorizeCore(filterContext.HttpContext))
        //    {
        //        base.OnAuthorization(filterContext);
        //    }
        //    else
        //    {
        //        this.HandleUnauthorizedRequest(filterContext);
        //    }
        //}

    }

}