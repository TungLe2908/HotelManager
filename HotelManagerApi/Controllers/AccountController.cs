//using HotelManagerApi.Models;
//using HotelManagerApi.Utilities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;


//namespace HotelManagerApi.Controllers
//{
//    public class AccountController : BaseController
//    {
        
//        [HttpPost]
//        public ApiResponse Login([FromBody]LoginRequest Request)
//        {
//            /*
//            var tmp = new Room();
//            DB.Rooms.Attach(tmp);
//            DB.SubmitChanges();


//            var del = DB.Rooms.Where(Del).Select(r=>r.RoomTypeID).First();
//           // DB.Rooms.DeleteOnSubmit(del);

//            //select RoomTypeID from Rooms where RoomID=='1'
//            var listdel = from room in DB.Rooms where room.RoomID == "1" select room.RoomTypeID;


//            //*/

//            var acc = DB.Accounts.Where(a => a.AccountName == Request.Username && a.AccountPassword == Request.Password);
//            if (acc.Count() >=0){
//                var per = DB.Permissions.Where(p=>p.PermissionID == acc.First().PermissionID);
//                return ApiResponse.CreateSuccess(per.First().Token);
//            }
                
//            return ApiResponse.CreateFail("Password is incorrect");

//        }

//        [HttpPost]
//        public ApiResponse AddAccount([FromBody] Account new_account)
//        {
//            try
//            {
//                var IsEmailValid = DB.Accounts.Where(acc => acc.AccountEmail == new_account.AccountEmail).Count() == 0;
//                if (IsEmailValid)
//                {
//                    DB.Accounts.InsertOnSubmit(new_account);
//                    DB.SubmitChanges();
//                    return ApiResponse.CreateSuccess("Insert succefully");
//                }
//                else
//                {
//                    return ApiResponse.CreateFail("Email is invalid", ReturnCode.EmailExists);
//                }
//            }
//                catch(Exception ex)
//            {
//                return ApiResponse.CreateFail(ex.Message);
//            }
//        }



//        /*
//        public bool Del(Room r)
//        {
//            return r.RoomID == "1";
//        }
//         */


//    }

//}
