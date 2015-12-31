﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Models
{
    public class OauthAccount
    {
        public string Email;
        public string Pass;
        public string Phone;
        public string Name;
        public string Token;
        public OauthAccount() { }
        public OauthAccount(FullAccount a)
        {
            Email = a.Name;
            Pass = a.Password;
            Phone = a.Phone;
            Name = a.Name;
            Token = "null";
        }
    }
}