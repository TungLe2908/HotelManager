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
    public class BookingController : BaseController
    {
        private List<string> GetFeatureName(List<string> ids)
        {
            List<string> re = new List<string>();
            for (int i = 0; i < ids.Count(); i++)
            {
                string name = DB.RoomFeatures.Where(f => f.FeatureID == int.Parse(ids[i])).First().FeatureName;
                re.Add(name);
            }
            return re;
        }
        
        [HttpPost]
        [CheckToken(new int[] { 0, 1, 2 })]
        public ApiResponse GetBooking([FromBody] DateRequest bDate)
        {
            var invalidBookingID = DB.Bookings.Where(b => !(b.DateStart > bDate.end || b.DateEnd < bDate.start)).Select(id => id.BookingID).ToArray();
            var invalidRoom = DB.BookingDetails.Where(r => invalidBookingID.Contains((int)r.BookingID) == true).Select(id => id.RoomID).ToArray();

            //Đếm số phòng trống theo loại phòng
            List<RoomTypeResponse> result = new List<RoomTypeResponse>();
            var listRoomType = DB.RoomTypes.ToArray();
            foreach (var roomType in listRoomType)
            {
                var noRoom = DB.Rooms.Where(r => r.RoomTypeID == roomType.RoomTypeID).Where(r => !invalidRoom.Contains(r.RoomID)).Count();
                if (noRoom > 0)
                {
                    var Features = GetFeatureName(roomType.ListFeatures.Split(';').ToList());
                    RoomTypeResponse roomTypeRes = new RoomTypeResponse(roomType, Features, noRoom);
                    result.Add(roomTypeRes);
                }
            }

            return ApiResponse.CreateSuccess(result);
        }


        [HttpPost]
        [CheckToken(new int[] { 0, 1, 2 })]
        public ApiResponse Book([FromBody] BookingRequest Info)
        {
            // check Info
            if (Info.DateStart > Info.DateEnd || DateTime.Now > Info.DateStart)
                return ApiResponse.CreateFail("Date is invalid");

            if (PermissionLevel > 0)
            {
                var account = DB.Accounts.Where(a => a.Email == Info.Email);
                if (account.Count() <= 0)
                    return ApiResponse.CreateFail("Email not exist");
            }

            Booking booking = new Booking()
            {
                BookingStatus = false,
                DateStart = Info.DateStart,
                DateEnd = Info.DateEnd,
                Quantity = Info.Quantity,
                Account = PermissionLevel == 0 ? CurrentAccount.Email : Info.Email,
            };
            try
            {
                var invalidBookingID = DB.Bookings.Where(b => !(b.DateStart > Info.DateStart || b.DateEnd < Info.DateEnd)).Select(id => id.BookingID).ToArray();
                var invalidRoom = DB.BookingDetails.Where(r => invalidBookingID.Contains((int)r.BookingID) == true).Select(id => id.RoomID).ToArray();

                var validBookingRoom = DB.Rooms.Where(r => r.RoomTypeID == Info.RoomType).Where(r => !invalidRoom.Contains(r.RoomID)).ToArray();
                if (validBookingRoom.Count() < Info.Quantity)
                {
                    return ApiResponse.CreateFail("Not enough room to book");
                }

                //Book room
                DB.Bookings.InsertOnSubmit(booking);
                DB.SubmitChanges();
                var BookingID = DB.Bookings.Max(b => b.BookingID);
                for (int i = 0; i < Info.Quantity; i++)
                {
                    DB.BookingDetails.InsertOnSubmit(new BookingDetail()
                    {
                        BookingID = BookingID,
                        RoomID = validBookingRoom[i].RoomID
                    });
                }
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess(booking);

            }
            catch (Exception ex)
            {
                return ApiResponse.CreateFail(ex.Message);
            }

        }

        [HttpPost]
        [CheckToken(new int[]{0,1,2})]
        public ApiResponse GetBookingHistory([FromBody] string Email)
        {
            try
            {
                var BookingEmail = PermissionLevel == 0 ? CurrentAccount.Email : Email;
                var ListBooking = DB.Bookings.Where(b => b.Account == BookingEmail).ToList();
                List<BookingHistoryResponse> Result = new List<BookingHistoryResponse>();

                foreach(var booking in ListBooking)
                {
                    try
                    {
                        var ListDetail = DB.BookingDetails.Where(b => b.BookingID == booking.BookingID).Select(b => b.RoomID).ToArray();
                        var ListRoom = DB.Rooms.Where(r => ListDetail.Contains(r.RoomID)).ToArray();
                        var RoomType = DB.RoomTypes.Where(r => r.RoomTypeID == ListRoom.First().RoomTypeID).Select(r => r.RoomTypeName);

                        var BookingRes = new BookingHistoryResponse()
                        {
                            BookingID = booking.BookingID,
                            BookingStatus = booking.BookingStatus.Value,
                            DateStart = booking.DateStart.Value,
                            DateEnd = booking.DateEnd.Value,
                            RoomType = RoomType.First(),
                            ListRoom = (from r in ListRoom select r.RoomID).ToList()
                        };
                        Result.Add(BookingRes);
                    }
                    catch { }
                }

                return ApiResponse.CreateSuccess(Result);
            }
            catch(Exception ex)
            {
                return ApiResponse.CreateFail(ex.Message);
            }
        }

        [HttpPost]
        [CheckToken(new int[]{1,2})]
        public ApiResponse DelBooking([FromBody] int BookingID)
        {
            try
            {
                var Bookings = DB.Bookings.Where(b => b.BookingID == BookingID);
                if(Bookings.Count()>0)
                {
                    var Booking = Bookings.First();
                    if(Booking.BookingStatus==false)
                    {
                        var ListDetail = DB.BookingDetails.Where(b => b.BookingID == Booking.BookingID).ToList();
                        DB.BookingDetails.DeleteAllOnSubmit(ListDetail);
                        DB.SubmitChanges();
                        DB.Bookings.DeleteOnSubmit(Booking);
                        DB.SubmitChanges();
                        return ApiResponse.CreateSuccess(null);
                    }
                    else
                    {
                        return ApiResponse.CreateFail("Can't delete this Booking");
                    }
                }
                else
                {
                    return ApiResponse.CreateFail("BookingID is invalid");
                }
            }
            catch (Exception ex)
            {
                return ApiResponse.CreateFail(ex.Message);
            }
        }

        [HttpPost]
        [CheckToken(new int[]{1,2})]
        public ApiResponse Pay([FromBody] int BookingID)
        {
            try
            {
                var Bookings = DB.Bookings.Where(b => b.BookingID == BookingID);
                if(Bookings.Count()>0)
                {
                    var Booking = Bookings.First();
                    if(Booking.BookingStatus==false)
                    {
                        Booking.BookingStatus = true;
                        DB.SubmitChanges();
                        return ApiResponse.CreateSuccess(null);
                    }
                    else
                    {
                        return ApiResponse.CreateFail("Can't pay this Booking");
                    }
                }
                else
                {
                    return ApiResponse.CreateFail("BookingID is invalid");
                }
            }
            catch (Exception ex)
            {
                return ApiResponse.CreateFail(ex.Message);
            }
        }

    }
}
