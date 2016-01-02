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
        public double Quantity { get; set; }
        public double Sum { get; set; }
    }
}