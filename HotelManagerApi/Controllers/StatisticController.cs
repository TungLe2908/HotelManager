using HotelManagerApi.Models;
using HotelManagerApi.Utilities;
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
            var listBookingID = DB.Bookings.Where(b => b.BookingStatus == true && b.DateStart >= dRequest.start && b.DateEnd <= dRequest.end).Select(id => id.BookingID).ToArray();

            var listRoomID = DB.BookingDetails.Where(b => listBookingID.Contains(b.BookingID) == true).Select(id => id.RoomID).ToArray();

            var listRooms = DB.Rooms.Where(r => listRoomID.Contains(r.RoomID)).GroupBy(p => p.RoomTypeID, p => p.RoomID, (key, g) => new { RoomTypeID = key, Rooms = g.ToArray() }).ToArray();

            List<BookingByTypeResponse> result = new List<BookingByTypeResponse>();
            foreach (var rt in listRooms)
            {
                var tmp = DB.RoomTypes.Where(r => r.RoomTypeID == rt.RoomTypeID).Select(p=> new {Name = p.RoomTypeName, Price = p.Price}).First();
                int count = 0;
                foreach (var room in listRoomID)
                {
                    if (rt.Rooms.Contains(room)) count += 1;
                }


                BookingByTypeResponse re = new BookingByTypeResponse() {
                    RoomTypeID = rt.RoomTypeID,
                    Quantity = count,
                    RoomTypeName = tmp.Name,
                    Sum = count * (int)tmp.Price
                };
                result.Add(re);
            }


            return ApiResponse.CreateSuccess(result);

        }
    }
}
