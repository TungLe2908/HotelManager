using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagerWeb.Utilities
{
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!filterContext.HttpContext.Session.IsLogin())
            {
                var CookieToken = filterContext.HttpContext.Request.Cookies["Token"];
                if (CookieToken == null)
                {
                    filterContext.Result = new RedirectResult("/home/index");
                }
                else
                {
                    if(!filterContext.HttpContext.Session.Save(CookieToken.Value))
                    {
                        filterContext.Result = new RedirectResult("/home/index");
                    }
                }
            }
        }
    }
}