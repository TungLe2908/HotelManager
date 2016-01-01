using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerWeb.Models
{
    public class MenuItem
    {
        public string Text { set; get; }
        public string Link { set; get; }
        public MenuItem() { }
        public MenuItem(string Text, string Link)
        {
            this.Text = Text;
            this.Link = Link;
        }
    }
}