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
    public class AccountController : BaseController
    {
        public ApiResponse Login([FromBody]string Username,[FromBody]string Password)
        {
            /*
            var tmp = new Room();
            DB.Rooms.Attach(tmp);
            DB.SubmitChanges();


            var del = DB.Rooms.Where(Del).Select(r=>r.RoomTypeID).First();
           // DB.Rooms.DeleteOnSubmit(del);

            //select RoomTypeID from Rooms where RoomID=='1'
            var listdel = from room in DB.Rooms where room.RoomID == "1" select room.RoomTypeID;


            //*/

            var acc = DB.Accounts.Where(a => a.AccountName == Username && a.AccountPassword == Password);
            if (acc.Count() >=0){
                var per = DB.Permissions.Where(p=>p.PermissionID == acc.First().PermissionID);
                return ApiResponse.CreateSuccess(per.First().Token);
            }
                
            return ApiResponse.CreateFail("Password is incorrect");

        }

        public ApiResponse AddAccount([FromBody] Account new_account)
        {
            try
            {
                DB.Accounts.Attach(new_account);
                return ApiResponse.CreateSuccess("Insert succefully");
            }
            catch
            {
                return ApiResponse.CreateFail("Can't insert");
            }
        }



        /*
        public bool Del(Room r)
        {
            return r.RoomID == "1";
        }
         */


    }
}
