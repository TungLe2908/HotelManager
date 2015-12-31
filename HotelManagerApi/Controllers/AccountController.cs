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

        private ApiResponse AddAccount(OauthAccount newAccount, int PermissionLevel)
        {
            ApiResponse Result = null;
            using (var client = new HttpClient())
            {
                String JsonResult = client.PostAsJsonAsync(GetConfig.Get("OauthUri") + "AddAccount", newAccount).Result.Content.ReadAsStringAsync().Result;
                Result = JsonConvert.DeserializeObject<ApiResponse>(JsonResult);
            }


            if (Result.Code == ReturnCode.Fail)
            {
                return ApiResponse.CreateFail("Oauth server has a problem");
            }
            else
            {
                try
                {
                    DB.Accounts.InsertOnSubmit(new Account()
                    {
                        Email = newAccount.Email,
                        Permission = PermissionLevel
                    });
                    DB.SubmitChanges();
                    return ApiResponse.CreateSuccess(null);
                }
                catch (Exception ex)
                {
                    return ApiResponse.CreateFail(ex.Message);
                }
            }
        }

        [HttpPost]
        //[CheckToken(new int[] { 1 })]
        public ApiResponse AddCustomerAccount([FromBody] OauthAccount newAccount)
        {
            return AddAccount(newAccount, 0);
        }

        [HttpPost]
        [CheckToken(new int[] { 2 })]
        public ApiResponse AddStaffAccount([FromBody] OauthAccount newAccount)
        {
            return AddAccount(newAccount, 1);
        }
    }

}
