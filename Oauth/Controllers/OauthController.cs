﻿using HotelManagerApi.Utilities;
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
        Oauth.Models.OauthDataContext DB = new Models.OauthDataContext();
        [HttpPost]
        public ApiResponse GetAccount([FromBody] string Token)
        {
            var ListAccount = DB.Accounts.Where(Acc => Acc.Token == Token);
            if(ListAccount.Count()>0)
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
    }
}
