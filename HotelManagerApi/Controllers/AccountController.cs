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
        [HttpPost]
        [CheckToken(new int[] { 2 })]
        public ApiResponse AddStaffAccount([FromBody] AddStaffRequest Staff)
        {
            try
            {
                DB.Accounts.InsertOnSubmit(new Account(){Email=Staff.Email,Permission=1,Name=Staff.Name});
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess(null);
            }
            catch(Exception ex)
            {
                return ApiResponse.CreateFail(ex.Message);
            }
        }
        [HttpGet]
        [CheckToken(new int[] { 0,1,2})]
        public ApiResponse GetAccount()
        {
            return ApiResponse.CreateSuccess(CurrentAccount);
        }

        [HttpGet]
        [CheckToken(new int[] { 1, 2 })]
        public ApiResponse GetCusAccount()
        {
            var ListAcc = DB.Accounts.Where(a => a.Permission == 0).Select(a => a.Email).ToArray();
            return ApiResponse.CreateSuccess(ListAcc);
        }

        [HttpGet]
        [CheckToken(new int[]{2})]
        public ApiResponse GetStaffAccount()
        {
            var ListAcc = DB.Accounts.Where(a => a.Permission == 1).Select(a=>new {Email=a.Email,Name=a.Name}).ToArray();
            return ApiResponse.CreateSuccess(ListAcc);
        }
    }

}
