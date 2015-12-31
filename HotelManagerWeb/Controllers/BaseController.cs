using HotelManagerWeb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagerWeb.Controllers
{
    [CheckLogin]
    public class BaseController : Controller
    {
    }
}