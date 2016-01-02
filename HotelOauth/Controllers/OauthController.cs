using HotelManagerApi.Utilities;
using HotelOauth.Models;
using Oauth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Oauth.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OauthController : ApiController
    {  
        OauthDataContext DB = new OauthDataContext();

        
        [HttpPost]
        public ApiResponse GetAccount([FromBody] string Token)
        {
            var ListAccount = DB.Accounts.Where(Acc => Acc.Token == Token);
            if (ListAccount.Count() > 0)
            {
                return ApiResponse.CreateSuccess(AccountResponse.Create(ListAccount.First()));
            }
            else
            {
                return ApiResponse.CreateFail("Token is invalid");
            }
        }

        [HttpPost]
        public ApiResponse GetToken([FromBody]TokenRequest request)
        {
            var ListAccount = DB.Accounts.Where(Acc => Acc.Email == request.Email && Acc.Pass == request.Password);
            if (ListAccount.Count() > 0)
            {
                return ApiResponse.CreateSuccess(ListAccount.First().Token);
            }
            else
            {
                return ApiResponse.CreateFail("Infomation is invalid");
            }
        }

        [HttpPost]
        public ApiResponse AddAccount([FromBody]Account newAccount)
        {
            bool existEmail = DB.Accounts.Where(a => a.Email == newAccount.Email).Count() > 0;
            if (existEmail)
            {
                return ApiResponse.CreateFail("Email is invalid");
            }
            else
            {
                try
                {
                    DB.AddAccount(newAccount.Email, newAccount.Pass, newAccount.Phone, newAccount.Name);
                    DB.SubmitChanges();
                    return ApiResponse.CreateSuccess(newAccount.Email);
                }
                catch (Exception ex)
                {
                    return ApiResponse.CreateFail(ex.Message);
                }
            }
        }

        [HttpPost]
        public ApiResponse UpdateAccount([FromBody]Account account)
        {
            var ListAccount = DB.Accounts.Where(a => a.Email == account.Email);
            if (ListAccount.Count()>0)
            {
                ListAccount.First().Name = account.Name;
                ListAccount.First().Phone = account.Phone;
                ListAccount.First().Pass = account.Pass;
                DB.SubmitChanges();
                return ApiResponse.CreateSuccess(null);
            }
            else
            {
                return ApiResponse.CreateFail("Email is invalid");
            }
        }

    }
}
