using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerApi.Utilities
{
    public class GetConfig
    {
        public static String Get(String Key)
        {
            var Settings = System.Web.Configuration.WebConfigurationManager.AppSettings;
            String Value = Settings[Key];
            if(Value!=null)
            {
                return Value;
            }
            else
            {
                return "";
            }
        }
    }
}