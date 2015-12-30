using HotelManagerApi.Models;
using HotelManagerApi.Utilities;
using Newtonsoft.Json;
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

        /*
        [HttpPost]
        public ApiResponse Login([FromBody]LoginRequest Request)
        {
            
            var tmp = new Room();
            DB.Rooms.Attach(tmp);
            DB.SubmitChanges();


            var del = DB.Rooms.Where(Del).Select(r=>r.RoomTypeID).First();
           // DB.Rooms.DeleteOnSubmit(del);

            //select RoomTypeID from Rooms where RoomID=='1'
            var listdel = from room in DB.Rooms where room.RoomID == "1" select room.RoomTypeID;


            

            var acc = DB.Accounts.Where(a => a.AccountName == Request.Username && a.AccountPassword == Request.Password);
            if (acc.Count() >= 0)
            {
                var per = DB.Permissions.Where(p => p.PermissionID == acc.First().PermissionID);
                return ApiResponse.CreateSuccess(per.First().Token);
            }

            return ApiResponse.CreateFail("Password is incorrect");

        }
            */

        [HttpPost]
        //[CheckToken(new int[] { 1 })]
        public ApiResponse AddAccount([FromBody] FullAccount newAccount)
        {
            OauthAccount a = new OauthAccount(newAccount);
            ApiResponse<OauthAccount> Result = null;
            using (var client = new HttpClient())
            {
                String JsonResult = client.PostAsJsonAsync(GetConfig.Get("OauthUri") + "AddAccount", a).Result.Content.ReadAsStringAsync().Result;
                Result = JsonConvert.DeserializeObject<ApiResponse<OauthAccount>>(JsonResult);
            }


            if (Result.Code == ReturnCode.Fail)
            {
                return ApiResponse.CreateFail("Can't add account");
            }
            else
            {
                try
                {
                    DB.Accounts.InsertOnSubmit(new Account(newAccount.Email, newAccount.PermissionID));
                    DB.SubmitChanges();
                    return ApiResponse.CreateSuccess("Add account successfully");
                }
                catch (Exception ex)
                {
                    return ApiResponse.CreateFail(ex.Message);
                }
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
