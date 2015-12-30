using HotelManagerApi.Models;
using HotelManagerApi.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace HotelManagerApi.Controllers
{
    public class RoomController : BaseController
    {
        [CheckToken(new int[]{1})]
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

        [CheckToken(new int[]{1})]
        public ApiResponse DeleteRoom([FromBody] int RoomID)
        {
            var del = DB.Rooms.Where(r => r.RoomID == RoomID);
            if (del.Count() >= 1)
            {
                DB.Rooms.DeleteOnSubmit(del.First());
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess("Delete successfully");
            }
            else
            {
                return ApiResponse.CreateFail("Can't find Room");
            }
        }

        [CheckToken(new int[]{1})]
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


    }
}