using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelManagerApi.Models;

namespace HotelManagerApi.Controllers
{
    public class BaseController : ApiController
    {
        public HotelEntitiesDataContext DB = new HotelEntitiesDataContext();
    }
}
