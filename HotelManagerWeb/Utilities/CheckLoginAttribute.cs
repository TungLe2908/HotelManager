using HotelManagerWeb.Models;
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
            var Session = filterContext.HttpContext.Session;
            if(!Session.IsLogin())
            {
                var CookieToken = filterContext.HttpContext.Request.Cookies["Token"];
                if (CookieToken == null)
                {
                    filterContext.Result = new RedirectResult("/home/index");
                }
                else
                {
                    if(!Session.Save(CookieToken.Value))
                    {
                        filterContext.Result = new RedirectResult("/home/logout");
                    }
                }
            }
            if (Session.IsLogin())
            {
                filterContext.Controller.ViewBag.MenuItems = Menu.Init(Session.GetPermission());
                filterContext.Controller.ViewBag.Permission = Session.GetPermission();
            }
        }
    }
}