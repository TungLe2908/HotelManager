using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagerWeb.Utilities;
using System.Net.Http;

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

        public ActionResult FacebookLogin()
        {
            string app_id = "609321552474818";
            string app_secret = "7542745bad7841e56952f2cf2b155304";
            string reqUri = Request.Url.AbsoluteUri.ToString();
            var codeindex = reqUri.IndexOf("?code");
            string redirectUri = reqUri.Remove(codeindex, reqUri.Length - codeindex);
            string code = Request["code"];

            string requestUri = @"https://graph.facebook.com/oauth/access_token?client_id=" + app_id + "&redirect_uri=" + redirectUri + "&client_secret=" + app_secret + "&code=" + code;

            var result = "";
            using (HttpClient client = new HttpClient())
            {
                result = client.GetStringAsync(requestUri).Result;
            }
            string str = result;
            int index1 = str.IndexOf("&");
            str = str.Remove(index1, str.Length - index1);
            string accessToken = "facebook~" + str.Replace("access_token=", "");

            Session.Save(accessToken);
            Response.Cookies.Add(new HttpCookie("Token", accessToken));
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