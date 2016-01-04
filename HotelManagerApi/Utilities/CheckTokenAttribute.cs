using HotelManagerApi.Controllers;
using HotelManagerApi.Models;
using Newtonsoft.Json;
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
                if (actionContext.Request.Headers.Contains("token"))
                {
                    string Token = actionContext.Request.Headers.GetValues("token").First();
                    int PermissionLevel = -1;
                    OauthAccount Oauth = null;
                    if (Token.Contains("facebook~"))
                    {
                        Token = Token.Replace("facebook~", "");
                        using (var client = new HttpClient())
                        {
                            String JsonResult = client.GetStringAsync("https://graph.facebook.com/me?fields=email,name&access_token=" + Token).Result;
                            if (JsonResult.Contains("error"))
                            {
                                actionContext.Response = new System.Net.Http.HttpResponseMessage()
                                {
                                    Content = new StringContent("Access token is incorrect"),
                                    StatusCode = HttpStatusCode.Unauthorized
                                };
                                return;
                            }
                            JsonResult = JsonResult.Replace("email", "Email").Replace("name", "Name");
                            Oauth = JsonConvert.DeserializeObject<OauthAccount>(JsonResult);
                        }

                    }
                    else
                    {
                        ApiResponse<OauthAccount> Result = null;
                        using (var client = new HttpClient())
                        {
                            String JsonResult = client.PostAsJsonAsync(GetConfig.Get("OauthUri") + "getaccount", Token).Result.Content.ReadAsStringAsync().Result;
                            Result = JsonConvert.DeserializeObject<ApiResponse<OauthAccount>>(JsonResult);
                        }


                        if (Result.Code == ReturnCode.Fail)
                        {
                            actionContext.Response = new System.Net.Http.HttpResponseMessage()
                            {
                                Content = new StringContent("Access token is incorrect"),
                                StatusCode = HttpStatusCode.Unauthorized
                            };
                            return;
                        }

                        Oauth = Result.Data;
                    }

                    using (var DB = new HotelEntitiesDataContext())
                    {
                        var ListAccount = DB.Accounts.Where(acc => acc.Email == Oauth.Email);
                        if (ListAccount.Count() == 0)
                        {
                            DB.Accounts.InsertOnSubmit(new Account() { Email = Oauth.Email, Name = Oauth.Name, Permission = 0 });
                            DB.SubmitChanges();
                            PermissionLevel = 0;
                        }
                        else
                        {
                            var account = ListAccount.First();
                            if (account.Name != Oauth.Name)
                            {
                                account.Name = Oauth.Name;
                                DB.SubmitChanges();
                            }
                            PermissionLevel = account.Permission.Value;
                        }
                        if (PermissionLevelList.Contains(PermissionLevel))
                        {
                            ((BaseController)actionContext.ControllerContext.Controller).PermissionLevel = PermissionLevel;
                            ((BaseController)actionContext.ControllerContext.Controller).CurrentAccount = Oauth;
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
            catch (Exception ex)
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