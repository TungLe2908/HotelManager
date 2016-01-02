using HotelManagerWeb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HotelManagerWeb.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        [CheckPermission(new int[] { 2 })]
        public ActionResult Staff()
        {
            return View();
        }
        [CheckPermission(new int[] { 2 })]
        public ActionResult AddStaff(String Email, String Name)
        {
            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Token", Session.GetToken());
                var Result = client.PostAsJsonAsync(GetConfig.Get("ApiUrl") + "account/AddStaffAccount", new { Email = Email, Name = Name }).Result;
            }
            return Redirect("/account/staff");
        }

        public ActionResult Index()
        {
            return Redirect("http://www.hoteloauth.somee.com/home/account?token="+Session.GetToken()+"&redir="+Request.UrlReferrer);
        }
    }
}