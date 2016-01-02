using HotelManagerApi.Models;
using HotelManagerApi.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagerApi.Controllers
{
    public class RoomController : BaseController
    {
        [HttpPost]
        //[CheckToken(new int[]{2})]
        public ApiResponse AddRoom([FromBody]Room newRoom)
        {
            try
            {
                DB.Rooms.InsertOnSubmit(newRoom);
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess("Insert successfully");
            }
            catch
            {
                return ApiResponse.CreateFail("Can't insert");
            }
        }

        [HttpPost]
        //[CheckToken(new int[] { 2 })]
        public ApiResponse UpdateRoom([FromBody]Room newRoom)
        {
            var room = DB.Rooms.Where(r => r.RoomID == newRoom.RoomID);
            if (room.Count() >= 1)
            {
                room.First().RoomTypeID = newRoom.RoomTypeID;
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess("Update successfully");
            }
            else
            {
                return ApiResponse.CreateFail("Can't update");
            }
        }

        [HttpPost]
        //[CheckToken(new int[]{2})]
        public ApiResponse DeleteRoom([FromBody] string RoomID)
        {
            var del = DB.Rooms.Where(r => r.RoomID == RoomID);
            if (del.Count() >= 1)
            {
                DB.Rooms.DeleteOnSubmit(del.First());
                DB.BookingDetails.DeleteAllOnSubmit(DB.BookingDetails.Where(r => r.RoomID == RoomID));
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess("Delete successfully");
            }
            else
            {
                return ApiResponse.CreateFail("Can't find Room");
            }
        }



        [HttpPost]
        //[CheckToken(new int[]{2})]
        public ApiResponse AddRoomFeature([FromBody] RoomFeature newFeature)
        {
            try
            {
                DB.RoomFeatures.InsertOnSubmit(newFeature);
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess("Insert successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse.CreateFail("Can't insert RoomFeature");
            }
        }

        [HttpPost]
        //[CheckToken(new int[]{2})]
        public ApiResponse UpdateRoomFeature([FromBody] RoomFeature newFeature)
        {

            var feature = DB.RoomFeatures.Where(f => f.FeatureID == newFeature.FeatureID);
            if (feature.Count() > 0)
            {
                RoomFeature featureFirst = feature.First();
                featureFirst.FeatureName = newFeature.FeatureName;
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess("Update successfully");
            }
            else
            {
                return ApiResponse.CreateFail("Can't update");
            }
        }

        private bool isValidFeature(int[] availableFeature, string[] Features)
        {
            for (int i = 0; i < Features.Count(); i++)
            {
                if (availableFeature.Contains(int.Parse(Features[i])) == false)
                {
                    return false;
                }
            }
            return true;
        }


        [HttpPost]
        //[CheckToken(new int[]{2})]
        public ApiResponse AddRoomType([FromBody] RoomType newRoomType)
        {
            try
            {
                //check RoomFeatures:
                int[] availableFeatures = DB.RoomFeatures.Select(f => f.FeatureID).ToArray();

                string[] listFeature = newRoomType.ListFeatures.Split(';');

                if (isValidFeature(availableFeatures, listFeature) == false)
                    return ApiResponse.CreateFail("Room Features are invalid");



                DB.RoomTypes.InsertOnSubmit(newRoomType);
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess("Insert successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse.CreateFail("Can't insert RoomType");
            }
        }

        [HttpPost]
        //[CheckToken(new int[]{2})]
        public ApiResponse UpdateRoomType([FromBody] RoomType newRoomType)
        {
            var roomList = DB.RoomTypes.Where(r => r.RoomTypeID == newRoomType.RoomTypeID);
            if (roomList.Count() > 0)
            {
                RoomType room = roomList.First();
                if (newRoomType.ListFeatures != room.ListFeatures)
                {
                    int[] availableFeatures = DB.RoomFeatures.Select(f => f.FeatureID).ToArray();
                    string[] listFeature = newRoomType.ListFeatures.Split(';');

                    if (isValidFeature(availableFeatures, listFeature) == false)
                        return ApiResponse.CreateFail("Room Features are invalid");
                }

                room.ListFeatures = newRoomType.ListFeatures;
                room.NoPeople = newRoomType.NoPeople;
                room.Price = newRoomType.Price;
                room.RoomTypeName = newRoomType.RoomTypeName;

                DB.SubmitChanges();
                return ApiResponse.CreateSuccess("Update successfully");
            }
            return ApiResponse.CreateFail("Can't update");
        }

        [HttpPost]
        public ApiResponse GetRoomFeature([FromBody] string ID)
        {
            var rt = DB.RoomTypes.Where(r => r.RoomTypeID == ID);
            if (rt.Count() > 0)
            {
                var listFeature = rt.First().ListFeatures.Split(';');
                var feature = DB.RoomFeatures.Where(r => listFeature.Contains(r.FeatureID.ToString())).Select(f => f.FeatureName).ToArray().Distinct();
                return ApiResponse.CreateSuccess(feature);
            }
            return ApiResponse.CreateFail("Can't find RoomType");
        }


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


        /*
        [HttpPost]
        public ApiResponse DeleteRoomType([FromBody] int ID)
        {
            var roomList = DB.Rooms.Where(r => r.RoomTypeID == ID);
            if (roomList.Count() > 0)
            {
                ApiResponse response;
                for (int i=0; i<roomList.Count(); i++){
                    response = DeleteRoom(roomList.ElementAt(i).RoomID);
                    if (response.Code == 0)
                        return ApiResponse.CreateFail(response.Message);
                }
                
                DB.RoomTypes.DeleteAllOnSubmit(DB.RoomTypes.Where(rt => rt.RoomTypeID == ID));
                DB.SubmitChanges();

            }
        }
         */

    }
}