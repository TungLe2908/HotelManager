﻿using HotelManagerApi.Models;
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
            try{
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
        public ApiResponse DeleteRoom([FromBody] int RoomID)
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
            catch(Exception ex)
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
        public ApiResponse updateRoomType([FromBody] RoomType newRoomType)
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
        public ApiResponse getRoomFeature([FromBody] int ID)
        {
            var rt = DB.RoomTypes.Where(r => r.RoomTypeID == ID);
            if (rt.Count() > 0)
            {
                var listFeature = rt.First().ListFeatures.Split(';');
                var feature = DB.RoomFeatures.Where(r => listFeature.Contains(r.FeatureID.ToString())).Select(f => f.FeatureName).ToArray();
                return ApiResponse.CreateSuccess(feature);
            }
            return ApiResponse.CreateFail("Can't find RoomType");
        }

        [HttpGet]
        //[CheckToken(new int[]{1,2})]
        public ApiResponse getRoomType()
        {
            return ApiResponse.CreateSuccess(DB.RoomTypes);
        }


        private List<string> getFeatureName(List<string> ids)
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

        public ApiResponse getBooking([FromBody] DateRequest bDate)
        {
            var invalidBookingID = DB.Bookings.Where(b => !(b.DateStart > bDate.end || b.DateEnd < bDate.start) ).Select(id => id.BookingID).ToArray();

            var invalidRoom = DB.BookingDetails.Where(r => invalidBookingID.Contains((int)r.BookingID) == true).Select(id => id.RoomID).ToArray();

            var invalidRoomType = DB.Rooms.Where(r => invalidRoom.Contains((int)r.RoomID) == true).Select(id => id.RoomTypeID).ToArray();

            var validRoomType = DB.Rooms.Where(r => invalidRoomType.Contains(r.RoomTypeID) == false).Select(id => id.RoomTypeID).ToArray().Distinct();

            if (validRoomType.Count() > 0)
            {
                List<RoomTypeResponse> result = new List<RoomTypeResponse>();
                for (int i = 0; i < validRoomType.Count(); i++)
                {
                    RoomTypeResponse r = new RoomTypeResponse();
                    r.RoomTypeID = (int)validRoomType.ElementAt(i);
                    RoomType rt = DB.RoomTypes.Where(t => t.RoomTypeID == r.RoomTypeID).First();
                    r.RoomTypeName = rt.RoomTypeName;
                    r.Price = (int)rt.Price;
                    r.NoPeople = (int)rt.NoPeople;
                    r.Picture = rt.Picture;

                    // 
                    r.Features = getFeatureName(rt.ListFeatures.Split(';').ToList());
                    //r.Features = (rt.ListFeatures.Split(';').ToList());
                    result.Add(r);
                    
                }
                return ApiResponse.CreateSuccess(result);
                    
            }
            else
                return ApiResponse.CreateFail("No RomType available");
            
        }



        /*
        [HttpPost]
        public ApiResponse deleteRoomType([FromBody] int ID)
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