using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagerWeb.Utilities
{
    public class CheckPermissionAttribute : ActionFilterAttribute
    {
        int[] PermissionList;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (!PermissionList.Contains(filterContext.HttpContext.Session.GetPermission()))
            {
                filterContext.Result = new RedirectResult("/booking/index");
            }


        }
        public CheckPermissionAttribute(int[] PermissionList)
        {
            this.PermissionList = PermissionList;
        }
    }
}