using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Utilities
{
    public class RoomTypeResponse
    {
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public int Price { get; set; }
        public int NoPeople { get; set; }

        public string Picture { get; set; }
        public List<string> Features;

        public RoomTypeResponse()
        {
            Features = new List<string>();
        }

    }
}