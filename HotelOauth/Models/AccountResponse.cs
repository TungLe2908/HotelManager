using HotelOauth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oauth.Models
{
    public class AccountResponse
    {
        public string Email;
        public string Name;
        public static AccountResponse Create(Account Acc)
        {
            return new AccountResponse()
            {
                Email = Acc.Email,
                Name = Acc.Name
            };
        }
    }
}