using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Models
{
    public class LoginRequest
    {
        public string Username { set; get; }
        public string Password { set; get; }
    }
}