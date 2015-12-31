using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelManagerApi.Models;
using System.Web.Http.Cors;

namespace HotelManagerApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController : ApiController
    {
        public HotelEntitiesDataContext DB = new HotelEntitiesDataContext();
        public int PermissionLevel { set; get; }
        public OauthAccount CurrentAccount { set; get; }
    }
}
