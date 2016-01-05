using HotelManagerApi.Models;
using HotelManagerApi.Utilities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HotelManagerApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        public ApiResponse Get()
        {
            try
            {
                List<WeatherItem> Result = new List<WeatherItem>();
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Linux; U; Android 4.0.3; ko-kr; LG-L160L Build/IML74K) AppleWebkit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30");
                    var StringResult = client.GetStringAsync("https://weather.yahoo.com/vietnam/ho-chi-minh/ho-chi-minh-city-1252431/").Result;
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(StringResult);
                    var WeatherNode = doc.DocumentNode.SelectNodes("//ul[@class='forecast']/li");
                    foreach (HtmlNode Sub in WeatherNode)
                    {
                        WeatherItem Item = new WeatherItem()
                        {
                            Name = Sub.SelectSingleNode("span[@class='name']").InnerHtml,
                            Status = Sub.Attributes.First().Value.Replace("condition wc-", "").Replace("-", " ").Replace(" d","").Replace(" n","").Trim(),
                            Min = Sub.SelectSingleNode("span/span[@class='lo-c']").InnerHtml.Replace("&deg;", ""),
                            Max = Sub.SelectSingleNode("span/span[@class='hi-c']").InnerHtml.Replace("&deg;", "")
                        };
                        Result.Add(Item);
                    }

                }
               return ApiResponse.CreateSuccess(Result);
            }
            catch(Exception ex)
            {
               return  ApiResponse.CreateFail(ex.Message);
            }
        }
    }
}
