using HotelOauth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelOauth.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(String Redir)
        {
            ViewBag.Redir = Redir;
            ViewBag.onlyRegister = false;
            return View();
        }

        public ActionResult Register(String Redir)
        {
            ViewBag.Redir = Redir;
            ViewBag.onlyRegister = true;
            return View("Index");
        }
        public ActionResult Account(String Token, String Redir)
        {
            if(String.IsNullOrEmpty(Token))
            {
                return Redirect("/home/index?redir=" + Redir);
            }
            ViewBag.Redir = Redir;
            ViewBag.onlyRegister = true;
            ViewBag.onlyEdit = true;
            using (var DB = new OauthDataContext())
            {
                var Listacc = DB.Accounts.Where(acc => acc.Token == Token);
                if(Listacc.Count()>0)
                {
                    ViewBag.Name = Listacc.First().Name;
                    ViewBag.Pass = Listacc.First().Pass;
                    ViewBag.Phone = Listacc.First().Phone;
                    ViewBag.Email = Listacc.First().Email;
                }
            }
            return View("Index");
        }
    }
}