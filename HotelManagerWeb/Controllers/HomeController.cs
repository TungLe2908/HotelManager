using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagerWeb.Utilities;

namespace HotelManagerWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if(Session.IsLogin() || Request.Cookies["Token"]!=null)
            {
                return Redirect("/booking/index");
            }
            return View();
        }

        public ActionResult Login(string Token)
        {
            Session.Save(Token);
            Response.Cookies.Add(new HttpCookie("Token", Token));
            return Redirect("/booking/index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Response.Cookies.Add(new HttpCookie("Token") {Expires = DateTime.Now.AddDays(-100) });
            return Redirect("/");
        }
    }
}