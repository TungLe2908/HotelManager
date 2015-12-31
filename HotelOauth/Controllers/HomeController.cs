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
    }
}