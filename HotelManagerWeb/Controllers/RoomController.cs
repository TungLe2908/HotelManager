using HotelManagerWeb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagerWeb.Controllers
{
    public class RoomController : BaseController
    {
        // GET: Room
        [CheckPermission(new int[] { 2 })]
        public ActionResult Index()
        {
            return View();
        }
    }
}