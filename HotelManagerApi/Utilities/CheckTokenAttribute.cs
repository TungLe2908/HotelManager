using HotelManagerApi.Controllers;
using HotelManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace HotelManagerApi.Utilities
{
    public class CheckTokenAttribute : ActionFilterAttribute
    {
        int[] PermissionLevelList;
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Content.Headers.Contains("token"))
                {
                    string Token = actionContext.Request.Headers.GetValues("token").First();
                    int PermissionLevel = -1;
                    using (var DB = new HotelEntitiesDataContext())
                    {
                        PermissionLevel = DB.Permissions.Where(p => p.Token.Equals(Token)).First().PermissionLevel.Value;
                    }
                    if (PermissionLevelList.Contains(PermissionLevel))
                    {
                        ((BaseController)actionContext.ControllerContext.Controller).PermissionLevel = PermissionLevel;
                    }
                    else
                    {
                        actionContext.Response = new System.Net.Http.HttpResponseMessage()
                        {
                            Content = new StringContent("Insufficient permission to perform"),
                            StatusCode = HttpStatusCode.Unauthorized
                        };
                    }
                }
                else
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage()
                    {
                        Content = new StringContent("Access token not found"),
                        StatusCode = HttpStatusCode.Unauthorized
                    };
                }
            }
            catch(Exception ex)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage()
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.ServiceUnavailable
                };
            }
        }
        public CheckTokenAttribute(int[] LevelList)
        {
            PermissionLevelList = LevelList;
        }

    }
}