using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext fillterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                fillterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "login", action = "Index", area = "Admin" }));
            }
            base.OnActionExecuting(fillterContext);
        }
    }
}