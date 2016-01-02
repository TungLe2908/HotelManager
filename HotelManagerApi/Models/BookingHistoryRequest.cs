using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Models
{
    public class BookingHistoryRequest
    {
        public string Email { set; get; }
        public DateTime? FromDate { set; get; }
    }
}