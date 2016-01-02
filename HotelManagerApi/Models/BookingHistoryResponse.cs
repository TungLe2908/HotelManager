using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Models
{
    public class BookingHistoryResponse
    {
        public DateTime DateStart { set; get; }

        public DateTime DateEnd { set; get; }

        public bool BookingStatus { set; get; }
        public string RoomType { set; get; }
        public List<String> ListRoom { set; get; }
        public int BookingID { set; get; }
        public string Email { set; get; }

    }
}