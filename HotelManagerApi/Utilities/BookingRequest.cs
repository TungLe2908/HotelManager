using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Utilities
{
    public class BookingRequest
    {
        public string Email { get; set; }

        public int RoomType { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public int Quantity { get; set; }
    }
}