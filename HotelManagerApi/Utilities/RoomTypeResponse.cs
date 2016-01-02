using HotelManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Utilities
{
    public class RoomTypeResponse
    {
        public string RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public int Price { get; set; }
        public int NoPeople { get; set; }

        public string Picture { get; set; }
        public List<string> Features { set; get; }
        public int NoRoom { set; get; }

        public RoomTypeResponse()
        {
        }
        public RoomTypeResponse(RoomType roomType, List<String> featureNames, int noRoom)
        {
            RoomTypeID = roomType.RoomTypeID;
            RoomTypeName = roomType.RoomTypeName;
            Price = roomType.Price.Value;
            NoPeople = roomType.NoPeople.Value;
            Picture = roomType.Picture;
            Features = featureNames;
            NoRoom = noRoom;
        }

    }
}