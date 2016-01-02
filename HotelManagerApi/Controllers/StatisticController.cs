﻿using HotelManagerApi.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagerApi.Controllers
{
    public class StatisticController : BaseController
    {

        [HttpPost] 
        //[CheckToken(new int[]{0,1,2})]
        public ApiResponse getStatisticByRoomType([FromBody] DateRequest dRequest)
        {
            var listBookingID = DB.Bookings.Where(b => b.BookingStatus == true && b.DateStart >= dRequest.start && b.DateEnd <= dRequest.end).Select(id => id.BookingID).Distinct();

            var listRoomID = DB.BookingDetails.Where(b => listBookingID.Contains(b.BookingID) == true).Select(id => id.RoomID).ToArray();

            var listRooms = DB.Rooms.Where(r => listRoomID.Contains(r.RoomID)).GroupBy(p => p.RoomTypeID, p => p.RoomID, (key, g) => new { RoomTypeID = key, Quantity = g.ToArray().Count() }).ToArray();

            
         

            return ApiResponse.CreateSuccess(listRooms);

        }
    }
}
