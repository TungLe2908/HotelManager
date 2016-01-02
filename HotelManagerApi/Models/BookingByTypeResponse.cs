using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Models
{
    public class BookingByTypeResponse
    {
        public string RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public int Quantity { get; set; }
        public long Sum { get; set; }
    }
}