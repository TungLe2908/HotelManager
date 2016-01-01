using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerWeb.Models
{
    public class Menu:List<MenuItem>
    {
        public static Menu Init(int Permission)
        {
            var Result = new Menu();
            Result.Add(new MenuItem("Booking", "/booking/index"));
            Result.Add(new MenuItem("Booking history", "/booking/history"));
            if (Permission >= 1)
            {
                Result.Add(new MenuItem("Edit booking", "/booking/edit"));
            }
            Result.Add(new MenuItem("My account", "/account/index"));
            if (Permission >= 2)
            {
                Result.Add(new MenuItem("Staff management", "/staff/index"));
            }
            Result.Add(new MenuItem("Logout", "/home/logout"));
          


            return Result;
        }
    }
}