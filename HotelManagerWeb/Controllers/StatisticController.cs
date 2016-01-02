using HotelManagerWeb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagerWeb.Controllers
{
    public class StatisticController : BaseController
    {
        // GET: Statistic
        [CheckPermission(new int[]{1,2})]
        public ActionResult Index()
        {
            return View();
        }
    }
}