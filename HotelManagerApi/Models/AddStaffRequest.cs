using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Models
{
    public class AddStaffRequest
    {
        public string Email { set; get; }
        public string Name { set; get; }
    }
}