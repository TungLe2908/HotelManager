using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Models
{
    public class AddAccountRequest
    {
        public string Email { set; get; }
        public string Name { set; get; }
    }
}