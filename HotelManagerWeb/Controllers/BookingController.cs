using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagerWeb.Utilities;

namespace HotelManagerWeb.Controllers
{
    public class BookingController : BaseController
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Management(String Email)
        {
            if(Session.GetPermission()>0 && !String.IsNullOrEmpty(Email))
            {
                ViewBag.CusEmail = Email;
            }
            return View();
        }
    }
}