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
        public string Password;
        public string Phone;
        public static AccountResponse Create(Account Acc)
        {
            return new AccountResponse()
            {
                Email = Acc.Email,
                Password = Acc.Pass,
                Phone = Acc.Phone
            };
        }
    }
}