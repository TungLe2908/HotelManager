using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Models
{
    public class FullAccount
    {
        public string Email { set; get; }
        public string Password { set; get; }
        public string Phone { set; get; }
        public string Name { set; get; }
        public string Token { set; get; }
        public int PermissionID { set; get; }
    }
}