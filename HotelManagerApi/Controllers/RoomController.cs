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
        //[CheckToken(new int[]{1})]
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
        //[CheckToken(new int[] { 1 })]
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
        //[CheckToken(new int[]{1})]
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
        //[CheckToken(new int[]{1})]
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
        //[CheckToken(new int[]{1})]
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

        /*
        [HttpPost]
        //[CheckToken(new int[]{1})]
        public ApiResponse AddRoomType([FromBody] RoomType newRoomType)
        {
            try
            {
                //check RoomFeatures:
                int[] roomFeatureList = DB.RoomFeatures.Select(f => f.FeatureID).ToArray();

                string[] listFeature = newRoomType.ListFeatures.Split(';');

                for (int i = 0; i < listFeature.Count(); i++)
                {
                    if (roomFeatureList.

                    }
                }


                DB.RoomTypes.InsertOnSubmit(newRoomType);
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess("Insert successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse.CreateFail("Can't insert RoomFeature");
            }
        }

        */

    }
}