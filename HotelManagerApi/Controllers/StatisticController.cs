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
        //[CheckToken(new int[]{1,2})]
        public ApiResponse getStatisticByRoomType([FromBody] DateRequest dRequest)
        {
            var listBookingID = DB.Bookings.Where(b => b.BookingStatus == true && b.DateStart >= dRequest.start && b.DateEnd <= dRequest.end).Select(id => new { BookingID = id.BookingID, Time = ((TimeSpan)(id.DateEnd - id.DateStart))}).ToArray();

            var listRoomID = DB.BookingDetails.Where(b => listBookingID.Select(idl => idl.BookingID).ToArray().Contains(b.BookingID) == true).ToArray();

            var listRooms = DB.Rooms.Where(r => listRoomID.Select(ro => ro.RoomID).Contains(r.RoomID)).GroupBy(p => p.RoomTypeID, p => p.RoomID, (key, g) => new { RoomTypeID = key, Rooms = g.ToArray() }).ToArray();

            List<BookingByTypeResponse> result = new List<BookingByTypeResponse>();
            foreach (var rt in listRooms)
            {
                var tmp = DB.RoomTypes.Where(r => r.RoomTypeID == rt.RoomTypeID).Select(p=> new {Name = p.RoomTypeName, Price = p.Price}).First();
                double count = 0;
                foreach (var room in listRoomID.Select(r => r.RoomID).Distinct())
                {
                   
                    if (rt.Rooms.Contains(room)) {
                        var listR = listRoomID.Where(rid => rid.RoomID == room).Select(id => id.BookingID).ToArray();
                        count = count + listBookingID.Where(lbk => listR.Contains(lbk.BookingID)).Select(p => p.Time.Days).ToArray().Sum();
                    }
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
