using HotelManagerApi.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace HotelManagerWeb.Utilities
{
    public static class SessionHelper
    {
        public static bool Save(this HttpSessionStateBase Session, string Token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Token", Token);
                    var Result = client.GetAsync(GetConfig.Get("ApiUrl") + "permission/getpermission").Result;
                    
                    if(Result.IsSuccessStatusCode)
                    {
                        Session["IsLogin"] = true;
                        Session["Token"] = Token;
                        var Content = Result.Content.ReadAsStringAsync().Result;
                        var Data = JsonConvert.DeserializeObject<ApiResponse<int>>(Content);
                        Session["Permission"] = Data.Data;
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static bool IsLogin(this HttpSessionStateBase Session)
        {
            if (Session["IsLogin"] == null)
            {
                return false;
            }
            return (bool)Session["IsLogin"];
        }
        public static string GetToken(this HttpSessionStateBase Session)
        {
            return (string)Session["Token"];
        }
        public static int GetPermission(this HttpSessionStateBase Session)
        {
            return (int)Session["Permission"];
        }
    }
}